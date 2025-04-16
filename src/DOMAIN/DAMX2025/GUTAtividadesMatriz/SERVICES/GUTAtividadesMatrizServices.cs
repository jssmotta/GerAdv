// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBGUTAtividadesMatriz
{
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "GUTATIVIDADESMATRIZINC");
#endif
}