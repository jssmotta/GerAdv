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

    public int FProcesso {[MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FProcesso; set => m_FProcesso = value; }

    [StringLength(60, ErrorMessage = "A propriedade FParaNome da tabela AgendaRelatorio deve ter no máximo 60 caracteres.")]
    public string? FParaNome {[MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FParaNome ?? string.Empty; set => m_FParaNome = value; }
    public string? FParaPessoas {[MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FParaPessoas ?? string.Empty; set => m_FParaPessoas = value; }
    public string? FBoxAudiencia {[MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FBoxAudiencia ?? string.Empty; set => m_FBoxAudiencia = value; }
    public string? FBoxAudienciaMobile {[MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FBoxAudienciaMobile ?? string.Empty; set => m_FBoxAudienciaMobile = value; }

    [StringLength(50, ErrorMessage = "A propriedade FNomeAdvogado da tabela AgendaRelatorio deve ter no máximo 50 caracteres.")]
    public string? FNomeAdvogado {[MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FNomeAdvogado ?? string.Empty; set => m_FNomeAdvogado = value; }

    [StringLength(40, ErrorMessage = "A propriedade FNomeForo da tabela AgendaRelatorio deve ter no máximo 40 caracteres.")]
    public string? FNomeForo {[MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FNomeForo ?? string.Empty; set => m_FNomeForo = value; }

    [StringLength(50, ErrorMessage = "A propriedade FNomeJustica da tabela AgendaRelatorio deve ter no máximo 50 caracteres.")]
    public string? FNomeJustica {[MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FNomeJustica ?? string.Empty; set => m_FNomeJustica = value; }

    [StringLength(40, ErrorMessage = "A propriedade FNomeArea da tabela AgendaRelatorio deve ter no máximo 40 caracteres.")]
    public string? FNomeArea {[MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FNomeArea ?? string.Empty; set => m_FNomeArea = value; }
}