// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBObjetos
{
    public const string CadastroGuid = "24ba4b17-9a36-4df5-9514-e5fadc370d1a";
#region AdministrativeMethods_Objetos
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE ojtCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "Objetos";
    public const string CamposSqlX = " Objetos.* ";
    public const string SensivelCamposSqlX = " Objetos.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "ojtCodigo";
    public const string CampoNome = "ojtNome";
    public const string PTabelaPrefixo = "ojt";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}