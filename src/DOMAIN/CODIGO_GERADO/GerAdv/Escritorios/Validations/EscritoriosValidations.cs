#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IEscritoriosValidation
{
    Task<string> ValidateReg(Models.Escritorios reg, IEscritoriosService service, ICidadeReader cidadeReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IEscritoriosService service, IAdvogadosService advogadosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class EscritoriosValidation : IEscritoriosValidation
{
    public async Task<string> CanDelete(int id, IEscritoriosService service, IAdvogadosService advogadosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var advogadosExists0 = await advogadosService.Filter(new Filters.FilterAdvogados { Escritorio = id }, uri);
        if (advogadosExists0 != null && advogadosExists0.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Advogados associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.Escritorios reg, IEscritoriosService service, ICidadeReader cidadeReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Escritorios '{reg.Nome}'  - Nome";
        if (!string.IsNullOrWhiteSpace(reg.CNPJ) && await IsCnpjDuplicado(reg, service, uri))
            return $"Escritorios com cnpj {reg.CNPJ.MaskCnpj()} já cadastrado.";
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

    private async Task<bool> IsDuplicado(Models.Escritorios reg, IEscritoriosService service, string uri)
    {
        var existingEscritorios = (await service.Filter(new Filters.FilterEscritorios { Nome = reg.Nome }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingEscritorios != null && existingEscritorios.Id > 0 && existingEscritorios.Id != reg.Id;
    }

    private async Task<bool> IsCnpjDuplicado(Models.Escritorios reg, IEscritoriosService service, string uri)
    {
        if (reg.CNPJ.Length == 0)
            return false;
        var existingEscritorios = (await service.Filter(new Filters.FilterEscritorios { CNPJ = reg.CNPJ.ClearInputCnpj() }, uri)).FirstOrDefault();
        return existingEscritorios != null && existingEscritorios.Id > 0 && existingEscritorios.Id != reg.Id;
    }
}