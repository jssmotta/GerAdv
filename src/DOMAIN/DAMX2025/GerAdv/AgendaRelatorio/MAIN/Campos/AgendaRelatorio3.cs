namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAgendaRelatorio
{
    [XmlIgnore]
    private protected int m_FProcesso;
    [XmlIgnore]
    private protected string? m_FParaNome, m_FParaPessoas, m_FBoxAudiencia, m_FBoxAudienciaMobile, m_FNomeAdvogado, m_FNomeForo, m_FNomeJustica, m_FNomeArea;
    [XmlIgnore]
    private protected DateTime? m_FData;
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

    public int FProcesso { get => m_FProcesso; set => m_FProcesso = value; }
    public string? FParaNome { get => m_FParaNome ?? string.Empty; set => m_FParaNome = value; }
    public string? FParaPessoas { get => m_FParaPessoas ?? string.Empty; set => m_FParaPessoas = value; }
    public string? FBoxAudiencia { get => m_FBoxAudiencia ?? string.Empty; set => m_FBoxAudiencia = value; }
    public string? FBoxAudienciaMobile { get => m_FBoxAudienciaMobile ?? string.Empty; set => m_FBoxAudienciaMobile = value; }
    public string? FNomeAdvogado { get => m_FNomeAdvogado ?? string.Empty; set => m_FNomeAdvogado = value; }
    public string? FNomeForo { get => m_FNomeForo ?? string.Empty; set => m_FNomeForo = value; }
    public string? FNomeJustica { get => m_FNomeJustica ?? string.Empty; set => m_FNomeJustica = value; }
    public string? FNomeArea { get => m_FNomeArea ?? string.Empty; set => m_FNomeArea = value; }
}