#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAdvogadosValidation
{
    Task<string> ValidateReg(Models.Advogados reg, IAdvogadosService service, ICargosReader cargosReader, IEscritoriosReader escritoriosReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class AdvogadosValidation : IAdvogadosValidation
{
    public async Task<string> ValidateReg(Models.Advogados reg, IAdvogadosService service, ICargosReader cargosReader, IEscritoriosReader escritoriosReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Advogados '{reg.Nome}' já cadastrado.";
        if (!string.IsNullOrWhiteSpace(reg.CPF) && await IsCpfDuplicado(reg, service, uri))
            return $"'Advogados' com cpf '{reg.CPF.MaskCpf()}' já cadastrado.";
        // Cargos
        if (!reg.Cargo.IsEmptyIDNumber())
        {
            var regCargos = cargosReader.Read(reg.Cargo, oCnn);
            if (regCargos == null || regCargos.Id != reg.Cargo)
            {
                return $"Cargos não encontrado ({regCargos?.Id}).";
            }
        }

        // Escritorios
        if (!reg.Escritorio.IsEmptyIDNumber())
        {
            var regEscritorios = escritoriosReader.Read(reg.Escritorio, oCnn);
            if (regEscritorios == null || regEscritorios.Id != reg.Escritorio)
            {
                return $"Escritorios não encontrado ({regEscritorios?.Id}).";
            }
        }

        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.Advogados reg, IAdvogadosService service, string uri)
    {
        var existingAdvogados = (await service.Filter(new Filters.FilterAdvogados { Escritorio = reg.Escritorio, Nome = reg.Nome }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingAdvogados != null && existingAdvogados.Id > 0 && existingAdvogados.Id != reg.Id;
    }

    private async Task<bool> IsCpfDuplicado(Models.Advogados reg, IAdvogadosService service, string uri)
    {
        var existingAdvogados = (await service.Filter(new Filters.FilterAdvogados { CPF = reg.CPF }, uri)).FirstOrDefault();
        return existingAdvogados != null && existingAdvogados.Id > 0 && existingAdvogados.Id != reg.Id;
    }
}