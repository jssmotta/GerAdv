﻿namespace MenphisSI.GerAdv.Interface;
public partial interface IDBFase
{
    public int ID { get; set; }
    public string? FDescricao { get; set; }
    public int FJustica { get; set; }
    public int FArea { get; set; }
}