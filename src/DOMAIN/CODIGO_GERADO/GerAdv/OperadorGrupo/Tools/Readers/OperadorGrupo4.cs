#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOperadorGrupoReader
{
    OperadorGrupoResponse? Read(int id, SqlConnection oCnn);
    OperadorGrupoResponse? Read(string where, SqlConnection oCnn);
    OperadorGrupoResponse? Read(Entity.DBOperadorGrupo dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    OperadorGrupoResponse? Read(DBOperadorGrupo dbRec);
}

public partial class OperadorGrupo : IOperadorGrupoReader
{
    public OperadorGrupoResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOperadorGrupo(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OperadorGrupoResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOperadorGrupo(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OperadorGrupoResponse? Read(Entity.DBOperadorGrupo dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadorgrupo = new OperadorGrupoResponse
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Grupo = dbRec.FGrupo,
            Inativo = dbRec.FInativo,
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
        operadorgrupo.Auditor = auditor;
        return operadorgrupo;
    }

    public OperadorGrupoResponse? Read(DBOperadorGrupo dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadorgrupo = new OperadorGrupoResponse
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Grupo = dbRec.FGrupo,
            Inativo = dbRec.FInativo,
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
        operadorgrupo.Auditor = auditor;
        return operadorgrupo;
    }
}