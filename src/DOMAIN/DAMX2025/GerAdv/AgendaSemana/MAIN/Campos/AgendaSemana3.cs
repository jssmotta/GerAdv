namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAgendaSemana
{
    [XmlIgnore]
    private protected int m_FFuncionario, m_FAdvogado, m_FTipoCompromisso, m_FCliente;
    [XmlIgnore]
    private protected string? m_FParaNome, m_FCompromisso, m_FNome, m_FNomeCliente, m_FTipo;
    [XmlIgnore]
    private protected DateTime? m_FData, m_FHora, m_FHoraFinal;
    [XmlIgnore]
    private protected bool m_FConcluido, m_FLiberado, m_FImportante;
    public string? FParaNome { get => m_FParaNome ?? string.Empty; set => m_FParaNome = value; }

    [XmlIgnore]
    public DateTime MData => Convert.ToDateTime(m_FData);

    public string? FData
    {
        get => $"{m_FData:dd/MM/yyyy HH:mm:ss}"; // 20250502
        set
        {
            if (!string.IsNullOrEmpty(value))
                m_FData = DateTime.ParseExact(value, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            ;
        }
    }

    public int FFuncionario { get => m_FFuncionario; set => m_FFuncionario = value; }
    public int FAdvogado { get => m_FAdvogado; set => m_FAdvogado = value; }

    [XmlIgnore]
    public DateTime MHora => Convert.ToDateTime(m_FHora);

    public string? FHora
    {
        get => $"{m_FHora:dd/MM/yyyy HH:mm:ss}"; // 20250502
        set
        {
            if (!string.IsNullOrEmpty(value))
                m_FHora = DateTime.ParseExact(value, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            ;
        }
    }

    public int FTipoCompromisso { get => m_FTipoCompromisso; set => m_FTipoCompromisso = value; }
    public string? FCompromisso { get => m_FCompromisso ?? string.Empty; set => m_FCompromisso = value; }
    public bool FConcluido { get => m_FConcluido; set => m_FConcluido = value; }
    public bool FLiberado { get => m_FLiberado; set => m_FLiberado = value; }
    public bool FImportante { get => m_FImportante; set => m_FImportante = value; }

    [XmlIgnore]
    public DateTime MHoraFinal => Convert.ToDateTime(m_FHoraFinal);

    public string? FHoraFinal
    {
        get => $"{m_FHoraFinal:dd/MM/yyyy HH:mm:ss}"; // 20250502
        set
        {
            if (!string.IsNullOrEmpty(value))
                m_FHoraFinal = DateTime.ParseExact(value, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            ;
        }
    }

    public string? FNome { get => m_FNome ?? string.Empty; set => m_FNome = value; }
    public int FCliente { get => m_FCliente; set => m_FCliente = value; }
    public string? FNomeCliente { get => m_FNomeCliente ?? string.Empty; set => m_FNomeCliente = value; }
    public string? FTipo { get => m_FTipo ?? string.Empty; set => m_FTipo = value; }
}