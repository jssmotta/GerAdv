namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProcessosParados
{
    [XmlIgnore]
    private protected bool pFldFProcesso, pFldFSemana, pFldFAno, pFldFDataHora, pFldFOperador, pFldFDataHistorico, pFldFDataNENotas;
    [XmlIgnore]
    private protected int m_FProcesso, m_FSemana, m_FAno, m_FOperador;
    [XmlIgnore]
    private protected DateTime? m_FDataHora, m_FDataHistorico, m_FDataNENotas;
    public int FProcesso
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FProcesso;
        set
        {
            pFldFProcesso = pFldFProcesso || value != m_FProcesso;
            if (pFldFProcesso)
                m_FProcesso = value;
        }
    }

    public int FSemana
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FSemana;
        set
        {
            pFldFSemana = pFldFSemana || value != m_FSemana;
            if (pFldFSemana)
                m_FSemana = value;
        }
    }

    public int FAno
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FAno;
        set
        {
            pFldFAno = pFldFAno || value != m_FAno;
            if (pFldFAno)
                m_FAno = value;
        }
    }

    public string? FDataHora
    {
        get => $"{m_FDataHora:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataHora:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDataHora, m_FDataHora, value);
            if (!setUpNow)
                return;
            pFldFDataHora = changed;
            m_FDataHora = data;
        }
    }

    public int FOperador
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FOperador;
        set
        {
            pFldFOperador = pFldFOperador || value != m_FOperador;
            if (pFldFOperador)
                m_FOperador = value;
        }
    }

    public string? FDataHistorico
    {
        get => $"{m_FDataHistorico:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataHistorico:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDataHistorico, m_FDataHistorico, value);
            if (!setUpNow)
                return;
            pFldFDataHistorico = changed;
            m_FDataHistorico = data;
        }
    }

    public string? FDataNENotas
    {
        get => $"{m_FDataNENotas:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataNENotas:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDataNENotas, m_FDataNENotas, value);
            if (!setUpNow)
                return;
            pFldFDataNENotas = changed;
            m_FDataNENotas = data;
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