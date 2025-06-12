#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface INECompromissosWriter
{
    Entity.DBNECompromissos Write(Models.NECompromissos necompromissos, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(NECompromissosResponse necompromissos, int operadorId, MsiSqlConnection oCnn);
}

public class NECompromissos : INECompromissosWriter
{
    public void Delete(NECompromissosResponse necompromissos, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[NECompromissos] WHERE ncpCodigo={necompromissos.Id};", oCnn);
    }

    public Entity.DBNECompromissos Write(Models.NECompromissos necompromissos, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = necompromissos.Id.IsEmptyIDNumber() ? new Entity.DBNECompromissos() : new Entity.DBNECompromissos(necompromissos.Id, oCnn);
        dbRec.FPalavraChave = necompromissos.PalavraChave;
        dbRec.FProvisionar = necompromissos.Provisionar;
        dbRec.FTipoCompromisso = necompromissos.TipoCompromisso;
        dbRec.FTextoCompromisso = necompromissos.TextoCompromisso;
        dbRec.FBold = necompromissos.Bold;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}