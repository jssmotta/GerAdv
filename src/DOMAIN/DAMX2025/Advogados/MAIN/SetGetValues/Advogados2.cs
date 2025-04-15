namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAdvogados
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBAdvogadosDicInfo.Cargo:
                FCargo = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAdvogadosDicInfo.EMailPro:
                FEMailPro = $"{value}"; // rgo J3: string
                return;
            case DBAdvogadosDicInfo.CPF:
                FCPF = $"{value}"; // rgo J3: string
                return;
            case DBAdvogadosDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBAdvogadosDicInfo.RG:
                FRG = $"{value}"; // rgo J3: string
                return;
            case DBAdvogadosDicInfo.Casa:
                FCasa = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAdvogadosDicInfo.NomeMae:
                FNomeMae = $"{value}"; // rgo J3: string
                return;
            case DBAdvogadosDicInfo.Escritorio:
                FEscritorio = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAdvogadosDicInfo.Estagiario:
                FEstagiario = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAdvogadosDicInfo.OAB:
                FOAB = $"{value}"; // rgo J3: string
                return;
            case DBAdvogadosDicInfo.NomeCompleto:
                FNomeCompleto = $"{value}"; // rgo J3: string
                return;
            case DBAdvogadosDicInfo.Endereco:
                FEndereco = $"{value}"; // rgo J3: string
                return;
            case DBAdvogadosDicInfo.Cidade:
                FCidade = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAdvogadosDicInfo.CEP:
                FCEP = $"{value}"; // rgo J3: string
                return;
            case DBAdvogadosDicInfo.Sexo:
                FSexo = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAdvogadosDicInfo.Bairro:
                FBairro = $"{value}"; // rgo J3: string
                return;
            case DBAdvogadosDicInfo.CTPSSerie:
                FCTPSSerie = $"{value}"; // rgo J3: string
                return;
            case DBAdvogadosDicInfo.CTPS:
                FCTPS = $"{value}"; // rgo J3: string
                return;
            case DBAdvogadosDicInfo.Fone:
                FFone = $"{value}"; // rgo J3: string
                return;
            case DBAdvogadosDicInfo.Fax:
                FFax = $"{value}"; // rgo J3: string
                return;
            case DBAdvogadosDicInfo.Comissao:
                FComissao = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAdvogadosDicInfo.DtInicio:
                FDtInicio = $"{value}"; // rgo J3: DateTime
                return;
            case DBAdvogadosDicInfo.DtFim:
                FDtFim = $"{value}"; // rgo J3: DateTime
                return;
            case DBAdvogadosDicInfo.DtNasc:
                FDtNasc = $"{value}"; // rgo J3: DateTime
                return;
            case DBAdvogadosDicInfo.Salario:
                FSalario = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBAdvogadosDicInfo.Secretaria:
                FSecretaria = $"{value}"; // rgo J3: string
                return;
            case DBAdvogadosDicInfo.TextoProcuracao:
                FTextoProcuracao = $"{value}"; // rgo J3: string
                return;
            case DBAdvogadosDicInfo.EMail:
                FEMail = $"{value}"; // rgo J3: string
                return;
            case DBAdvogadosDicInfo.Especializacao:
                FEspecializacao = $"{value}"; // rgo J3: string
                return;
            case DBAdvogadosDicInfo.Pasta:
                FPasta = $"{value}"; // rgo J3: string
                return;
            case DBAdvogadosDicInfo.Observacao:
                FObservacao = $"{value}"; // rgo J3: string
                return;
            case DBAdvogadosDicInfo.ContaBancaria:
                FContaBancaria = $"{value}"; // rgo J3: string
                return;
            case DBAdvogadosDicInfo.ParcTop:
                FParcTop = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAdvogadosDicInfo.Class:
                FClass = $"{value}"; // rgo J3: string
                return;
            case DBAdvogadosDicInfo.Top:
                FTop = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAdvogadosDicInfo.Etiqueta:
                FEtiqueta = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAdvogadosDicInfo.Ani:
                FAni = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAdvogadosDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAdvogadosDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBAdvogadosDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAdvogadosDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBAdvogadosDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAdvogadosDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBAdvogadosDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBAdvogadosDicInfo.Cargo => NFCargo(),
        DBAdvogadosDicInfo.EMailPro => NFEMailPro(),
        DBAdvogadosDicInfo.CPF => NFCPF(),
        DBAdvogadosDicInfo.Nome => NFNome(),
        DBAdvogadosDicInfo.RG => NFRG(),
        DBAdvogadosDicInfo.Casa => FCasa.ToString(),
        DBAdvogadosDicInfo.NomeMae => NFNomeMae(),
        DBAdvogadosDicInfo.Escritorio => NFEscritorio(),
        DBAdvogadosDicInfo.Estagiario => FEstagiario.ToString(),
        DBAdvogadosDicInfo.OAB => NFOAB(),
        DBAdvogadosDicInfo.NomeCompleto => NFNomeCompleto(),
        DBAdvogadosDicInfo.Endereco => NFEndereco(),
        DBAdvogadosDicInfo.Cidade => NFCidade(),
        DBAdvogadosDicInfo.CEP => NFCEP(),
        DBAdvogadosDicInfo.Sexo => FSexo.ToString(),
        DBAdvogadosDicInfo.Bairro => NFBairro(),
        DBAdvogadosDicInfo.CTPSSerie => NFCTPSSerie(),
        DBAdvogadosDicInfo.CTPS => NFCTPS(),
        DBAdvogadosDicInfo.Fone => NFFone(),
        DBAdvogadosDicInfo.Fax => NFFax(),
        DBAdvogadosDicInfo.Comissao => NFComissao(),
        DBAdvogadosDicInfo.DtInicio => NFDtInicio(),
        DBAdvogadosDicInfo.DtFim => NFDtFim(),
        DBAdvogadosDicInfo.DtNasc => NFDtNasc(),
        DBAdvogadosDicInfo.Salario => NFSalario(),
        DBAdvogadosDicInfo.Secretaria => NFSecretaria(),
        DBAdvogadosDicInfo.TextoProcuracao => NFTextoProcuracao(),
        DBAdvogadosDicInfo.EMail => NFEMail(),
        DBAdvogadosDicInfo.Especializacao => NFEspecializacao(),
        DBAdvogadosDicInfo.Pasta => NFPasta(),
        DBAdvogadosDicInfo.Observacao => NFObservacao(),
        DBAdvogadosDicInfo.ContaBancaria => NFContaBancaria(),
        DBAdvogadosDicInfo.ParcTop => FParcTop.ToString(),
        DBAdvogadosDicInfo.Class => NFClass(),
        DBAdvogadosDicInfo.Top => FTop.ToString(),
        DBAdvogadosDicInfo.Etiqueta => FEtiqueta.ToString(),
        DBAdvogadosDicInfo.Ani => FAni.ToString(),
        DBAdvogadosDicInfo.Bold => FBold.ToString(),
        DBAdvogadosDicInfo.GUID => NFGUID(),
        DBAdvogadosDicInfo.QuemCad => NFQuemCad(),
        DBAdvogadosDicInfo.DtCad => MDtCad,
        DBAdvogadosDicInfo.QuemAtu => NFQuemAtu(),
        DBAdvogadosDicInfo.DtAtu => MDtAtu,
        DBAdvogadosDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}