#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IInstanciaValidation
{
    Task<string> ValidateReg(Models.Instancia reg, IInstanciaService service, IProcessosReader processosReader, IAcaoReader acaoReader, IForoReader foroReader, ITipoRecursoReader tiporecursoReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IInstanciaService service, INENotasService nenotasService, IProSucumbenciaService prosucumbenciaService, ITribunalService tribunalService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class InstanciaValidation : IInstanciaValidation
{
    public async Task<string> CanDelete(int id, IInstanciaService service, INENotasService nenotasService, IProSucumbenciaService prosucumbenciaService, ITribunalService tribunalService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var nenotasExists0 = await nenotasService.Filter(new Filters.FilterNENotas { Instancia = id }, uri);
        if (nenotasExists0 != null && nenotasExists0.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela N E Notas associados a ele.";
        var prosucumbenciaExists1 = await prosucumbenciaService.Filter(new Filters.FilterProSucumbencia { Instancia = id }, uri);
        if (prosucumbenciaExists1 != null && prosucumbenciaExists1.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Pro Sucumbencia associados a ele.";
        var tribunalExists2 = await tribunalService.Filter(new Filters.FilterTribunal { Instancia = id }, uri);
        if (tribunalExists2 != null && tribunalExists2.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Tribunal associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.Instancia reg, IInstanciaService service, IProcessosReader processosReader, IAcaoReader acaoReader, IForoReader foroReader, ITipoRecursoReader tiporecursoReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.NroProcesso))
            return "NroProcesso é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Instancia '{reg.NroProcesso}' Divisao e/ou NroProcesso e/ou SubDivisao";
        // Processos
        if (!reg.Processo.IsEmptyIDNumber())
        {
            var regProcessos = processosReader.Read(reg.Processo, oCnn);
            if (regProcessos == null || regProcessos.Id != reg.Processo)
            {
                return $"Processos não encontrado ({regProcessos?.Id}).";
            }
        }

        // Acao
        if (!reg.Acao.IsEmptyIDNumber())
        {
            var regAcao = acaoReader.Read(reg.Acao, oCnn);
            if (regAcao == null || regAcao.Id != reg.Acao)
            {
                return $"Acao não encontrado ({regAcao?.Id}).";
            }
        }

        // Foro
        if (!reg.Foro.IsEmptyIDNumber())
        {
            var regForo = foroReader.Read(reg.Foro, oCnn);
            if (regForo == null || regForo.Id != reg.Foro)
            {
                return $"Foro não encontrado ({regForo?.Id}).";
            }
        }

        // TipoRecurso
        if (!reg.TipoRecurso.IsEmptyIDNumber())
        {
            var regTipoRecurso = tiporecursoReader.Read(reg.TipoRecurso, oCnn);
            if (regTipoRecurso == null || regTipoRecurso.Id != reg.TipoRecurso)
            {
                return $"Tipo Recurso não encontrado ({regTipoRecurso?.Id}).";
            }
        }

        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.Instancia reg, IInstanciaService service, string uri)
    {
        var existingInstancia = (await service.Filter(new Filters.FilterInstancia { Divisao = reg.Divisao, NroProcesso = reg.NroProcesso, SubDivisao = reg.SubDivisao }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingInstancia != null && existingInstancia.Id > 0 && existingInstancia.Id != reg.Id;
    }
}