// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBContatoCRMOperador
{
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "CONTATOCRMOPERADORINC");
#endif
}