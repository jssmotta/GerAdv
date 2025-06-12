#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTAtividadesWriter
{
    Entity.DBGUTAtividades Write(Models.GUTAtividades gutatividades, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(GUTAtividadesResponse gutatividades, int operadorId, MsiSqlConnection oCnn);
}

public class GUTAtividades : IGUTAtividadesWriter
{
    public void Delete(GUTAtividadesResponse gutatividades, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[GUTAtividades] WHERE agtCodigo={gutatividades.Id};", oCnn);
    }

    public Entity.DBGUTAtividades Write(Models.GUTAtividades gutatividades, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = gutatividades.Id.IsEmptyIDNumber() ? new Entity.DBGUTAtividades() : new Entity.DBGUTAtividades(gutatividades.Id, oCnn);
        dbRec.FNome = gutatividades.Nome;
        dbRec.FObservacao = gutatividades.Observacao;
        dbRec.FGUTGrupo = gutatividades.GUTGrupo;
        dbRec.FGUTPeriodicidade = gutatividades.GUTPeriodicidade;
        dbRec.FOperador = gutatividades.Operador;
        dbRec.FConcluido = gutatividades.Concluido;
        if (gutatividades.DataConcluido != null)
            dbRec.FDataConcluido = gutatividades.DataConcluido.ToString();
        dbRec.FDiasParaIniciar = gutatividades.DiasParaIniciar;
        dbRec.FMinutosParaRealizar = gutatividades.MinutosParaRealizar;
        dbRec.FGUID = gutatividades.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}