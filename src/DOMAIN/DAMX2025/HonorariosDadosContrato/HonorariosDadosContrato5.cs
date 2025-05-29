// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBHonorariosDadosContrato
{
    public const string CadastroGuid = "58ba3455-bf80-4cf3-b932-0dab9c435db7";
#region AdministrativeMethods_HonorariosDadosContrato
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE hdcCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "HonorariosDadosContrato";
    public const string CamposSqlX = " HonorariosDadosContrato.* ";
    public const string SensivelCamposSqlX = " HonorariosDadosContrato.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "hdcCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "hdc";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}