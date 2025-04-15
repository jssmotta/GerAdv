#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IParteOponenteReader
{
    ParteOponenteResponse? Read(string where, SqlConnection oCnn);
    ParteOponenteResponse? Read(Entity.DBParteOponente dbRec);
    ParteOponenteResponse? Read(DBParteOponente dbRec);
}

public partial class ParteOponente : IParteOponenteReader
{
    public ParteOponenteResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBParteOponente(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ParteOponenteResponse? Read(Entity.DBParteOponente dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var parteoponente = new ParteOponenteResponse
        {
            Id = dbRec.ID,
            Oponente = dbRec.FOponente,
            Processo = dbRec.FProcesso,
        };
        return parteoponente;
    }

    public ParteOponenteResponse? Read(DBParteOponente dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var parteoponente = new ParteOponenteResponse
        {
            Id = dbRec.ID,
            Oponente = dbRec.FOponente,
            Processo = dbRec.FProcesso,
        };
        return parteoponente;
    }
}