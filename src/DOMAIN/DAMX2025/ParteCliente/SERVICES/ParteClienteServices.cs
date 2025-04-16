// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBParteCliente
{
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "PARTECLIENTEINC");
#endif
}