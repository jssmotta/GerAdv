#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IUltimosProcessosReader
{
    UltimosProcessosResponse? Read(int id, SqlConnection oCnn);
    UltimosProcessosResponse? Read(string where, SqlConnection oCnn);
    UltimosProcessosResponse? Read(Entity.DBUltimosProcessos dbRec);
    UltimosProcessosResponse? Read(DBUltimosProcessos dbRec);
}

public partial class UltimosProcessos : IUltimosProcessosReader
{
    public UltimosProcessosResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBUltimosProcessos(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public UltimosProcessosResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBUltimosProcessos(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public UltimosProcessosResponse? Read(Entity.DBUltimosProcessos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var ultimosprocessos = new UltimosProcessosResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Quem = dbRec.FQuem,
        };
        if (DateTime.TryParse(dbRec.FQuando, out _))
            ultimosprocessos.Quando = dbRec.FQuando;
        return ultimosprocessos;
    }

    public UltimosProcessosResponse? Read(DBUltimosProcessos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var ultimosprocessos = new UltimosProcessosResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Quem = dbRec.FQuem,
        };
        if (DateTime.TryParse(dbRec.FQuando, out _))
            ultimosprocessos.Quando = dbRec.FQuando;
        return ultimosprocessos;
    }
}