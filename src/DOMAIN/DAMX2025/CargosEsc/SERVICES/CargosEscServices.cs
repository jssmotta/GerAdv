// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBCargosEsc
{
    [XmlIgnore]
    public string MPercentualStr { get => m_FPercentual.ToString("0.00"); set => FPercentual = DevourerOne.ConvertString2Decimal(value); }
#if (forWeb)
public string FNomeWebSafe => m_FNome?.trim()?.replace(">", string.Empty)?.replace("<", string.Empty) ?? string.Empty;
#endif
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "CARGOSESCINC");
#endif
}