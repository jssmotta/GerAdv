﻿namespace MenphisSI.GerAdv.Interface;
public partial interface IDBOperadores
{
    public int ID { get; set; }
    public bool FEnviado { get; set; }
    public bool FCasa { get; set; }
    public int FCasaID { get; set; }
    public int FCasaCodigo { get; set; }
    public bool FIsNovo { get; set; }
    public int FCliente { get; set; }
    public int FGrupo { get; set; }
    public string? FNome { get; set; }
    public string? FEMail { get; set; }
    public string? FSenha { get; set; }
    public bool FAtivado { get; set; }
    public bool FAtualizarSenha { get; set; }
    public string? FSenha256 { get; set; }
    public string? FSuporteSenha256 { get; set; }
    public string? FSuporteMaxAge { get; set; }
}