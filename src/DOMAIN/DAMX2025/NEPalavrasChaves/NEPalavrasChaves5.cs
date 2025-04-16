// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBNEPalavrasChaves
{
    public const string CadastroGuid = "b293c404-a761-489e-bb53-f569eec6d9c6";
#region AdministrativeMethods_NEPalavrasChaves
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE npcCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "NEPalavrasChaves";
    public const string CamposSqlX = " NEPalavrasChaves.* ";
    public const string SensivelCamposSqlX = " NEPalavrasChaves.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "npcCodigo";
    public const string CampoNome = "npcNome";
    public const string PTabelaPrefixo = "npc";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}