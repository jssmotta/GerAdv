namespace MenphisSI.DB;

[Serializable]
public partial class DBInfoSystem : IDBInfoSystem
{
    public string NomeSemPrefixo()
    {
        var result = Prefixo.Length > 0 && FNome.StartsWith(Prefixo) ? FNome.Substring(Prefixo.Length) : FNome;
        return result.Equals("") ? "CampoCodigo" : result;
    }

    public string GetForeingTabela() => FForeingKeyTable ?? string.Empty; 
     

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

    public EGroupSepDados Grupo { get; set; }
    /// <summary>
    /// Nome da tabela
    /// </summary>

    public string TTabela { get; set; }
    /// <summary>
    /// Campo código ( ) da tabela
    /// </summary>

    public string TCampoCodigo { get; set; }
    /// <summary>
    /// Nome do campo no banco de dados
    /// </summary>

    public string FNome { get; set; }
    /// <summary>
    /// Tipo do dado no banco de dados
    /// </summary>

    public ETipoDadosSysteminfo FTipo { get; set; }
    /// <summary>
    /// O campo nome é chave
    /// </summary>

    public bool FIsKeyNome { get; set; }
    /// <summary>
    /// O campo código é chave
    /// </summary>

    public bool FIsKeyCodigo { get; set; }
    /// <summary>
    /// Tabela da Chave estrangeira
    /// </summary>

    public string? FForeingKey { get; set; }
    /// <summary>
    /// Nome da Tabela da Chave estrangeira
    /// </summary>

    public string? FForeingKeyTable { get; set; }
    /// <summary>
    /// DicInfo, Objeto da Tabela da Chave estrangeira
    /// </summary>

    public IODicInfo? FForeingObject { get; set; }
    /// <summary>
    /// O campo é pesquisável? Padrão: NOME, CEP, ENDEREÇO, BAIRRO, FONE, FAX, EMAIL, HOMEPAGE
    /// </summary>

    public bool FPesquisavel { get; set; }
     

    public bool FForeingKeyObrigatoria { get; set; }
    /// <summary>
    /// Tamanho máximo de campos tipo texto
    /// </summary>

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
    /// Caption para as janelas do sistema e formulários
    /// </summary>

    public string FCaption { get; set; }
    /// <summary>
    /// Tooltip para os campos para das janelas do sistema e formulários
    /// </summary>

    public string FTooltip { get; set; }
    public bool IsRequired { get; internal set; }
    // Changed Prefixo from internal set to public set for testability
    public string Prefixo { get; set; } = string.Empty;
   
    public string GetTabelaNome() => TTabela;
    public string GetCampoNome() => FNome;

}
