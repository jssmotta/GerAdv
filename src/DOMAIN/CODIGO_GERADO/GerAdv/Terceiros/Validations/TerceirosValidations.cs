#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITerceirosValidation
{
    Task<string> ValidateReg(Models.Terceiros reg, ITerceirosService service, IProcessosReader processosReader, IPosicaoOutrasPartesReader posicaooutraspartesReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class TerceirosValidation : ITerceirosValidation
{
    public async Task<string> ValidateReg(Models.Terceiros reg, ITerceirosService service, IProcessosReader processosReader, IPosicaoOutrasPartesReader posicaooutraspartesReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Terceiros '{reg.Nome}' já cadastrado.";
        // Processos
        if (reg.Processo.IsEmptyIDNumber())
        {
            var regProcessos = processosReader.Read(reg.Processo, oCnn);
            if (regProcessos == null || regProcessos.Id != reg.Processo)
            {
                return $"Processos não encontrado ({regProcessos?.Id}).";
            }
        }

        // PosicaoOutrasPartes
        if (reg.Situacao.IsEmptyIDNumber())
        {
            var regPosicaoOutrasPartes = posicaooutraspartesReader.Read(reg.Situacao, oCnn);
            if (regPosicaoOutrasPartes == null || regPosicaoOutrasPartes.Id != reg.Situacao)
            {
                return $"Posicao Outras Partes não encontrado ({regPosicaoOutrasPartes?.Id}).";
            }
        }

        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.Terceiros reg, ITerceirosService service, string uri)
    {
        var existingTerceiros = (await service.Filter(new Filters.FilterTerceiros { Nome = reg.Nome, Processo = reg.Processo }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingTerceiros != null && existingTerceiros.Id > 0 && existingTerceiros.Id != reg.Id;
    }
}