// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBForo
{
    public const string CadastroGuid = "aa5d533f-cb3d-4a50-a25b-7cd521fc8dd7";
#region AdministrativeMethods_Foro
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE forCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "Foro";
    public const string CamposSqlX = " Foro.* ";
    public const string SensivelCamposSqlX = " Foro.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "forCodigo";
    public const string CampoNome = "forNome";
    public const string PTabelaPrefixo = "for";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}