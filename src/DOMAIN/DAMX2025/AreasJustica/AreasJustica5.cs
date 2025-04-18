// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBAreasJustica
{
    public const string CadastroGuid = "c2404b2c-da3e-4d65-8b15-ba8fd844d568";
#region AdministrativeMethods_AreasJustica
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE arjCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "AreasJustica";
    public const string CamposSqlX = " AreasJustica.* ";
    public const string SensivelCamposSqlX = " AreasJustica.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "arjCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "arj";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}