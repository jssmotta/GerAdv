#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IDiario2Writer
{
    Entity.DBDiario2 Write(Models.Diario2 diario2, int auditorQuem, SqlConnection oCnn);
}

public class Diario2 : IDiario2Writer
{
    public Entity.DBDiario2 Write(Models.Diario2 diario2, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = diario2.Id.IsEmptyIDNumber() ? new Entity.DBDiario2() : new Entity.DBDiario2(diario2.Id, oCnn);
        if (diario2.Data != null)
            dbRec.FData = diario2.Data.ToString();
        if (diario2.Hora != null)
            dbRec.FHora = diario2.Hora.ToString();
        dbRec.FOperador = diario2.Operador;
        dbRec.FNome = diario2.Nome;
        dbRec.FOcorrencia = diario2.Ocorrencia;
        dbRec.FCliente = diario2.Cliente;
        dbRec.FBold = diario2.Bold;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}