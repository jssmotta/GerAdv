// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBOperador
{
    public const string CadastroGuid = "410cd94a-fdd6-4598-bc50-e69d770fdb8d";
    /*

#region AdministrativeMethods_Operador

public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans)
 => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans)
=> nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE operCodigo={nId};", oCnn, oTrans);

#endregion

*/
    public const string PTabelaNome = "Operador";
    public const string CamposSqlX = " Operador.* ";
    public const string SensivelCamposSqlX = " Operador.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "operCodigo";
    public const string CampoNome = "operNome";
    public const string PTabelaPrefixo = "oper";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}