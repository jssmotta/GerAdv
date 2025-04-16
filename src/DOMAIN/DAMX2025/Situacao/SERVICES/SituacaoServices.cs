// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBSituacao
{
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "SITUACAOINC");
#endif
}