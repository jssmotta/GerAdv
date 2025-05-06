#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IInstanciaWhere
{
    InstanciaResponse Read(string where, SqlConnection oCnn);
}

public partial class Instancia : IInstanciaWhere
{
    public InstanciaResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBInstancia(sqlWhere: where, oCnn: oCnn);
        var instancia = new InstanciaResponse
        {
            Id = dbRec.ID,
            LiminarPedida = dbRec.FLiminarPedida ?? string.Empty,
            Objeto = dbRec.FObjeto ?? string.Empty,
            StatusResultado = dbRec.FStatusResultado,
            LiminarPendente = dbRec.FLiminarPendente,
            InterpusemosRecurso = dbRec.FInterpusemosRecurso,
            LiminarConcedida = dbRec.FLiminarConcedida,
            LiminarNegada = dbRec.FLiminarNegada,
            Processo = dbRec.FProcesso,
            LiminarParcial = dbRec.FLiminarParcial,
            LiminarResultado = dbRec.FLiminarResultado ?? string.Empty,
            NroProcesso = dbRec.FNroProcesso ?? string.Empty,
            Divisao = dbRec.FDivisao,
            LiminarCliente = dbRec.FLiminarCliente,
            Comarca = dbRec.FComarca,
            SubDivisao = dbRec.FSubDivisao,
            Principal = dbRec.FPrincipal,
            Acao = dbRec.FAcao,
            Foro = dbRec.FForo,
            TipoRecurso = dbRec.FTipoRecurso,
            ZKey = dbRec.FZKey ?? string.Empty,
            ZKeyQuem = dbRec.FZKeyQuem,
            NroAntigo = dbRec.FNroAntigo ?? string.Empty,
            AccessCode = dbRec.FAccessCode ?? string.Empty,
            Julgador = dbRec.FJulgador,
            ZKeyIA = dbRec.FZKeyIA ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            instancia.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FZKeyQuando, out _))
            instancia.ZKeyQuando = dbRec.FZKeyQuando;
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
        instancia.Auditor = auditor;
        return instancia;
    }
}