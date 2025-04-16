
namespace MenphisSI.Internal;

[Serializable]
internal class VAuditor : XCodeIdBase
{

    [XmlIgnore]
        
    private protected DateTime? m_FDtCad, m_FDtAtu;
    private protected bool m_FVisto, pFldFQuemCad, pFldFDtCad, pFldFQuemAtu, pFldFDtAtu, pFldFVisto, pFldFGUID;
    /// <summary>
    /// Auditor do Sistema (DBOperador.ID)
    /// </summary>
    [XmlIgnore]
    private protected int m_AuditorQuem, m_FQuemCad, m_FQuemAtu;
    [XmlIgnore]
    private protected string? m_FGUID; // C#8 string?

   
    [XmlAttribute]
    
    public string FGUID
    {
        get => m_FGUID ?? string.Empty;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                pFldFGUID = pFldFGUID || !string.IsNullOrEmpty(m_FGUID);
                m_FGUID = string.Empty;
            }
            else
            {
                pFldFGUID = pFldFGUID || !(m_FGUID ?? string.Empty).Equals(value);
                if (pFldFGUID) m_FGUID = value.Trim().Length > 150 ? value.Trim()[..150] : value.Trim();
            }
        }
    }

    /// <summary>
    /// Atribui a hora junto com Data
    /// </summary>
    [XmlIgnore]
    public DateTime FDtCadWithHora
    {
        set
        {
            pFldFDtCad = true;
            m_FDtCad = value;
        }
    }
    /// <summary>
    /// FDtCad com a Data e a Hora
    /// </summary>
    [XmlIgnore]
    public string MDtCadDataX_DataHora => $"{m_FDtCad:dd/MM/yyyy HH:mm:ss}";
    /// <summary>
    /// FDtCad somente com a Hora
    /// </summary>
    [XmlIgnore]
    public string MDtCadX_Hora => $"{m_FDtCad:HH:mm:ss}";/// <summary>
                                                         /// Atribui a hora junto com Data
                                                         /// </summary>
    [XmlIgnore]
    public DateTime FDtAtuWithHora
    {
        set
        {
            pFldFDtAtu = true;
            m_FDtAtu = value;
        }
    }
    /// <summary>
    /// FDtAtu com a Data e a Hora
    /// </summary>
    [XmlIgnore]
    public string MDtAtuDataX_DataHora => $"{m_FDtAtu:dd/MM/yyyy HH:mm:ss}";
    /// <summary>
    /// FDtAtu somente com a Hora
    /// </summary>
    [XmlIgnore]
    public string MDtAtuX_Hora => $"{m_FDtAtu:HH:mm:ss}";
    /// <summary>
    /// É Visto
    /// </summary>
    [XmlIgnore]
    public bool IsVisto => m_FVisto;
    /// <summary>
    /// Não é Visto
    /// </summary>
    [XmlIgnore]
    public bool NotIsVisto => !m_FVisto;

    /// <summary>
    /// Campo: advQuemCad
    /// </summary>
    [XmlAttribute]
    // ReSharper disable once InconsistentNaming
    public int FQuemCad
    {
        get => m_FQuemCad;
        set { if (value == m_FQuemCad) return; pFldFQuemCad = true; m_FQuemCad = value; }
    }
    /// <summary>
    /// FDtCad como DateTime
    /// </summary>
    [XmlIgnore]
    public DateTime MDtCad => Convert.ToDateTime(m_FDtCad);
    /// <summary>
    /// Campo: advDtCad
    /// </summary>
    [XmlAttribute]
    // ReSharper disable once InconsistentNaming
    public string FDtCad
    {
        get => $"{m_FDtCad:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDtCad:dd/MM/yyyy}";
        set { (var setUpNow, var changed, var data) = DevourerOne.DateUp7(pFldFDtCad, m_FDtCad, value); if (!setUpNow) return; pFldFDtCad = changed; m_FDtCad = data; }
    }
    /// <summary>
    /// Campo: advQuemAtu
    /// </summary>
    [XmlAttribute]
    // ReSharper disable once InconsistentNaming
    public int FQuemAtu
    {
        get => m_FQuemAtu;
        set { if (value == m_FQuemAtu) return; pFldFQuemAtu = true; m_FQuemAtu = value; }
    }
    /// <summary>
    /// FDtAtu como DateTime
    /// </summary>
    [XmlIgnore]
    public DateTime MDtAtu => Convert.ToDateTime(m_FDtAtu);
    /// <summary>
    /// Campo: advDtAtu
    /// </summary>
    [XmlAttribute]
    // ReSharper disable once InconsistentNaming
    public string FDtAtu
    {
        get => $"{m_FDtAtu:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDtAtu:dd/MM/yyyy}";
        set { (var setUpNow, var changed, var data) = DevourerOne.DateUp7(pFldFDtAtu, m_FDtAtu, value); if (!setUpNow) return; pFldFDtAtu = changed; m_FDtAtu = data; }
    }
    /// <summary>
    /// Campo: advVisto
    /// </summary>
    [XmlAttribute]
    // ReSharper disable once InconsistentNaming
    public bool FVisto
    {
        get => m_FVisto;
        set { if (value == m_FVisto) return; pFldFVisto = true; m_FVisto = value; }
    }
    /// <summary>
    /// Campo: advAuditorQuem
    /// </summary>
    [XmlAttribute]
    // ReSharper disable once InconsistentNaming
    public int AuditorQuem
    {
        get => m_AuditorQuem;
        set { if (value == 0) { if (m_IdRegistro == 0) { value = 1; } else { return; } } if (m_IdRegistro == 0) { FQuemCad = value; FDtCad = DevourerOne.PNow; } else { FQuemAtu = value; FDtAtu = DevourerOne.PNow; } m_AuditorQuem = value; }
        // editCode:AuditorQuem
    }
}

