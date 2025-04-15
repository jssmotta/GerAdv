#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProProcuradoresWriter
{
    Entity.DBProProcuradores Write(Models.ProProcuradores proprocuradores, int auditorQuem, SqlConnection oCnn);
}

public class ProProcuradores : IProProcuradoresWriter
{
    public Entity.DBProProcuradores Write(Models.ProProcuradores proprocuradores, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = proprocuradores.Id.IsEmptyIDNumber() ? new Entity.DBProProcuradores() : new Entity.DBProProcuradores(proprocuradores.Id, oCnn);
        dbRec.FAdvogado = proprocuradores.Advogado;
        dbRec.FNome = proprocuradores.Nome;
        dbRec.FProcesso = proprocuradores.Processo;
        if (proprocuradores.Data != null)
            dbRec.FData = proprocuradores.Data.ToString();
        dbRec.FSubstabelecimento = proprocuradores.Substabelecimento;
        dbRec.FProcuracao = proprocuradores.Procuracao;
        dbRec.FBold = proprocuradores.Bold;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}