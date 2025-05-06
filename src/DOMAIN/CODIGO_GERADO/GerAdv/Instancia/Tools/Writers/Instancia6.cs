#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IInstanciaWriter
{
    Entity.DBInstancia Write(Models.Instancia instancia, int auditorQuem, SqlConnection oCnn);
}

public class Instancia : IInstanciaWriter
{
    public Entity.DBInstancia Write(Models.Instancia instancia, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = instancia.Id.IsEmptyIDNumber() ? new Entity.DBInstancia() : new Entity.DBInstancia(instancia.Id, oCnn);
        dbRec.FLiminarPedida = instancia.LiminarPedida;
        dbRec.FObjeto = instancia.Objeto;
        dbRec.FStatusResultado = instancia.StatusResultado;
        dbRec.FLiminarPendente = instancia.LiminarPendente;
        dbRec.FInterpusemosRecurso = instancia.InterpusemosRecurso;
        dbRec.FLiminarConcedida = instancia.LiminarConcedida;
        dbRec.FLiminarNegada = instancia.LiminarNegada;
        dbRec.FProcesso = instancia.Processo;
        if (instancia.Data != null)
            dbRec.FData = instancia.Data.ToString();
        dbRec.FLiminarParcial = instancia.LiminarParcial;
        dbRec.FLiminarResultado = instancia.LiminarResultado;
        dbRec.FNroProcesso = instancia.NroProcesso;
        dbRec.FDivisao = instancia.Divisao;
        dbRec.FLiminarCliente = instancia.LiminarCliente;
        dbRec.FComarca = instancia.Comarca;
        dbRec.FSubDivisao = instancia.SubDivisao;
        dbRec.FPrincipal = instancia.Principal;
        dbRec.FAcao = instancia.Acao;
        dbRec.FForo = instancia.Foro;
        dbRec.FTipoRecurso = instancia.TipoRecurso;
        dbRec.FZKey = instancia.ZKey;
        dbRec.FZKeyQuem = instancia.ZKeyQuem;
        if (instancia.ZKeyQuando != null)
            dbRec.FZKeyQuando = instancia.ZKeyQuando.ToString();
        dbRec.FNroAntigo = instancia.NroAntigo;
        dbRec.FAccessCode = instancia.AccessCode;
        dbRec.FJulgador = instancia.Julgador;
        dbRec.FZKeyIA = instancia.ZKeyIA;
        dbRec.FGUID = instancia.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}