// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBParteOponente
{
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "PARTEOPONENTEINC");
#endif
}