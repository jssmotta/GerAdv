#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IContratosReader
{
    ContratosResponse? Read(int id, MsiSqlConnection oCnn);
    ContratosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ContratosResponse? Read(Entity.DBContratos dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ContratosResponse? Read(DBContratos dbRec);
    ContratosResponseAll? ReadAll(DBContratos dbRec, DataRow dr);
}

public partial class Contratos : IContratosReader
{
    public ContratosResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBContratos(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ContratosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBContratos(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ContratosResponse? Read(Entity.DBContratos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var contratos = new ContratosResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Cliente = dbRec.FCliente,
            Advogado = dbRec.FAdvogado,
            Dia = dbRec.FDia,
            Valor = dbRec.FValor,
            OcultarRelatorio = dbRec.FOcultarRelatorio,
            PercEscritorio = dbRec.FPercEscritorio,
            ValorConsultoria = dbRec.FValorConsultoria,
            TipoCobranca = dbRec.FTipoCobranca,
            Protestar = dbRec.FProtestar ?? string.Empty,
            Juros = dbRec.FJuros ?? string.Empty,
            ValorRealizavel = dbRec.FValorRealizavel,
            DOCUMENTO = dbRec.FDOCUMENTO ?? string.Empty,
            EMail1 = dbRec.FEMail1 ?? string.Empty,
            EMail2 = dbRec.FEMail2 ?? string.Empty,
            EMail3 = dbRec.FEMail3 ?? string.Empty,
            Pessoa1 = dbRec.FPessoa1 ?? string.Empty,
            Pessoa2 = dbRec.FPessoa2 ?? string.Empty,
            Pessoa3 = dbRec.FPessoa3 ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            ClienteContrato = dbRec.FClienteContrato,
            IdExtrangeiro = dbRec.FIdExtrangeiro,
            ChaveContrato = dbRec.FChaveContrato ?? string.Empty,
            Avulso = dbRec.FAvulso,
            Suspenso = dbRec.FSuspenso,
            Multa = dbRec.FMulta ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataInicio, out _))
            contratos.DataInicio = dbRec.FDataInicio;
        if (DateTime.TryParse(dbRec.FDataTermino, out _))
            contratos.DataTermino = dbRec.FDataTermino;
        return contratos;
    }

    public ContratosResponse? Read(DBContratos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var contratos = new ContratosResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Cliente = dbRec.FCliente,
            Advogado = dbRec.FAdvogado,
            Dia = dbRec.FDia,
            Valor = dbRec.FValor,
            OcultarRelatorio = dbRec.FOcultarRelatorio,
            PercEscritorio = dbRec.FPercEscritorio,
            ValorConsultoria = dbRec.FValorConsultoria,
            TipoCobranca = dbRec.FTipoCobranca,
            Protestar = dbRec.FProtestar ?? string.Empty,
            Juros = dbRec.FJuros ?? string.Empty,
            ValorRealizavel = dbRec.FValorRealizavel,
            DOCUMENTO = dbRec.FDOCUMENTO ?? string.Empty,
            EMail1 = dbRec.FEMail1 ?? string.Empty,
            EMail2 = dbRec.FEMail2 ?? string.Empty,
            EMail3 = dbRec.FEMail3 ?? string.Empty,
            Pessoa1 = dbRec.FPessoa1 ?? string.Empty,
            Pessoa2 = dbRec.FPessoa2 ?? string.Empty,
            Pessoa3 = dbRec.FPessoa3 ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            ClienteContrato = dbRec.FClienteContrato,
            IdExtrangeiro = dbRec.FIdExtrangeiro,
            ChaveContrato = dbRec.FChaveContrato ?? string.Empty,
            Avulso = dbRec.FAvulso,
            Suspenso = dbRec.FSuspenso,
            Multa = dbRec.FMulta ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataInicio, out _))
            contratos.DataInicio = dbRec.FDataInicio;
        if (DateTime.TryParse(dbRec.FDataTermino, out _))
            contratos.DataTermino = dbRec.FDataTermino;
        return contratos;
    }

    public ContratosResponseAll? ReadAll(DBContratos dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var contratos = new ContratosResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Cliente = dbRec.FCliente,
            Advogado = dbRec.FAdvogado,
            Dia = dbRec.FDia,
            Valor = dbRec.FValor,
            OcultarRelatorio = dbRec.FOcultarRelatorio,
            PercEscritorio = dbRec.FPercEscritorio,
            ValorConsultoria = dbRec.FValorConsultoria,
            TipoCobranca = dbRec.FTipoCobranca,
            Protestar = dbRec.FProtestar ?? string.Empty,
            Juros = dbRec.FJuros ?? string.Empty,
            ValorRealizavel = dbRec.FValorRealizavel,
            DOCUMENTO = dbRec.FDOCUMENTO ?? string.Empty,
            EMail1 = dbRec.FEMail1 ?? string.Empty,
            EMail2 = dbRec.FEMail2 ?? string.Empty,
            EMail3 = dbRec.FEMail3 ?? string.Empty,
            Pessoa1 = dbRec.FPessoa1 ?? string.Empty,
            Pessoa2 = dbRec.FPessoa2 ?? string.Empty,
            Pessoa3 = dbRec.FPessoa3 ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            ClienteContrato = dbRec.FClienteContrato,
            IdExtrangeiro = dbRec.FIdExtrangeiro,
            ChaveContrato = dbRec.FChaveContrato ?? string.Empty,
            Avulso = dbRec.FAvulso,
            Suspenso = dbRec.FSuspenso,
            Multa = dbRec.FMulta ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataInicio, out _))
            contratos.DataInicio = dbRec.FDataInicio;
        if (DateTime.TryParse(dbRec.FDataTermino, out _))
            contratos.DataTermino = dbRec.FDataTermino;
        contratos.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        contratos.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        contratos.NomeAdvogados = dr["advNome"]?.ToString() ?? string.Empty;
        return contratos;
    }
}