// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBClientes
{
    [XmlIgnore]
    public DateTime FRGDataExpWithHora
    {
        set
        {
            pFldFRGDataExp = true;
            m_FRGDataExp = value;
        }
    }

    [XmlIgnore]
    public string MRGDataExpDataX_DataHora => $"{m_FRGDataExp:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MRGDataExpX_Hora => $"{m_FRGDataExp:HH:mm:ss}";

#if (forWeb)
public string FNomeWebSafe => sex.m_FNome?.trim()?.replace(">", string.Empty)?.replace("<", string.Empty) ?? string.Empty;
#endif
    public string CNPJMaskWithInfo() => FCNPJ.IsEmpty() ? TConstantes.PCnpjNaoInformado : DevourerOne.CNPJValido(FCNPJ) ? DevourerOne.MaskCnpj(FCNPJ) + TConstantes.PCnpjCalculoOK : DevourerOne.MaskCnpj(FCNPJ) + TConstantes.PCnpjCalculoErro;
    [XmlIgnore]
    public DateTime FDataWithHora
    {
        set
        {
            pFldFData = true;
            m_FData = value;
        }
    }

    [XmlIgnore]
    public string MDataDataX_DataHora => $"{m_FData:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MDataX_Hora => $"{m_FData:HH:mm:ss}";
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClickDual(ID, "ClienteINC");
#endif
    public int Classificacao => FClass.IsEmpty() ? 3 : DevourerOne.ClassRating(FClass);
#if (forWeb)
public string LnkAction => 
(m_FObito) ? "<img src='https://cdn1.advocati.net.br/msi/v20/images/obito.webp' width='16' height='16' alt='Óbito' />" : DevourerOne.LnkProcesso(ID, "cliId") + 
$"<a title='Ver as despesas' hRef='FINDespesasCAD.aspx?cliId={ID}'><img alt='despesas' src='https://cdn1.advocati.net.br/msi/v20/despesas316.png' /></a><a title='Editar o registro do cliente' hRef='ClienteINC.aspx?Id={ID}'><img alt='edt.' src='https://cdn1.advocati.net.br/msi/v20/images/editar3.png'/></a>";

#endif
    public string LnkCEP => CEPMask();
    public string Documentos => !string.IsNullOrEmpty(FCPF) ? DevourerOne.MaskCpf(FCPF) + FRG.ComTraço() : (!string.IsNullOrEmpty(FCNPJ) ? DevourerOne.MaskCnpj(FCNPJ) + FInscEst.ComTraço() : string.Empty);
    public virtual bool PessoaFisica => FTipo;
    public bool PessoaJuridica => !FTipo;
    public string DocumentoCPFCNPJ => PessoaFisica ? (FCPF.IsEmpty() ? string.Empty : DevourerOne.MaskCpf(FCPF)) : (FCNPJ.IsEmpty() ? string.Empty : DevourerOne.MaskCnpj(FCNPJ));
#if (forTheWeb)

public string FoneCss => DevourerOne.FoneCss2(FFone, E_TipoRegistroPeople.CQUEM_CLIENTE, ID);

public string FoneCSSAsLink => DevourerOne.FoneCss(true, FFone, E_TipoRegistroPeople.CQUEM_CLIENTE, ID);

public string LinhaEmail => string.Empty; // DevourerOne.LinhaEmailContato(FNome, FEmail, string.Empty, m_FWebSite); 

#endif
}