#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IHonorariosDadosContratoReader
{
    HonorariosDadosContratoResponse? Read(int id, MsiSqlConnection oCnn);
    HonorariosDadosContratoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    HonorariosDadosContratoResponse? Read(Entity.DBHonorariosDadosContrato dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    HonorariosDadosContratoResponse? Read(DBHonorariosDadosContrato dbRec);
    HonorariosDadosContratoResponseAll? ReadAll(DBHonorariosDadosContrato dbRec, DataRow dr);
}

public partial class HonorariosDadosContrato : IHonorariosDadosContratoReader
{
    public HonorariosDadosContratoResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBHonorariosDadosContrato(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public HonorariosDadosContratoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBHonorariosDadosContrato(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public HonorariosDadosContratoResponse? Read(Entity.DBHonorariosDadosContrato dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var honorariosdadoscontrato = new HonorariosDadosContratoResponse
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            Fixo = dbRec.FFixo,
            Variavel = dbRec.FVariavel,
            PercSucesso = dbRec.FPercSucesso,
            Processo = dbRec.FProcesso,
            ArquivoContrato = dbRec.FArquivoContrato ?? string.Empty,
            TextoContrato = dbRec.FTextoContrato ?? string.Empty,
            ValorFixo = dbRec.FValorFixo,
            Observacao = dbRec.FObservacao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataContrato, out _))
            honorariosdadoscontrato.DataContrato = dbRec.FDataContrato;
        return honorariosdadoscontrato;
    }

    public HonorariosDadosContratoResponse? Read(DBHonorariosDadosContrato dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var honorariosdadoscontrato = new HonorariosDadosContratoResponse
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            Fixo = dbRec.FFixo,
            Variavel = dbRec.FVariavel,
            PercSucesso = dbRec.FPercSucesso,
            Processo = dbRec.FProcesso,
            ArquivoContrato = dbRec.FArquivoContrato ?? string.Empty,
            TextoContrato = dbRec.FTextoContrato ?? string.Empty,
            ValorFixo = dbRec.FValorFixo,
            Observacao = dbRec.FObservacao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataContrato, out _))
            honorariosdadoscontrato.DataContrato = dbRec.FDataContrato;
        return honorariosdadoscontrato;
    }

    public HonorariosDadosContratoResponseAll? ReadAll(DBHonorariosDadosContrato dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var honorariosdadoscontrato = new HonorariosDadosContratoResponseAll
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            Fixo = dbRec.FFixo,
            Variavel = dbRec.FVariavel,
            PercSucesso = dbRec.FPercSucesso,
            Processo = dbRec.FProcesso,
            ArquivoContrato = dbRec.FArquivoContrato ?? string.Empty,
            TextoContrato = dbRec.FTextoContrato ?? string.Empty,
            ValorFixo = dbRec.FValorFixo,
            Observacao = dbRec.FObservacao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataContrato, out _))
            honorariosdadoscontrato.DataContrato = dbRec.FDataContrato;
        honorariosdadoscontrato.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        honorariosdadoscontrato.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return honorariosdadoscontrato;
    }
}