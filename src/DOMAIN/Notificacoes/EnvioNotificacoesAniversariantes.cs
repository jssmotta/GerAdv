using MenphisSI.GerAdv.Readers;
using MenphisSI.GerEntityTools.Entity;
using MenphisSI.Shared.BaseCommon.Email.Models;

namespace Domain.BaseCommon.Helpers;
public partial class EnvioNotificacoesAniversariantes(SendEmailApi servicoEmail)
{
    private readonly SendEmailApi _servicoEmail = servicoEmail ?? throw new ArgumentNullException(nameof(servicoEmail));

    private string ConteudoHtml(string operador, int advogado, string uri, MsiSqlConnection oCnn)
    {
        var ds = ObterAniversariantes(oCnn, uri, advogado);
        if (ds.Rows.Count == 0)
        {
            return "";
        }
        var sbRet = new StringBuilder();
        sbRet.Append(ConteudoEmailHtml(operador, advogado, uri, oCnn));
        sbRet.AppendLine(CriarTabelaDaAgendaHtml(ds, operador, ds.Rows.Count, "você está recebendo aviso de aniversariantes somente de clientes ativos que você tem algum processo ou compromisso em nome deles.", ""));
        return sbRet.ToString();
    }

    private string ConteudoEmailHtml(string operador, int advogado, string uri, MsiSqlConnection oCnn)
    {
        var dsComAgenda = ObterAniversariantesComCompromissos(oCnn, uri, advogado);
        if (dsComAgenda.Rows.Count == 0)
        {
            return "";
        }
        return CriarTabelaDaAgendaHtml(dsComAgenda, operador, dsComAgenda.Rows.Count, " a data ao lado do nome do cliente é a data do próximo compromisso que esse cliente possui agendado.", " com compromissos na agenda");
    }

    private string ConteudoHtmlFuncionarios(string operador, int advogado, string uri, MsiSqlConnection oCnn)
    {
        var ds = ObterAniversariantesFuncionarios(oCnn, uri, operador, advogado);
        if (ds.Rows.Count == 0)
        {
            return "";
        }
        return CriarTabelaDaAgendaHtml(ds, operador, ds.Rows.Count, "você está recebendo aviso de aniversariantes somente de clientes ativos porque você é um colaborador com usuário Master.", "");
    }

    private void TestaViews(string uri)
    {

        string createViewScript1 = $@"
            IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'dbo.NotificarAniversariantes'))
BEGIN
    EXEC('CREATE VIEW [dbo].[NotificarAniversariantes] AS 
            SELECT DISTINCT
                c.cliCodigo,
                c.cliNome,
                DAY(c.cliDtNasc) as dia,
	            MONTH(c.cliDtNasc) as mes,
                a.advCodigo,
                a.advNome
            FROM
                dbo.Clientes c
            LEFT JOIN
                dbo.Processos p ON c.cliCodigo = p.proCliente
            LEFT JOIN
                dbo.Historico h ON p.proCodigo = h.hisProcesso
            LEFT JOIN
                dbo.Agenda ag ON c.cliCodigo = ag.ageCliente
            LEFT JOIN
                dbo.Advogados a ON a.advCodigo = p.proAdvogado OR a.advCodigo = ag.ageAdvogado
            left join
	            dbo.Operador o ON o.operCadCod = a.advCodigo AND o.operCadID=1
            WHERE
	            o.operSituacao=1 AND
                c.cliInativo=0 AND
                MONTH(c.cliDtNasc) = MONTH(GETDATE()) AND
                DAY(c.cliDtNasc) BETWEEN DAY(GETDATE()) AND DAY(DATEADD(DAY, 7, GETDATE()));	            
            ');
END;

                    ;";


        using var conexao = ConfiguracoesSys.GetConnectionByUriRwAsync(uri).GetAwaiter().GetResult();
        ConfiguracoesDBT.ExecuteSqlCreate(createViewScript1, conexao);
    }
    private DataTable ObterAniversariantesComCompromissos(
        MsiSqlConnection conexao,
        string uri,
        int advogado,
        int nTry = 0)
    {

        string whereClause = ConstruirCondicaoFiltro(advogado);

        string sql = $@"
WITH ClientesNumerados AS (
    SELECT 
        cliNome + ' ' + FORMAT(ageData, 'dd/MM/yyyy') AS cliNome,  
        mes, 
        dia, 
        ageData,
		advCodigo,
        ROW_NUMBER() OVER (PARTITION BY cliNome ORDER BY ageData) AS RowNum
    FROM NotificarAniversariantes n
    JOIN processos p ON p.proCliente = n.cliCodigo
    JOIN agenda a ON a.ageProcesso = p.proCodigo 
    WHERE a.ageData BETWEEN GETDATE() AND DATEADD(DAY, 7, GETDATE())
)
SELECT 
    cliNome, 
    mes, 
    dia, 
    ageData,
	advCodigo
FROM ClientesNumerados
WHERE RowNum = 1 AND {whereClause}
ORDER BY ageData;
";

        return ConfiguracoesDBT.GetDataTable2(sql, conexao)!;

    }

    private DataTable ObterAniversariantes(
        MsiSqlConnection conexao,
        string uri,
        int advogado,
        int nTry = 0)
    {

        string whereClause = ConstruirCondicaoFiltro(advogado);

        string sql = $@"
    SELECT distinct cliNome, mes, dia 
    FROM dbo.NotificarAniversariantes
    WHERE {whereClause}   
    ORDER BY mes, dia, cliNome;
";

        return ConfiguracoesDBT.GetDataTable2(sql, conexao)!;

    }



    private string ConstruirCondicaoFiltro(int advogado)
    {
        return $"advCodigo={advogado}";
    }

    

    public async Task<int> EnviarEmailsParaAdvogados(string uri, MsiSqlConnection oCnn)
    {
        TestaViews(uri);

        string filtroOperadores = DBOperadorDicInfo.Situacao.Sql(true) + TSql.And +
            DBOperadorDicInfo.Excluido.Sql(false) + TSql.And +
            "operCadID=1 AND operCadCod IN (select distinct advCodigo from NotificarAniversariantes)";

        var reader = new OperadorReader(new FOperadorFactory());
        var readerAdv = new AdvogadosReader(new FAdvogadosFactory());
        var readerFunc = new FuncionariosReader(new FFuncionariosFactory());
        var operadores = await reader.ListarAsync(oCnn, 100, uri, filtroOperadores,[], "operNome",new CancellationToken());
        var assunto = "Aniversariantes próximos 7 dias";
        var count = 0;

        foreach (var operador in operadores)
        {
            if (string.IsNullOrEmpty(operador.EMailNet) || string.IsNullOrEmpty(operador.Nome))
            {
                continue;
            }

            var cNome = operador.CadID == 1 ?
               (await readerAdv.ListarNAsync(1, uri, DBAdvogadosDicInfo.CampoCodigo + "=" + operador.CadCod, [], DBAdvogadosDicInfo.Nome))?.ToList()?.FirstOrDefault()?.Nome() ?? ""
              : (await readerFunc.ListarNAsync(1, uri, DBFuncionariosDicInfo.CampoCodigo + "=" + operador.CadCod, [], DBFuncionariosDicInfo.Nome))?.ToList()?.FirstOrDefault()?.Nome() ?? "";

            if (cNome == null || cNome.Equals("")) continue;

            var conteudoHtml = ConteudoHtml(cNome, operador.CadCod, uri, oCnn);

            if (string.IsNullOrEmpty(conteudoHtml))
            {
                continue;
            }


 
            var email = new SendEmailModel
            {
                EmailPara = operador.EMailNet,
                NomePara = cNome,
                Assunto = assunto + " - " + cNome,
                Mensagem = conteudoHtml,
                NomeDoMail = "ADVOCATI.NET - MENPHIS - SISTEMAS INTELIGENTES",
                Time2Live = 24,
                Uri = uri,
                EmailNet = operador.EMailNet
            };

          
           _ = _servicoEmail.Send(email); 


            count++;
             
        }

        return count;
    }

    

    public async Task<int> EnviarEmailsParaFuncionarios(string uri, MsiSqlConnection oCnn)
    {
        string filtroOperadores = DBOperadorDicInfo.Situacao.Sql(true) + TSql.And + DBOperadorDicInfo.Master.Sql(true) + TSql.And + DBOperadorDicInfo.CadID + "=" + 2;
        
        var reader = new OperadorReader( new FOperadorFactory());
        var readerAdv = new AdvogadosReader( new FAdvogadosFactory());
        var readerFunc = new FuncionariosReader( new FFuncionariosFactory());
        var operadores = await reader.ListarAsync(oCnn, 100, uri, filtroOperadores, [], "operNome", new CancellationToken());

        var assunto = "Aniversariantes próximos 7 dias";
        var count = 0;

        foreach (var operador in operadores)
        {
            if (string.IsNullOrEmpty(operador.EMailNet) || string.IsNullOrEmpty(operador.Nome))
            {
                continue;
            }

            var cNome = operador.CadID == 1 ?
                     (await readerAdv.ListarNAsync(1, uri, DBAdvogadosDicInfo.CampoCodigo + "=" + operador.CadCod, [], DBAdvogadosDicInfo.Nome))?.ToList()?.FirstOrDefault()?.Nome() ?? ""
                    : (await readerFunc.ListarNAsync(1, uri, DBFuncionariosDicInfo.CampoCodigo + "=" + operador.CadCod, [], DBFuncionariosDicInfo.Nome))?.ToList()?.FirstOrDefault()?.Nome() ?? "";

            if (cNome == null || cNome.Equals("")) continue;

            var conteudoHtml = ConteudoHtmlFuncionarios(cNome, operador.CadID, uri, oCnn);

            if (string.IsNullOrEmpty(conteudoHtml))
            {
                continue;
            }

 

            var email = new SendEmailModel
            {
                EmailPara = operador.EMailNet,
                NomePara = cNome,
                Assunto = assunto + " - " + cNome,
                Mensagem = conteudoHtml,
                NomeDoMail = "ADVOCATI.NET - MENPHIS - SISTEMAS INTELIGENTES",
                Time2Live = 24,
                Uri = uri,
                EmailNet = operador.EMailNet
            };

            _ = _servicoEmail.Send(email);
 
            count++;

        }

        return count;
    }

    private DataTable ObterAniversariantesFuncionarios(
    MsiSqlConnection conexao,
    string uri,
    string operador,
    int advogado,
    int nTry = 0)
    {
        try
        {

            string operadorSanitizado = operador.Replace("'", "''");

            string sql = $@"
    SELECT distinct cliNome, mes, dia 
    FROM dbo.NotificarAniversariantesFuncionarios    
    ORDER BY mes, dia, cliNome;
";

            return ConfiguracoesDBT.GetDataTable2(sql, conexao)!;
        }
        catch (Exception)
        {
            if (++nTry > 3)
            {
                throw;
            }

            TestaViewsFuncionarios(uri);
            return ObterAniversariantesFuncionarios(conexao, uri, operador, advogado, nTry);
        }
    }

    private void TestaViewsFuncionarios(string uri)
    {

        string createViewScript1 = $@"
            IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'dbo.NotificarAniversariantesFuncionarios'))
BEGIN
    EXEC('CREATE VIEW [dbo].[NotificarAniversariantesFuncionarios] AS 
            SELECT DISTINCT
                c.cliCodigo,
                c.cliNome,
                DAY(c.cliDtNasc) as dia,
	            MONTH(c.cliDtNasc) as mes                                
            FROM
                dbo.Clientes c
            
            WHERE	            
                c.cliInativo=0 AND
                MONTH(c.cliDtNasc) = MONTH(GETDATE()) AND
                DAY(c.cliDtNasc) BETWEEN DAY(GETDATE()) AND DAY(DATEADD(DAY, 7, GETDATE()));	            
            ');
END;

                    ;";


        using var conexao = ConfiguracoesSys.GetConnectionByUriAsync(uri).GetAwaiter().GetResult();
        ConfiguracoesDBT.ExecuteSqlCreate(createViewScript1, conexao);
    }

}