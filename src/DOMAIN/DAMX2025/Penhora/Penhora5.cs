// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBPenhora
{
    public const string CadastroGuid = "a832ca60-1a2a-4712-b655-6a47691756c7";
#region AdministrativeMethods_Penhora
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE phrCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "Penhora";
    public const string CamposSqlX = " Penhora.* ";
    public const string SensivelCamposSqlX = " Penhora.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "phrCodigo";
    public const string CampoNome = "phrNome";
    public const string PTabelaPrefixo = "phr";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}