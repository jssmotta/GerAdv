#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IContatoCRMOperadorReader
{
    ContatoCRMOperadorResponse? Read(int id, SqlConnection oCnn);
    ContatoCRMOperadorResponse? Read(string where, SqlConnection oCnn);
    ContatoCRMOperadorResponse? Read(Entity.DBContatoCRMOperador dbRec);
    ContatoCRMOperadorResponse? Read(DBContatoCRMOperador dbRec);
}

public partial class ContatoCRMOperador : IContatoCRMOperadorReader
{
    public ContatoCRMOperadorResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBContatoCRMOperador(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ContatoCRMOperadorResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBContatoCRMOperador(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ContatoCRMOperadorResponse? Read(Entity.DBContatoCRMOperador dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var contatocrmoperador = new ContatoCRMOperadorResponse
        {
            Id = dbRec.ID,
            ContatoCRM = dbRec.FContatoCRM,
            CargoEsc = dbRec.FCargoEsc,
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
        contatocrmoperador.Auditor = auditor;
        return contatocrmoperador;
    }

    public ContatoCRMOperadorResponse? Read(DBContatoCRMOperador dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var contatocrmoperador = new ContatoCRMOperadorResponse
        {
            Id = dbRec.ID,
            ContatoCRM = dbRec.FContatoCRM,
            CargoEsc = dbRec.FCargoEsc,
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
        contatocrmoperador.Auditor = auditor;
        return contatocrmoperador;
    }
}