#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProTipoBaixaWriter
{
    Entity.DBProTipoBaixa Write(Models.ProTipoBaixa protipobaixa, int auditorQuem, SqlConnection oCnn);
}

public class ProTipoBaixa : IProTipoBaixaWriter
{
    public Entity.DBProTipoBaixa Write(Models.ProTipoBaixa protipobaixa, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = protipobaixa.Id.IsEmptyIDNumber() ? new Entity.DBProTipoBaixa() : new Entity.DBProTipoBaixa(protipobaixa.Id, oCnn);
        dbRec.FNome = protipobaixa.Nome;
        dbRec.FBold = protipobaixa.Bold;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}