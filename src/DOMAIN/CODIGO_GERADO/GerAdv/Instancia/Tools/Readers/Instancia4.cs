#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IInstanciaReader
{
    InstanciaResponse? Read(int id, SqlConnection oCnn);
    InstanciaResponse? Read(string where, SqlConnection oCnn);
    InstanciaResponse? Read(Entity.DBInstancia dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    InstanciaResponse? Read(DBInstancia dbRec);
}

public partial class Instancia : IInstanciaReader
{
    public InstanciaResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBInstancia(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public InstanciaResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBInstancia(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public InstanciaResponse? Read(Entity.DBInstancia dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

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
            Guid = dbRec.FGUID ?? string.Empty,
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

    public InstanciaResponse? Read(DBInstancia dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

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
            Guid = dbRec.FGUID ?? string.Empty,
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