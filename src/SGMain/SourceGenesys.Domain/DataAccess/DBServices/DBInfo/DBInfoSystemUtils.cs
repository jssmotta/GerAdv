namespace MenphisSI.DB;

public partial class DBInfoSystem
{
    public static string[] AuditorFields =
    [
        "QuemCad",
        "DtCad",
        "QuemAtu",
        "DtAtu",
        "Visto"
    ]; 

    public static bool IsAuditor(DBInfoSystem campo)
    {
        var prefixo = campo.Prefixo;
        return AuditorFields.Any(a => campo.FNome.Equals(prefixo + a));    
    }

    public static string AuditorCaption(DBInfoSystem campo)
    {
        var prefixo = campo.Prefixo;
        var fieldName = campo.FNome;

        return fieldName switch
        {
            var name when name.Equals(prefixo + AuditorFields[0]) => "Quem cadastrou",
            var name when name.Equals(prefixo + AuditorFields[1]) => "Data de cadastro",
            var name when name.Equals(prefixo + AuditorFields[2]) => "Quem atualizou",
            var name when name.Equals(prefixo + AuditorFields[3]) => "Data de atualização",
            var name when name.Equals(prefixo + AuditorFields[4]) => "Visto",
            _ => campo.FCaption
        };
    }

    public static bool IsDocumentId(int tipo) =>
       tipo == (int)EDataTypeSystemInfo.SystemInfoTextCpf ||
       tipo == (int)EDataTypeSystemInfo.SystemInfoTextCnpj;

    /// <summary>
    /// Tamanho fixo de 10 casas para as datas
    /// </summary>
    /// <param name="eTipoDadosSystemInfo"></param>
    /// <returns></returns>
    public static bool IsDataFixedSize(EDataTypeSystemInfo eTipoDadosSystemInfo)

        => (eTipoDadosSystemInfo is EDataTypeSystemInfo.SystemInfoDateStart or
                 EDataTypeSystemInfo.SystemInfoDateEnds or
                 EDataTypeSystemInfo.SystemInfoDatetime or
                 EDataTypeSystemInfo.SystemInfoDateBirthday);

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
               idTipo == (int)EDataTypeSystemInfo.SystemInfoTextGuid ||
               idTipo == (int)EDataTypeSystemInfo.SystemInfoTextClassificationStar ||
               (idTipo >= 20 && idTipo <= 39) ||
               idTipo == (int)EDataTypeSystemInfo.SystemInfoTextCnh ||
               IsMemo(idTipo);
    /// <summary>
    /// Fone/fax repete com o isText
    /// </summary>
    /// <param name="idTipo"></param>
    /// <returns></returns>
    public static bool IsMemo(int idTipo) =>
               idTipo is ((int)EDataTypeSystemInfo.SystemInfoMemo) or
               ((int)EDataTypeSystemInfo.SystemInfoMemoObservations) or
               ((int)EDataTypeSystemInfo.SystemInfoTextFax) or
               ((int)EDataTypeSystemInfo.SystemInfoTextPhoneNumber);
    /// <summary>
    /// Indica se é Int
    /// </summary>
    /// <param name="idTipo"></param>
    /// <returns></returns>
    public static bool IsForeingKey(int idTipo) =>
               idTipo is ((int)EDataTypeSystemInfo.SystemInfoForeingkey) or 
               ((int)EDataTypeSystemInfo.SystemInfoForeingkeyWhoUpdt) or
               ((int)EDataTypeSystemInfo.SystemInfoForeingkeyWhoAdd);
    /// <summary>
    /// Indica se é um tipo [int]
    /// </summary>
    /// <param name="idTipo"></param>
    /// <returns></returns>
    public static bool IsNumber(int idTipo) =>
         idTipo == (int)EDataTypeSystemInfo.SystemInfoNumber || IsForeingKey(idTipo);
    /// <summary>
    /// indica se é um tipo [float]
    /// </summary>
    /// <param name="idTipo"></param>
    /// <returns></returns>
    public static bool IsDoubleOrDecimal(int idTipo) =>
        idTipo is ((int)EDataTypeSystemInfo.SystemInfoDouble) or
        ((int)EDataTypeSystemInfo.SystemInfoNumberSalary);
    /// <summary>
    /// Indica se é do tipo Bool
    /// </summary>
    /// <param name="idTipo"></param>
    /// <returns></returns>
    public static bool IsBoolean(int idTipo) =>
        idTipo is ((int)EDataTypeSystemInfo.SystemInfoBoolean) or
        ((int)EDataTypeSystemInfo.SystemInfoBooleanBold) or
        ((int)EDataTypeSystemInfo.SystemInfoBooleanTag) or
        ((int)EDataTypeSystemInfo.SystemInfoBooleanSex) or
        ((int)EDataTypeSystemInfo.SystemInfoBooleanTypePerson) or
        ((int)EDataTypeSystemInfo.SystemInfoBooleanAuditorReviewed) or
        ((int)EDataTypeSystemInfo.SystemInfoBooleanRemmeberBirthday);


    public static bool IsEMail(int idTipo) =>
         idTipo is ((int)EDataTypeSystemInfo.SystemInfoTextEmail) or
            ((int)EDataTypeSystemInfo.SystemInfoTextEmailBilling) or
            ((int)EDataTypeSystemInfo.SystemInfoTextEmailPro);

    /// <summary>
    /// Indica se o campo é tipo [DateTime]
    /// </summary>
    /// <param name="idTipo"></param>
    /// <returns></returns>
    public static bool IsData(int idTipo) =>
            idTipo is ((int)EDataTypeSystemInfo.SystemInfoDateAdd) or
            ((int)EDataTypeSystemInfo.SystemInfoDateOnly) or
            ((int)EDataTypeSystemInfo.SystemInfoTimeOnly) or
            ((int)EDataTypeSystemInfo.SystemInfoDateStart) or
            ((int)EDataTypeSystemInfo.SystemInfoDateEnds) or
            ((int)EDataTypeSystemInfo.SystemInfoDateUpdt) or
            ((int)EDataTypeSystemInfo.SystemInfoDateBirthday) or
            ((int)EDataTypeSystemInfo.SystemInfoDatetime);


    public static bool IsDateOnly(int idTipo) =>
        idTipo is
        ((int)EDataTypeSystemInfo.SystemInfoDateOnly) or
        ((int)EDataTypeSystemInfo.SystemInfoDateStart) or
        ((int)EDataTypeSystemInfo.SystemInfoDateEnds) or
        ((int)EDataTypeSystemInfo.SystemInfoDateBirthday);
        
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
         IsForeingKey(idTipo) || idTipo == (int)EDataTypeSystemInfo.SystemInfoNumber;

    public static string SqlSizeByType(DBInfoSystem item)
     =>
         IsData((int)item.FTipo) ? string.Empty :
        (IsText((int)item.FTipo)
            ? (item.FTamanho > 2048 ? "(max)" : $"({item.FTamanho})") : string.Empty
        );

    private static string GetNomeCampoByInfoSystem(EDataTypeSystemInfo eTipoDadosSystemInfo, List<DBInfoSystem> lista)
    {
        for (var nt = 0; nt < lista.Count; nt++)
            if ((int)eTipoDadosSystemInfo == (int)lista[nt].FTipo) return lista[nt].FNome;
        return string.Empty;
    }

    private static string GetNomeCampoByInfoSystem(EDataTypeSystemInfo eTipoDadosSystemInfo, List<DBInfoSystem> lista, string cInclude)
    {
        for (var nt = 0; nt < lista.Count; nt++)
            if ((int)eTipoDadosSystemInfo == (int)lista[nt].FTipo)
                if (lista[nt].FNome.IndexOf(cInclude, StringComparison.CurrentCultureIgnoreCase) != -1) return lista[nt].FNome;

        return string.Empty;
    }
}
