namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBFuncionarios
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBFuncionariosDicInfo.EMailPro:
                FEMailPro = $"{value}"; // rgo J3: string
                return;
            case DBFuncionariosDicInfo.Cargo:
                FCargo = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBFuncionariosDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBFuncionariosDicInfo.Funcao:
                FFuncao = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBFuncionariosDicInfo.Sexo:
                FSexo = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBFuncionariosDicInfo.Registro:
                FRegistro = $"{value}"; // rgo J3: string
                return;
            case DBFuncionariosDicInfo.CPF:
                FCPF = $"{value}"; // rgo J3: string
                return;
            case DBFuncionariosDicInfo.RG:
                FRG = $"{value}"; // rgo J3: string
                return;
            case DBFuncionariosDicInfo.Tipo:
                FTipo = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBFuncionariosDicInfo.Observacao:
                FObservacao = $"{value}"; // rgo J3: string
                return;
            case DBFuncionariosDicInfo.Endereco:
                FEndereco = $"{value}"; // rgo J3: string
                return;
            case DBFuncionariosDicInfo.Bairro:
                FBairro = $"{value}"; // rgo J3: string
                return;
            case DBFuncionariosDicInfo.Cidade:
                FCidade = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBFuncionariosDicInfo.CEP:
                FCEP = $"{value}"; // rgo J3: string
                return;
            case DBFuncionariosDicInfo.Contato:
                FContato = $"{value}"; // rgo J3: string
                return;
            case DBFuncionariosDicInfo.Fax:
                FFax = $"{value}"; // rgo J3: string
                return;
            case DBFuncionariosDicInfo.Fone:
                FFone = $"{value}"; // rgo J3: string
                return;
            case DBFuncionariosDicInfo.EMail:
                FEMail = $"{value}"; // rgo J3: string
                return;
            case DBFuncionariosDicInfo.Periodo_Ini:
                FPeriodo_Ini = $"{value}"; // rgo J3: DateTime
                return;
            case DBFuncionariosDicInfo.Periodo_Fim:
                FPeriodo_Fim = $"{value}"; // rgo J3: DateTime
                return;
            case DBFuncionariosDicInfo.CTPSNumero:
                FCTPSNumero = $"{value}"; // rgo J3: string
                return;
            case DBFuncionariosDicInfo.CTPSSerie:
                FCTPSSerie = $"{value}"; // rgo J3: string
                return;
            case DBFuncionariosDicInfo.PIS:
                FPIS = $"{value}"; // rgo J3: string
                return;
            case DBFuncionariosDicInfo.Salario:
                FSalario = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBFuncionariosDicInfo.CTPSDtEmissao:
                FCTPSDtEmissao = $"{value}"; // rgo J3: DateTime
                return;
            case DBFuncionariosDicInfo.DtNasc:
                FDtNasc = $"{value}"; // rgo J3: DateTime
                return;
            case DBFuncionariosDicInfo.Data:
                FData = $"{value}"; // rgo J3: DateTime
                return;
            case DBFuncionariosDicInfo.LiberaAgenda:
                FLiberaAgenda = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBFuncionariosDicInfo.Pasta:
                FPasta = $"{value}"; // rgo J3: string
                return;
            case DBFuncionariosDicInfo.Class:
                FClass = $"{value}"; // rgo J3: string
                return;
            case DBFuncionariosDicInfo.Etiqueta:
                FEtiqueta = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBFuncionariosDicInfo.Ani:
                FAni = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBFuncionariosDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBFuncionariosDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBFuncionariosDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBFuncionariosDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBFuncionariosDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBFuncionariosDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBFuncionariosDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBFuncionariosDicInfo.EMailPro => NFEMailPro(),
        DBFuncionariosDicInfo.Cargo => NFCargo(),
        DBFuncionariosDicInfo.Nome => NFNome(),
        DBFuncionariosDicInfo.Funcao => NFFuncao(),
        DBFuncionariosDicInfo.Sexo => FSexo.ToString(),
        DBFuncionariosDicInfo.Registro => NFRegistro(),
        DBFuncionariosDicInfo.CPF => NFCPF(),
        DBFuncionariosDicInfo.RG => NFRG(),
        DBFuncionariosDicInfo.Tipo => FTipo.ToString(),
        DBFuncionariosDicInfo.Observacao => NFObservacao(),
        DBFuncionariosDicInfo.Endereco => NFEndereco(),
        DBFuncionariosDicInfo.Bairro => NFBairro(),
        DBFuncionariosDicInfo.Cidade => NFCidade(),
        DBFuncionariosDicInfo.CEP => NFCEP(),
        DBFuncionariosDicInfo.Contato => NFContato(),
        DBFuncionariosDicInfo.Fax => NFFax(),
        DBFuncionariosDicInfo.Fone => NFFone(),
        DBFuncionariosDicInfo.EMail => NFEMail(),
        DBFuncionariosDicInfo.Periodo_Ini => NFPeriodo_Ini(),
        DBFuncionariosDicInfo.Periodo_Fim => NFPeriodo_Fim(),
        DBFuncionariosDicInfo.CTPSNumero => NFCTPSNumero(),
        DBFuncionariosDicInfo.CTPSSerie => NFCTPSSerie(),
        DBFuncionariosDicInfo.PIS => NFPIS(),
        DBFuncionariosDicInfo.Salario => NFSalario(),
        DBFuncionariosDicInfo.CTPSDtEmissao => NFCTPSDtEmissao(),
        DBFuncionariosDicInfo.DtNasc => NFDtNasc(),
        DBFuncionariosDicInfo.Data => NFData(),
        DBFuncionariosDicInfo.LiberaAgenda => FLiberaAgenda.ToString(),
        DBFuncionariosDicInfo.Pasta => NFPasta(),
        DBFuncionariosDicInfo.Class => NFClass(),
        DBFuncionariosDicInfo.Etiqueta => FEtiqueta.ToString(),
        DBFuncionariosDicInfo.Ani => FAni.ToString(),
        DBFuncionariosDicInfo.Bold => FBold.ToString(),
        DBFuncionariosDicInfo.GUID => NFGUID(),
        DBFuncionariosDicInfo.QuemCad => NFQuemCad(),
        DBFuncionariosDicInfo.DtCad => MDtCad,
        DBFuncionariosDicInfo.QuemAtu => NFQuemAtu(),
        DBFuncionariosDicInfo.DtAtu => MDtAtu,
        DBFuncionariosDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}