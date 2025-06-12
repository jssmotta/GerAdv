#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITribEnderecosValidation
{
    Task<string> ValidateReg(Models.TribEnderecos reg, ITribEnderecosService service, ITribunalReader tribunalReader, ICidadeReader cidadeReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, ITribEnderecosService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class TribEnderecosValidation : ITribEnderecosValidation
{
    public async Task<string> CanDelete(int id, ITribEnderecosService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.TribEnderecos reg, ITribEnderecosService service, ITribunalReader tribunalReader, ICidadeReader cidadeReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        // Tribunal
        if (!reg.Tribunal.IsEmptyIDNumber())
        {
            var regTribunal = tribunalReader.Read(reg.Tribunal, oCnn);
            if (regTribunal == null || regTribunal.Id != reg.Tribunal)
            {
                return $"Tribunal não encontrado ({regTribunal?.Id}).";
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