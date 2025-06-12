#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IContatoCRMViewReader
{
    ContatoCRMViewResponse? Read(int id, MsiSqlConnection oCnn);
    ContatoCRMViewResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ContatoCRMViewResponse? Read(Entity.DBContatoCRMView dbRec);
    ContatoCRMViewResponse? Read(DBContatoCRMView dbRec);
    ContatoCRMViewResponseAll? ReadAll(DBContatoCRMView dbRec, DataRow dr);
}

public partial class ContatoCRMView : IContatoCRMViewReader
{
    public ContatoCRMViewResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBContatoCRMView(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ContatoCRMViewResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBContatoCRMView(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ContatoCRMViewResponse? Read(Entity.DBContatoCRMView dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var contatocrmview = new ContatoCRMViewResponse
        {
            Id = dbRec.ID,
            CGUID = dbRec.FCGUID ?? string.Empty,
            IP = dbRec.FIP ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            contatocrmview.Data = dbRec.FData;
        return contatocrmview;
    }

    public ContatoCRMViewResponse? Read(DBContatoCRMView dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var contatocrmview = new ContatoCRMViewResponse
        {
            Id = dbRec.ID,
            CGUID = dbRec.FCGUID ?? string.Empty,
            IP = dbRec.FIP ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            contatocrmview.Data = dbRec.FData;
        return contatocrmview;
    }

    public ContatoCRMViewResponseAll? ReadAll(DBContatoCRMView dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var contatocrmview = new ContatoCRMViewResponseAll
        {
            Id = dbRec.ID,
            CGUID = dbRec.FCGUID ?? string.Empty,
            IP = dbRec.FIP ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            contatocrmview.Data = dbRec.FData;
        return contatocrmview;
    }
}