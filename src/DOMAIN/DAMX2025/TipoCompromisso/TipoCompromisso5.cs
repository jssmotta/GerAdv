// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBTipoCompromisso
{
    public const string CadastroGuid = "0d3dd4e1-da59-44d0-a238-23af21e303ba";
#region AdministrativeMethods_TipoCompromisso
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE tipCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "TipoCompromisso";
    public const string CamposSqlX = " TipoCompromisso.* ";
    public const string SensivelCamposSqlX = " TipoCompromisso.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "tipCodigo";
    public const string CampoNome = "tipDescricao";
    public const string PTabelaPrefixo = "tip";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}