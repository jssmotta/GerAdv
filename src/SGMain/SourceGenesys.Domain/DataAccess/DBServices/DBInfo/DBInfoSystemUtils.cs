namespace MenphisSI.DB;

public partial class DBInfoSystem
{
    public static bool IsDocumento(int tipo) =>
       tipo == (int)ETipoDadosSysteminfo.SysteminfoTextCpf ||
       tipo == (int)ETipoDadosSysteminfo.SysteminfoTextCnpj;

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


    public static bool IsEMail(int idTipo) =>
         idTipo is ((int)ETipoDadosSysteminfo.SysteminfoTextEmail) or
            ((int)ETipoDadosSysteminfo.SysteminfoTextEmailCob) or
            ((int)ETipoDadosSysteminfo.SysteminfoTextEmailPro);

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
    public static string SqlType(DBInfoSystem item)
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

    public static string SqlSizeByType(DBInfoSystem item)
     =>
         IsData((int)item.FTipo) ? string.Empty :
        (IsText((int)item.FTipo)
            ? (item.FTamanho > 2048 ? "(max)" : $"({item.FTamanho})") : string.Empty
        );

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
}
