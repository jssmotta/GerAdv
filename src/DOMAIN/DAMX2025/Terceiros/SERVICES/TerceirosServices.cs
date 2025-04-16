// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBTerceiros
{
#if (forWeb)
public string FNomeWebSafe => m_FNome?.trim()?.replace(">", string.Empty)?.replace("<", string.Empty) ?? string.Empty;
#endif
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "TERCEIROSINC");
#endif
    public int Classificacao => FClass.IsEmpty() ? 3 : DevourerOne.ClassRating(FClass);
#if (forWeb)
public string LnkAction =>  $"<a title='Editar o registro' hRef='TerceirosINC.aspx?Id={ID}'><img alt='edt.' src='https://cdn1.advocati.net.br/msi/v20/images/editar3.webp'/></a>";

#endif
    public string LnkCEP => CEPMask();
#if (forTheWeb)

public string FoneCss => DevourerOne.FoneCss2(FFone, E_TipoRegistroPeople.CQUEM_TERCEIRO, ID);

public string FoneCSSAsLink => DevourerOne.FoneCss(true, FFone, E_TipoRegistroPeople.CQUEM_TERCEIRO, ID);

public string LinhaEmail => string.Empty; // DevourerOne.LinhaEmailContato(FNome, FEmail, string.Empty, string.Empty); 

#endif
}