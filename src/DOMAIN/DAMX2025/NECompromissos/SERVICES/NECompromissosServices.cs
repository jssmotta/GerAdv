// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBNECompromissos
{
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "NECOMPROMISSOSINC");
#endif
}