﻿namespace MenphisSI.GerAdv.Interface;
public partial interface IDBSituacao
{
    public int ID { get; set; }
    public string? FParte_Int { get; set; }
    public string? FParte_Opo { get; set; }
    public bool FTop { get; set; }
    public bool FBold { get; set; }
}