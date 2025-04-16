#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProDespesasWriter
{
    Entity.DBProDespesas Write(Models.ProDespesas prodespesas, int auditorQuem, SqlConnection oCnn);
}

public class ProDespesas : IProDespesasWriter
{
    public Entity.DBProDespesas Write(Models.ProDespesas prodespesas, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = prodespesas.Id.IsEmptyIDNumber() ? new Entity.DBProDespesas() : new Entity.DBProDespesas(prodespesas.Id, oCnn);
        dbRec.FLigacaoID = prodespesas.LigacaoID;
        dbRec.FCliente = prodespesas.Cliente;
        dbRec.FCorrigido = prodespesas.Corrigido;
        if (prodespesas.Data != null)
            dbRec.FData = prodespesas.Data.ToString();
        dbRec.FValorOriginal = prodespesas.ValorOriginal;
        dbRec.FProcesso = prodespesas.Processo;
        dbRec.FQuitado = prodespesas.Quitado;
        if (prodespesas.DataCorrecao != null)
            dbRec.FDataCorrecao = prodespesas.DataCorrecao.ToString();
        dbRec.FValor = prodespesas.Valor;
        dbRec.FTipo = prodespesas.Tipo;
        dbRec.FHistorico = prodespesas.Historico;
        dbRec.FLivroCaixa = prodespesas.LivroCaixa;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}