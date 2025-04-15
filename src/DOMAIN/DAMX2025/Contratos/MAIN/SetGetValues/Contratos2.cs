namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBContratos
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBContratosDicInfo.Processo:
                FProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBContratosDicInfo.Cliente:
                FCliente = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBContratosDicInfo.Advogado:
                FAdvogado = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBContratosDicInfo.Dia:
                FDia = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBContratosDicInfo.Valor:
                FValor = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBContratosDicInfo.DataInicio:
                FDataInicio = $"{value}"; // rgo J3: DateTime
                return;
            case DBContratosDicInfo.DataTermino:
                FDataTermino = $"{value}"; // rgo J3: DateTime
                return;
            case DBContratosDicInfo.OcultarRelatorio:
                FOcultarRelatorio = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBContratosDicInfo.PercEscritorio:
                FPercEscritorio = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBContratosDicInfo.ValorConsultoria:
                FValorConsultoria = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBContratosDicInfo.TipoCobranca:
                FTipoCobranca = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBContratosDicInfo.Protestar:
                FProtestar = $"{value}"; // rgo J3: string
                return;
            case DBContratosDicInfo.Juros:
                FJuros = $"{value}"; // rgo J3: string
                return;
            case DBContratosDicInfo.ValorRealizavel:
                FValorRealizavel = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBContratosDicInfo.DOCUMENTO:
                FDOCUMENTO = $"{value}"; // rgo J3: string
                return;
            case DBContratosDicInfo.EMail1:
                FEMail1 = $"{value}"; // rgo J3: string
                return;
            case DBContratosDicInfo.EMail2:
                FEMail2 = $"{value}"; // rgo J3: string
                return;
            case DBContratosDicInfo.EMail3:
                FEMail3 = $"{value}"; // rgo J3: string
                return;
            case DBContratosDicInfo.Pessoa1:
                FPessoa1 = $"{value}"; // rgo J3: string
                return;
            case DBContratosDicInfo.Pessoa2:
                FPessoa2 = $"{value}"; // rgo J3: string
                return;
            case DBContratosDicInfo.Pessoa3:
                FPessoa3 = $"{value}"; // rgo J3: string
                return;
            case DBContratosDicInfo.OBS:
                FOBS = $"{value}"; // rgo J3: string
                return;
            case DBContratosDicInfo.ClienteContrato:
                FClienteContrato = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBContratosDicInfo.IdExtrangeiro:
                FIdExtrangeiro = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBContratosDicInfo.ChaveContrato:
                FChaveContrato = $"{value}"; // rgo J3: string
                return;
            case DBContratosDicInfo.Avulso:
                FAvulso = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBContratosDicInfo.Suspenso:
                FSuspenso = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBContratosDicInfo.Multa:
                FMulta = $"{value}"; // rgo J3: string
                return;
            case DBContratosDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBContratosDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBContratosDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBContratosDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBContratosDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBContratosDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBContratosDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBContratosDicInfo.Processo => NFProcesso(),
        DBContratosDicInfo.Cliente => NFCliente(),
        DBContratosDicInfo.Advogado => NFAdvogado(),
        DBContratosDicInfo.Dia => NFDia(),
        DBContratosDicInfo.Valor => NFValor(),
        DBContratosDicInfo.DataInicio => NFDataInicio(),
        DBContratosDicInfo.DataTermino => NFDataTermino(),
        DBContratosDicInfo.OcultarRelatorio => FOcultarRelatorio.ToString(),
        DBContratosDicInfo.PercEscritorio => NFPercEscritorio(),
        DBContratosDicInfo.ValorConsultoria => NFValorConsultoria(),
        DBContratosDicInfo.TipoCobranca => NFTipoCobranca(),
        DBContratosDicInfo.Protestar => NFProtestar(),
        DBContratosDicInfo.Juros => NFJuros(),
        DBContratosDicInfo.ValorRealizavel => NFValorRealizavel(),
        DBContratosDicInfo.DOCUMENTO => NFDOCUMENTO(),
        DBContratosDicInfo.EMail1 => NFEMail1(),
        DBContratosDicInfo.EMail2 => NFEMail2(),
        DBContratosDicInfo.EMail3 => NFEMail3(),
        DBContratosDicInfo.Pessoa1 => NFPessoa1(),
        DBContratosDicInfo.Pessoa2 => NFPessoa2(),
        DBContratosDicInfo.Pessoa3 => NFPessoa3(),
        DBContratosDicInfo.OBS => NFOBS(),
        DBContratosDicInfo.ClienteContrato => NFClienteContrato(),
        DBContratosDicInfo.IdExtrangeiro => NFIdExtrangeiro(),
        DBContratosDicInfo.ChaveContrato => NFChaveContrato(),
        DBContratosDicInfo.Avulso => FAvulso.ToString(),
        DBContratosDicInfo.Suspenso => FSuspenso.ToString(),
        DBContratosDicInfo.Multa => NFMulta(),
        DBContratosDicInfo.Bold => FBold.ToString(),
        DBContratosDicInfo.GUID => NFGUID(),
        DBContratosDicInfo.QuemCad => NFQuemCad(),
        DBContratosDicInfo.DtCad => MDtCad,
        DBContratosDicInfo.QuemAtu => NFQuemAtu(),
        DBContratosDicInfo.DtAtu => MDtAtu,
        DBContratosDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}