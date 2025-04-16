#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ICargosEscWriter
{
    Entity.DBCargosEsc Write(Models.CargosEsc cargosesc, int auditorQuem, SqlConnection oCnn);
}

public class CargosEsc : ICargosEscWriter
{
    public Entity.DBCargosEsc Write(Models.CargosEsc cargosesc, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = cargosesc.Id.IsEmptyIDNumber() ? new Entity.DBCargosEsc() : new Entity.DBCargosEsc(cargosesc.Id, oCnn);
        dbRec.FPercentual = cargosesc.Percentual;
        dbRec.FNome = cargosesc.Nome;
        dbRec.FClassificacao = cargosesc.Classificacao;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}