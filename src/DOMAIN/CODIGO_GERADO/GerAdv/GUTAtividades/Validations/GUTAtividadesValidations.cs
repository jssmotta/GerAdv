#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTAtividadesValidation
{
    Task<string> ValidateReg(Models.GUTAtividades reg, IGUTAtividadesService service, IGUTPeriodicidadeReader gutperiodicidadeReader, IOperadorReader operadorReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class GUTAtividadesValidation : IGUTAtividadesValidation
{
    public async Task<string> ValidateReg(Models.GUTAtividades reg, IGUTAtividadesService service, IGUTPeriodicidadeReader gutperiodicidadeReader, IOperadorReader operadorReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        // GUTPeriodicidade
        if (!reg.GUTPeriodicidade.IsEmptyIDNumber())
        {
            var regGUTPeriodicidade = gutperiodicidadeReader.Read(reg.GUTPeriodicidade, oCnn);
            if (regGUTPeriodicidade == null || regGUTPeriodicidade.Id != reg.GUTPeriodicidade)
            {
                return $"G U T Periodicidade não encontrado ({regGUTPeriodicidade?.Id}).";
            }
        }

        // Operador
        if (!reg.Operador.IsEmptyIDNumber())
        {
            var regOperador = operadorReader.Read(reg.Operador, oCnn);
            if (regOperador == null || regOperador.Id != reg.Operador)
            {
                return $"Operador não encontrado ({regOperador?.Id}).";
            }
        }

        return string.Empty;
    }
}