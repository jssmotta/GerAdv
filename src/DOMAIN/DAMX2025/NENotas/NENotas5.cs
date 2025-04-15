// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBNENotas
{
    public const string CadastroGuid = "1c1fa8b4-29a9-456d-9dd5-767499264220";
#region AdministrativeMethods_NENotas
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE nepCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "NENotas";
    public const string CamposSqlX = " NENotas.* ";
    public const string SensivelCamposSqlX = " NENotas.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "nepCodigo";
    public const string CampoNome = "nepNome";
    public const string PTabelaPrefixo = "nep";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}