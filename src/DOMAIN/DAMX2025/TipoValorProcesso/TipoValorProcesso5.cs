// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBTipoValorProcesso
{
    public const string CadastroGuid = "f3fca6bf-e589-477e-9b6f-2de37b128bdc";
#region AdministrativeMethods_TipoValorProcesso
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE ptvCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "TipoValorProcesso";
    public const string CamposSqlX = " TipoValorProcesso.* ";
    public const string SensivelCamposSqlX = " TipoValorProcesso.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "ptvCodigo";
    public const string CampoNome = "ptvDescricao";
    public const string PTabelaPrefixo = "ptv";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}