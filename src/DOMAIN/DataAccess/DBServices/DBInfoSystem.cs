namespace MenphisSI.DB;
 
[Serializable]
public class DBInfoSystem : IDBInfoSystem
{

   

    public string GetForeingTabela() => FForeingKeyTable ?? string.Empty;
   
    public bool TipoData() =>
        FTipo is ETipoDadosSysteminfo.SysteminfoDataCadastramento or
        ETipoDadosSysteminfo.SysteminfoDataInicio or
        ETipoDadosSysteminfo.SysteminfoDataModificacao or
        ETipoDadosSysteminfo.SysteminfoDataNascimento or
        ETipoDadosSysteminfo.SysteminfoDataTermino;

 
    public static string GetGroupSepDescription(EGroupSepDados grupo)
    =>
         ((int)grupo) switch
         {
             (int)EGroupSepDados.GroupSepBasico => "B\u00E1sico",
             (int)EGroupSepDados.GroupSepInformacao => "Informa\u00E7\u00F5es",
             (int)EGroupSepDados.GroupSepDadosPF => "Dados de Pessoa f\u00EDsica",
             (int)EGroupSepDados.GroupSepDadosPJ => "Dados de Pessoa jur\u00EDdica",
             (int)EGroupSepDados.GroupSepRepresentante => "Representante",
             (int)EGroupSepDados.GroupSepPeriodo => "Per\u00EDodo",
             (int)EGroupSepDados.GroupSepContato => "Contato",
             (int)EGroupSepDados.GroupSepCarteiraTrabalho => "Carteira de trabalho",
             (int)EGroupSepDados.GroupSepEndereco => "Endere\u00E7o",
             (int)EGroupSepDados.GroupSepDadosGerais => "Dados gerais",
             (int)EGroupSepDados.GroupSepConfig => "Configura\u00E7\u00E3o do registro",
             (int)EGroupSepDados.GroupSepAuditor => "Auditor do Sistema",
             _ => string.Empty,
         };
    /// <summary>
    /// Database Information System
    /// </summary>
    //public DBInfoSystem() { }

    /// <summary>
    /// Criar objecto InfoSystem on TheFly
    /// </summary>
    /// <param name="nome"></param>
    /// <param name="tamanho"></param>
    /// <param name="caption"></param>
    public DBInfoSystem(byte grupo,
                        string tabela, string tabelaCampoCodigo, string nome,
                        int tamanho,
                        string caption, string tooltip,
                        ETipoDadosSysteminfo tipo,
                        bool pesquisavel,
                        bool keyNome,
                        bool keyCodigo
                        )
    {
        TTabela = tabela;
        TCampoCodigo = tabelaCampoCodigo;
        FNome = nome;
        FCaption = caption;
        FTooltip = tooltip;
        FTamanho = tamanho;
        FTipo = tipo;
        FPesquisavel = pesquisavel;
        FIsKeyNome = keyNome;
        FIsKeyCodigo = keyCodigo;
        Grupo = (EGroupSepDados)grupo;
    }
    /// <summary>
    /// 26-01-2017 22:45
    /// </summary>
    /// <param name="grupo"></param>
    /// <param name="tabela"></param>
    /// <param name="tabelaCampoCodigo"></param>
    /// <param name="nome"></param>
    /// <param name="caption"></param>
    /// <param name="tooltip"></param>
    /// <param name="tipo"></param>
    public DBInfoSystem(int grupo,
                   string tabela, string tabelaCampoCodigo, string nome,
                   string caption, string tooltip,
                   ETipoDadosSysteminfo tipo
                   )
    {
        TTabela = tabela;
        TCampoCodigo = tabelaCampoCodigo;
        FNome = nome;
        FCaption = caption;
        FTooltip = tooltip;
        FTamanho = -1;
        FTipo = tipo;
        FPesquisavel = true;
        FIsKeyNome = false;
        FIsKeyCodigo = false;
        Grupo = (EGroupSepDados)grupo;
    }
    /// <summary>
    /// Campos relacionados
    /// </summary>
    /// <param name="nome"></param>
    /// <param name="tamanho"></param>
    /// <param name="caption"></param>
    /// <param name="tipo"></param>
    /// <param name="foreingKey"></param>
    /// <param name="foreingKeyTable"></param>
    public DBInfoSystem(int grupo, string tabela,
        string tabelaCampoCodigo,
        string nome,
        //int tamanho,
        string caption, string tooltip,
        ETipoDadosSysteminfo tipo,
        string foreingKey,
        string foreingKeyTable,
        IODicInfo foreingObject,
        bool foreingKeyObrigatoria)
    {
        TTabela = tabela;
        TCampoCodigo = tabelaCampoCodigo;
        FNome = nome;
        FCaption = caption;
        FTooltip = tooltip;
        FTamanho = -1;// tamanho;
        FTipo = tipo;
        FForeingKey = foreingKey;
        FForeingKeyTable = foreingKeyTable;
        FForeingKeyObrigatoria = foreingKeyObrigatoria;
        FForeingObject = foreingObject;
        Grupo = (EGroupSepDados)grupo;
    }
    /// <summary>
    /// Campos comuns
    /// </summary>
    /// <param name="nome"></param>
    /// <param name="tamanho"></param>
    /// <param name="caption"></param>
    /// <param name="tipo"></param>
    /// <param name="pesquisavel"></param>
    public DBInfoSystem(byte grupo, string tabela, string tabelaCampoCodigo, string nome,
               int tamanho,
               string caption, string tooltip,
               ETipoDadosSysteminfo tipo,
               bool pesquisavel
               )
    {
        TTabela = tabela;
        FTooltip = tooltip;
        TCampoCodigo = tabelaCampoCodigo;
        FNome = nome;
        FCaption = caption;
        FTamanho = tamanho;
        FTipo = tipo;
        FPesquisavel = pesquisavel;
        Grupo = (EGroupSepDados)grupo;
    }
    /// <summary>
    /// Grupo de dados
    /// </summary>
    [XmlAttribute]
    public EGroupSepDados Grupo { get; set; }
    /// <summary>
    /// Nome da tabela
    /// </summary>
    [XmlAttribute]
    public string TTabela { get; set; }
    /// <summary>
    /// Campo código ( ) da tabela
    /// </summary>
    [XmlAttribute]
    public string TCampoCodigo { get; set; }
    /// <summary>
    /// Nome do campo no banco de dados
    /// </summary>
    [XmlAttribute]
    public string FNome { get; set; }
    /// <summary>
    /// Tipo do dado no banco de dados
    /// </summary>
    [XmlAttribute]
    public ETipoDadosSysteminfo FTipo { get; set; }
    /// <summary>
    /// O campo nome é chave
    /// </summary>
    [XmlAttribute]
    public bool FIsKeyNome { get; set; }
    /// <summary>
    /// O campo código é chave
    /// </summary>
    [XmlAttribute]
    public bool FIsKeyCodigo { get; set; }
    /// <summary>
    /// Tabela da Chave estrangeira
    /// </summary>
    [XmlAttribute]
    public string? FForeingKey { get; set; }
    /// <summary>
    /// Nome da Tabela da Chave estrangeira
    /// </summary>
    [XmlAttribute]
    public string? FForeingKeyTable { get; set; }
    /// <summary>
    /// DicInfo, Objeto da Tabela da Chave estrangeira
    /// </summary>
    [XmlAttribute]
    public IODicInfo? FForeingObject { get; set; }
    /// <summary>
    /// O campo é pesquisável? Padrão: NOME, CEP, ENDEREÇO, BAIRRO, FONE, FAX, EMAIL, HOMEPAGE
    /// </summary>
    [XmlAttribute]
    public bool FPesquisavel { get; set; }
    /// <summary>
    /// Ocultar campo para edição
    /// </summary>
    //[XmlAttribute]
    //public bool FHidden { get; set; }
    /// <summary>
    /// Mensagem de validação
    /// </summary>
    //[XmlAttribute]
    //public string FMensagemValidacao { get; set; }
    /// <summary>
    /// Chave estrangeira obrigatória
    /// </summary>
    [XmlAttribute]
    public bool FForeingKeyObrigatoria { get; set; }
    /// <summary>
    /// Tamanho máximo de campos tipo texto
    /// </summary>
    [XmlAttribute]
    public int FTamanho { get; set; }
    /// <summary>
    /// Tamanho para os campos com máscara
    /// </summary>
    [XmlIgnore]
    public int FTamanhoX
    {
        get
        {
            if (FTipo == ETipoDadosSysteminfo.SysteminfoTextCpf) return FTamanho + 3;
            else if (FTipo == ETipoDadosSysteminfo.SysteminfoTextCnpj) return FTamanho + 4;
            else if (FTipo == ETipoDadosSysteminfo.SysteminfoTextCep) return 10;

            return IsDataFixedSize(FTipo) ? 10 : FTamanho;
        }
    }
    /// <summary>
    /// Tamanho fixo de 10 casas para as datas
    /// </summary>
    /// <param name="eTipoDadosSysteminfo"></param>
    /// <returns></returns>
    public static bool IsDataFixedSize(ETipoDadosSysteminfo eTipoDadosSysteminfo)

        => (eTipoDadosSysteminfo is ETipoDadosSysteminfo.SysteminfoDataInicio or
                 ETipoDadosSysteminfo.SysteminfoDataTermino or
                 ETipoDadosSysteminfo.SysteminfoDatetime or
                 ETipoDadosSysteminfo.SysteminfoDataNascimento);

    /// <summary>
    /// Caption para as janelas do sistema e formulários
    /// </summary>
    [XmlAttribute]
    public string FCaption { get; set; }
    /// <summary>
    /// Tooltip para os campos para das janelas do sistema e formulários
    /// </summary>
    [XmlAttribute]
    public string FTooltip { get; set; }

    private static string GetNomeCampoByInfoSystem(ETipoDadosSysteminfo eTipoDadosSysteminfo, List<DBInfoSystem> lista)
    {
        for (var nt = 0; nt < lista.Count; nt++)
            if ((int)eTipoDadosSysteminfo == (int)lista[nt].FTipo) return lista[nt].FNome;
        return string.Empty;
    }

    private static string GetNomeCampoByInfoSystem(ETipoDadosSysteminfo eTipoDadosSysteminfo, List<DBInfoSystem> lista, string cInclude)
    {
        for (var nt = 0; nt < lista.Count; nt++)
            if ((int)eTipoDadosSysteminfo == (int)lista[nt].FTipo)
                if (lista[nt].FNome.IndexOf(cInclude, StringComparison.CurrentCultureIgnoreCase) != -1) return lista[nt].FNome;

        return string.Empty;
    }
    /// <summary>
    /// Indica se o campo é do tipo Texto
    /// </summary>
    public static bool IsText(int idTipo) =>
               idTipo == (int)ETipoDadosSysteminfo.SysteminfoTextGuid ||
               idTipo == (int)ETipoDadosSysteminfo.SysteminfoTextClassificacaoStar ||
               (idTipo >= 20 && idTipo <= 39) ||
               idTipo == (int)ETipoDadosSysteminfo.SysteminfoTextCnh ||
               IsMemo(idTipo);
    /// <summary>
    /// Fone/fax repete com o isText
    /// </summary>
    /// <param name="idTipo"></param>
    /// <returns></returns>
    public static bool IsMemo(int idTipo) =>
               idTipo is ((int)ETipoDadosSysteminfo.SysteminfoMemo) or
               ((int)ETipoDadosSysteminfo.SysteminfoMemoObservacao) or
               ((int)ETipoDadosSysteminfo.SysteminfoTextFax) or
               ((int)ETipoDadosSysteminfo.SysteminfoTextFone);
    /// <summary>
    /// Indica se é Int
    /// </summary>
    /// <param name="idTipo"></param>
    /// <returns></returns>
    public static bool IsForeingKey(int idTipo) =>
               idTipo is ((int)ETipoDadosSysteminfo.SysteminfoForeingkey) or
               ((int)ETipoDadosSysteminfo.SysteminfoForeingkeyCidade) or
               ((int)ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu) or
               ((int)ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad);
    /// <summary>
    /// Indica se é um tipo [int]
    /// </summary>
    /// <param name="idTipo"></param>
    /// <returns></returns>
    public static bool IsNumber(int idTipo) =>
         idTipo == (int)ETipoDadosSysteminfo.SysteminfoNumber || IsForeingKey(idTipo);
    /// <summary>
    /// indica se é um tipo [float]
    /// </summary>
    /// <param name="idTipo"></param>
    /// <returns></returns>
    public static bool IsDoubleOrDecimal(int idTipo) =>
        idTipo is ((int)ETipoDadosSysteminfo.SysteminfoDouble) or
        ((int)ETipoDadosSysteminfo.SysteminfoDoubleSalario);
    /// <summary>
    /// Indica se é do tipo Bool
    /// </summary>
    /// <param name="idTipo"></param>
    /// <returns></returns>
    public static bool IsBoolean(int idTipo) =>
        idTipo is ((int)ETipoDadosSysteminfo.SysteminfoBoolean) or
        ((int)ETipoDadosSysteminfo.SysteminfoBooleanBold) or
        ((int)ETipoDadosSysteminfo.SysteminfoBooleanEtiqueta) or
        ((int)ETipoDadosSysteminfo.SysteminfoBooleanSexo) or
        ((int)ETipoDadosSysteminfo.SysteminfoBooleanTipoPessoa) or
        ((int)ETipoDadosSysteminfo.SysteminfoBooleanVisto) or
        ((int)ETipoDadosSysteminfo.SysteminfoBooleanLembrarAniversario);
    /// <summary>
    /// Indica se o campo é tipo [DateTime]
    /// </summary>
    /// <param name="idTipo"></param>
    /// <returns></returns>
    public static bool IsData(int idTipo) =>
            idTipo is ((int)ETipoDadosSysteminfo.SysteminfoDataCadastramento) or
            ((int)ETipoDadosSysteminfo.SysteminfoDataInicio) or
            ((int)ETipoDadosSysteminfo.SysteminfoDataTermino) or
            ((int)ETipoDadosSysteminfo.SysteminfoDataModificacao) or
            ((int)ETipoDadosSysteminfo.SysteminfoDataNascimento) or
            ((int)ETipoDadosSysteminfo.SysteminfoDatetime);
    /// <summary>
    /// Passa o tipo do campo para o SQLmontar o CreateTable
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    internal static string SqlType(DBInfoSystem item)
    {
        var idTipo = (int)item.FTipo;

        if (IsData(idTipo))
            return "datetime";
        else if (IsBoolean(idTipo))
            return "bit";
        else if (IsDoubleOrDecimal(idTipo))
            return "float";
        else if (IsInteger(idTipo))
            return "int";
        else if (item.FTamanho > 0)
            return "nvarchar";

        throw new(message: "Tipo desconhecido, shadow 0x900x9999x192391");
    }
    /// <summary>
    /// Indica se é um campo tipo [int]
    /// </summary>
    /// <param name="idTipo"></param>
    /// <returns></returns>
    private static bool IsInteger(int idTipo) =>
         IsForeingKey(idTipo) || idTipo == (int)ETipoDadosSysteminfo.SysteminfoNumber;

    internal static string SqlSizeByType(DBInfoSystem item)
     =>
         IsData((int)item.FTipo) ? string.Empty :
        (IsText((int)item.FTipo)
            ? (item.FTamanho > 2048 ? "(max)" : $"({item.FTamanho})") : string.Empty
        );
    public string GetTabelaNome() => TTabela;
    public string GetCampoNome() => FNome;
}
