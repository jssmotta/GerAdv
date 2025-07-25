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
    [StringLength(60, ErrorMessage = "A propriedade FParaNome da tabela AgendaSemana deve ter no máximo 60 caracteres.")]
    public string? FParaNome {[MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FParaNome ?? string.Empty; set => m_FParaNome = value; }

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

    public int FFuncionario {[MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FFuncionario; set => m_FFuncionario = value; }
    public int FAdvogado {[MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FAdvogado; set => m_FAdvogado = value; }

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

    public int FTipoCompromisso {[MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FTipoCompromisso; set => m_FTipoCompromisso = value; }
    public string? FCompromisso {[MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FCompromisso ?? string.Empty; set => m_FCompromisso = value; }
    public bool FConcluido {[MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FConcluido; set => m_FConcluido = value; }
    public bool FLiberado {[MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FLiberado; set => m_FLiberado = value; }
    public bool FImportante {[MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FImportante; set => m_FImportante = value; }

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

    [StringLength(80, ErrorMessage = "A propriedade FNome da tabela AgendaSemana deve ter no máximo 80 caracteres.")]
    public string? FNome {[MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FNome ?? string.Empty; set => m_FNome = value; }
    public int FCliente {[MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FCliente; set => m_FCliente = value; }

    [StringLength(80, ErrorMessage = "A propriedade FNomeCliente da tabela AgendaSemana deve ter no máximo 80 caracteres.")]
    public string? FNomeCliente {[MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FNomeCliente ?? string.Empty; set => m_FNomeCliente = value; }

    [StringLength(100, ErrorMessage = "A propriedade FTipo da tabela AgendaSemana deve ter no máximo 100 caracteres.")]
    public string? FTipo {[MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FTipo ?? string.Empty; set => m_FTipo = value; }
}