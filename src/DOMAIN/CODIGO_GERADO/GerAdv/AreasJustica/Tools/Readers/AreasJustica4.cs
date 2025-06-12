#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAreasJusticaReader
{
    AreasJusticaResponse? Read(int id, MsiSqlConnection oCnn);
    AreasJusticaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AreasJusticaResponse? Read(Entity.DBAreasJustica dbRec);
    AreasJusticaResponse? Read(DBAreasJustica dbRec);
    AreasJusticaResponseAll? ReadAll(DBAreasJustica dbRec, DataRow dr);
}

public partial class AreasJustica : IAreasJusticaReader
{
    public AreasJusticaResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAreasJustica(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AreasJusticaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAreasJustica(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AreasJusticaResponse? Read(Entity.DBAreasJustica dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var areasjustica = new AreasJusticaResponse
        {
            Id = dbRec.ID,
            Area = dbRec.FArea,
            Justica = dbRec.FJustica,
        };
        return areasjustica;
    }

    public AreasJusticaResponse? Read(DBAreasJustica dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var areasjustica = new AreasJusticaResponse
        {
            Id = dbRec.ID,
            Area = dbRec.FArea,
            Justica = dbRec.FJustica,
        };
        return areasjustica;
    }

    public AreasJusticaResponseAll? ReadAll(DBAreasJustica dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var areasjustica = new AreasJusticaResponseAll
        {
            Id = dbRec.ID,
            Area = dbRec.FArea,
            Justica = dbRec.FJustica,
        };
        areasjustica.DescricaoArea = dr["areDescricao"]?.ToString() ?? string.Empty;
        areasjustica.NomeJustica = dr["jusNome"]?.ToString() ?? string.Empty;
        return areasjustica;
    }
}