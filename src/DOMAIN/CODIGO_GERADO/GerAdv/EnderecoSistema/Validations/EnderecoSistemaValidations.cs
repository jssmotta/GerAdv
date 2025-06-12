#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IEnderecoSistemaValidation
{
    Task<string> ValidateReg(Models.EnderecoSistema reg, IEnderecoSistemaService service, ITipoEnderecoSistemaReader tipoenderecosistemaReader, IProcessosReader processosReader, ICidadeReader cidadeReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IEnderecoSistemaService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class EnderecoSistemaValidation : IEnderecoSistemaValidation
{
    public async Task<string> CanDelete(int id, IEnderecoSistemaService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.EnderecoSistema reg, IEnderecoSistemaService service, ITipoEnderecoSistemaReader tipoenderecosistemaReader, IProcessosReader processosReader, ICidadeReader cidadeReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        // TipoEnderecoSistema
        if (!reg.TipoEnderecoSistema.IsEmptyIDNumber())
        {
            var regTipoEnderecoSistema = tipoenderecosistemaReader.Read(reg.TipoEnderecoSistema, oCnn);
            if (regTipoEnderecoSistema == null || regTipoEnderecoSistema.Id != reg.TipoEnderecoSistema)
            {
                return $"Tipo Endereco Sistema não encontrado ({regTipoEnderecoSistema?.Id}).";
            }
        }

        // Processos
        if (!reg.Processo.IsEmptyIDNumber())
        {
            var regProcessos = processosReader.Read(reg.Processo, oCnn);
            if (regProcessos == null || regProcessos.Id != reg.Processo)
            {
                return $"Processos não encontrado ({regProcessos?.Id}).";
            }
        }

        // Cidade
        if (!reg.Cidade.IsEmptyIDNumber())
        {
            var regCidade = cidadeReader.Read(reg.Cidade, oCnn);
            if (regCidade == null || regCidade.Id != reg.Cidade)
            {
                return $"Cidade não encontrado ({regCidade?.Id}).";
            }
        }

        return string.Empty;
    }
}