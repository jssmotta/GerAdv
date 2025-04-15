#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IParteClienteReader
{
    ParteClienteResponse? Read(string where, SqlConnection oCnn);
    ParteClienteResponse? Read(Entity.DBParteCliente dbRec);
    ParteClienteResponse? Read(DBParteCliente dbRec);
}

public partial class ParteCliente : IParteClienteReader
{
    public ParteClienteResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBParteCliente(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ParteClienteResponse? Read(Entity.DBParteCliente dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var partecliente = new ParteClienteResponse
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            Processo = dbRec.FProcesso,
        };
        return partecliente;
    }

    public ParteClienteResponse? Read(DBParteCliente dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var partecliente = new ParteClienteResponse
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            Processo = dbRec.FProcesso,
        };
        return partecliente;
    }
}