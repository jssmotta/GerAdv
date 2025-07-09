
namespace MenphisSI;

[Serializable]
public class VAuditor : XCodeIdBase
{
    /// 26-03-2019 18:30
    /// <param name="key"></param>
    /// <param name="oCnn"></param>
    /// <param name="valueDefault"></param>
    /// <returns></returns>
    public string ReadCfgC(in string? key, in MsiSqlConnection? oCnn, in string valueDefault = "") =>
        ConfigSys.ReadCfgSysC(key, ID, oCnn, valueDefault);
    public void WriteCfgC(in string? key, in string value, in MsiSqlConnection? oCnn)
        => ConfigSys.WriteCfgSysC(key, ID, value, oCnn);

    public string ReadCfgMemo(in string? key, in MsiSqlConnection? oCnn, in string valueDefault = "") =>
        ConfigSys.ReadCfgSysMemo(key, ID, oCnn);

    public void WriteCfgMemo(in string? key, in string value, in MsiSqlConnection? oCnn)
        => ConfigSys.WriteCfgSysMemo(key, ID, value, oCnn);

    /// <summary>
    /// 27-07-2019
    /// </summary>
    /// <param name="key"></param>
    /// <param name="oCnn"></param>
    /// <param name="valueDefault"></param>
    /// <returns></returns>
    public int ReadCfg(in string key, in MsiSqlConnection? oCnn, in int valueDefault = -1) =>
        ConfigSys.ReadCfgSys(key, ID, oCnn, valueDefault);
    public void WriteCfg(in string key, in int value, in MsiSqlConnection? oCnn) =>
     ConfigSys.WriteCfgSys(key, ID, value, oCnn);

    /// <summary>
    /// 26-07-2019 21:01
    /// </summary>
    /// <param name="key"></param>
    /// <param name="oCnn"></param>
    /// <param name="valueDefault"></param>
    /// <returns></returns>
    public bool ReadCfgBool(in string key, in MsiSqlConnection? oCnn, in bool valueDefault = false)
    {
        var ret = ConfigSys.ReadCfgSysC(key, ID, oCnn, valueDefault ? "True" : "False");
        return ret.IsEmpty() ? (valueDefault ? "True" : "False").IsEquals("True") : ret.IsEquals("True");
    }
    public void WriteCfgBool(in string key, in bool value, in MsiSqlConnection? oCnn) =>
     ConfigSys.WriteCfgSysC(key, ID, value ? "True" : "False", oCnn);

    [XmlIgnore]
    // Aqui #1 DeclareFieldsType.cs
    // ReSharper disable InconsistentNaming
    private protected DateTime? m_FDtCad, m_FDtAtu;
    private protected bool m_FVisto, pFldFQuemCad, pFldFDtCad, pFldFQuemAtu, pFldFDtAtu, pFldFVisto, pFldFGUID;
    /// <summary>
    /// Auditor do Sistema (DBOperador.ID)
    /// </summary>
    [XmlIgnore]
    private protected int m_AuditorQuem, m_FQuemCad, m_FQuemAtu;
    [XmlIgnore]
    private protected string? m_FGUID; // C#8 string?

    /// <summary>
    /// 26/04/2020 19:14
    /// </summary>
    /// <returns></returns>
    public int NFQuemCad() => m_FQuemCad;

    /// <summary>
    /// 26/04/2020 19:14
    /// </summary>
    /// <returns></returns>
    public int NFQuemAtu() => m_FQuemAtu;

    /// <summary>
    /// 26-04-202 17:38
    /// </summary>
    /// <returns></returns>
    public string NFGUID() => m_FGUID ?? string.Empty;
    /// <summary>
    /// Campo: xxxGUID, tamanho: 150
    /// </summary>
    [XmlAttribute]
    // ReSharper disable once InconsistentNaming
    public string FGUID
    {
        get => m_FGUID ?? string.Empty;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                pFldFGUID = pFldFGUID || !string.IsNullOrEmpty(m_FGUID);
                m_FGUID = string.Empty;
                return;
            }

            pFldFGUID = pFldFGUID || !(m_FGUID ?? string.Empty).Equals(value);
            if (pFldFGUID) m_FGUID = value != null && value.Trim().Length > 150 ? value.Trim()[..150] : value.trim();

        }
    }

    public void ForceUpdateGuid() => pFldFGUID = true;

  
    /// <summary>
    /// FDtCad com a Data e a Hora
    /// </summary>
    [XmlIgnore]
    public string MDtCadDataX_DataHora => $"{m_FDtCad:dd/MM/yyyy HH:mm:ss}";
    /// <summary>
    /// FDtCad somente com a Hora
    /// </summary>
    [XmlIgnore]
    public string MDtCadX_Hora => $"{m_FDtCad:HH:mm:ss}";
 
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
        set { var (setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDtCad, m_FDtCad, value); if (!setUpNow) return; pFldFDtCad = changed; m_FDtCad = data; }
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
    public string? FDtAtu
    {
        get => $"{m_FDtAtu:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDtAtu:dd/MM/yyyy}";
        set { var (setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDtAtu, m_FDtAtu, value); if (!setUpNow) return; pFldFDtAtu = changed; m_FDtAtu = data; }
    }
    /// <summary>
    /// Campo: advVisto
    /// </summary>
    [XmlAttribute]
    // ReSharper disable once InconsistentNaming
    public bool FVisto
    {
        get => m_FVisto;
        set { if (value == m_FVisto) return; if (value) ForceUpdateGuid(); pFldFVisto = true; m_FVisto = value; }
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

