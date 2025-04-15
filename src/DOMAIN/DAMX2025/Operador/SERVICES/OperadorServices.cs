// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBOperador
{
#if (forWeb)
public string FNomeWebSafe => m_FNome?.trim()?.replace(">", string.Empty)?.replace("<", string.Empty) ?? string.Empty;
#endif
    [XmlIgnore]
    public DateTime FUltimoLogoffWithHora
    {
        set
        {
            pFldFUltimoLogoff = true;
            m_FUltimoLogoff = value;
        }
    }

    [XmlIgnore]
    public string MUltimoLogoffDataX_DataHora => $"{m_FUltimoLogoff:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MUltimoLogoffX_Hora => $"{m_FUltimoLogoff:HH:mm:ss}";

    [XmlIgnore]
    public DateTime FDataLimiteResetWithHora
    {
        set
        {
            pFldFDataLimiteReset = true;
            m_FDataLimiteReset = value;
        }
    }

    [XmlIgnore]
    public string MDataLimiteResetDataX_DataHora => $"{m_FDataLimiteReset:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MDataLimiteResetX_Hora => $"{m_FDataLimiteReset:HH:mm:ss}";

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

    [XmlIgnore]
    public DateTime FSuporteUltimoAcessoWithHora
    {
        set
        {
            pFldFSuporteUltimoAcesso = true;
            m_FSuporteUltimoAcesso = value;
        }
    }

    [XmlIgnore]
    public string MSuporteUltimoAcessoDataX_DataHora => $"{m_FSuporteUltimoAcesso:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MSuporteUltimoAcessoX_Hora => $"{m_FSuporteUltimoAcesso:HH:mm:ss}";
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "OPERADORINC");
#endif
#if (forTheWeb)

public string LinhaEmail => string.Empty; // DevourerOne.LinhaEmailContato(FNome, FEmail, string.Empty, string.Empty); 

#endif
}