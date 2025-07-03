#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOperadorEMailPopupReader
{
    OperadorEMailPopupResponse? Read(int id, MsiSqlConnection oCnn);
    OperadorEMailPopupResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    OperadorEMailPopupResponse? Read(Entity.DBOperadorEMailPopup dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    OperadorEMailPopupResponse? Read(DBOperadorEMailPopup dbRec);
    OperadorEMailPopupResponseAll? ReadAll(DBOperadorEMailPopup dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class OperadorEMailPopup : IOperadorEMailPopupReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) oepCodigo, oepNome FROM {"OperadorEMailPopup".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}oepNome");
        }

        return query.ToString();
    }

    public OperadorEMailPopupResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOperadorEMailPopup(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OperadorEMailPopupResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOperadorEMailPopup(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OperadorEMailPopupResponse? Read(Entity.DBOperadorEMailPopup dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadoremailpopup = new OperadorEMailPopupResponse
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Nome = dbRec.FNome ?? string.Empty,
            SMTP = dbRec.FSMTP ?? string.Empty,
            POP3 = dbRec.FPOP3 ?? string.Empty,
            Autenticacao = dbRec.FAutenticacao,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Usuario = dbRec.FUsuario ?? string.Empty,
            PortaSmtp = dbRec.FPortaSmtp,
            PortaPop3 = dbRec.FPortaPop3,
            Assinatura = dbRec.FAssinatura ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return operadoremailpopup;
    }

    public OperadorEMailPopupResponse? Read(DBOperadorEMailPopup dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadoremailpopup = new OperadorEMailPopupResponse
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Nome = dbRec.FNome ?? string.Empty,
            SMTP = dbRec.FSMTP ?? string.Empty,
            POP3 = dbRec.FPOP3 ?? string.Empty,
            Autenticacao = dbRec.FAutenticacao,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Usuario = dbRec.FUsuario ?? string.Empty,
            PortaSmtp = dbRec.FPortaSmtp,
            PortaPop3 = dbRec.FPortaPop3,
            Assinatura = dbRec.FAssinatura ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return operadoremailpopup;
    }

    public OperadorEMailPopupResponseAll? ReadAll(DBOperadorEMailPopup dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadoremailpopup = new OperadorEMailPopupResponseAll
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Nome = dbRec.FNome ?? string.Empty,
            SMTP = dbRec.FSMTP ?? string.Empty,
            POP3 = dbRec.FPOP3 ?? string.Empty,
            Autenticacao = dbRec.FAutenticacao,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Usuario = dbRec.FUsuario ?? string.Empty,
            PortaSmtp = dbRec.FPortaSmtp,
            PortaPop3 = dbRec.FPortaPop3,
            Assinatura = dbRec.FAssinatura ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        operadoremailpopup.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        return operadoremailpopup;
    }
}