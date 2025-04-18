#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IFuncaoReader
{
    FuncaoResponse? Read(int id, SqlConnection oCnn);
    FuncaoResponse? Read(string where, SqlConnection oCnn);
    FuncaoResponse? Read(Entity.DBFuncao dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    FuncaoResponse? Read(DBFuncao dbRec);
}

public partial class Funcao : IFuncaoReader
{
    public FuncaoResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBFuncao(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public FuncaoResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBFuncao(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public FuncaoResponse? Read(Entity.DBFuncao dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var funcao = new FuncaoResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
        };
        var auditor = new Auditor
        {
            Visto = dbRec.FVisto,
            QuemCad = dbRec.FQuemCad
        };
        if (auditor.QuemAtu > 0)
            auditor.QuemAtu = dbRec.FQuemAtu;
        if (dbRec.FDtCad.NotIsEmpty())
            auditor.DtCad = Convert.ToDateTime(dbRec.FDtCad);
        if (!(dbRec.FDtAtu is { }))
            auditor.DtAtu = Convert.ToDateTime(dbRec.FDtAtu);
        funcao.Auditor = auditor;
        return funcao;
    }

    public FuncaoResponse? Read(DBFuncao dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var funcao = new FuncaoResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
        };
        var auditor = new Auditor
        {
            Visto = dbRec.FVisto,
            QuemCad = dbRec.FQuemCad
        };
        if (auditor.QuemAtu > 0)
            auditor.QuemAtu = dbRec.FQuemAtu;
        if (dbRec.FDtCad.NotIsEmpty())
            auditor.DtCad = Convert.ToDateTime(dbRec.FDtCad);
        if (!(dbRec.FDtAtu is { }))
            auditor.DtAtu = Convert.ToDateTime(dbRec.FDtAtu);
        funcao.Auditor = auditor;
        return funcao;
    }
}