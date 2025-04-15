// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBTipoValorProcesso
{
#if (forWeb)
public string FDescricaoWebSafe => 
m_FDescricao?.trim()?.replace(">", string.Empty)?.replace("<", string.Empty) ?? string.Empty;
#endif
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "TIPOVALORPROCESSOINC");
#endif
}