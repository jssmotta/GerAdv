#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTAtividadesMatrizValidation
{
    Task<string> ValidateReg(Models.GUTAtividadesMatriz reg, IGUTAtividadesMatrizService service, IGUTMatrizReader gutmatrizReader, IGUTAtividadesReader gutatividadesReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IGUTAtividadesMatrizService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class GUTAtividadesMatrizValidation : IGUTAtividadesMatrizValidation
{
    public async Task<string> CanDelete(int id, IGUTAtividadesMatrizService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.GUTAtividadesMatriz reg, IGUTAtividadesMatrizService service, IGUTMatrizReader gutmatrizReader, IGUTAtividadesReader gutatividadesReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        // GUTMatriz
        if (!reg.GUTMatriz.IsEmptyIDNumber())
        {
            var regGUTMatriz = gutmatrizReader.Read(reg.GUTMatriz, oCnn);
            if (regGUTMatriz == null || regGUTMatriz.Id != reg.GUTMatriz)
            {
                return $"G U T Matriz não encontrado ({regGUTMatriz?.Id}).";
            }
        }

        // GUTAtividades
        if (!reg.GUTAtividade.IsEmptyIDNumber())
        {
            var regGUTAtividades = gutatividadesReader.Read(reg.GUTAtividade, oCnn);
            if (regGUTAtividades == null || regGUTAtividades.Id != reg.GUTAtividade)
            {
                return $"G U T Atividades não encontrado ({regGUTAtividades?.Id}).";
            }
        }

        return string.Empty;
    }
}