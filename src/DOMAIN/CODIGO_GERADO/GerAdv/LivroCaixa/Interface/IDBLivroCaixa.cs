﻿namespace MenphisSI.GerAdv.Interface;
public partial interface IDBLivroCaixa
{
    public int ID { get; set; }
    public int FIDDes { get; set; }
    public int FPessoal { get; set; }
    public bool FAjuste { get; set; }
    public int FIDHon { get; set; }
    public int FIDHonParc { get; set; }
    public bool FIDHonSuc { get; set; }
    public string? FData { get; set; }
    public int FProcesso { get; set; }
    public decimal FValor { get; set; }
    public bool FTipo { get; set; }
    public string? FHistorico { get; set; }
    public int FGrupo { get; set; }
}