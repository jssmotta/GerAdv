// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBProBarCODE
{
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "PROBARCODEINC");
#endif
}