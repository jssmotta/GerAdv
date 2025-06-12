#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IEndTitReader
{
    EndTitResponse? Read(int id, MsiSqlConnection oCnn);
    EndTitResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    EndTitResponse? Read(Entity.DBEndTit dbRec);
    EndTitResponse? Read(DBEndTit dbRec);
    EndTitResponseAll? ReadAll(DBEndTit dbRec, DataRow dr);
}

public partial class EndTit : IEndTitReader
{
    public EndTitResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBEndTit(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public EndTitResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBEndTit(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public EndTitResponse? Read(Entity.DBEndTit dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var endtit = new EndTitResponse
        {
            Id = dbRec.ID,
            Endereco = dbRec.FEndereco,
            Titulo = dbRec.FTitulo,
        };
        return endtit;
    }

    public EndTitResponse? Read(DBEndTit dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var endtit = new EndTitResponse
        {
            Id = dbRec.ID,
            Endereco = dbRec.FEndereco,
            Titulo = dbRec.FTitulo,
        };
        return endtit;
    }

    public EndTitResponseAll? ReadAll(DBEndTit dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var endtit = new EndTitResponseAll
        {
            Id = dbRec.ID,
            Endereco = dbRec.FEndereco,
            Titulo = dbRec.FTitulo,
        };
        return endtit;
    }
}