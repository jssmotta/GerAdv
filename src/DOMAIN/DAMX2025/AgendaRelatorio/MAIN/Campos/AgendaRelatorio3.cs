namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAgendaRelatorio
{
    [XmlIgnore]
    private protected int m_FProcesso;
    [XmlIgnore]
    private protected string? m_FParaNome, m_FParaPessoas, m_FBoxAudiencia, m_FBoxAudienciaMobile, m_FNomeAdvogado, m_FNomeForo, m_FNomeJustica, m_FNomeArea;
    [XmlIgnore]
    private protected DateTime? m_FData;
    public string NFData() => $"{m_FData:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FData:dd/MM/yyyy}";
    [XmlIgnore]
    public DateTime MData => Convert.ToDateTime(m_FData);

    [XmlAttribute]
    public string? FData { get => $"{m_FData:dd/MM/yyyy}"; set => m_FData = Convert.ToDateTime(value); }

    public int NFProcesso() => m_FProcesso;
    [XmlAttribute]
    public int FProcesso { get => m_FProcesso; set => m_FProcesso = value; }

    public string NFParaNome() => m_FParaNome ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FParaNome { get => m_FParaNome ?? string.Empty; set => m_FParaNome = value; }

    public string NFParaPessoas() => m_FParaPessoas ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FParaPessoas { get => m_FParaPessoas ?? string.Empty; set => m_FParaPessoas = value; }

    public string NFBoxAudiencia() => m_FBoxAudiencia ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FBoxAudiencia { get => m_FBoxAudiencia ?? string.Empty; set => m_FBoxAudiencia = value; }

    public string NFBoxAudienciaMobile() => m_FBoxAudienciaMobile ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FBoxAudienciaMobile { get => m_FBoxAudienciaMobile ?? string.Empty; set => m_FBoxAudienciaMobile = value; }

    public string NFNomeAdvogado() => m_FNomeAdvogado ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FNomeAdvogado { get => m_FNomeAdvogado ?? string.Empty; set => m_FNomeAdvogado = value; }

    public string NFNomeForo() => m_FNomeForo ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FNomeForo { get => m_FNomeForo ?? string.Empty; set => m_FNomeForo = value; }

    public string NFNomeJustica() => m_FNomeJustica ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FNomeJustica { get => m_FNomeJustica ?? string.Empty; set => m_FNomeJustica = value; }

    public string NFNomeArea() => m_FNomeArea ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FNomeArea { get => m_FNomeArea ?? string.Empty; set => m_FNomeArea = value; }
}