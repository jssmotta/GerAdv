// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBAreasJustica
{
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "AREASJUSTICAINC");
#endif
}