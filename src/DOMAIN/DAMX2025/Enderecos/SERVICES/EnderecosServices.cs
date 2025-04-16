// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBEnderecos
{
#if (forWeb)
public string FDescricaoWebSafe => 
m_FDescricao?.trim()?.replace(">", string.Empty)?.replace("<", string.Empty) ?? string.Empty;
#endif
    [XmlIgnore]
    public DateTime FDtNascWithHora
    {
        set
        {
            pFldFDtNasc = true;
            m_FDtNasc = value;
        }
    }

    [XmlIgnore]
    public string MDtNascDataX_DataHora => $"{m_FDtNasc:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MDtNascX_Hora => $"{m_FDtNasc:HH:mm:ss}";
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "EnderecoINC");
#endif
#if (forWeb)
public string LnkAction =>  $"<a title='Editar o registro' hRef='EnderecoINC.aspx?Id={ID}'><img alt='edt.' src='https://cdn1.advocati.net.br/msi/v20/images/editar3.webp'/></a>";

#endif
    public string LnkCEP => CEPMask();
#if (forTheWeb)

public string FoneCss => DevourerOne.FoneCss2(FFone, E_TipoRegistroPeople.CQUEM_AGENDA_ENDERECO, ID);

public string FoneCSSAsLink => DevourerOne.FoneCss(true, FFone, E_TipoRegistroPeople.CQUEM_AGENDA_ENDERECO, ID);

public string LinhaEmail => string.Empty; // DevourerOne.LinhaEmailContato(m_FDescricao, FEmail, string.Empty, m_FWebSite); 

#endif
}