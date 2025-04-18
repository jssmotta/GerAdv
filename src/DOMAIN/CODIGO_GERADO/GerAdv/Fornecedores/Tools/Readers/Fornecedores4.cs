#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IFornecedoresReader
{
    FornecedoresResponse? Read(int id, SqlConnection oCnn);
    FornecedoresResponse? Read(string where, SqlConnection oCnn);
    FornecedoresResponse? Read(Entity.DBFornecedores dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    FornecedoresResponse? Read(DBFornecedores dbRec);
}

public partial class Fornecedores : IFornecedoresReader
{
    public FornecedoresResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBFornecedores(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public FornecedoresResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBFornecedores(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public FornecedoresResponse? Read(Entity.DBFornecedores dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

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
            Guid = dbRec.FGUID ?? string.Empty,
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

    public FornecedoresResponse? Read(DBFornecedores dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

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
            Guid = dbRec.FGUID ?? string.Empty,
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