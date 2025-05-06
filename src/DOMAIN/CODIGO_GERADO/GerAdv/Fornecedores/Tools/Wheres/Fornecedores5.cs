#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IFornecedoresWhere
{
    FornecedoresResponse Read(string where, SqlConnection oCnn);
}

public partial class Fornecedores : IFornecedoresWhere
{
    public FornecedoresResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBFornecedores(sqlWhere: where, oCnn: oCnn);
        var fornecedores = new FornecedoresResponse
        {
            Id = dbRec.ID,
            Grupo = dbRec.FGrupo,
            Nome = dbRec.FNome ?? string.Empty,
            SubGrupo = dbRec.FSubGrupo,
            Tipo = dbRec.FTipo,
            Sexo = dbRec.FSexo,
            CNPJ = dbRec.FCNPJ ?? string.Empty,
            InscEst = dbRec.FInscEst ?? string.Empty,
            CPF = dbRec.FCPF ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP ?? string.Empty,
            Cidade = dbRec.FCidade,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Email = dbRec.FEmail ?? string.Empty,
            Site = dbRec.FSite ?? string.Empty,
            Obs = dbRec.FObs ?? string.Empty,
            Produtos = dbRec.FProdutos ?? string.Empty,
            Contatos = dbRec.FContatos ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        var auditor = new Auditor
        {
            Visto = dbRec.FVisto,
            QuemCad = dbRec.FQuemCad
        };
        if (auditor.QuemAtu > 0)
            auditor.QuemAtu = dbRec.FQuemAtu;
        if (dbRec.FDtCad.NotIsEmpty())
            auditor.DtCad = Convert.ToDateTime(dbRec.FDtCad);
        if (!(dbRec.FDtAtu is { }))
            auditor.DtAtu = Convert.ToDateTime(dbRec.FDtAtu);
        fornecedores.Auditor = auditor;
        return fornecedores;
    }
}