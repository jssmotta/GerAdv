// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBAgendaRelatorio
{
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "AGENDARELATORIOINC");
#endif
}