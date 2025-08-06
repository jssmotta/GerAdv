using Microsoft.AspNetCore.Http;

namespace MenphisSI;
public static class ExtensionMethodStringsW3
{

    public static bool IsEmptyX(this int value)    
        => value == int.MinValue;

    public static bool IsEmptyX(this decimal value)
    => value == decimal.MinValue;

    public static bool IsEmptyX(this string value)    
        => string.IsNullOrWhiteSpace(value);

    public static bool IsEmptyDX(this string value)
    {
        if (string.IsNullOrWhiteSpace(value)) return true;
        if (DateTime.TryParse(value, out DateTime dateValue))
            return dateValue == DateTime.MinValue;
        return true;
    }

    public static bool IsValidEmail(this string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
    public static bool IsValidCpf(this string? cpf) => DevourerOne.CPFValido(cpf ?? string.Empty);
    public static bool IsValidCnpj(this string? cnpj) => DevourerOne.CNPJValido(cnpj ?? string.Empty);
    public static string ClearInputCep(this string? cep) => cep?.Trim().Replace("-", "").Replace(".", "").Replace(" ", "").Replace("_", "") ?? string.Empty;
    public static string ClearInputCnpj(this string? cnpj) => cnpj?.Trim().Replace(".", "").Replace("/", "").Replace("-", "").Replace("_", "") ?? string.Empty;
    public static string ClearInputCepCpfCnpj(this string ? cepCpfCnpj) => cepCpfCnpj?.Trim().Replace("-", "").Replace(".", "").Replace("/", "").Replace(" ", "").Replace("_", "") ?? string.Empty;
    public static string ClearInputCpf(this string? cpf) => cpf?.Trim().Replace(".", "").Replace("-", "").Replace("_", "") ?? string.Empty;
    public static string SqlDataMaiorQue(this string campo, DateTime dia) => DevourerOne.AppendDataSqlMaiorOuIgual(dia, campo);
    public static string SqlOrderDesc(this string campo) => $" [{campo}] DESC";
    public static string dbo(this string TabelaNome, MsiSqlConnection? oCnn) => TabelaNome.Contains("_sp_") ?
        $"{oCnn?.UseDbo ?? "dbo"}.{TabelaNome}" :     
        $" [{oCnn?.UseDbo ?? "dbo"}].[{TabelaNome}] ";

    public static string SqlCmdBoolCheck(this string campo, bool valueCheck) => $" [{campo}]={(valueCheck ? "1" : "0")}";
    public static string SqlCmdBoolSim(this string campo) => $" [{campo}]=1 ";
    public static string SqlCmdBoolNao(this string campo) => $" ( [{campo}] IS NULL OR [{campo}]=0 ) ";
    public static string SqlCmdNumberIgual(this string campo, int id) => id == 0 ? $" ([{campo}]={id} OR [{campo}] IS NULL) " : $" [{campo}]={id} ";
    public static string SqlCmdNumberIgual(this string campo, long id) => id == 0 ? $" ([{campo}]={id} OR [{campo}] IS NULL) " : $" [{campo}]={id} ";
    public static string SqlCmdIsNull(this string campo) => $" [{campo}] IS NULL ";
    public static string SqlCmdNotIsNull(this string campo) => $" NOT [{campo}] IS NULL "; 
    public static string SqlCmdTextIgual(this string campo, string? text, int nMax) => $" [{campo}] {DevourerConsts.MsiCollate} like '{(text?.Trim().Length <= nMax ? text.trim().ToUpper() : (text.trim().ToUpper())[..nMax]).PreparaParaSql()}' ";
    public static string SqlCmdTextIgual(this string campo, string? text) => $" [{campo}] = '{text.trim().PreparaParaSql()}' ";

    public static string SqlCmdTextDiff(this string campo, string? text) => $" ( [{campo}] IS NULL OR NOT [{campo}] like '{text?.PreparaParaSql()}' ) ";
    public static string SqlCmdTextLike(this string campo, string? text) => $" [{campo}] {DevourerConsts.MsiCollate} like '{text?.Trim().Replace("'", "''").Replace("?", "%").PreparaParaSql()}%' ";

    public static string SqlCmdTextLikeInit(this string campo, string? text) => $" [{campo}] {DevourerConsts.MsiCollate} like '%{text.replace("'", "''").Replace("?", "%").Trim().PreparaParaSql()}%' ";
    public static string SqlCmdTextLikeSpaces(this string campo, string? text) => $" {campo} {DevourerConsts.MsiCollate} like '%{text.replace("'", "''").PreparaParaSql().Replace("?", "%").Replace(" ", "%")}%' "; // less .ToUpper - 09-03-2017
 
    public static string SqlCmdNumberDiff(this string campo, int id) => $" ([{campo}]<>{id} OR [{campo}] IS NULL) ";
    public static string PreparaParaSql(this string? text) => text?.Replace("'", "''") ?? "";
}
