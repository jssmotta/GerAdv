#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IFuncionariosValidation
{
    Task<string> ValidateReg(Models.Funcionarios reg, IFuncionariosService service, ICargosReader cargosReader, IFuncaoReader funcaoReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class FuncionariosValidation : IFuncionariosValidation
{
    public async Task<string> ValidateReg(Models.Funcionarios reg, IFuncionariosService service, ICargosReader cargosReader, IFuncaoReader funcaoReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (!string.IsNullOrWhiteSpace(reg.CPF) && await IsCpfDuplicado(reg, service, uri))
            return $"'Colaborador' com cpf '{reg.CPF.MaskCpf()}' já cadastrado.";
        // Cargos
        if (!reg.Cargo.IsEmptyIDNumber())
        {
            var regCargos = cargosReader.Read(reg.Cargo, oCnn);
            if (regCargos == null || regCargos.Id != reg.Cargo)
            {
                return $"Cargos não encontrado ({regCargos?.Id}).";
            }
        }

        // Funcao
        if (!reg.Funcao.IsEmptyIDNumber())
        {
            var regFuncao = funcaoReader.Read(reg.Funcao, oCnn);
            if (regFuncao == null || regFuncao.Id != reg.Funcao)
            {
                return $"Função não encontrado ({regFuncao?.Id}).";
            }
        }

        return string.Empty;
    }

    private async Task<bool> IsCpfDuplicado(Models.Funcionarios reg, IFuncionariosService service, string uri)
    {
        var existingFuncionarios = (await service.Filter(new Filters.FilterFuncionarios { CPF = reg.CPF }, uri)).FirstOrDefault();
        return existingFuncionarios != null && existingFuncionarios.Id > 0 && existingFuncionarios.Id != reg.Id;
    }
}