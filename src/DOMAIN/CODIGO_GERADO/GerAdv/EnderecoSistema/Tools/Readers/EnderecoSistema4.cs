#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IEnderecoSistemaReader
{
    EnderecoSistemaResponse? Read(int id, SqlConnection oCnn);
    EnderecoSistemaResponse? Read(string where, SqlConnection oCnn);
    EnderecoSistemaResponse? Read(Entity.DBEnderecoSistema dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    EnderecoSistemaResponse? Read(DBEnderecoSistema dbRec);
}

public partial class EnderecoSistema : IEnderecoSistemaReader
{
    public EnderecoSistemaResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBEnderecoSistema(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public EnderecoSistemaResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBEnderecoSistema(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public EnderecoSistemaResponse? Read(Entity.DBEnderecoSistema dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var enderecosistema = new EnderecoSistemaResponse
        {
            Id = dbRec.ID,
            Cadastro = dbRec.FCadastro,
            CadastroExCod = dbRec.FCadastroExCod,
            TipoEnderecoSistema = dbRec.FTipoEnderecoSistema,
            Processo = dbRec.FProcesso,
            Motivo = dbRec.FMotivo ?? string.Empty,
            ContatoNoLocal = dbRec.FContatoNoLocal ?? string.Empty,
            Cidade = dbRec.FCidade,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Observacao = dbRec.FObservacao ?? string.Empty,
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
        enderecosistema.Auditor = auditor;
        return enderecosistema;
    }

    public EnderecoSistemaResponse? Read(DBEnderecoSistema dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var enderecosistema = new EnderecoSistemaResponse
        {
            Id = dbRec.ID,
            Cadastro = dbRec.FCadastro,
            CadastroExCod = dbRec.FCadastroExCod,
            TipoEnderecoSistema = dbRec.FTipoEnderecoSistema,
            Processo = dbRec.FProcesso,
            Motivo = dbRec.FMotivo ?? string.Empty,
            ContatoNoLocal = dbRec.FContatoNoLocal ?? string.Empty,
            Cidade = dbRec.FCidade,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Observacao = dbRec.FObservacao ?? string.Empty,
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
        enderecosistema.Auditor = auditor;
        return enderecosistema;
    }
}