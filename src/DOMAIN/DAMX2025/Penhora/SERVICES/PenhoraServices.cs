// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBPenhora
{
#if (forWeb)
public string FNomeWebSafe => m_FNome?.trim()?.replace(">", string.Empty)?.replace("<", string.Empty) ?? string.Empty;
#endif
#if (forWeb)
public string FDescricaoWebSafe => 
m_FDescricao?.trim()?.replace(">", string.Empty)?.replace("<", string.Empty) ?? string.Empty;
#endif
    [XmlIgnore]
    public DateTime FDataPenhoraWithHora
    {
        set
        {
            pFldFDataPenhora = true;
            m_FDataPenhora = value;
        }
    }

    [XmlIgnore]
    public string MDataPenhoraDataX_DataHora => $"{m_FDataPenhora:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MDataPenhoraX_Hora => $"{m_FDataPenhora:HH:mm:ss}";
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "PENHORAINC");
#endif
}