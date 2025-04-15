#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOperadoresWhere
{
    OperadoresResponse Read(string where, SqlConnection oCnn);
}

public partial class Operadores : IOperadoresWhere
{
    public OperadoresResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOperadores(sqlWhere: where, oCnn: oCnn);
        var operadores = new OperadoresResponse
        {
            Id = dbRec.ID,
            Enviado = dbRec.FEnviado,
            Casa = dbRec.FCasa,
            CasaID = dbRec.FCasaID,
            CasaCodigo = dbRec.FCasaCodigo,
            IsNovo = dbRec.FIsNovo,
            Cliente = dbRec.FCliente,
            Grupo = dbRec.FGrupo,
            Nome = dbRec.FNome ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Ativado = dbRec.FAtivado,
        };
        if (DateTime.TryParse(dbRec.FSuporteMaxAge, out _))
            operadores.SuporteMaxAge = dbRec.FSuporteMaxAge;
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
        operadores.Auditor = auditor;
        return operadores;
    }
}