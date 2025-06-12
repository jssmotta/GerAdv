#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOponentesValidation
{
    Task<string> ValidateReg(Models.Oponentes reg, IOponentesService service, ICidadeReader cidadeReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IOponentesService service, IGruposEmpresasService gruposempresasService, IOponentesRepLegalService oponentesreplegalService, IProcessosService processosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class OponentesValidation : IOponentesValidation
{
    public async Task<string> CanDelete(int id, IOponentesService service, IGruposEmpresasService gruposempresasService, IOponentesRepLegalService oponentesreplegalService, IProcessosService processosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var gruposempresasExists = await gruposempresasService.Filter(new Filters.FilterGruposEmpresas { Oponente = id }, uri);
        if (gruposempresasExists != null && gruposempresasExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Grupos Empresas associados a ele.";
        var oponentesreplegalExists = await oponentesreplegalService.Filter(new Filters.FilterOponentesRepLegal { Oponente = id }, uri);
        if (oponentesreplegalExists != null && oponentesreplegalExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Oponentes Rep Legal associados a ele.";
        var processosExists = await processosService.Filter(new Filters.FilterProcessos { Oponente = id }, uri);
        if (processosExists != null && processosExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Processos associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.Oponentes reg, IOponentesService service, ICidadeReader cidadeReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Oponentes '{reg.Nome}' já cadastrado.";
        if (!string.IsNullOrWhiteSpace(reg.CPF) && await IsCpfDuplicado(reg, service, uri))
            return $"'Oponentes' com cpf '{reg.CPF.MaskCpf()}' já cadastrado.";
        if (!string.IsNullOrWhiteSpace(reg.CNPJ) && await IsCnpjDuplicado(reg, service, uri))
            return $"Oponentes com cnpj {reg.CNPJ.MaskCnpj()} já cadastrado.";
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

    private async Task<bool> IsDuplicado(Models.Oponentes reg, IOponentesService service, string uri)
    {
        var existingOponentes = (await service.Filter(new Filters.FilterOponentes { Nome = reg.Nome }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingOponentes != null && existingOponentes.Id > 0 && existingOponentes.Id != reg.Id;
    }

    private async Task<bool> IsCnpjDuplicado(Models.Oponentes reg, IOponentesService service, string uri)
    {
        if (reg.CNPJ.Length == 0)
            return false;
        var existingOponentes = (await service.Filter(new Filters.FilterOponentes { CNPJ = reg.CNPJ }, uri)).FirstOrDefault();
        return existingOponentes != null && existingOponentes.Id > 0 && existingOponentes.Id != reg.Id;
    }

    private async Task<bool> IsCpfDuplicado(Models.Oponentes reg, IOponentesService service, string uri)
    {
        if (reg.CPF.Length == 0)
            return false;
        var existingOponentes = (await service.Filter(new Filters.FilterOponentes { CPF = reg.CPF }, uri)).FirstOrDefault();
        return existingOponentes != null && existingOponentes.Id > 0 && existingOponentes.Id != reg.Id;
    }
}