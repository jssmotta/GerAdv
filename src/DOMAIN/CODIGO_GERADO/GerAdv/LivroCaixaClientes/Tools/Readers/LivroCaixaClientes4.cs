#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ILivroCaixaClientesReader
{
    LivroCaixaClientesResponse? Read(int id, SqlConnection oCnn);
    LivroCaixaClientesResponse? Read(string where, SqlConnection oCnn);
    LivroCaixaClientesResponse? Read(Entity.DBLivroCaixaClientes dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    LivroCaixaClientesResponse? Read(DBLivroCaixaClientes dbRec);
}

public partial class LivroCaixaClientes : ILivroCaixaClientesReader
{
    public LivroCaixaClientesResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBLivroCaixaClientes(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public LivroCaixaClientesResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBLivroCaixaClientes(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public LivroCaixaClientesResponse? Read(Entity.DBLivroCaixaClientes dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var livrocaixaclientes = new LivroCaixaClientesResponse
        {
            Id = dbRec.ID,
            LivroCaixa = dbRec.FLivroCaixa,
            Cliente = dbRec.FCliente,
            Lancado = dbRec.FLancado,
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
        livrocaixaclientes.Auditor = auditor;
        return livrocaixaclientes;
    }

    public LivroCaixaClientesResponse? Read(DBLivroCaixaClientes dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var livrocaixaclientes = new LivroCaixaClientesResponse
        {
            Id = dbRec.ID,
            LivroCaixa = dbRec.FLivroCaixa,
            Cliente = dbRec.FCliente,
            Lancado = dbRec.FLancado,
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
        livrocaixaclientes.Auditor = auditor;
        return livrocaixaclientes;
    }
}