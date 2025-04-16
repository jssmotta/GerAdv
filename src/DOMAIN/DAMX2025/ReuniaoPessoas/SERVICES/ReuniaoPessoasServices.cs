// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBReuniaoPessoas
{
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "REUNIAOPESSOASINC");
#endif
}