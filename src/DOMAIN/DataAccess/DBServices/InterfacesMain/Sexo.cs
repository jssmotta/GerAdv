
namespace MenphisSI.Internal;

/// <summary>
/// Janeiro-2018
/// </summary>
[Serializable]
internal class VSexo : VAuditor
{
    private protected bool m_FSexo, m_FBold, m_FEtiqueta, m_FAni, pFldFDtNasc, pFldFSexo, pFldFCPF, pFldFEtiqueta, pFldFAni, pFldFBold, pFldFClass, pFldFBairro, pFldFEndereco, pFldFCEP, pFldFCidade;
    private protected string? m_FCPF, m_FClass, m_FBairro, m_FEndereco, m_FCEP;
    private protected int m_FCidade;
    private protected DateTime? m_FDtNasc;

    public string ArtigoSexo => m_FSexo ? "o" : "a";
  
    public string Tratamento => (m_FSexo ? DevourerOne.PSenhor : DevourerOne.PSenhora); // + " " + m_FNome.FirstLastName();
    /// <summary>
    /// FDtNasc como DateTime
    /// </summary>
    [XmlIgnore]
    public DateTime MDtNasc => Convert.ToDateTime(m_FDtNasc);
    /// <summary>
    /// Campo: advDtNasc
    /// </summary>
    [XmlAttribute]
    // ReSharper disable once InconsistentNaming
    public string FDtNasc
    {
        get => $"{m_FDtNasc:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDtNasc:dd/MM/yyyy}";
        set { var (setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDtNasc, m_FDtNasc, value); if (!setUpNow) return; pFldFDtNasc = changed; m_FDtNasc = data; }
    }
    /// <summary>
    /// Campo: advSexo
    /// </summary>
    [XmlAttribute]
    // ReSharper disable once InconsistentNaming
    public bool FSexo
    {
        get => m_FSexo;
        set { if (value == m_FSexo) return; pFldFSexo = true; m_FSexo = value; }
    }
    /// <summary>
    /// Coloca máscara no CPF
    /// </summary>
    /// <returns></returns>
    public string MaskCPF => FCPF.MaskCpf();
    /// <summary>
    /// Campo: advCPF, tamanho: 11
    /// </summary>
    [XmlAttribute]
    // ReSharper disable once InconsistentNaming
    public string FCPF
    {
        get => m_FCPF ?? string.Empty;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                pFldFCPF = pFldFCPF || !string.IsNullOrEmpty(m_FCPF);
                m_FCPF = string.Empty;
            }
            else
            {
                pFldFCPF = pFldFCPF || !(m_FCPF ?? string.Empty).Equals(value);
                if (pFldFCPF) m_FCPF = value.Trim().Length > 11 ? value.Trim().FixAbc()[..11] : value.Trim().FixAbc(); // ABC_FIND_CODE
            }
        }
    }

    /// <summary>
    /// Dia do nascimento
    /// </summary>
    [XmlIgnore]
    public string DiaNascimento => $"{MDtNasc:dd}";
    /// <summary>
    /// Idade em string
    /// </summary>
    /// <returns></returns>
    [XmlIgnore]
    public virtual string MIdade => !FDtNasc.Equals(string.Empty) ? DevourerOne.Idade(MDtNasc).ToString() : string.Empty;
    /// <summary>
    /// Idade em numeral
    /// </summary>
    /// <returns></returns>
    [XmlIgnore]
    public int MIdadeNumeral => MIdade.Equals(string.Empty) ? 0 : Convert.ToInt32(DevourerOne.Idade(MDtNasc).ToString());

    /// <summary>
    /// Indicação que este registro se refere a uma pessoa do sexo masculino
    /// </summary>
    public bool Homem { get => m_FSexo; set => m_FSexo = value; }

    /// <summary>
    /// Indicação que este registro se refere a uma pessoa do sexo feminino
    /// </summary>
    public bool Mulher { get => !m_FSexo; set => m_FSexo = !value; }

    /// <summary>
    /// 07-01-2017 15:05
    /// </summary>
    public string SexoMasculinoFeminino => m_FSexo ? "Masculino" : "Feminino";

    /// <summary>
    /// Atribui a hora junto com Data
    /// </summary>
    [XmlIgnore]
    public DateTime FDtNascWithHora
    {
        set
        {
            pFldFDtNasc = true;
            m_FDtNasc = value;
        }
    }
    /// <summary>
    /// FDtNasc com a Data e a Hora
    /// </summary>
    [XmlIgnore]
    public string MDtNascDataX_DataHora => $"{m_FDtNasc:dd/MM/yyyy HH:mm:ss}";
    /// <summary>
    /// FDtNasc somente com a Hora
    /// </summary>
    [XmlIgnore]
    public string MDtNascX_Hora => $"{m_FDtNasc:HH:mm:ss}";
    /// <summary>
    /// É Sexo
    /// </summary>
    [XmlIgnore]
    public bool IsSexo => m_FSexo;
    /// <summary>
    /// Não é Sexo
    /// </summary>
    [XmlIgnore]
    public bool NotIsSexo => !m_FSexo;
    /// <summary>
    /// string Sim/Não
    /// </summary>
    public string MSexoYN => m_FSexo ? TConstantes.PSim : TConstantes.PNao;
    /// <summary>
    /// Retorna o CPF com máscará e informação de validação do CPF
    /// </summary>
    /// <returns></returns>
    public string CPFMaskWithInfo() => FCPF.Equals(string.Empty)
            ? TConstantes.PCpfNaoInformado
            : DevourerOne.CPFValido(FCPF) ? FCPF.MaskCpf() + TConstantes.PCpfCalculoOK : FCPF.MaskCpf() + TConstantes.PCpfCalculoErro;
    /// <summary>
    /// Campo: Endereco, tamanho: 80
    /// </summary>
    [XmlAttribute]
    // ReSharper disable once InconsistentNaming
    public string FEndereco
    {
        get => m_FEndereco ?? string.Empty;
        set
        {
            pFldFEndereco = pFldFEndereco || !(m_FEndereco ?? string.Empty).Equals(value);
            if (pFldFEndereco) m_FEndereco = value.FixAbc(80); // ABC_FIND_CODE
        }
    }
    /// <summary>
    /// Campo: Bairro, tamanho: 50
    /// </summary>
    [XmlAttribute]
    // ReSharper disable once InconsistentNaming
    public string FBairro
    {
        get => m_FBairro ?? string.Empty;
        set
        {
            pFldFBairro = pFldFBairro || !(m_FBairro ?? string.Empty).Equals(value);
            if (pFldFBairro) m_FBairro = value.FixAbc(50);  
        }
    }

    /// <summary>
    /// Campo: cliCEP, tamanho: 10
    /// </summary>
    [XmlAttribute]
    // ReSharper disable once InconsistentNaming
    public string FCEP
    {
        get => m_FCEP ?? string.Empty;
        set
        {
            pFldFCEP = pFldFCEP || !(m_FCEP ?? string.Empty).Equals(value);
            if (pFldFCEP) m_FCEP = value.FixAbc(10); // ABC_FIND_CODE
             
        }
    }

    /// <summary>
    /// Campo: Cidade
    /// </summary>
    [XmlAttribute]
    // ReSharper disable once InconsistentNaming
    public int FCidade
    {
        get => m_FCidade;
        set { pFldFCidade = pFldFCidade || (value != m_FCidade); if (pFldFCidade) m_FCidade = value; }
    }

    /// <summary>
    /// CEP com máscara
    /// </summary>
    /// <returns></returns>
    public string CEPMask() => FCEP.MaskCep();
    public string MaskCEP => FCEP.MaskCep();

    /// <summary>
    /// Campo: Etiqueta
    /// </summary>
    [XmlAttribute]
    // ReSharper disable once InconsistentNaming
    public bool FEtiqueta
    {
        get => m_FEtiqueta;
        set { pFldFEtiqueta = pFldFEtiqueta || (value != m_FEtiqueta); if (pFldFEtiqueta) m_FEtiqueta = value; }
    }
    /// <summary>
    /// Campo: Class[ificação]
    /// </summary>
    [XmlAttribute]
    // ReSharper disable once InconsistentNaming
    public string FClass
    {
        get => m_FClass ?? string.Empty;
        set { pFldFClass = pFldFClass || (value != m_FClass); if (pFldFClass) m_FClass = value; }
    }
    /// <summary>
    /// Campo: Ani[versário, lembrar]
    /// </summary>
    [XmlAttribute]
    // ReSharper disable once InconsistentNaming
    public bool FAni
    {
        get => m_FAni;
        set { pFldFAni = pFldFAni || (value != m_FAni); if (pFldFAni) m_FAni = value; }
    }
    /// <summary>
    /// Campo: Bold, Negritar
    /// </summary>
    [XmlAttribute]
    // ReSharper disable once InconsistentNaming
    public bool FBold
    {
        get => m_FBold;
        set { pFldFBold = pFldFBold || (value != m_FBold); if (pFldFBold) m_FBold = value; }
    }

 
}

