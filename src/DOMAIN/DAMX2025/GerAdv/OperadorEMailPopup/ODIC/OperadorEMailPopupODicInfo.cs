#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBOperadorEMailPopupODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBOperadorEMailPopupDicInfo.TabelaNome;
    public string ICampoCodigo() => DBOperadorEMailPopupDicInfo.CampoCodigo;
    public string IPrefixo() => DBOperadorEMailPopupDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBOperadorEMailPopupDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBOperadorEMailPopupDicInfo.Operador => DBOperadorEMailPopupDicInfo.OepOperador,
        DBOperadorEMailPopupDicInfo.Nome => DBOperadorEMailPopupDicInfo.OepNome,
        DBOperadorEMailPopupDicInfo.Senha => DBOperadorEMailPopupDicInfo.OepSenha,
        DBOperadorEMailPopupDicInfo.SMTP => DBOperadorEMailPopupDicInfo.OepSMTP,
        DBOperadorEMailPopupDicInfo.POP3 => DBOperadorEMailPopupDicInfo.OepPOP3,
        DBOperadorEMailPopupDicInfo.Autenticacao => DBOperadorEMailPopupDicInfo.OepAutenticacao,
        DBOperadorEMailPopupDicInfo.Descricao => DBOperadorEMailPopupDicInfo.OepDescricao,
        DBOperadorEMailPopupDicInfo.Usuario => DBOperadorEMailPopupDicInfo.OepUsuario,
        DBOperadorEMailPopupDicInfo.PortaSmtp => DBOperadorEMailPopupDicInfo.OepPortaSmtp,
        DBOperadorEMailPopupDicInfo.PortaPop3 => DBOperadorEMailPopupDicInfo.OepPortaPop3,
        DBOperadorEMailPopupDicInfo.Assinatura => DBOperadorEMailPopupDicInfo.OepAssinatura,
        DBOperadorEMailPopupDicInfo.Senha256 => DBOperadorEMailPopupDicInfo.OepSenha256,
        DBOperadorEMailPopupDicInfo.GUID => DBOperadorEMailPopupDicInfo.OepGUID,
        DBOperadorEMailPopupDicInfo.QuemCad => DBOperadorEMailPopupDicInfo.OepQuemCad,
        DBOperadorEMailPopupDicInfo.DtCad => DBOperadorEMailPopupDicInfo.OepDtCad,
        DBOperadorEMailPopupDicInfo.QuemAtu => DBOperadorEMailPopupDicInfo.OepQuemAtu,
        DBOperadorEMailPopupDicInfo.DtAtu => DBOperadorEMailPopupDicInfo.OepDtAtu,
        DBOperadorEMailPopupDicInfo.Visto => DBOperadorEMailPopupDicInfo.OepVisto,
        _ => null
    };
    public static string TCampoCodigo => DBOperadorEMailPopupDicInfo.CampoCodigo;
    public static string TCampoNome => DBOperadorEMailPopupDicInfo.CampoNome;
    public static string TTabelaNome => DBOperadorEMailPopupDicInfo.TabelaNome;
    public static string TTablePrefix => DBOperadorEMailPopupDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBOperadorEMailPopupDicInfo.OepOperador, DBOperadorEMailPopupDicInfo.OepNome, DBOperadorEMailPopupDicInfo.OepSenha, DBOperadorEMailPopupDicInfo.OepSMTP, DBOperadorEMailPopupDicInfo.OepPOP3, DBOperadorEMailPopupDicInfo.OepAutenticacao, DBOperadorEMailPopupDicInfo.OepDescricao, DBOperadorEMailPopupDicInfo.OepUsuario, DBOperadorEMailPopupDicInfo.OepPortaSmtp, DBOperadorEMailPopupDicInfo.OepPortaPop3, DBOperadorEMailPopupDicInfo.OepAssinatura, DBOperadorEMailPopupDicInfo.OepSenha256, DBOperadorEMailPopupDicInfo.OepGUID, DBOperadorEMailPopupDicInfo.OepQuemCad, DBOperadorEMailPopupDicInfo.OepDtCad, DBOperadorEMailPopupDicInfo.OepQuemAtu, DBOperadorEMailPopupDicInfo.OepDtAtu, DBOperadorEMailPopupDicInfo.OepVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBOperadorEMailPopupDicInfo.OepOperador, DBOperadorEMailPopupDicInfo.OepNome, DBOperadorEMailPopupDicInfo.OepSenha, DBOperadorEMailPopupDicInfo.OepSMTP, DBOperadorEMailPopupDicInfo.OepPOP3, DBOperadorEMailPopupDicInfo.OepAutenticacao, DBOperadorEMailPopupDicInfo.OepDescricao, DBOperadorEMailPopupDicInfo.OepUsuario, DBOperadorEMailPopupDicInfo.OepPortaSmtp, DBOperadorEMailPopupDicInfo.OepPortaPop3, DBOperadorEMailPopupDicInfo.OepAssinatura, DBOperadorEMailPopupDicInfo.OepSenha256, DBOperadorEMailPopupDicInfo.OepGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "oepCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBOperadorEMailPopupDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "oepCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBOperadorEMailPopupDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
