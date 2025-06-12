#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgendaQuemValidation
{
    Task<string> ValidateReg(Models.AgendaQuem reg, IAgendaQuemService service, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, IPrepostosReader prepostosReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IAgendaQuemService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class AgendaQuemValidation : IAgendaQuemValidation
{
    public async Task<string> CanDelete(int id, IAgendaQuemService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.AgendaQuem reg, IAgendaQuemService service, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, IPrepostosReader prepostosReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        // Advogados
        if (!reg.Advogado.IsEmptyIDNumber())
        {
            var regAdvogados = advogadosReader.Read(reg.Advogado, oCnn);
            if (regAdvogados == null || regAdvogados.Id != reg.Advogado)
            {
                return $"Advogados não encontrado ({regAdvogados?.Id}).";
            }
        }

        // Funcionarios
        if (!reg.Funcionario.IsEmptyIDNumber())
        {
            var regFuncionarios = funcionariosReader.Read(reg.Funcionario, oCnn);
            if (regFuncionarios == null || regFuncionarios.Id != reg.Funcionario)
            {
                return $"Colaborador não encontrado ({regFuncionarios?.Id}).";
            }
        }

        // Prepostos
        if (!reg.Preposto.IsEmptyIDNumber())
        {
            var regPrepostos = prepostosReader.Read(reg.Preposto, oCnn);
            if (regPrepostos == null || regPrepostos.Id != reg.Preposto)
            {
                return $"Prepostos não encontrado ({regPrepostos?.Id}).";
            }
        }

        return string.Empty;
    }
}