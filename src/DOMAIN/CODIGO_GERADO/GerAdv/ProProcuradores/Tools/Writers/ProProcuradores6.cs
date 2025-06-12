#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProProcuradoresWriter
{
    Entity.DBProProcuradores Write(Models.ProProcuradores proprocuradores, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(ProProcuradoresResponse proprocuradores, int operadorId, MsiSqlConnection oCnn);
}

public class ProProcuradores : IProProcuradoresWriter
{
    public void Delete(ProProcuradoresResponse proprocuradores, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[ProProcuradores] WHERE papCodigo={proprocuradores.Id};", oCnn);
    }

    public Entity.DBProProcuradores Write(Models.ProProcuradores proprocuradores, int auditorQuem, MsiSqlConnection oCnn)
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
        dbRec.FGUID = proprocuradores.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}