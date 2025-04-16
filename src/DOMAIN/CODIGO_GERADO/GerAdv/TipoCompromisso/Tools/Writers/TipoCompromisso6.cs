#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoCompromissoWriter
{
    Entity.DBTipoCompromisso Write(Models.TipoCompromisso tipocompromisso, int auditorQuem, SqlConnection oCnn);
}

public class TipoCompromisso : ITipoCompromissoWriter
{
    public Entity.DBTipoCompromisso Write(Models.TipoCompromisso tipocompromisso, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = tipocompromisso.Id.IsEmptyIDNumber() ? new Entity.DBTipoCompromisso() : new Entity.DBTipoCompromisso(tipocompromisso.Id, oCnn);
        dbRec.FIcone = tipocompromisso.Icone;
        dbRec.FDescricao = tipocompromisso.Descricao;
        dbRec.FFinanceiro = tipocompromisso.Financeiro;
        dbRec.FBold = tipocompromisso.Bold;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}