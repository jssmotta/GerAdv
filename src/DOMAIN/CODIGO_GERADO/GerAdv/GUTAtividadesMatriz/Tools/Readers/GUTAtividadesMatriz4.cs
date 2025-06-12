#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTAtividadesMatrizReader
{
    GUTAtividadesMatrizResponse? Read(int id, MsiSqlConnection oCnn);
    GUTAtividadesMatrizResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    GUTAtividadesMatrizResponse? Read(Entity.DBGUTAtividadesMatriz dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    GUTAtividadesMatrizResponse? Read(DBGUTAtividadesMatriz dbRec);
    GUTAtividadesMatrizResponseAll? ReadAll(DBGUTAtividadesMatriz dbRec, DataRow dr);
}

public partial class GUTAtividadesMatriz : IGUTAtividadesMatrizReader
{
    public GUTAtividadesMatrizResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGUTAtividadesMatriz(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GUTAtividadesMatrizResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGUTAtividadesMatriz(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GUTAtividadesMatrizResponse? Read(Entity.DBGUTAtividadesMatriz dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutatividadesmatriz = new GUTAtividadesMatrizResponse
        {
            Id = dbRec.ID,
            GUTMatriz = dbRec.FGUTMatriz,
            GUTAtividade = dbRec.FGUTAtividade,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return gutatividadesmatriz;
    }

    public GUTAtividadesMatrizResponse? Read(DBGUTAtividadesMatriz dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutatividadesmatriz = new GUTAtividadesMatrizResponse
        {
            Id = dbRec.ID,
            GUTMatriz = dbRec.FGUTMatriz,
            GUTAtividade = dbRec.FGUTAtividade,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return gutatividadesmatriz;
    }

    public GUTAtividadesMatrizResponseAll? ReadAll(DBGUTAtividadesMatriz dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutatividadesmatriz = new GUTAtividadesMatrizResponseAll
        {
            Id = dbRec.ID,
            GUTMatriz = dbRec.FGUTMatriz,
            GUTAtividade = dbRec.FGUTAtividade,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        gutatividadesmatriz.DescricaoGUTMatriz = dr["gutDescricao"]?.ToString() ?? string.Empty;
        gutatividadesmatriz.NomeGUTAtividades = dr["agtNome"]?.ToString() ?? string.Empty;
        return gutatividadesmatriz;
    }
}