#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProTipoBaixaWriter
{
    Entity.DBProTipoBaixa Write(Models.ProTipoBaixa protipobaixa, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(ProTipoBaixaResponse protipobaixa, int operadorId, MsiSqlConnection oCnn);
}

public class ProTipoBaixa : IProTipoBaixaWriter
{
    public void Delete(ProTipoBaixaResponse protipobaixa, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[ProTipoBaixa] WHERE ptxCodigo={protipobaixa.Id};", oCnn);
    }

    public Entity.DBProTipoBaixa Write(Models.ProTipoBaixa protipobaixa, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = protipobaixa.Id.IsEmptyIDNumber() ? new Entity.DBProTipoBaixa() : new Entity.DBProTipoBaixa(protipobaixa.Id, oCnn);
        dbRec.FNome = protipobaixa.Nome;
        dbRec.FBold = protipobaixa.Bold;
        dbRec.FGUID = protipobaixa.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}