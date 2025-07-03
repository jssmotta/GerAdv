#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ILigacoesReader
{
    LigacoesResponse? Read(int id, MsiSqlConnection oCnn);
    LigacoesResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    LigacoesResponse? Read(Entity.DBLigacoes dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    LigacoesResponse? Read(DBLigacoes dbRec);
    LigacoesResponseAll? ReadAll(DBLigacoes dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Ligacoes : ILigacoesReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) ligCodigo, ligNome FROM {"Ligacoes".dbo(oCnn)} (NOLOCK) ");
        if (!string.IsNullOrEmpty(whereClause))
        {
            query.Append(!whereClause.ToUpperInvariant().Contains(TSql.Where, StringComparison.OrdinalIgnoreCase) ? TSql.Where : string.Empty).Append(whereClause);
        }

        if (!string.IsNullOrEmpty(orderClause))
        {
            query.Append(!orderClause.ToUpperInvariant().Contains(TSql.OrderBy, StringComparison.OrdinalIgnoreCase) ? TSql.OrderBy : string.Empty).Append(orderClause);
        }
        else
        {
            query.Append($"{TSql.OrderBy}ligNome");
        }

        return query.ToString();
    }

    public LigacoesResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBLigacoes(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public LigacoesResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBLigacoes(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public LigacoesResponse? Read(Entity.DBLigacoes dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var ligacoes = new LigacoesResponse
        {
            Id = dbRec.ID,
            Assunto = dbRec.FAssunto ?? string.Empty,
            AgeClienteAvisado = dbRec.FAgeClienteAvisado,
            Celular = dbRec.FCelular,
            Cliente = dbRec.FCliente,
            Contato = dbRec.FContato ?? string.Empty,
            QuemID = dbRec.FQuemID,
            Telefonista = dbRec.FTelefonista,
            Nome = dbRec.FNome ?? string.Empty,
            QuemCodigo = dbRec.FQuemCodigo,
            Solicitante = dbRec.FSolicitante,
            Para = dbRec.FPara ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Ramal = dbRec.FRamal,
            Particular = dbRec.FParticular,
            Realizada = dbRec.FRealizada,
            Status = dbRec.FStatus ?? string.Empty,
            Urgente = dbRec.FUrgente,
            LigarPara = dbRec.FLigarPara ?? string.Empty,
            Processo = dbRec.FProcesso,
            StartScreen = dbRec.FStartScreen,
            Emotion = dbRec.FEmotion,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataRealizada, out _))
            ligacoes.DataRealizada = dbRec.FDataRealizada;
        if (DateTime.TryParse(dbRec.FUltimoAviso, out _))
            ligacoes.UltimoAviso = dbRec.FUltimoAviso;
        if (DateTime.TryParse(dbRec.FHoraFinal, out _))
            ligacoes.HoraFinal = dbRec.FHoraFinal;
        if (DateTime.TryParse(dbRec.FData, out _))
            ligacoes.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FHora, out _))
            ligacoes.Hora = dbRec.FHora;
        return ligacoes;
    }

    public LigacoesResponse? Read(DBLigacoes dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var ligacoes = new LigacoesResponse
        {
            Id = dbRec.ID,
            Assunto = dbRec.FAssunto ?? string.Empty,
            AgeClienteAvisado = dbRec.FAgeClienteAvisado,
            Celular = dbRec.FCelular,
            Cliente = dbRec.FCliente,
            Contato = dbRec.FContato ?? string.Empty,
            QuemID = dbRec.FQuemID,
            Telefonista = dbRec.FTelefonista,
            Nome = dbRec.FNome ?? string.Empty,
            QuemCodigo = dbRec.FQuemCodigo,
            Solicitante = dbRec.FSolicitante,
            Para = dbRec.FPara ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Ramal = dbRec.FRamal,
            Particular = dbRec.FParticular,
            Realizada = dbRec.FRealizada,
            Status = dbRec.FStatus ?? string.Empty,
            Urgente = dbRec.FUrgente,
            LigarPara = dbRec.FLigarPara ?? string.Empty,
            Processo = dbRec.FProcesso,
            StartScreen = dbRec.FStartScreen,
            Emotion = dbRec.FEmotion,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataRealizada, out _))
            ligacoes.DataRealizada = dbRec.FDataRealizada;
        if (DateTime.TryParse(dbRec.FUltimoAviso, out _))
            ligacoes.UltimoAviso = dbRec.FUltimoAviso;
        if (DateTime.TryParse(dbRec.FHoraFinal, out _))
            ligacoes.HoraFinal = dbRec.FHoraFinal;
        if (DateTime.TryParse(dbRec.FData, out _))
            ligacoes.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FHora, out _))
            ligacoes.Hora = dbRec.FHora;
        return ligacoes;
    }

    public LigacoesResponseAll? ReadAll(DBLigacoes dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var ligacoes = new LigacoesResponseAll
        {
            Id = dbRec.ID,
            Assunto = dbRec.FAssunto ?? string.Empty,
            AgeClienteAvisado = dbRec.FAgeClienteAvisado,
            Celular = dbRec.FCelular,
            Cliente = dbRec.FCliente,
            Contato = dbRec.FContato ?? string.Empty,
            QuemID = dbRec.FQuemID,
            Telefonista = dbRec.FTelefonista,
            Nome = dbRec.FNome ?? string.Empty,
            QuemCodigo = dbRec.FQuemCodigo,
            Solicitante = dbRec.FSolicitante,
            Para = dbRec.FPara ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Ramal = dbRec.FRamal,
            Particular = dbRec.FParticular,
            Realizada = dbRec.FRealizada,
            Status = dbRec.FStatus ?? string.Empty,
            Urgente = dbRec.FUrgente,
            LigarPara = dbRec.FLigarPara ?? string.Empty,
            Processo = dbRec.FProcesso,
            StartScreen = dbRec.FStartScreen,
            Emotion = dbRec.FEmotion,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataRealizada, out _))
            ligacoes.DataRealizada = dbRec.FDataRealizada;
        if (DateTime.TryParse(dbRec.FUltimoAviso, out _))
            ligacoes.UltimoAviso = dbRec.FUltimoAviso;
        if (DateTime.TryParse(dbRec.FHoraFinal, out _))
            ligacoes.HoraFinal = dbRec.FHoraFinal;
        if (DateTime.TryParse(dbRec.FData, out _))
            ligacoes.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FHora, out _))
            ligacoes.Hora = dbRec.FHora;
        ligacoes.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        ligacoes.NomeRamal = dr["ramNome"]?.ToString() ?? string.Empty;
        ligacoes.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return ligacoes;
    }
}