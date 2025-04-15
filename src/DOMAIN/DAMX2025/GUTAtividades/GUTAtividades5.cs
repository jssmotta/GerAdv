// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBGUTAtividades
{
    public const string CadastroGuid = "e7a4d6ee-0997-47e2-b930-ca18cfda4159";
#region AdministrativeMethods_GUTAtividades
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE agtCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "GUTAtividades";
    public const string CamposSqlX = " GUTAtividades.* ";
    public const string SensivelCamposSqlX = " GUTAtividades.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "agtCodigo";
    public const string CampoNome = "agtNome";
    public const string PTabelaPrefixo = "agt";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}