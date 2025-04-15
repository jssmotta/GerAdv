#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPrepostosValidation
{
    Task<string> ValidateReg(Models.Prepostos reg, IPrepostosService service, IFuncaoReader funcaoReader, ISetorReader setorReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class PrepostosValidation : IPrepostosValidation
{
    public async Task<string> ValidateReg(Models.Prepostos reg, IPrepostosService service, IFuncaoReader funcaoReader, ISetorReader setorReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (!string.IsNullOrWhiteSpace(reg.CPF) && await IsCpfDuplicado(reg, service, uri))
            return $"'Prepostos' com cpf '{reg.CPF.MaskCpf()}' já cadastrado.";
        // Funcao
        if (reg.Funcao.IsEmptyIDNumber())
        {
            var regFuncao = funcaoReader.Read(reg.Funcao, oCnn);
            if (regFuncao == null || regFuncao.Id != reg.Funcao)
            {
                return $"Função não encontrado ({regFuncao?.Id}).";
            }
        }

        // Setor
        if (reg.Setor.IsEmptyIDNumber())
        {
            var regSetor = setorReader.Read(reg.Setor, oCnn);
            if (regSetor == null || regSetor.Id != reg.Setor)
            {
                return $"Setor não encontrado ({regSetor?.Id}).";
            }
        }

        return string.Empty;
    }

    private async Task<bool> IsCpfDuplicado(Models.Prepostos reg, IPrepostosService service, string uri)
    {
        var existingPrepostos = (await service.Filter(new Filters.FilterPrepostos { CPF = reg.CPF }, uri)).FirstOrDefault();
        return existingPrepostos != null && existingPrepostos.Id > 0 && existingPrepostos.Id != reg.Id;
    }
}