#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPenhoraWriter
{
    Entity.DBPenhora Write(Models.Penhora penhora, int auditorQuem, SqlConnection oCnn);
}

public class Penhora : IPenhoraWriter
{
    public Entity.DBPenhora Write(Models.Penhora penhora, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = penhora.Id.IsEmptyIDNumber() ? new Entity.DBPenhora() : new Entity.DBPenhora(penhora.Id, oCnn);
        dbRec.FProcesso = penhora.Processo;
        dbRec.FNome = penhora.Nome;
        dbRec.FDescricao = penhora.Descricao;
        if (penhora.DataPenhora != null)
            dbRec.FDataPenhora = penhora.DataPenhora.ToString();
        dbRec.FPenhoraStatus = penhora.PenhoraStatus;
        dbRec.FMaster = penhora.Master;
        dbRec.FGUID = penhora.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}