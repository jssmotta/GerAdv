﻿namespace MenphisSI.GerAdv.Interface;
public partial interface IDBInstancia
{
    public int ID { get; set; }
    public string? FLiminarPedida { get; set; }
    public string? FObjeto { get; set; }
    public int FStatusResultado { get; set; }
    public bool FLiminarPendente { get; set; }
    public bool FInterpusemosRecurso { get; set; }
    public bool FLiminarConcedida { get; set; }
    public bool FLiminarNegada { get; set; }
    public int FProcesso { get; set; }
    public string? FData { get; set; }
    public bool FLiminarParcial { get; set; }
    public string? FLiminarResultado { get; set; }
    public string? FNroProcesso { get; set; }
    public int FDivisao { get; set; }
    public bool FLiminarCliente { get; set; }
    public int FComarca { get; set; }
    public int FSubDivisao { get; set; }
    public bool FPrincipal { get; set; }
    public int FAcao { get; set; }
    public int FForo { get; set; }
    public int FTipoRecurso { get; set; }
    public string? FZKey { get; set; }
    public int FZKeyQuem { get; set; }
    public string? FZKeyQuando { get; set; }
    public string? FNroAntigo { get; set; }
    public string? FAccessCode { get; set; }
    public int FJulgador { get; set; }
    public string? FZKeyIA { get; set; }
    public string? FGUID { get; set; }
}