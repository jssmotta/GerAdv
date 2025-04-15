namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBEndTit
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFEndereco, pFldFTitulo;
    [XmlIgnore]
    private protected int m_FEndereco, m_FTitulo;
    public int NFEndereco() => m_FEndereco;
    [XmlAttribute]
    public int FEndereco
    {
        get => m_FEndereco;
        set
        {
            pFldFEndereco = pFldFEndereco || value != m_FEndereco;
            if (pFldFEndereco)
                m_FEndereco = value;
        }
    }

    public int NFTitulo() => m_FTitulo;
    [XmlAttribute]
    public int FTitulo
    {
        get => m_FTitulo;
        set
        {
            pFldFTitulo = pFldFTitulo || value != m_FTitulo;
            if (pFldFTitulo)
                m_FTitulo = value;
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
    public List<DBInfoSystem> IFieldsRaw() => throw new NotImplementedException();
    public List<DBInfoSystem> IPkFields() => throw new NotImplementedException();
    public List<DBInfoSystem> IPkIndicesFields() => throw new NotImplementedException();
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => false;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public int GetID() => ID;
}