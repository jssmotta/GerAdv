using MenphisSI.GerAdv.Readers;
using MenphisSI.GerEntityTools.Entity;
using MenphisSI.Shared.BaseCommon.Email.Models;

namespace Domain.BaseCommon.Helpers;

public enum E_TIPO_ENVIO
{
    NOVOS = 1,
    DIA = 2
}

public partial class EnvioNotificacoes
{
    private readonly SendEmailApi _servicoEmail;

    public EnvioNotificacoes(SendEmailApi servicoEmail)
    {
        _servicoEmail = servicoEmail ?? throw new ArgumentNullException(nameof(servicoEmail));
    }

    private string ConteudoHtml(string operador, E_TIPO_ENVIO tipo, string uri, MsiSqlConnection oCnn)
    {
        var ds = ObterCompromissos(oCnn, tipo, uri, operador);
        if (ds.Rows.Count == 0)
        {
            return "";
        }
        return CriarTabelaDaAgendaHtml(ds, operador, ds.Rows.Count);
    }

    private void TestaViews(string uri)
    {

        string createViewScript1 = $@"
            IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'dbo.AgendaRelatorio'))
BEGIN
    EXEC('CREATE VIEW [dbo].[AgendaRelatorio] AS 
        SELECT 
            qa.*, 
            vp.advNome AS xxxNomeAdvogado,
            vp.forNome AS xxxNomeForo,
            vp.jusNome AS xxxNomeJustica,
            vp.areDescricao AS xxxNomeArea
        FROM [dbo].[view_QAgenda] qa
        JOIN [dbo].[agenda] a ON a.ageCodigo = qa.vqaCodigo
        LEFT JOIN [dbo].[view_QProcessos] vp ON a.ageIDInsProcesso = vp.insCodigo;');
END;

                    ;";

        string createViewScript2 = @"
               IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'dbo.AgendaSemana'))
BEGIN
    EXEC('CREATE VIEW [dbo].[AgendaSemana] 
    WITH SCHEMABINDING AS
    SELECT
        CASE WHEN f.funNome IS NULL THEN adv.advNome ELSE f.funNome END AS xxxParaNome,
        a.ageCodigo AS xxxCodigo,
        a.ageData AS xxxData, 
        a.ageFuncionario AS xxxFuncionario, 
        a.ageAdvogado AS xxxAdvogado,
        a.ageHora AS xxxHora, 
        a.ageTipoCompromisso AS xxxTipoCompromisso, 
        a.ageCompromisso AS xxxCompromisso, 
        a.ageConcluido AS xxxConcluido, 
        a.ageLiberado AS xxxLiberado,   
        a.ageImportante AS xxxImportante, 
        a.ageHrFinal AS xxxHoraFinal, 
        c.cliNome AS xxxNomeCliente, 
        t.tipDescricao AS xxxTipo
    FROM dbo.Agenda a
    LEFT JOIN dbo.Funcionarios f ON f.funCodigo = a.ageFuncionario
    LEFT JOIN dbo.Advogados adv ON adv.advCodigo = a.ageAdvogado
    LEFT JOIN dbo.Clientes c ON c.cliCodigo = a.ageCliente
    JOIN dbo.TipoCompromisso t ON t.tipCodigo = a.ageTipoCompromisso;');
END;


";
        using var conexao = ConfiguracoesSys.GetConnectionByUriAsync(uri).GetAwaiter().GetResult();
        ConfiguracoesDBT.ExecuteSqlCreate(createViewScript1, conexao);
        ConfiguracoesDBT.ExecuteSqlCreate(createViewScript2, conexao);
    }

    private DataTable ObterCompromissos(
        MsiSqlConnection conexao,
        E_TIPO_ENVIO tipo,
        string uri,
        string operador,
        int nTry = 0)
    {
        try
        {
            string whereClause = ConstruirCondicaoFiltro(tipo);
            string operadorSanitizado = operador.Replace("'", "''");

            string sql = $@"
SELECT [vqaData], [xxxBoxAudienciaMobile] 
FROM [dbo].[AgendaRelatorio]
LEFT JOIN [dbo].[Agenda] a ON vqaCodigo = a.ageCodigo
WHERE a.ageConcluido = 0 
     {whereClause}
     AND xxxParaNome LIKE '{operadorSanitizado}'
ORDER BY vqaData;";

            return ConfiguracoesDBT.GetDataTable2(sql, conexao)!;
        }
        catch (Exception)
        {
            if (++nTry > 3)
            {
                throw;
            }

            TestaViews(uri);
            return ObterCompromissos(conexao, tipo, uri, operador, nTry);
        }
    }
    
    private string ConstruirCondicaoFiltro(E_TIPO_ENVIO tipo)
    {
        if (tipo == E_TIPO_ENVIO.NOVOS)
        {
            return @"  AND (CAST(a.ageDtCad AS DATE) = CAST(GETDATE() AS DATE) 
                    OR CAST(a.ageDtAtu AS DATE) = CAST(GETDATE() AS DATE))";
        }

        int diasAFrente = (DateTime.Now.DayOfWeek == DayOfWeek.Monday) ? 8 : 5;

        return $@" AND vqaData >= DATEADD(DAY, -1, GETDATE()) 
                AND vqaData <= DATEADD(DAY, {diasAFrente}, GETDATE())";
    }

   

    
    public async Task<int> EnviarEmailsParaAdvogados(E_TIPO_ENVIO tipo, string uri, MsiSqlConnection oCnn)
    {
        string filtroOperadores = DBOperadorDicInfo.Situacao.Sql(true);

        var reader = new OperadorReader(new FOperadorFactory());
        var readerAdv = new AdvogadosReader(new FAdvogadosFactory());
       // var readerFunc = new FuncionariosReader(new FFuncionariosFactory());
        var operadores = await reader.ListarAsync(oCnn, 100, uri, filtroOperadores, [], "operNome", new CancellationToken());
      
        var assunto = tipo == E_TIPO_ENVIO.NOVOS ? "Novos compromissos e atualizados do dia de hoje" : "Compromissos da Agenda do Advocati.NET para ";
        var count = 0;

        foreach (var operador in operadores)
        {
            if (string.IsNullOrEmpty(operador.EMailNet) || string.IsNullOrEmpty(operador.Nome))
            {
                continue;
            }

            var cNome = operador.CadID == 1 ?
                     (await readerAdv.ListarNAsync(1, uri, DBAdvogadosDicInfo.CampoCodigo + "=" + operador.CadCod, [], DBAdvogadosDicInfo.Nome))?.ToList()?.FirstOrDefault()?.Nome() ?? ""
                    :  "";

            if (cNome == null || cNome.Equals("")) continue;

            var conteudoHtml = ConteudoHtml(cNome, tipo, uri, oCnn);

            if (string.IsNullOrEmpty(conteudoHtml))
            {
                continue;
            }

 
            var email = new SendEmailModel
            {
                EmailPara = operador.EMailNet,
                NomePara = cNome,
                Assunto = assunto + cNome,
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


}
