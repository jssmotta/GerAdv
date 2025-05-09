﻿namespace MenphisSI.GerAdv.Interface;
public partial interface IDBHistorico
{
    public int ID { get; set; }
    public int FExtraID { get; set; }
    public int FIDNE { get; set; }
    public string? FExtraGUID { get; set; }
    public int FLiminarOrigem { get; set; }
    public bool FNaoPublicavel { get; set; }
    public int FProcesso { get; set; }
    public int FPrecatoria { get; set; }
    public int FApenso { get; set; }
    public int FIDInstProcesso { get; set; }
    public int FFase { get; set; }
    public string? FData { get; set; }
    public string? FObservacao { get; set; }
    public bool FAgendado { get; set; }
    public bool FConcluido { get; set; }
    public bool FMesmaAgenda { get; set; }
    public int FSAD { get; set; }
    public bool FResumido { get; set; }
    public int FStatusAndamento { get; set; }
    public bool FTop { get; set; }
    public string? FGUID { get; set; }
}