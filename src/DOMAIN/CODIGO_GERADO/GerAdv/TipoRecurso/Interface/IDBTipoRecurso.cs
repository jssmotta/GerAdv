﻿namespace MenphisSI.GerAdv.Interface;
public partial interface IDBTipoRecurso
{
    public int ID { get; set; }
    public int FJustica { get; set; }
    public int FArea { get; set; }
    public string? FDescricao { get; set; }
}