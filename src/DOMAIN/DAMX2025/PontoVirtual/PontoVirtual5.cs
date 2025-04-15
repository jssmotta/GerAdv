// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBPontoVirtual
{
    public const string CadastroGuid = "0c7c8be3-5710-43fb-9068-2e94529f01a5";
#region AdministrativeMethods_PontoVirtual
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE pvtCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "PontoVirtual";
    public const string CamposSqlX = " PontoVirtual.* ";
    public const string SensivelCamposSqlX = " PontoVirtual.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "pvtCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "pvt";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}