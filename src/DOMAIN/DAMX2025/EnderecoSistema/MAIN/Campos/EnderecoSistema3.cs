namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBEnderecoSistema
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFCadastro, pFldFCadastroExCod, pFldFTipoEnderecoSistema, pFldFProcesso, pFldFMotivo, pFldFContatoNoLocal, pFldFCidade, pFldFEndereco, pFldFBairro, pFldFCEP, pFldFFone, pFldFFax, pFldFObservacao;
    [XmlIgnore]
    private protected int m_FCadastro, m_FCadastroExCod, m_FTipoEnderecoSistema, m_FProcesso, m_FCidade;
    [XmlIgnore]
    private protected string? m_FMotivo, m_FContatoNoLocal, m_FEndereco, m_FBairro, m_FCEP, m_FFone, m_FFax, m_FObservacao;
    [XmlAttribute]
    public int FCadastro
    {
        get => m_FCadastro;
        set
        {
            pFldFCadastro = pFldFCadastro || value != m_FCadastro;
            if (pFldFCadastro)
                m_FCadastro = value;
        }
    }

    [XmlAttribute]
    public int FCadastroExCod
    {
        get => m_FCadastroExCod;
        set
        {
            pFldFCadastroExCod = pFldFCadastroExCod || value != m_FCadastroExCod;
            if (pFldFCadastroExCod)
                m_FCadastroExCod = value;
        }
    }

    [XmlAttribute]
    public int FTipoEnderecoSistema
    {
        get => m_FTipoEnderecoSistema;
        set
        {
            pFldFTipoEnderecoSistema = pFldFTipoEnderecoSistema || value != m_FTipoEnderecoSistema;
            if (pFldFTipoEnderecoSistema)
                m_FTipoEnderecoSistema = value;
        }
    }

    [XmlAttribute]
    public int FProcesso
    {
        get => m_FProcesso;
        set
        {
            pFldFProcesso = pFldFProcesso || value != m_FProcesso;
            if (pFldFProcesso)
                m_FProcesso = value;
        }
    }

    [XmlAttribute]
    public string? FMotivo
    {
        get => m_FMotivo ?? string.Empty;
        set
        {
            pFldFMotivo = pFldFMotivo || !(m_FMotivo ?? string.Empty).Equals(value);
            if (pFldFMotivo)
                m_FMotivo = value.trim().Length > 200 ? value.trim().substring(0, 200) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public string? FContatoNoLocal
    {
        get => m_FContatoNoLocal ?? string.Empty;
        set
        {
            pFldFContatoNoLocal = pFldFContatoNoLocal || !(m_FContatoNoLocal ?? string.Empty).Equals(value);
            if (pFldFContatoNoLocal)
                m_FContatoNoLocal = value.trim().Length > 50 ? value.trim().substring(0, 50) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public int FCidade
    {
        get => m_FCidade;
        set
        {
            pFldFCidade = pFldFCidade || value != m_FCidade;
            if (pFldFCidade)
                m_FCidade = value;
        }
    }

    [XmlAttribute]
    public string? FEndereco
    {
        get => m_FEndereco ?? string.Empty;
        set
        {
            pFldFEndereco = pFldFEndereco || !(m_FEndereco ?? string.Empty).Equals(value);
            if (pFldFEndereco)
                m_FEndereco = value.trim().Length > 150 ? value.trim().substring(0, 150) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public string? FBairro
    {
        get => m_FBairro ?? string.Empty;
        set
        {
            pFldFBairro = pFldFBairro || !(m_FBairro ?? string.Empty).Equals(value);
            if (pFldFBairro)
                m_FBairro = value.trim().Length > 50 ? value.trim().substring(0, 50) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string CEPMask() => DevourerOne.MaskCep(FCEP);
    [XmlAttribute]
    public string? FCEP
    {
        get => m_FCEP ?? string.Empty;
        set
        {
            pFldFCEP = pFldFCEP || !(m_FCEP ?? string.Empty).Equals(value);
            if (pFldFCEP)
                m_FCEP = value.trim().Length > 10 ? value.trim().substring(0, 10) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public string? FFone
    {
        get => m_FFone ?? string.Empty;
        set
        {
            pFldFFone = pFldFFone || !(m_FFone ?? string.Empty).Equals(value);
            if (pFldFFone)
                m_FFone = value.trim().FixAbc() ?? string.Empty;
        }
    }

    [XmlAttribute]
    public string? FFax
    {
        get => m_FFax ?? string.Empty;
        set
        {
            pFldFFax = pFldFFax || !(m_FFax ?? string.Empty).Equals(value);
            if (pFldFFax)
                m_FFax = value.trim().FixAbc() ?? string.Empty;
        }
    }

    [XmlAttribute]
    public string? FObservacao
    {
        get => m_FObservacao ?? string.Empty;
        set
        {
            pFldFObservacao = pFldFObservacao || !(m_FObservacao ?? string.Empty).Equals(value);
            if (pFldFObservacao)
                m_FObservacao = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public bool IVisto() => m_FVisto;
    public int IQuemCad() => m_FQuemCad;
    public int IQuemAtu() => m_FQuemAtu;
    public DateTime IDtCad() => MDtCad;
    public DateTime IDtAtu() => MDtAtu;
    public string IDtCadDataX_DataHora() => MDtCadDataX_DataHora;
    public string IDtAtuDataX_DataHora() => MDtAtuDataX_DataHora;
    public void SetAuditor(int usuarioId) => AuditorQuem = usuarioId;
    public string IMDtCadDataX_DataHora() => MDtAtuDataX_DataHora;
    public string ITabelaName() => PTabelaNome;
    public string ICampoCodigo() => CampoCodigo;
    public string ICampoNome() => CampoNome;
    public string IPrefixo() => PTabelaPrefixo;
    public List<DBInfoSystem> IFieldsRaw() => throw new NotImplementedException();
    public List<DBInfoSystem> IPkFields() => throw new NotImplementedException();
    public List<DBInfoSystem> IPkIndicesFields() => throw new NotImplementedException();
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public int GetID() => ID;
}