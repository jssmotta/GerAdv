// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBDivisaoTribunal
{
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "DIVISAOTRIBUNALINC");
#endif
#if (forWeb)
public string LnkAction =>  $"<a title='Editar o registro' hRef='DivisaoTribunalINC.aspx?Id={ID}'><img alt='edt.' src='https://cdn1.advocati.net.br/msi/v20/images/editar3.webp'/></a>";

#endif
    public string LnkCEP => CEPMask();
}