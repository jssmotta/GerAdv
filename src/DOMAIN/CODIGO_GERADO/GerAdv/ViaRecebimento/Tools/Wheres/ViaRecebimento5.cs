#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IViaRecebimentoWhere
{
    ViaRecebimentoResponse Read(string where, SqlConnection oCnn);
}

public partial class ViaRecebimento : IViaRecebimentoWhere
{
    public ViaRecebimentoResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBViaRecebimento(sqlWhere: where, oCnn: oCnn);
        var viarecebimento = new ViaRecebimentoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return viarecebimento;
    }
}