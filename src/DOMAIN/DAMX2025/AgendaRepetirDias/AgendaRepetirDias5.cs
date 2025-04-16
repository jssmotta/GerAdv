// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBAgendaRepetirDias
{
    public const string CadastroGuid = "94b3d914-f051-4d83-a36b-30fa1b8a3c9d";
#region AdministrativeMethods_AgendaRepetirDias
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE rpdCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "AgendaRepetirDias";
    public const string CamposSqlX = " AgendaRepetirDias.* ";
    public const string SensivelCamposSqlX = " AgendaRepetirDias.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "rpdCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "rpd";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}