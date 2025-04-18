// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBProObservacoes
{
    public const string CadastroGuid = "5b6010e6-1838-477e-af33-65cdeaf106fc";
#region AdministrativeMethods_ProObservacoes
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE pobCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "ProObservacoes";
    public const string CamposSqlX = " ProObservacoes.* ";
    public const string SensivelCamposSqlX = " ProObservacoes.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "pobCodigo";
    public const string CampoNome = "pobNome";
    public const string PTabelaPrefixo = "pob";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}