namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBOperadores
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBOperadoresDicInfo.Enviado:
                FEnviado = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBOperadoresDicInfo.Casa:
                FCasa = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBOperadoresDicInfo.CasaID:
                FCasaID = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOperadoresDicInfo.CasaCodigo:
                FCasaCodigo = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOperadoresDicInfo.IsNovo:
                FIsNovo = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBOperadoresDicInfo.Cliente:
                FCliente = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOperadoresDicInfo.Grupo:
                FGrupo = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOperadoresDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBOperadoresDicInfo.EMail:
                FEMail = $"{value}"; // rgo J3: string
                return;
            case DBOperadoresDicInfo.Senha:
                FSenha = $"{value}"; // rgo J3: string
                return;
            case DBOperadoresDicInfo.Ativado:
                FAtivado = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBOperadoresDicInfo.AtualizarSenha:
                FAtualizarSenha = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBOperadoresDicInfo.Senha256:
                FSenha256 = $"{value}"; // rgo J3: string
                return;
            case DBOperadoresDicInfo.SuporteSenha256:
                FSuporteSenha256 = $"{value}"; // rgo J3: string
                return;
            case DBOperadoresDicInfo.SuporteMaxAge:
                FSuporteMaxAge = $"{value}"; // rgo J3: DateTime
                return;
            case DBOperadoresDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOperadoresDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBOperadoresDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOperadoresDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBOperadoresDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBOperadoresDicInfo.Enviado => FEnviado.ToString(),
        DBOperadoresDicInfo.Casa => FCasa.ToString(),
        DBOperadoresDicInfo.CasaID => NFCasaID(),
        DBOperadoresDicInfo.CasaCodigo => NFCasaCodigo(),
        DBOperadoresDicInfo.IsNovo => FIsNovo.ToString(),
        DBOperadoresDicInfo.Cliente => NFCliente(),
        DBOperadoresDicInfo.Grupo => NFGrupo(),
        DBOperadoresDicInfo.Nome => NFNome(),
        DBOperadoresDicInfo.EMail => NFEMail(),
        DBOperadoresDicInfo.Senha => NFSenha(),
        DBOperadoresDicInfo.Ativado => FAtivado.ToString(),
        DBOperadoresDicInfo.AtualizarSenha => FAtualizarSenha.ToString(),
        DBOperadoresDicInfo.Senha256 => NFSenha256(),
        DBOperadoresDicInfo.SuporteSenha256 => NFSuporteSenha256(),
        DBOperadoresDicInfo.SuporteMaxAge => NFSuporteMaxAge(),
        DBOperadoresDicInfo.QuemCad => NFQuemCad(),
        DBOperadoresDicInfo.DtCad => MDtCad,
        DBOperadoresDicInfo.QuemAtu => NFQuemAtu(),
        DBOperadoresDicInfo.DtAtu => MDtAtu,
        DBOperadoresDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}