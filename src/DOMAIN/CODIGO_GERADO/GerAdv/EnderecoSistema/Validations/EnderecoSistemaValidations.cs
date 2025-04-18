#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IEnderecoSistemaValidation
{
    Task<string> ValidateReg(Models.EnderecoSistema reg, IEnderecoSistemaService service, ITipoEnderecoSistemaReader tipoenderecosistemaReader, IProcessosReader processosReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class EnderecoSistemaValidation : IEnderecoSistemaValidation
{
    public async Task<string> ValidateReg(Models.EnderecoSistema reg, IEnderecoSistemaService service, ITipoEnderecoSistemaReader tipoenderecosistemaReader, IProcessosReader processosReader, [FromRoute, Required] string uri, SqlConnection oCnn)
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

        return string.Empty;
    }
}