// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBLivroCaixaClientes
{
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "LIVROCAIXACLIENTESINC");
#endif
}