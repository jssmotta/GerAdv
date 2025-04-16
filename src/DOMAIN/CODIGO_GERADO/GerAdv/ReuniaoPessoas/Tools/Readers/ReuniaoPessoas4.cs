#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IReuniaoPessoasReader
{
    ReuniaoPessoasResponse? Read(int id, SqlConnection oCnn);
    ReuniaoPessoasResponse? Read(string where, SqlConnection oCnn);
    ReuniaoPessoasResponse? Read(Entity.DBReuniaoPessoas dbRec);
    ReuniaoPessoasResponse? Read(DBReuniaoPessoas dbRec);
}

public partial class ReuniaoPessoas : IReuniaoPessoasReader
{
    public ReuniaoPessoasResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBReuniaoPessoas(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ReuniaoPessoasResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBReuniaoPessoas(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ReuniaoPessoasResponse? Read(Entity.DBReuniaoPessoas dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var reuniaopessoas = new ReuniaoPessoasResponse
        {
            Id = dbRec.ID,
            Reuniao = dbRec.FReuniao,
            Operador = dbRec.FOperador,
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
        reuniaopessoas.Auditor = auditor;
        return reuniaopessoas;
    }

    public ReuniaoPessoasResponse? Read(DBReuniaoPessoas dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var reuniaopessoas = new ReuniaoPessoasResponse
        {
            Id = dbRec.ID,
            Reuniao = dbRec.FReuniao,
            Operador = dbRec.FOperador,
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
        reuniaopessoas.Auditor = auditor;
        return reuniaopessoas;
    }
}