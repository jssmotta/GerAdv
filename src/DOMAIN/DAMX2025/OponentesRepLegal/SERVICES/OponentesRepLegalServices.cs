// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBOponentesRepLegal
{
#if (forWeb)
public string FNomeWebSafe => sex.m_FNome?.trim()?.replace(">", string.Empty)?.replace("<", string.Empty) ?? string.Empty;
#endif
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "OPONENTESREPLEGALINC");
#endif
#if (forWeb)
public string LnkAction =>  $"<a title='Editar o registro' hRef='OponentesRepLegalINC.aspx?Id={ID}'><img alt='edt.' src='https://cdn1.advocati.net.br/msi/v20/images/editar3.webp'/></a>";

#endif
    public string LnkCEP => CEPMask();
    public string Documentos => FCPF.IsEmpty() ? string.Empty : DevourerOne.MaskCpf(FCPF) + FRG.ComTraço();
#if (forTheWeb)

public string LinhaEmail => string.Empty; // DevourerOne.LinhaEmailContato(FNome, FEmail, string.Empty, m_FWebSite); 

#endif
}