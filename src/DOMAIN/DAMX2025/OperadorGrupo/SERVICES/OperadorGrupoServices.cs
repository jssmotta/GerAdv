// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBOperadorGrupo
{
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "OPERADORGRUPOINC");
#endif
}