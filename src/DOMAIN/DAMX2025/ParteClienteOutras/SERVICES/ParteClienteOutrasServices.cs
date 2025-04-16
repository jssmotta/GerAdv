// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBParteClienteOutras
{
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "PARTECLIENTEOUTRASINC");
#endif
}