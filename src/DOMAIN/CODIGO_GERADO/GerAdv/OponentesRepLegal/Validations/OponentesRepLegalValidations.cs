#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOponentesRepLegalValidation
{
    Task<string> ValidateReg(Models.OponentesRepLegal reg, IOponentesRepLegalService service, IOponentesReader oponentesReader, ICidadeReader cidadeReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IOponentesRepLegalService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class OponentesRepLegalValidation : IOponentesRepLegalValidation
{
    public async Task<string> CanDelete(int id, IOponentesRepLegalService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.OponentesRepLegal reg, IOponentesRepLegalService service, IOponentesReader oponentesReader, ICidadeReader cidadeReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (!string.IsNullOrWhiteSpace(reg.CPF))
        {
            var testaCpf = await IsCpfDuplicado(reg, service, uri);
            if (testaCpf.Item1 && testaCpf.Item2 != null)
            {
                return $"Oponentes Rep Legal ({testaCpf.Item2.Nome}) com cpf '{reg.CPF.MaskCpf()}' já cadastrado.";
            }
            else if (testaCpf.Item1)
            {
                return $"Oponentes Rep Legal com cpf '{reg.CPF.MaskCpf()}' já cadastrado.";
            }
        }

        // Oponentes
        if (!reg.Oponente.IsEmptyIDNumber())
        {
            var regOponentes = oponentesReader.Read(reg.Oponente, oCnn);
            if (regOponentes == null || regOponentes.Id != reg.Oponente)
            {
                return $"Oponentes não encontrado ({regOponentes?.Id}).";
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

    private async Task<(bool, OponentesRepLegalResponseAll? )> IsCpfDuplicado(Models.OponentesRepLegal reg, IOponentesRepLegalService service, string uri)
    {
        if (reg.CPF.Length == 0)
            return (false, null);
        var existingOponentesRepLegal = (await service.Filter(new Filters.FilterOponentesRepLegal { CPF = reg.CPF.ClearInputCpf() }, uri)).FirstOrDefault();
        return (existingOponentesRepLegal != null && existingOponentesRepLegal.Id > 0 && existingOponentesRepLegal.Id != reg.Id, existingOponentesRepLegal);
    }
}