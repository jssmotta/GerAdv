#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IBensMateriaisWriter
{
    Entity.DBBensMateriais Write(Models.BensMateriais bensmateriais, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(BensMateriaisResponse bensmateriais, int operadorId, MsiSqlConnection oCnn);
}

public class BensMateriais : IBensMateriaisWriter
{
    public void Delete(BensMateriaisResponse bensmateriais, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[BensMateriais] WHERE bmtCodigo={bensmateriais.Id};", oCnn);
    }

    public Entity.DBBensMateriais Write(Models.BensMateriais bensmateriais, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = bensmateriais.Id.IsEmptyIDNumber() ? new Entity.DBBensMateriais() : new Entity.DBBensMateriais(bensmateriais.Id, oCnn);
        dbRec.FNome = bensmateriais.Nome;
        dbRec.FBensClassificacao = bensmateriais.BensClassificacao;
        if (bensmateriais.DataCompra != null)
            dbRec.FDataCompra = bensmateriais.DataCompra.ToString();
        if (bensmateriais.DataFimDaGarantia != null)
            dbRec.FDataFimDaGarantia = bensmateriais.DataFimDaGarantia.ToString();
        dbRec.FNFNRO = bensmateriais.NFNRO;
        dbRec.FFornecedor = bensmateriais.Fornecedor;
        dbRec.FValorBem = bensmateriais.ValorBem;
        dbRec.FNroSerieProduto = bensmateriais.NroSerieProduto;
        dbRec.FComprador = bensmateriais.Comprador;
        dbRec.FCidade = bensmateriais.Cidade;
        dbRec.FGarantiaLoja = bensmateriais.GarantiaLoja;
        if (bensmateriais.DataTerminoDaGarantiaDaLoja != null)
            dbRec.FDataTerminoDaGarantiaDaLoja = bensmateriais.DataTerminoDaGarantiaDaLoja.ToString();
        dbRec.FObservacoes = bensmateriais.Observacoes;
        dbRec.FNomeVendedor = bensmateriais.NomeVendedor;
        dbRec.FBold = bensmateriais.Bold;
        dbRec.FGUID = bensmateriais.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}