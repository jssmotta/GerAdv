#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IParteClienteOutrasReader
{
    ParteClienteOutrasResponse? Read(int id, MsiSqlConnection oCnn);
    ParteClienteOutrasResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ParteClienteOutrasResponse? Read(Entity.DBParteClienteOutras dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ParteClienteOutrasResponse? Read(DBParteClienteOutras dbRec);
    ParteClienteOutrasResponseAll? ReadAll(DBParteClienteOutras dbRec, DataRow dr);
}

public partial class ParteClienteOutras : IParteClienteOutrasReader
{
    public ParteClienteOutrasResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBParteClienteOutras(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ParteClienteOutrasResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBParteClienteOutras(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ParteClienteOutrasResponse? Read(Entity.DBParteClienteOutras dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var parteclienteoutras = new ParteClienteOutrasResponse
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            Processo = dbRec.FProcesso,
            PrimeiraReclamada = dbRec.FPrimeiraReclamada,
        };
        return parteclienteoutras;
    }

    public ParteClienteOutrasResponse? Read(DBParteClienteOutras dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var parteclienteoutras = new ParteClienteOutrasResponse
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            Processo = dbRec.FProcesso,
            PrimeiraReclamada = dbRec.FPrimeiraReclamada,
        };
        return parteclienteoutras;
    }

    public ParteClienteOutrasResponseAll? ReadAll(DBParteClienteOutras dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var parteclienteoutras = new ParteClienteOutrasResponseAll
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            Processo = dbRec.FProcesso,
            PrimeiraReclamada = dbRec.FPrimeiraReclamada,
        };
        parteclienteoutras.NomeOutrasPartesCliente = dr["opcNome"]?.ToString() ?? string.Empty;
        parteclienteoutras.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return parteclienteoutras;
    }
}