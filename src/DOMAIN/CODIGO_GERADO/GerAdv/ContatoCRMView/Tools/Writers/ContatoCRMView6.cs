#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IContatoCRMViewWriter
{
    Entity.DBContatoCRMView Write(Models.ContatoCRMView contatocrmview, SqlConnection oCnn);
}

public class ContatoCRMView : IContatoCRMViewWriter
{
    public Entity.DBContatoCRMView Write(Models.ContatoCRMView contatocrmview, SqlConnection oCnn)
    {
        var dbRec = contatocrmview.Id.IsEmptyIDNumber() ? new Entity.DBContatoCRMView() : new Entity.DBContatoCRMView(contatocrmview.Id, oCnn);
        if (contatocrmview.Data != null)
            dbRec.FData = contatocrmview.Data.ToString();
        dbRec.FIP = contatocrmview.IP;
        dbRec.Update(oCnn);
        return dbRec;
    }
}