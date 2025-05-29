// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBOperadorGruposAgenda
{
    public const string CadastroGuid = "56643fb6-b330-4197-a200-6165c3e9cfbe";
#region AdministrativeMethods_OperadorGruposAgenda
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE groCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "OperadorGruposAgenda";
    public const string CamposSqlX = " OperadorGruposAgenda.* ";
    public const string SensivelCamposSqlX = " OperadorGruposAgenda.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "groCodigo";
    public const string CampoNome = "groNome";
    public const string PTabelaPrefixo = "gro";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}