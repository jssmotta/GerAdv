// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBGruposEmpresas
{
#if (forWeb)
public string FDescricaoWebSafe => 
m_FDescricao?.trim()?.replace(">", string.Empty)?.replace("<", string.Empty) ?? string.Empty;
#endif
#if (forTheWeb)

public string LinhaEmail => string.Empty; // DevourerOne.LinhaEmailContato(FNome, FEmail, string.Empty, string.Empty); 

#endif
}