#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProDepositosReader
{
    ProDepositosResponse? Read(int id, MsiSqlConnection oCnn);
    ProDepositosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProDepositosResponse? Read(Entity.DBProDepositos dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProDepositosResponse? Read(DBProDepositos dbRec);
    ProDepositosResponseAll? ReadAll(DBProDepositos dbRec, DataRow dr);
}

public partial class ProDepositos : IProDepositosReader
{
    public ProDepositosResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProDepositos(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProDepositosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProDepositos(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProDepositosResponse? Read(Entity.DBProDepositos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var prodepositos = new ProDepositosResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Fase = dbRec.FFase,
            Valor = dbRec.FValor,
            TipoProDesposito = dbRec.FTipoProDesposito,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            prodepositos.Data = dbRec.FData;
        return prodepositos;
    }

    public ProDepositosResponse? Read(DBProDepositos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var prodepositos = new ProDepositosResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Fase = dbRec.FFase,
            Valor = dbRec.FValor,
            TipoProDesposito = dbRec.FTipoProDesposito,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            prodepositos.Data = dbRec.FData;
        return prodepositos;
    }

    public ProDepositosResponseAll? ReadAll(DBProDepositos dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var prodepositos = new ProDepositosResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Fase = dbRec.FFase,
            Valor = dbRec.FValor,
            TipoProDesposito = dbRec.FTipoProDesposito,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            prodepositos.Data = dbRec.FData;
        prodepositos.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        prodepositos.DescricaoFase = dr["fasDescricao"]?.ToString() ?? string.Empty;
        prodepositos.NomeTipoProDesposito = dr["tpdNome"]?.ToString() ?? string.Empty;
        return prodepositos;
    }
}