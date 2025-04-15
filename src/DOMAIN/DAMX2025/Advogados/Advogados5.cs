// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBAdvogados
{
    public const string CadastroGuid = "fe9fbf7a-5623-4c26-b669-6015de890596";
#region AdministrativeMethods_Advogados
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE advCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "Advogados";
    public const string CamposSqlX = " Advogados.* ";
    public const string SensivelCamposSqlX = " Advogados.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "advCodigo";
    public const string CampoNome = "advNome";
    public const string PTabelaPrefixo = "adv";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}