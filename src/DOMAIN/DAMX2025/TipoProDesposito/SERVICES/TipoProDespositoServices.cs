// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBTipoProDesposito
{
#if (forWeb)
public string FNomeWebSafe => m_FNome?.trim()?.replace(">", string.Empty)?.replace("<", string.Empty) ?? string.Empty;
#endif
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "TIPOPRODESPOSITOINC");
#endif
}