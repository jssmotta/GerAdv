// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBGruposEmpresas
{
    public const string CadastroGuid = "b43fa331-4333-421f-bcd5-0ce0ef458213";
#region AdministrativeMethods_GruposEmpresas
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE grpCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "GruposEmpresas";
    public const string CamposSqlX = " GruposEmpresas.* ";
    public const string SensivelCamposSqlX = " GruposEmpresas.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "grpCodigo";
    public const string CampoNome = "grpDescricao";
    public const string PTabelaPrefixo = "grp";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}