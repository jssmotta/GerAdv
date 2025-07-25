namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAndComp
{
    [XmlIgnore]
    private protected bool pFldFAndamento, pFldFCompromisso;
    [XmlIgnore]
    private protected int m_FAndamento, m_FCompromisso;
    public int FAndamento
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FAndamento;
        set
        {
            pFldFAndamento = pFldFAndamento || value != m_FAndamento;
            if (pFldFAndamento)
                m_FAndamento = value;
        }
    }

    public int FCompromisso
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FCompromisso;
        set
        {
            pFldFCompromisso = pFldFCompromisso || value != m_FCompromisso;
            if (pFldFCompromisso)
                m_FCompromisso = value;
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