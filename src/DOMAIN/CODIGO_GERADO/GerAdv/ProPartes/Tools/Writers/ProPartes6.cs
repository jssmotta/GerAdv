#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProPartesWriter
{
    Entity.DBProPartes Write(Models.ProPartes propartes, SqlConnection oCnn);
}

public class ProPartes : IProPartesWriter
{
    public Entity.DBProPartes Write(Models.ProPartes propartes, SqlConnection oCnn)
    {
        var dbRec = propartes.Id.IsEmptyIDNumber() ? new Entity.DBProPartes() : new Entity.DBProPartes(propartes.Id, oCnn);
        dbRec.FParte = propartes.Parte;
        dbRec.FProcesso = propartes.Processo;
        dbRec.Update(oCnn);
        return dbRec;
    }
}