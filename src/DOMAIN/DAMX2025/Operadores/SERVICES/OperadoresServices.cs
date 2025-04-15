// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBOperadores
{
#if (forWeb)
public string FNomeWebSafe => m_FNome?.trim()?.replace(">", string.Empty)?.replace("<", string.Empty) ?? string.Empty;
#endif
    [XmlIgnore]
    public DateTime FSuporteMaxAgeWithHora
    {
        set
        {
            pFldFSuporteMaxAge = true;
            m_FSuporteMaxAge = value;
        }
    }

    [XmlIgnore]
    public string MSuporteMaxAgeDataX_DataHora => $"{m_FSuporteMaxAge:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MSuporteMaxAgeX_Hora => $"{m_FSuporteMaxAge:HH:mm:ss}";
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "OPERADORESINC");
#endif
#if (forTheWeb)

public string LinhaEmail => string.Empty; // DevourerOne.LinhaEmailContato(FNome, FEmail, string.Empty, string.Empty); 

#endif
}