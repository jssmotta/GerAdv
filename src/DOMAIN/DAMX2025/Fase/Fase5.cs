// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBFase
{
    public const string CadastroGuid = "08919325-19aa-467a-965a-f723bd4e9c41";
#region AdministrativeMethods_Fase
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE fasCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "Fase";
    public const string CamposSqlX = " Fase.* ";
    public const string SensivelCamposSqlX = " Fase.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "fasCodigo";
    public const string CampoNome = "fasDescricao";
    public const string PTabelaPrefixo = "fas";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}