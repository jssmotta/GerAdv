namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBContatoCRMView
{
    [XmlIgnore]
    private protected bool pFldFCGUID, pFldFData, pFldFIP;
    [XmlIgnore]
    private protected string? m_FCGUID, m_FIP;
    [XmlIgnore]
    private protected DateTime? m_FData;
    [StringLength(100, ErrorMessage = "A propriedade FCGUID da tabela ContatoCRMView deve ter no máximo 100 caracteres.")]
    public string? FCGUID
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FCGUID ?? string.Empty;
        set
        {
            pFldFCGUID = pFldFCGUID || !(m_FCGUID ?? string.Empty).Equals(value);
            if (pFldFCGUID)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FCGUID = trimmed.Length > 100 ? trimmed.AsSpan(0, 100).ToString() : trimmed;
            }
        }
    }

    public string? FData
    {
        get => $"{m_FData:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FData:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFData, m_FData, value);
            if (!setUpNow)
                return;
            pFldFData = changed;
            m_FData = data;
        }
    }

    [StringLength(50, ErrorMessage = "A propriedade FIP da tabela ContatoCRMView deve ter no máximo 50 caracteres.")]
    public string? FIP
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FIP ?? string.Empty;
        set
        {
            pFldFIP = pFldFIP || !(m_FIP ?? string.Empty).Equals(value);
            if (pFldFIP)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FIP = trimmed.Length > 50 ? trimmed.AsSpan(0, 50).ToString() : trimmed;
            }
        }
    }

    public int IQuemCad() => 0;
    public int IQuemAtu() => 0;
    public string IDtCadDataX_DataHora() => string.Empty;
    public string IDtAtuDataX_DataHora() => string.Empty;
    [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
    public void SetAuditor(int usuarioId)
    {
    }

    public string ITabelaName() => PTabelaNome;
    public string ICampoCodigo() => CampoCodigo;
    public string ICampoNome() => CampoNome;
    public string IPrefixo() => PTabelaPrefixo;
    public ImmutableArray<DBInfoSystem> IFieldsRaw() => throw new NotImplementedException();
    public ImmutableArray<DBInfoSystem> IPkFields() => throw new NotImplementedException();
    public ImmutableArray<DBInfoSystem> IPkIndicesFields() => throw new NotImplementedException();
#pragma warning disable CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasAuditor() => false;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasNameId() => false;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int GetID() => ID;
}