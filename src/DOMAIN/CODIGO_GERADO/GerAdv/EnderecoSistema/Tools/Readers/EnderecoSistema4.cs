#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IEnderecoSistemaReader
{
    EnderecoSistemaResponse? Read(int id, MsiSqlConnection oCnn);
    EnderecoSistemaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    EnderecoSistemaResponse? Read(Entity.DBEnderecoSistema dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    EnderecoSistemaResponse? Read(DBEnderecoSistema dbRec);
    EnderecoSistemaResponseAll? ReadAll(DBEnderecoSistema dbRec, DataRow dr);
}

public partial class EnderecoSistema : IEnderecoSistemaReader
{
    public EnderecoSistemaResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBEnderecoSistema(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public EnderecoSistemaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBEnderecoSistema(sqlWhere: where, parameters: parameters, oCnn: oCnn);
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
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Observacao = dbRec.FObservacao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
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
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Observacao = dbRec.FObservacao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return enderecosistema;
    }

    public EnderecoSistemaResponseAll? ReadAll(DBEnderecoSistema dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var enderecosistema = new EnderecoSistemaResponseAll
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
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Observacao = dbRec.FObservacao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        enderecosistema.NomeTipoEnderecoSistema = dr["tesNome"]?.ToString() ?? string.Empty;
        enderecosistema.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        enderecosistema.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        return enderecosistema;
    }
}