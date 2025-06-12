#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IBensMateriaisWhere
{
    BensMateriaisResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class BensMateriais : IBensMateriaisWhere
{
    public BensMateriaisResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBBensMateriais(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var bensmateriais = new BensMateriaisResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            BensClassificacao = dbRec.FBensClassificacao,
            NFNRO = dbRec.FNFNRO ?? string.Empty,
            Fornecedor = dbRec.FFornecedor,
            ValorBem = dbRec.FValorBem,
            NroSerieProduto = dbRec.FNroSerieProduto ?? string.Empty,
            Comprador = dbRec.FComprador ?? string.Empty,
            Cidade = dbRec.FCidade,
            GarantiaLoja = dbRec.FGarantiaLoja,
            Observacoes = dbRec.FObservacoes ?? string.Empty,
            NomeVendedor = dbRec.FNomeVendedor ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataCompra, out _))
            bensmateriais.DataCompra = dbRec.FDataCompra;
        if (DateTime.TryParse(dbRec.FDataFimDaGarantia, out _))
            bensmateriais.DataFimDaGarantia = dbRec.FDataFimDaGarantia;
        if (DateTime.TryParse(dbRec.FDataTerminoDaGarantiaDaLoja, out _))
            bensmateriais.DataTerminoDaGarantiaDaLoja = dbRec.FDataTerminoDaGarantiaDaLoja;
        return bensmateriais;
    }
}