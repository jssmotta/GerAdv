// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBParceriaProc
{
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "PARCERIAPROCINC");
#endif
}