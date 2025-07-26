namespace MenphisSI;

/// <summary>
/// Janeiro-2018
/// </summary>
[Serializable]
public class VSexo : VAuditor
{
    private protected ESexo sex = new();
    private protected bool m_FSexo, m_FBold, m_FEtiqueta, m_FAni, pFldFDtNasc, pFldFSexo, pFldFCPF, pFldFEtiqueta, pFldFAni, pFldFBold, pFldFClass, pFldFBairro, pFldFEndereco, pFldFCEP, pFldFCidade;
    private protected int m_FCidade;
    private protected DateTime? m_FDtNasc;

    public bool HasGraph { get; set; }

    public (string abreviacao, string hexColor) ColorGraph
    {
        get
        {
            var abreviacao = sex.m_FNome.ImgFirstLastName();
            return (abreviacao, abreviacao.ColorFirstLastName());
        }
    }

    public string ColorGraphFirstLastName(string abrev) => abrev.ColorFirstLastName();

    public string DivGraph2(string abrev, string cssClass = PImagemCss90)
    {
        var hexColor = abrev.ColorFirstLastName();
        return $@"<div abrev=""{abrev}"" style=""background-color:{hexColor} !important;"" class=""{cssClass}"">&nbsp;</div>";
    }

    public const string PImagemCss90 = "imagemLetra90";
    public string DivGraph(string cssClass = PImagemCss90) => DivGraph(cssClass, string.Empty);
    public string DivGraph(string cssClass, string commands = "")
    {
        var (abreviacao, hexColor) = ColorGraph;
        return $@"<div abrev=""{abreviacao}"" {commands} style=""background-color:{hexColor} !important;"" class=""{cssClass}"">&nbsp;</div>";
    }

   

    public string NFDtNasc() => $"{m_FDtNasc:dd/MM/yyyy}".IsEquals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDtNasc:dd/MM/yyyy}";
    public int NFCidade() => m_FCidade;
    public string NFCPF() => sex.m_FCPF ?? "";
    public string NFClass() => sex.m_FClass;
    public string NFNome() => sex.m_FNome ?? "";
    public string NFBairro() => sex.m_FBairro ?? "";
    public string NFEndereco() => sex.m_FEndereco ?? "";
    public string NFCEP() => sex.m_FCEP ?? "";

    public string ArtigoSexo => m_FSexo ? "o" : "a";
    /// <summary>
    /// Retorna Dra. Fulana da Silva - nome do advogado com tratamento
    /// </summary>
    public string FNomeComTratamentoDr => (m_FSexo ? DevourerOne.PDoutor : DevourerOne.PDoutora) + " " + sex.m_FNome.FirstName();
    /// <summary>
    /// Retornar Sr. ou Sra. para o CloudSystem
    /// </summary>
    public string FNomeProfissionalComTratamentoSr => (m_FSexo ? DevourerOne.PSenhor : DevourerOne.PSenhora) + " " + sex.m_FNome.FirstName();
    /// <summary>
    /// Retornar Sr. ou Sra. para o CloudSystem
    /// </summary>
    public string Tratamento => (m_FSexo ? DevourerOne.PSenhor : DevourerOne.PSenhora); // + " " + m_FNome.FirstLastName();
    /// <summary>
    /// FDtNasc como DateTime
    /// </summary>
    [XmlIgnore]
    public DateTime MDtNasc => Convert.ToDateTime(m_FDtNasc);
    /// <summary>
    /// Campo: advDtNasc
    /// </summary>
    
    // ReSharper disable once InconsistentNaming
    public string FDtNasc
    {
        get => $"{m_FDtNasc:dd/MM/yyyy}".IsEquals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDtNasc:dd/MM/yyyy}";
        set { var (setUpNow, changed, data) = DevourerOne.DateUp12(pFldFDtNasc, m_FDtNasc, value); if (!setUpNow) return; pFldFDtNasc = changed; m_FDtNasc = data; }
    }
    /// <summary>
    /// Campo: advSexo
    /// </summary>
    
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
    
    // ReSharper disable once InconsistentNaming
    public string FCPF
    {
        get => sex.m_FCPF;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                pFldFCPF = pFldFCPF || !string.IsNullOrEmpty(sex.m_FCPF);
                sex.m_FCPF = string.Empty;
            }
            else
            {
                pFldFCPF = pFldFCPF || !sex.m_FCPF.IsEquals(value);
                if (pFldFCPF) sex.m_FCPF = (value != null && value.Trim().Length > 11 ? value.Trim().FixAbc()[..11] : value?.Trim().FixAbc())!; // ABC_FIND_CODE
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
    public virtual string MIdade => !FDtNasc.IsEquals(string.Empty) ? DevourerOne.Idade(MDtNasc).ToString() : string.Empty;
    /// <summary>
    /// Idade em numeral
    /// </summary>
    /// <returns></returns>
    [XmlIgnore]
    public int MIdadeNumeral => MIdade.IsEquals(string.Empty) ? 0 : Convert.ToInt32(DevourerOne.Idade(MDtNasc).ToString());

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
    public string CPFMaskWithInfo() => FCPF.IsEquals(string.Empty)
            ? TConstantes.PCpfNaoInformado
            : DevourerOne.CPFValido(FCPF) ? FCPF.MaskCpf() + TConstantes.PCpfCalculoOK : FCPF.MaskCpf() + TConstantes.PCpfCalculoErro;
    /// <summary>
    /// Campo: Endereco, tamanho: 80
    /// </summary>
    
    // ReSharper disable once InconsistentNaming
    public string FEndereco
    {
        get => sex.m_FEndereco;
        set
        {
            pFldFEndereco = pFldFEndereco || !sex.m_FEndereco.IsEquals(value);
            if (pFldFEndereco) sex.m_FEndereco = value?.FixAbc(80) ?? string.Empty; // ABC_FIND_CODE
        }
    }

    public void SetNome(string nome) => sex.m_FNome = nome;

    /// <summary>
    /// Campo: Bairro, tamanho: 50
    /// </summary>
    
    // ReSharper disable once InconsistentNaming
    public string FBairro
    {
        get => sex.m_FBairro;
        set
        {
            pFldFBairro = pFldFBairro || !sex.m_FBairro.IsEquals(value);
            if (pFldFBairro) sex.m_FBairro = value?.FixAbc(50) ?? string.Empty; // ABC_FIND_CODE
            //if (string.IsNullOrEmpty(value))
            //{
            //    pFldFBairro = pFldFBairro || !string.IsNullOrEmpty(m_FBairro);
            //    m_FBairro = string.Empty;
            //}
            //else
            //{
            //    pFldFBairro = pFldFBairro || !(m_FBairro ?? string.Empty).IsEquals(value);
            //    if (pFldFBairro) m_FBairro = value.Trim().Length > 50 ? value.Trim().FixAbc().Substring(0, 50) : value.Trim().FixAbc(); // ABC_FIND_CODE
            //}
        }
    }

    /// <summary>
    /// Campo: cliCEP, tamanho: 10
    /// </summary>
    
    // ReSharper disable once InconsistentNaming
    public string FCEP
    {
        get => sex.m_FCEP;
        set
        {
            pFldFCEP = pFldFCEP || !sex.m_FCEP.IsEquals(value);
            if (pFldFCEP) sex.m_FCEP = value?.FixAbc(10) ?? string.Empty; // ABC_FIND_CODE
            /*
                if (string.IsNullOrEmpty(value))
                {
                    pFldFCEP = pFldFCEP || !string.IsNullOrEmpty(m_FCEP);
                    m_FCEP = string.Empty;
                }
                else
                {
                    pFldFCEP = pFldFCEP || !(m_FCEP ?? string.Empty).IsEquals(value);
                    if (pFldFCEP) m_FCEP = value.Trim().Length > 10 ? value.Trim().FixAbc().Substring(0, 10) : value.Trim().FixAbc(); // ABC_FIND_CODE
                }
                */
        }
    }

    /// <summary>
    /// Campo: Cidade
    /// </summary>
    
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
    
    // ReSharper disable once InconsistentNaming
    public bool FEtiqueta
    {
        get => m_FEtiqueta;
        set { pFldFEtiqueta = pFldFEtiqueta || (value != m_FEtiqueta); if (pFldFEtiqueta) m_FEtiqueta = value; }
    }
    /// <summary>
    /// Campo: Class[ificação]
    /// </summary>
    
    // ReSharper disable once InconsistentNaming
    public string FClass
    {
        get => sex.m_FClass;
        set { pFldFClass = pFldFClass || (value != sex.m_FClass); if (pFldFClass) sex.m_FClass = value; }
    }
    /// <summary>
    /// Campo: Ani[versário, lembrar]
    /// </summary>
    
    // ReSharper disable once InconsistentNaming
    public bool FAni
    {
        get => m_FAni;
        set { pFldFAni = pFldFAni || (value != m_FAni); if (pFldFAni) m_FAni = value; }
    }
    /// <summary>
    /// Campo: Bold, Negritar
    /// </summary>
    
    // ReSharper disable once InconsistentNaming
    public bool FBold
    {
        get => m_FBold;
        set { pFldFBold = pFldFBold || (value != m_FBold); if (pFldFBold) m_FBold = value; }
    }

    public string NomeNegritarWeb => m_FBold ? $"<b>{sex.m_FNome}</b>" : sex.m_FNome;
}