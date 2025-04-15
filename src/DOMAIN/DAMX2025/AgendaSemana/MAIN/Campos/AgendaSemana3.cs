namespace MenphisSI.GerAdv;
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
    public string NFParaNome() => m_FParaNome ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FParaNome { get => m_FParaNome ?? string.Empty; set => m_FParaNome = value; }

    public string NFData() => $"{m_FData:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FData:dd/MM/yyyy}";
    [XmlIgnore]
    public DateTime MData => Convert.ToDateTime(m_FData);

    [XmlAttribute]
    public string? FData { get => $"{m_FData:dd/MM/yyyy}"; set => m_FData = Convert.ToDateTime(value); }

    public int NFFuncionario() => m_FFuncionario;
    [XmlAttribute]
    public int FFuncionario { get => m_FFuncionario; set => m_FFuncionario = value; }

    public int NFAdvogado() => m_FAdvogado;
    [XmlAttribute]
    public int FAdvogado { get => m_FAdvogado; set => m_FAdvogado = value; }

    public string NFHora() => $"{m_FHora:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FHora:HH:mm}";
    [XmlIgnore]
    public DateTime MHora => Convert.ToDateTime(m_FHora);

    [XmlAttribute]
    public string? FHora { get => $"{m_FHora:dd/MM/yyyy}"; set => m_FHora = Convert.ToDateTime(value); }

    public int NFTipoCompromisso() => m_FTipoCompromisso;
    [XmlAttribute]
    public int FTipoCompromisso { get => m_FTipoCompromisso; set => m_FTipoCompromisso = value; }

    public string NFCompromisso() => m_FCompromisso ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FCompromisso { get => m_FCompromisso ?? string.Empty; set => m_FCompromisso = value; }

    public bool NFConcluido() => m_FConcluido;
    [XmlAttribute]
    public bool FConcluido { get => m_FConcluido; set => m_FConcluido = value; }

    public bool NFLiberado() => m_FLiberado;
    [XmlAttribute]
    public bool FLiberado { get => m_FLiberado; set => m_FLiberado = value; }

    public bool NFImportante() => m_FImportante;
    [XmlAttribute]
    public bool FImportante { get => m_FImportante; set => m_FImportante = value; }

    public string NFHoraFinal() => $"{m_FHoraFinal:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FHoraFinal:HH:mm}";
    [XmlIgnore]
    public DateTime MHoraFinal => Convert.ToDateTime(m_FHoraFinal);

    [XmlAttribute]
    public string? FHoraFinal { get => $"{m_FHoraFinal:dd/MM/yyyy}"; set => m_FHoraFinal = Convert.ToDateTime(value); }

    public string NFNome() => m_FNome ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FNome { get => m_FNome ?? string.Empty; set => m_FNome = value; }

    public int NFCliente() => m_FCliente;
    [XmlAttribute]
    public int FCliente { get => m_FCliente; set => m_FCliente = value; }

    public string NFNomeCliente() => m_FNomeCliente ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FNomeCliente { get => m_FNomeCliente ?? string.Empty; set => m_FNomeCliente = value; }

    public string NFTipo() => m_FTipo ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FTipo { get => m_FTipo ?? string.Empty; set => m_FTipo = value; }
}