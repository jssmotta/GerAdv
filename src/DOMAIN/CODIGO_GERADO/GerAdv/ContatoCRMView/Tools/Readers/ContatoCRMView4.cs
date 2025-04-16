#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IContatoCRMViewReader
{
    ContatoCRMViewResponse? Read(int id, SqlConnection oCnn);
    ContatoCRMViewResponse? Read(string where, SqlConnection oCnn);
    ContatoCRMViewResponse? Read(Entity.DBContatoCRMView dbRec);
    ContatoCRMViewResponse? Read(DBContatoCRMView dbRec);
}

public partial class ContatoCRMView : IContatoCRMViewReader
{
    public ContatoCRMViewResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBContatoCRMView(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ContatoCRMViewResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBContatoCRMView(sqlWhere: where, oCnn: oCnn);
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
            IP = dbRec.FIP ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            contatocrmview.Data = dbRec.FData;
        return contatocrmview;
    }
}