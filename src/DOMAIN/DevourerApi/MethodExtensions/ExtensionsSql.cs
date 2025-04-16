namespace MenphisSI;
public static class ExtensionMethodStringsW3
{
    public static string SqlDataMaiorQue(this string campo, DateTime dia) => DevourerOne.AppendDataSqlMaiorOuIgual(dia, campo);
    public static string SqlOrderDesc(this string campo) => $" [{campo}] DESC";
    public static string dbo(this string TabelaNome) => $" [dbo].[{TabelaNome}] ";
     

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
