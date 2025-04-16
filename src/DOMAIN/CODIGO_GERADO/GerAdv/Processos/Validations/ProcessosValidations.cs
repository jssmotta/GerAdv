#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProcessosValidation
{
    Task<string> ValidateReg(Models.Processos reg, IProcessosService service, IAdvogadosReader advogadosReader, IJusticaReader justicaReader, IPrepostosReader prepostosReader, IClientesReader clientesReader, IOponentesReader oponentesReader, IAreaReader areaReader, ISituacaoReader situacaoReader, IRitoReader ritoReader, IAtividadesReader atividadesReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class ProcessosValidation : IProcessosValidation
{
    public async Task<string> ValidateReg(Models.Processos reg, IProcessosService service, IAdvogadosReader advogadosReader, IJusticaReader justicaReader, IPrepostosReader prepostosReader, IClientesReader clientesReader, IOponentesReader oponentesReader, IAreaReader areaReader, ISituacaoReader situacaoReader, IRitoReader ritoReader, IAtividadesReader atividadesReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.NroPasta))
            return "NroPasta é obrigatório";
        // Advogados
        if (reg.AdvOpo.IsEmptyIDNumber())
        {
            var regAdvogados = advogadosReader.Read(reg.AdvOpo, oCnn);
            if (regAdvogados == null || regAdvogados.Id != reg.AdvOpo)
            {
                return $"Advogados não encontrado ({regAdvogados?.Id}).";
            }
        }

        // Justica
        if (reg.Justica.IsEmptyIDNumber())
        {
            var regJustica = justicaReader.Read(reg.Justica, oCnn);
            if (regJustica == null || regJustica.Id != reg.Justica)
            {
                return $"Justica não encontrado ({regJustica?.Id}).";
            }
        }

        // Advogados
        if (reg.Advogado.IsEmptyIDNumber())
        {
            var regAdvogados = advogadosReader.Read(reg.Advogado, oCnn);
            if (regAdvogados == null || regAdvogados.Id != reg.Advogado)
            {
                return $"Advogados não encontrado ({regAdvogados?.Id}).";
            }
        }

        // Prepostos
        if (reg.Preposto.IsEmptyIDNumber())
        {
            var regPrepostos = prepostosReader.Read(reg.Preposto, oCnn);
            if (regPrepostos == null || regPrepostos.Id != reg.Preposto)
            {
                return $"Prepostos não encontrado ({regPrepostos?.Id}).";
            }
        }

        // Clientes
        if (reg.Cliente.IsEmptyIDNumber())
        {
            var regClientes = clientesReader.Read(reg.Cliente, oCnn);
            if (regClientes == null || regClientes.Id != reg.Cliente)
            {
                return $"Clientes não encontrado ({regClientes?.Id}).";
            }
        }

        // Oponentes
        if (reg.Oponente.IsEmptyIDNumber())
        {
            var regOponentes = oponentesReader.Read(reg.Oponente, oCnn);
            if (regOponentes == null || regOponentes.Id != reg.Oponente)
            {
                return $"Oponentes não encontrado ({regOponentes?.Id}).";
            }
        }

        // Area
        if (reg.Area.IsEmptyIDNumber())
        {
            var regArea = areaReader.Read(reg.Area, oCnn);
            if (regArea == null || regArea.Id != reg.Area)
            {
                return $"Area não encontrado ({regArea?.Id}).";
            }
        }

        // Situacao
        if (reg.Situacao.IsEmptyIDNumber())
        {
            var regSituacao = situacaoReader.Read(reg.Situacao, oCnn);
            if (regSituacao == null || regSituacao.Id != reg.Situacao)
            {
                return $"Situacao não encontrado ({regSituacao?.Id}).";
            }
        }

        // Rito
        if (reg.Rito.IsEmptyIDNumber())
        {
            var regRito = ritoReader.Read(reg.Rito, oCnn);
            if (regRito == null || regRito.Id != reg.Rito)
            {
                return $"Rito não encontrado ({regRito?.Id}).";
            }
        }

        // Atividades
        if (reg.Atividade.IsEmptyIDNumber())
        {
            var regAtividades = atividadesReader.Read(reg.Atividade, oCnn);
            if (regAtividades == null || regAtividades.Id != reg.Atividade)
            {
                return $"Atividades não encontrado ({regAtividades?.Id}).";
            }
        }

        return string.Empty;
    }
}