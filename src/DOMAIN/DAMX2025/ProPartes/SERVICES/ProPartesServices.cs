// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBProPartes
{
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "PROPARTESINC");
#endif
}