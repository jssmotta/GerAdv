
namespace MenphisSI;

[Serializable]
public class XCodeIdBaseShadows   //: StylesCad - Deixou o Sistema lento, muitas heranças.
{
    private protected int m_IdRegistro, shadowCodigo;
    private protected bool
        pFldFShadowCountChange,
        pFldFShadowOperador,
        pFldFShadowDataHora,
        pFldFShadowIpAddress,
        pFldFShadowVisto,
        pFldFShadowVistoOperador,
        pFldFShadowVistoDataHora,
        pFldFShadowCamposModificados,
        pFldFShadowViewOperador,
        pFldFShadowViewDataHoraInicio,
        pFldFShadowViewDataHoraTermino,
        m_FShadowVisto;

    private protected int m_FShadowVistoOperador, m_FShadowOperador, m_FShadowCountChange, m_FShadowViewOperador;
    private protected string? m_FShadowCamposModificados, m_FShadowIpAddress;
    private protected DateTime? m_FShadowVistoDataHora, m_FShadowDataHora, m_FShadowViewDataHoraInicio, m_FShadowViewDataHoraTermino;
    /// <summary>
    /// Campo: acaShadowCountChange
    /// </summary>
    [XmlAttribute]
    // ReSharper disable once InconsistentNaming
    public int FShadowCountChange
    {
        get => m_FShadowCountChange;
        set { pFldFShadowCountChange = pFldFShadowCountChange || value != m_FShadowCountChange; if (pFldFShadowCountChange) m_FShadowCountChange = value; }
    }
    /// <summary>
    /// Campo: acaShadowOperador
    /// </summary>
    [XmlAttribute]
    // ReSharper disable once InconsistentNaming
    public int FShadowOperador
    {
        get => m_FShadowOperador;
        set { pFldFShadowOperador = pFldFShadowOperador || value != m_FShadowOperador; if (pFldFShadowOperador) m_FShadowOperador = value; }
    }
    /// <summary>
    /// FShadowDataHora como DateTime
    /// </summary>
    [XmlIgnore]
    public DateTime MShadowDataHora => Convert.ToDateTime(m_FShadowDataHora);
    /// <summary>
    /// Campo: acaShadowDataHora
    /// </summary>
    [XmlAttribute]
    // ReSharper disable once InconsistentNaming
    public string FShadowDataHora
    {
        get => $"{m_FShadowDataHora:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FShadowDataHora:dd/MM/yyyy}";
        set { (var setUpNow, var changed, var data) = DevourerOne.DateUp7(pFldFShadowDataHora, m_FShadowDataHora, value); if (!setUpNow) return; pFldFShadowDataHora = changed; m_FShadowDataHora = data; }
    }
    /// <summary>
    /// Campo: acaShadowIpAddress, tamanho: 100
    /// </summary>
    [XmlAttribute]
    // ReSharper disable once InconsistentNaming
    public string FShadowIpAddress
    {
        get => m_FShadowIpAddress ?? string.Empty;
        set
        {
            pFldFShadowIpAddress = pFldFShadowIpAddress || !(m_FShadowIpAddress ?? string.Empty).Equals(value);
            if (pFldFShadowIpAddress) m_FShadowIpAddress = value.FixAbc(100);
        }
    }
    /// <summary>
    /// Campo: acaShadowVisto, tamanho: 1
    /// </summary>
    [XmlAttribute]
    // ReSharper disable once InconsistentNaming
    public bool FShadowVisto
    {
        get => m_FShadowVisto;
        set { pFldFShadowVisto = pFldFShadowVisto || value != m_FShadowVisto; if (pFldFShadowVisto) m_FShadowVisto = value; }
    }
    /// <summary>
    /// Campo: acaShadowVistoOperador
    /// </summary>
    [XmlAttribute]
    // ReSharper disable once InconsistentNaming
    public int FShadowVistoOperador
    {
        get => m_FShadowVistoOperador;
        set { pFldFShadowVistoOperador = pFldFShadowVistoOperador || value != m_FShadowVistoOperador; if (pFldFShadowVistoOperador) m_FShadowVistoOperador = value; }
    }
    /// <summary>
    /// FShadowVistoDataHora como DateTime
    /// </summary>
    [XmlIgnore]
    public DateTime MShadowVistoDataHora => Convert.ToDateTime(m_FShadowVistoDataHora);
    /// <summary>
    /// Campo: acaShadowVistoDataHora
    /// </summary>
    [XmlAttribute]
    // ReSharper disable once InconsistentNaming
    public string FShadowVistoDataHora
    {
        get => $"{m_FShadowVistoDataHora:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FShadowVistoDataHora:dd/MM/yyyy}";
        set { (var setUpNow, var changed, var data) = DevourerOne.DateUp7(pFldFShadowVistoDataHora, m_FShadowVistoDataHora, value); if (!setUpNow) return; pFldFShadowVistoDataHora = changed; m_FShadowVistoDataHora = data; }
    }
    /// <summary>
    /// Campo: acaShadowCamposModificados, tamanho: 2048
    /// </summary>
    [XmlAttribute]
    // ReSharper disable once InconsistentNaming
    public string FShadowCamposModificados
    {
        get => m_FShadowCamposModificados ?? string.Empty;
        set
        {
            pFldFShadowCamposModificados = pFldFShadowCamposModificados || !(m_FShadowCamposModificados ?? string.Empty).Equals(value);
            if (pFldFShadowCamposModificados) m_FShadowCamposModificados = value.FixAbc(2048);
        }
    }
    /// <summary>
    /// Campo: acaShadowViewOperador
    /// </summary>
    [XmlAttribute]
    // ReSharper disable once InconsistentNaming
    public int FShadowViewOperador
    {
        get => m_FShadowViewOperador;
        set { pFldFShadowViewOperador = pFldFShadowViewOperador || value != m_FShadowViewOperador; if (pFldFShadowViewOperador) m_FShadowViewOperador = value; }
    }
    /// <summary>
    /// FShadowViewDataHoraInicio como DateTime
    /// </summary>
    [XmlIgnore]
    public DateTime MShadowViewDataHoraInicio => Convert.ToDateTime(m_FShadowViewDataHoraInicio);
    /// <summary>
    /// Campo: acaShadowViewDataHoraInicio
    /// </summary>
    [XmlAttribute]
    // ReSharper disable once InconsistentNaming
    public string FShadowViewDataHoraInicio
    {
        get => $"{m_FShadowViewDataHoraInicio:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FShadowViewDataHoraInicio:dd/MM/yyyy}";
        set { (var setUpNow, var changed, var data) = DevourerOne.DateUp7(pFldFShadowViewDataHoraInicio, m_FShadowViewDataHoraInicio, value); if (!setUpNow) return; pFldFShadowViewDataHoraInicio = changed; m_FShadowViewDataHoraInicio = data; }
    }
    /// <summary>
    /// FShadowViewDataHoraTermino como DateTime
    /// </summary>
    [XmlIgnore]
    public DateTime MShadowViewDataHoraTermino => Convert.ToDateTime(m_FShadowViewDataHoraTermino);
    /// <summary>
    /// Campo: acaShadowViewDataHoraTermino
    /// </summary>
    [XmlAttribute]
    // ReSharper disable once InconsistentNaming
    public string FShadowViewDataHoraTermino
    {
        get => $"{m_FShadowViewDataHoraTermino:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FShadowViewDataHoraTermino:dd/MM/yyyy}";
        set { var (setUpNow, changed, data) = DevourerOne.DateUp7(pFldFShadowViewDataHoraTermino, m_FShadowViewDataHoraTermino, value); if (!setUpNow) return; pFldFShadowViewDataHoraTermino = changed; m_FShadowViewDataHoraTermino = data; }
    }

    /// <summary>
    /// Id do Erro -1,-2-3 ou 0 sucesso
    /// </summary>
    public int Error;
    /// <summary>
    /// Descrição do erro ao gravar
    /// </summary>
    public string? ErrorDescription;

    /// <summary>
    /// 07-01-2017 15:50
    /// </summary>
    public int Código => m_IdRegistro;

    /// <summary>
    /// Campo código
    /// </summary>
    public int ID { get => m_IdRegistro; set => m_IdRegistro = value; }

    /// <summary>
    /// Estilo da linha para o CSS
    /// </summary>
    [XmlIgnore]
    public static byte Style;

    /// <summary>
    /// Estilo CSS para a linha
    /// </summary>
    [XmlIgnore]
    public string StyleColumn
    {
        get
        {
            Style = Style == 1 ? (byte)0 : (byte)1;
            return
                    $" style='color:Black;font-size:12px;background-color:{(Style == 0 ? "#EBEBEB" : "#C0C0C0")}' onmouseover='overRow(this)' onmouseout=\"outRow(this,'{(Style == 0 ? "#EBEBEB" : "#C0C0C0")}','Black');\" ";
        }
    }
}

