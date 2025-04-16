// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBGraph
{
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "GRAPHINC");
#endif
}