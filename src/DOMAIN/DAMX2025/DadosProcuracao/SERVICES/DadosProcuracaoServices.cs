// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBDadosProcuracao
{
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "DADOSPROCURACAOINC");
#endif
}