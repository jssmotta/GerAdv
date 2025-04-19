#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBOperadorODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBOperadorDicInfo.TabelaNome;
    public string ICampoCodigo() => DBOperadorDicInfo.CampoCodigo;
    public string IPrefixo() => DBOperadorDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => true;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBOperadorDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => true;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBOperadorDicInfo.EMail => DBOperadorDicInfo.OperEMail,
        DBOperadorDicInfo.Pasta => DBOperadorDicInfo.OperPasta,
        DBOperadorDicInfo.Telefonista => DBOperadorDicInfo.OperTelefonista,
        DBOperadorDicInfo.Master => DBOperadorDicInfo.OperMaster,
        DBOperadorDicInfo.Nome => DBOperadorDicInfo.OperNome,
        DBOperadorDicInfo.Nick => DBOperadorDicInfo.OperNick,
        DBOperadorDicInfo.Ramal => DBOperadorDicInfo.OperRamal,
        DBOperadorDicInfo.CadID => DBOperadorDicInfo.OperCadID,
        DBOperadorDicInfo.CadCod => DBOperadorDicInfo.OperCadCod,
        DBOperadorDicInfo.Excluido => DBOperadorDicInfo.OperExcluido,
        DBOperadorDicInfo.Situacao => DBOperadorDicInfo.OperSituacao,
        DBOperadorDicInfo.Computador => DBOperadorDicInfo.OperComputador,
        DBOperadorDicInfo.MinhaDescricao => DBOperadorDicInfo.OperMinhaDescricao,
        DBOperadorDicInfo.UltimoLogoff => DBOperadorDicInfo.OperUltimoLogoff,
        DBOperadorDicInfo.EMailNet => DBOperadorDicInfo.OperEMailNet,
        DBOperadorDicInfo.OnlineIP => DBOperadorDicInfo.OperOnlineIP,
        DBOperadorDicInfo.OnLine => DBOperadorDicInfo.OperOnLine,
        DBOperadorDicInfo.SysOp => DBOperadorDicInfo.OperSysOp,
        DBOperadorDicInfo.StatusId => DBOperadorDicInfo.OperStatusId,
        DBOperadorDicInfo.StatusMessage => DBOperadorDicInfo.OperStatusMessage,
        DBOperadorDicInfo.IsFinanceiro => DBOperadorDicInfo.OperIsFinanceiro,
        DBOperadorDicInfo.Top => DBOperadorDicInfo.OperTop,
        DBOperadorDicInfo.Sexo => DBOperadorDicInfo.OperSexo,
        DBOperadorDicInfo.Basico => DBOperadorDicInfo.OperBasico,
        DBOperadorDicInfo.Externo => DBOperadorDicInfo.OperExterno,
        DBOperadorDicInfo.Senha256 => DBOperadorDicInfo.OperSenha256,
        DBOperadorDicInfo.EMailConfirmado => DBOperadorDicInfo.OperEMailConfirmado,
        DBOperadorDicInfo.DataLimiteReset => DBOperadorDicInfo.OperDataLimiteReset,
        DBOperadorDicInfo.SuporteSenha256 => DBOperadorDicInfo.OperSuporteSenha256,
        DBOperadorDicInfo.SuporteMaxAge => DBOperadorDicInfo.OperSuporteMaxAge,
        DBOperadorDicInfo.SuporteNomeSolicitante => DBOperadorDicInfo.OperSuporteNomeSolicitante,
        DBOperadorDicInfo.SuporteUltimoAcesso => DBOperadorDicInfo.OperSuporteUltimoAcesso,
        DBOperadorDicInfo.SuporteIpUltimoAcesso => DBOperadorDicInfo.OperSuporteIpUltimoAcesso,
        DBOperadorDicInfo.GUID => DBOperadorDicInfo.OperGUID,
        DBOperadorDicInfo.QuemCad => DBOperadorDicInfo.OperQuemCad,
        DBOperadorDicInfo.DtCad => DBOperadorDicInfo.OperDtCad,
        DBOperadorDicInfo.QuemAtu => DBOperadorDicInfo.OperQuemAtu,
        DBOperadorDicInfo.DtAtu => DBOperadorDicInfo.OperDtAtu,
        DBOperadorDicInfo.Visto => DBOperadorDicInfo.OperVisto,
        _ => null
    };
    public static string TCampoCodigo => DBOperadorDicInfo.CampoCodigo;
    public static string TCampoNome => DBOperadorDicInfo.CampoNome;
    public static string TTabelaNome => DBOperadorDicInfo.TabelaNome;
    public static string TTablePrefix => DBOperadorDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBOperadorDicInfo.OperEMail, DBOperadorDicInfo.OperPasta, DBOperadorDicInfo.OperTelefonista, DBOperadorDicInfo.OperMaster, DBOperadorDicInfo.OperNome, DBOperadorDicInfo.OperNick, DBOperadorDicInfo.OperRamal, DBOperadorDicInfo.OperCadID, DBOperadorDicInfo.OperCadCod, DBOperadorDicInfo.OperExcluido, DBOperadorDicInfo.OperSituacao, DBOperadorDicInfo.OperComputador, DBOperadorDicInfo.OperMinhaDescricao, DBOperadorDicInfo.OperUltimoLogoff, DBOperadorDicInfo.OperEMailNet, DBOperadorDicInfo.OperOnlineIP, DBOperadorDicInfo.OperOnLine, DBOperadorDicInfo.OperSysOp, DBOperadorDicInfo.OperStatusId, DBOperadorDicInfo.OperStatusMessage, DBOperadorDicInfo.OperIsFinanceiro, DBOperadorDicInfo.OperTop, DBOperadorDicInfo.OperSexo, DBOperadorDicInfo.OperBasico, DBOperadorDicInfo.OperExterno, DBOperadorDicInfo.OperSenha256, DBOperadorDicInfo.OperEMailConfirmado, DBOperadorDicInfo.OperDataLimiteReset, DBOperadorDicInfo.OperSuporteSenha256, DBOperadorDicInfo.OperSuporteMaxAge, DBOperadorDicInfo.OperSuporteNomeSolicitante, DBOperadorDicInfo.OperSuporteUltimoAcesso, DBOperadorDicInfo.OperSuporteIpUltimoAcesso, DBOperadorDicInfo.OperGUID, DBOperadorDicInfo.OperQuemCad, DBOperadorDicInfo.OperDtCad, DBOperadorDicInfo.OperQuemAtu, DBOperadorDicInfo.OperDtAtu, DBOperadorDicInfo.OperVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBOperadorDicInfo.OperEMail, DBOperadorDicInfo.OperPasta, DBOperadorDicInfo.OperTelefonista, DBOperadorDicInfo.OperMaster, DBOperadorDicInfo.OperNome, DBOperadorDicInfo.OperNick, DBOperadorDicInfo.OperRamal, DBOperadorDicInfo.OperCadID, DBOperadorDicInfo.OperCadCod, DBOperadorDicInfo.OperExcluido, DBOperadorDicInfo.OperSituacao, DBOperadorDicInfo.OperComputador, DBOperadorDicInfo.OperMinhaDescricao, DBOperadorDicInfo.OperUltimoLogoff, DBOperadorDicInfo.OperEMailNet, DBOperadorDicInfo.OperOnlineIP, DBOperadorDicInfo.OperOnLine, DBOperadorDicInfo.OperSysOp, DBOperadorDicInfo.OperStatusId, DBOperadorDicInfo.OperStatusMessage, DBOperadorDicInfo.OperIsFinanceiro, DBOperadorDicInfo.OperTop, DBOperadorDicInfo.OperSexo, DBOperadorDicInfo.OperBasico, DBOperadorDicInfo.OperExterno, DBOperadorDicInfo.OperSenha256, DBOperadorDicInfo.OperEMailConfirmado, DBOperadorDicInfo.OperDataLimiteReset, DBOperadorDicInfo.OperSuporteSenha256, DBOperadorDicInfo.OperSuporteMaxAge, DBOperadorDicInfo.OperSuporteNomeSolicitante, DBOperadorDicInfo.OperSuporteUltimoAcesso, DBOperadorDicInfo.OperSuporteIpUltimoAcesso, DBOperadorDicInfo.OperGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "operCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBOperadorDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "operCodigo",
            "operNome"
        };
        var result = campos.Where(campo => !campo.Equals(DBOperadorDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
