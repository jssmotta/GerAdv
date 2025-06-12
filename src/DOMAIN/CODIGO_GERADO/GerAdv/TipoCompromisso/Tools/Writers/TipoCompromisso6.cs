#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoCompromissoWriter
{
    Entity.DBTipoCompromisso Write(Models.TipoCompromisso tipocompromisso, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(TipoCompromissoResponse tipocompromisso, int operadorId, MsiSqlConnection oCnn);
}

public class TipoCompromisso : ITipoCompromissoWriter
{
    public void Delete(TipoCompromissoResponse tipocompromisso, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[TipoCompromisso] WHERE tipCodigo={tipocompromisso.Id};", oCnn);
    }

    public Entity.DBTipoCompromisso Write(Models.TipoCompromisso tipocompromisso, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = tipocompromisso.Id.IsEmptyIDNumber() ? new Entity.DBTipoCompromisso() : new Entity.DBTipoCompromisso(tipocompromisso.Id, oCnn);
        dbRec.FIcone = tipocompromisso.Icone;
        dbRec.FDescricao = tipocompromisso.Descricao;
        dbRec.FFinanceiro = tipocompromisso.Financeiro;
        dbRec.FBold = tipocompromisso.Bold;
        dbRec.FGUID = tipocompromisso.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}