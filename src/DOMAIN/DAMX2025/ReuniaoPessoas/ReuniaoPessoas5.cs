// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBReuniaoPessoas
{
    public const string CadastroGuid = "b6ffbe84-2fac-4bf1-bb39-938561dc52c3";
#region AdministrativeMethods_ReuniaoPessoas
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE rnpCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "ReuniaoPessoas";
    public const string CamposSqlX = " ReuniaoPessoas.* ";
    public const string SensivelCamposSqlX = " ReuniaoPessoas.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "rnpCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "rnp";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}