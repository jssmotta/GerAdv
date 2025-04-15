// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBPosicaoOutrasPartes
{
    public const string CadastroGuid = "e9a21dfc-4242-4d82-b519-77c0cf08bb8c";
#region AdministrativeMethods_PosicaoOutrasPartes
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE posCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "PosicaoOutrasPartes";
    public const string CamposSqlX = " PosicaoOutrasPartes.* ";
    public const string SensivelCamposSqlX = " PosicaoOutrasPartes.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "posCodigo";
    public const string CampoNome = "posDescricao";
    public const string PTabelaPrefixo = "pos";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}