#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IContatoCRMValidation
{
    Task<string> ValidateReg(Models.ContatoCRM reg, IContatoCRMService service, IOperadorReader operadorReader, IClientesReader clientesReader, IProcessosReader processosReader, ITipoContatoCRMReader tipocontatocrmReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IContatoCRMService service, IContatoCRMOperadorService contatocrmoperadorService, IDocsRecebidosItensService docsrecebidositensService, IRecadosService recadosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class ContatoCRMValidation : IContatoCRMValidation
{
    public async Task<string> CanDelete(int id, IContatoCRMService service, IContatoCRMOperadorService contatocrmoperadorService, IDocsRecebidosItensService docsrecebidositensService, IRecadosService recadosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var contatocrmoperadorExists0 = await contatocrmoperadorService.Filter(new Filters.FilterContatoCRMOperador { ContatoCRM = id }, uri);
        if (contatocrmoperadorExists0 != null && contatocrmoperadorExists0.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Contato C R M Operador associados a ele.";
        var docsrecebidositensExists1 = await docsrecebidositensService.Filter(new Filters.FilterDocsRecebidosItens { ContatoCRM = id }, uri);
        if (docsrecebidositensExists1 != null && docsrecebidositensExists1.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Docs Recebidos Itens associados a ele.";
        var recadosExists2 = await recadosService.Filter(new Filters.FilterRecados { ContatoCRM = id }, uri);
        if (recadosExists2 != null && recadosExists2.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Recados associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.ContatoCRM reg, IContatoCRMService service, IOperadorReader operadorReader, IClientesReader clientesReader, IProcessosReader processosReader, ITipoContatoCRMReader tipocontatocrmReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        // Operador
        if (!reg.Operador.IsEmptyIDNumber())
        {
            var regOperador = operadorReader.Read(reg.Operador, oCnn);
            if (regOperador == null || regOperador.Id != reg.Operador)
            {
                return $"Operador não encontrado ({regOperador?.Id}).";
            }
        }

        // Clientes
        if (!reg.Cliente.IsEmptyIDNumber())
        {
            var regClientes = clientesReader.Read(reg.Cliente, oCnn);
            if (regClientes == null || regClientes.Id != reg.Cliente)
            {
                return $"Clientes não encontrado ({regClientes?.Id}).";
            }
        }

        // Processos
        if (!reg.Processo.IsEmptyIDNumber())
        {
            var regProcessos = processosReader.Read(reg.Processo, oCnn);
            if (regProcessos == null || regProcessos.Id != reg.Processo)
            {
                return $"Processos não encontrado ({regProcessos?.Id}).";
            }
        }

        // TipoContatoCRM
        if (!reg.TipoContatoCRM.IsEmptyIDNumber())
        {
            var regTipoContatoCRM = tipocontatocrmReader.Read(reg.TipoContatoCRM, oCnn);
            if (regTipoContatoCRM == null || regTipoContatoCRM.Id != reg.TipoContatoCRM)
            {
                return $"Tipo Contato C R M não encontrado ({regTipoContatoCRM?.Id}).";
            }
        }

        return string.Empty;
    }
}