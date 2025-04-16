namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBPrepostos
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBPrepostosDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBPrepostosDicInfo.Funcao:
                FFuncao = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBPrepostosDicInfo.Setor:
                FSetor = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBPrepostosDicInfo.DtNasc:
                FDtNasc = $"{value}"; // rgo J3: DateTime
                return;
            case DBPrepostosDicInfo.Qualificacao:
                FQualificacao = $"{value}"; // rgo J3: string
                return;
            case DBPrepostosDicInfo.Sexo:
                FSexo = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBPrepostosDicInfo.Idade:
                FIdade = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBPrepostosDicInfo.CPF:
                FCPF = $"{value}"; // rgo J3: string
                return;
            case DBPrepostosDicInfo.RG:
                FRG = $"{value}"; // rgo J3: string
                return;
            case DBPrepostosDicInfo.Periodo_Ini:
                FPeriodo_Ini = $"{value}"; // rgo J3: DateTime
                return;
            case DBPrepostosDicInfo.Periodo_Fim:
                FPeriodo_Fim = $"{value}"; // rgo J3: DateTime
                return;
            case DBPrepostosDicInfo.Registro:
                FRegistro = $"{value}"; // rgo J3: string
                return;
            case DBPrepostosDicInfo.CTPSNumero:
                FCTPSNumero = $"{value}"; // rgo J3: string
                return;
            case DBPrepostosDicInfo.CTPSSerie:
                FCTPSSerie = $"{value}"; // rgo J3: string
                return;
            case DBPrepostosDicInfo.CTPSDtEmissao:
                FCTPSDtEmissao = $"{value}"; // rgo J3: DateTime
                return;
            case DBPrepostosDicInfo.PIS:
                FPIS = $"{value}"; // rgo J3: string
                return;
            case DBPrepostosDicInfo.Salario:
                FSalario = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBPrepostosDicInfo.LiberaAgenda:
                FLiberaAgenda = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBPrepostosDicInfo.Observacao:
                FObservacao = $"{value}"; // rgo J3: string
                return;
            case DBPrepostosDicInfo.Endereco:
                FEndereco = $"{value}"; // rgo J3: string
                return;
            case DBPrepostosDicInfo.Bairro:
                FBairro = $"{value}"; // rgo J3: string
                return;
            case DBPrepostosDicInfo.Cidade:
                FCidade = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBPrepostosDicInfo.CEP:
                FCEP = $"{value}"; // rgo J3: string
                return;
            case DBPrepostosDicInfo.Fone:
                FFone = $"{value}"; // rgo J3: string
                return;
            case DBPrepostosDicInfo.Fax:
                FFax = $"{value}"; // rgo J3: string
                return;
            case DBPrepostosDicInfo.EMail:
                FEMail = $"{value}"; // rgo J3: string
                return;
            case DBPrepostosDicInfo.Pai:
                FPai = $"{value}"; // rgo J3: string
                return;
            case DBPrepostosDicInfo.Mae:
                FMae = $"{value}"; // rgo J3: string
                return;
            case DBPrepostosDicInfo.Class:
                FClass = $"{value}"; // rgo J3: string
                return;
            case DBPrepostosDicInfo.Etiqueta:
                FEtiqueta = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBPrepostosDicInfo.Ani:
                FAni = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBPrepostosDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBPrepostosDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBPrepostosDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBPrepostosDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBPrepostosDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBPrepostosDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBPrepostosDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBPrepostosDicInfo.Nome => NFNome(),
        DBPrepostosDicInfo.Funcao => NFFuncao(),
        DBPrepostosDicInfo.Setor => NFSetor(),
        DBPrepostosDicInfo.DtNasc => NFDtNasc(),
        DBPrepostosDicInfo.Qualificacao => NFQualificacao(),
        DBPrepostosDicInfo.Sexo => FSexo.ToString(),
        DBPrepostosDicInfo.Idade => NFIdade(),
        DBPrepostosDicInfo.CPF => NFCPF(),
        DBPrepostosDicInfo.RG => NFRG(),
        DBPrepostosDicInfo.Periodo_Ini => NFPeriodo_Ini(),
        DBPrepostosDicInfo.Periodo_Fim => NFPeriodo_Fim(),
        DBPrepostosDicInfo.Registro => NFRegistro(),
        DBPrepostosDicInfo.CTPSNumero => NFCTPSNumero(),
        DBPrepostosDicInfo.CTPSSerie => NFCTPSSerie(),
        DBPrepostosDicInfo.CTPSDtEmissao => NFCTPSDtEmissao(),
        DBPrepostosDicInfo.PIS => NFPIS(),
        DBPrepostosDicInfo.Salario => NFSalario(),
        DBPrepostosDicInfo.LiberaAgenda => FLiberaAgenda.ToString(),
        DBPrepostosDicInfo.Observacao => NFObservacao(),
        DBPrepostosDicInfo.Endereco => NFEndereco(),
        DBPrepostosDicInfo.Bairro => NFBairro(),
        DBPrepostosDicInfo.Cidade => NFCidade(),
        DBPrepostosDicInfo.CEP => NFCEP(),
        DBPrepostosDicInfo.Fone => NFFone(),
        DBPrepostosDicInfo.Fax => NFFax(),
        DBPrepostosDicInfo.EMail => NFEMail(),
        DBPrepostosDicInfo.Pai => NFPai(),
        DBPrepostosDicInfo.Mae => NFMae(),
        DBPrepostosDicInfo.Class => NFClass(),
        DBPrepostosDicInfo.Etiqueta => FEtiqueta.ToString(),
        DBPrepostosDicInfo.Ani => FAni.ToString(),
        DBPrepostosDicInfo.Bold => FBold.ToString(),
        DBPrepostosDicInfo.GUID => NFGUID(),
        DBPrepostosDicInfo.QuemCad => NFQuemCad(),
        DBPrepostosDicInfo.DtCad => MDtCad,
        DBPrepostosDicInfo.QuemAtu => NFQuemAtu(),
        DBPrepostosDicInfo.DtAtu => MDtAtu,
        DBPrepostosDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}