﻿namespace MenphisSI.GerAdv.Interface;
public partial interface IDBRito
{
    public int ID { get; set; }
    public string? FDescricao { get; set; }
    public bool FTop { get; set; }
    public bool FBold { get; set; }
}