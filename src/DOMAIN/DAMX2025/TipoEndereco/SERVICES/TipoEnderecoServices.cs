// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBTipoEndereco
{
#if (forWeb)
public string FDescricaoWebSafe => 
m_FDescricao?.trim()?.replace(">", string.Empty)?.replace("<", string.Empty) ?? string.Empty;
#endif
}