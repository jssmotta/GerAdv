namespace MenphisSI;

[Serializable]
public class VAuditor64 : XCodeIdBase64
{   

    [XmlIgnore]
    // Aqui #1 DeclareFieldsType.cs
    // ReSharper disable InconsistentNaming
    private protected DateTime? m_FDtCad, m_FDtAtu;
    private protected bool m_FVisto, pFldFQuemCad, pFldFDtCad, pFldFQuemAtu, pFldFDtAtu, pFldFVisto;
    /// <summary>
    /// Auditor do Sistema (DBOperador.ID)
    /// </summary>
    [XmlIgnore]
    private protected int m_AuditorQuem, m_FQuemCad, m_FQuemAtu;

    /// <summary>
    /// Campo: advQuemCad
    /// </summary>

    // ReSharper disable once InconsistentNaming
    public int FQuemCad
    {
        get => m_FQuemCad;
        set { if (value == m_FQuemCad) return; pFldFQuemCad = true; m_FQuemCad = value; }
    }

    // ReSharper disable once InconsistentNaming
    public string FDtCad
    {
        get => $"{m_FDtCad:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDtCad:dd/MM/yyyy}";
        set { var (setUpNow, changed, data) = DevourerOne.DateUp12(pFldFDtCad, m_FDtCad, value); if (!setUpNow) return; pFldFDtCad = changed; m_FDtCad = data; }
    }
    /// <summary>
    /// Campo: advQuemAtu
    /// </summary>

    // ReSharper disable once InconsistentNaming
    public int FQuemAtu
    {
        get => m_FQuemAtu;
        set { if (value == m_FQuemAtu) return; pFldFQuemAtu = true; m_FQuemAtu = value; }
    }

    public string? FDtAtu
    {
        get => $"{m_FDtAtu:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDtAtu:dd/MM/yyyy}";
        set { var (setUpNow, changed, data) = DevourerOne.DateUp12(pFldFDtAtu, m_FDtAtu, value); if (!setUpNow) return; pFldFDtAtu = changed; m_FDtAtu = data; }
    }
    /// <summary>
    /// Campo: advVisto
    /// </summary>

    // ReSharper disable once InconsistentNaming
    public bool FVisto
    {
        get => m_FVisto;
        set { if (value == m_FVisto) return; pFldFVisto = true; m_FVisto = value; }
    }
    /// <summary>
    /// Campo: advAuditorQuem
    /// </summary>

    // ReSharper disable once InconsistentNaming
    public virtual int AuditorQuem
    {
        get => m_AuditorQuem;
        set { if (value == 0) { if (m_IdRegistro == 0) { value = 1; } else { return; } } if (m_IdRegistro == 0) { FQuemCad = value; FDtCad = DevourerOne.PNow; } else { FQuemAtu = value; FDtAtu = DevourerOne.PNow; } m_AuditorQuem = value; }
        // editCode:AuditorQuem
    }
}

