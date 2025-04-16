// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBAdvogados
{
#if (forWeb)
public string FNomeWebSafe => sex.m_FNome?.trim()?.replace(">", string.Empty)?.replace("<", string.Empty) ?? string.Empty;
#endif
    [XmlIgnore]
    public DateTime FDtInicioWithHora
    {
        set
        {
            pFldFDtInicio = true;
            m_FDtInicio = value;
        }
    }

    [XmlIgnore]
    public string MDtInicioDataX_DataHora => $"{m_FDtInicio:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MDtInicioX_Hora => $"{m_FDtInicio:HH:mm:ss}";

    [XmlIgnore]
    public DateTime FDtFimWithHora
    {
        set
        {
            pFldFDtFim = true;
            m_FDtFim = value;
        }
    }

    [XmlIgnore]
    public string MDtFimDataX_DataHora => $"{m_FDtFim:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MDtFimX_Hora => $"{m_FDtFim:HH:mm:ss}";

    [XmlIgnore]
    public string MSalarioStr { get => m_FSalario.ToString("0.00"); set => FSalario = DevourerOne.ConvertString2Decimal(value); }
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "AdvogadoINC");
#endif
    public int Classificacao => FClass.IsEmpty() ? 3 : DevourerOne.ClassRating(FClass);
#if (forWeb)
public string LnkAction =>   DevourerOne.LnkProcesso(ID, "advId") + $"<a title='Editar o registro' hRef='ProfiINCRedirect.aspx?Id={ID}'><img alt='edt.' src='https://cdn1.advocati.net.br/msi/v20/images/editar3.webp'/></a>";

#endif
    public string LnkCEP => CEPMask();
    public string Documentos => FCPF.IsEmpty() ? string.Empty : DevourerOne.MaskCpf(FCPF) + FRG.ComTraço();
#if (forTheWeb)

public string FoneCss => DevourerOne.FoneCss2(FFone, E_TipoRegistroPeople.CQUEM_ADVOGADO, ID);

public string FoneCSSAsLink => DevourerOne.FoneCss(true, FFone, E_TipoRegistroPeople.CQUEM_ADVOGADO, ID);

public string LinhaEmail => string.Empty; // DevourerOne.LinhaEmailContato(FNome, FEmail, m_FEmailPro, string.Empty); 

#endif
}