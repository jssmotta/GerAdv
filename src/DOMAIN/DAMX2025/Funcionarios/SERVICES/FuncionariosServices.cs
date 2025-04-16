// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBFuncionarios
{
#if (forWeb)
public string FNomeWebSafe => sex.m_FNome?.trim()?.replace(">", string.Empty)?.replace("<", string.Empty) ?? string.Empty;
#endif
    [XmlIgnore]
    public DateTime FPeriodo_IniWithHora
    {
        set
        {
            pFldFPeriodo_Ini = true;
            m_FPeriodo_Ini = value;
        }
    }

    [XmlIgnore]
    public string MPeriodo_IniDataX_DataHora => $"{m_FPeriodo_Ini:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MPeriodo_IniX_Hora => $"{m_FPeriodo_Ini:HH:mm:ss}";

    [XmlIgnore]
    public DateTime FPeriodo_FimWithHora
    {
        set
        {
            pFldFPeriodo_Fim = true;
            m_FPeriodo_Fim = value;
        }
    }

    [XmlIgnore]
    public string MPeriodo_FimDataX_DataHora => $"{m_FPeriodo_Fim:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MPeriodo_FimX_Hora => $"{m_FPeriodo_Fim:HH:mm:ss}";

    [XmlIgnore]
    public string MSalarioStr { get => m_FSalario.ToString("0.00"); set => FSalario = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public DateTime FCTPSDtEmissaoWithHora
    {
        set
        {
            pFldFCTPSDtEmissao = true;
            m_FCTPSDtEmissao = value;
        }
    }

    [XmlIgnore]
    public string MCTPSDtEmissaoDataX_DataHora => $"{m_FCTPSDtEmissao:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MCTPSDtEmissaoX_Hora => $"{m_FCTPSDtEmissao:HH:mm:ss}";

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
public string TRClick => DevourerOne.TableTrClick(ID, "FUNCIONARIOSINC");
#endif
    public int Classificacao => FClass.IsEmpty() ? 3 : DevourerOne.ClassRating(FClass);
#if (forWeb)
public string LnkAction =>  $"<a title='Editar o registro' hRef='FuncionarioINC.aspx?Id={ID}'><img alt='edt.' src='https://cdn1.advocati.net.br/msi/v20/images/editar3.webp'/></a>";

#endif
    public string LnkCEP => CEPMask();
    public string Documentos => FCPF.IsEmpty() ? string.Empty : DevourerOne.MaskCpf(FCPF) + FRG.ComTraço();
#if (forTheWeb)

public string FoneCss => DevourerOne.FoneCss2(FFone, E_TipoRegistroPeople.CQUEM_FUNCIONARIOS, ID);

public string FoneCSSAsLink => DevourerOne.FoneCss(true, FFone, E_TipoRegistroPeople.CQUEM_FUNCIONARIOS, ID);

public string LinhaEmail => string.Empty; // DevourerOne.LinhaEmailContato(FNome, FEmail, string.Empty, string.Empty); 

#endif
}