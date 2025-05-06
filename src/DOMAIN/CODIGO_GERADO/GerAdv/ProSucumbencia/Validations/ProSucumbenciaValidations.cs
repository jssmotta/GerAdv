#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProSucumbenciaValidation
{
    Task<string> ValidateReg(Models.ProSucumbencia reg, IProSucumbenciaService service, IProcessosReader processosReader, IInstanciaReader instanciaReader, ITipoOrigemSucumbenciaReader tipoorigemsucumbenciaReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class ProSucumbenciaValidation : IProSucumbenciaValidation
{
    public async Task<string> ValidateReg(Models.ProSucumbencia reg, IProSucumbenciaService service, IProcessosReader processosReader, IInstanciaReader instanciaReader, ITipoOrigemSucumbenciaReader tipoorigemsucumbenciaReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        // Processos
        if (!reg.Processo.IsEmptyIDNumber())
        {
            var regProcessos = processosReader.Read(reg.Processo, oCnn);
            if (regProcessos == null || regProcessos.Id != reg.Processo)
            {
                return $"Processos não encontrado ({regProcessos?.Id}).";
            }
        }

        // Instancia
        if (!reg.Instancia.IsEmptyIDNumber())
        {
            var regInstancia = instanciaReader.Read(reg.Instancia, oCnn);
            if (regInstancia == null || regInstancia.Id != reg.Instancia)
            {
                return $"Instancia não encontrado ({regInstancia?.Id}).";
            }
        }

        // TipoOrigemSucumbencia
        if (!reg.TipoOrigemSucumbencia.IsEmptyIDNumber())
        {
            var regTipoOrigemSucumbencia = tipoorigemsucumbenciaReader.Read(reg.TipoOrigemSucumbencia, oCnn);
            if (regTipoOrigemSucumbencia == null || regTipoOrigemSucumbencia.Id != reg.TipoOrigemSucumbencia)
            {
                return $"Tipo Origem Sucumbencia não encontrado ({regTipoOrigemSucumbencia?.Id}).";
            }
        }

        return string.Empty;
    }
}