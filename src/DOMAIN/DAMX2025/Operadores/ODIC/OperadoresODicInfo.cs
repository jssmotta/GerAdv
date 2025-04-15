#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBOperadoresODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBOperadoresDicInfo.TabelaNome;
    public string ICampoCodigo() => DBOperadoresDicInfo.CampoCodigo;
    public string IPrefixo() => DBOperadoresDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBOperadoresDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBOperadoresDicInfo.Enviado => DBOperadoresDicInfo.OperEnviado,
        DBOperadoresDicInfo.Casa => DBOperadoresDicInfo.OperCasa,
        DBOperadoresDicInfo.CasaID => DBOperadoresDicInfo.OperCasaID,
        DBOperadoresDicInfo.CasaCodigo => DBOperadoresDicInfo.OperCasaCodigo,
        DBOperadoresDicInfo.IsNovo => DBOperadoresDicInfo.OperIsNovo,
        DBOperadoresDicInfo.Cliente => DBOperadoresDicInfo.OperCliente,
        DBOperadoresDicInfo.Grupo => DBOperadoresDicInfo.OperGrupo,
        DBOperadoresDicInfo.Nome => DBOperadoresDicInfo.OperNome,
        DBOperadoresDicInfo.EMail => DBOperadoresDicInfo.OperEMail,
        DBOperadoresDicInfo.Senha => DBOperadoresDicInfo.OperSenha,
        DBOperadoresDicInfo.Ativado => DBOperadoresDicInfo.OperAtivado,
        DBOperadoresDicInfo.AtualizarSenha => DBOperadoresDicInfo.OperAtualizarSenha,
        DBOperadoresDicInfo.Senha256 => DBOperadoresDicInfo.OperSenha256,
        DBOperadoresDicInfo.SuporteSenha256 => DBOperadoresDicInfo.OperSuporteSenha256,
        DBOperadoresDicInfo.SuporteMaxAge => DBOperadoresDicInfo.OperSuporteMaxAge,
        DBOperadoresDicInfo.QuemCad => DBOperadoresDicInfo.OperQuemCad,
        DBOperadoresDicInfo.DtCad => DBOperadoresDicInfo.OperDtCad,
        DBOperadoresDicInfo.QuemAtu => DBOperadoresDicInfo.OperQuemAtu,
        DBOperadoresDicInfo.DtAtu => DBOperadoresDicInfo.OperDtAtu,
        DBOperadoresDicInfo.Visto => DBOperadoresDicInfo.OperVisto,
        _ => null
    };
    public static string TCampoCodigo => DBOperadoresDicInfo.CampoCodigo;
    public static string TCampoNome => DBOperadoresDicInfo.CampoNome;
    public static string TTabelaNome => DBOperadoresDicInfo.TabelaNome;
    public static string TTablePrefix => DBOperadoresDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBOperadoresDicInfo.OperEnviado, DBOperadoresDicInfo.OperCasa, DBOperadoresDicInfo.OperCasaID, DBOperadoresDicInfo.OperCasaCodigo, DBOperadoresDicInfo.OperIsNovo, DBOperadoresDicInfo.OperCliente, DBOperadoresDicInfo.OperGrupo, DBOperadoresDicInfo.OperNome, DBOperadoresDicInfo.OperEMail, DBOperadoresDicInfo.OperSenha, DBOperadoresDicInfo.OperAtivado, DBOperadoresDicInfo.OperAtualizarSenha, DBOperadoresDicInfo.OperSenha256, DBOperadoresDicInfo.OperSuporteSenha256, DBOperadoresDicInfo.OperSuporteMaxAge, DBOperadoresDicInfo.OperQuemCad, DBOperadoresDicInfo.OperDtCad, DBOperadoresDicInfo.OperQuemAtu, DBOperadoresDicInfo.OperDtAtu, DBOperadoresDicInfo.OperVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBOperadoresDicInfo.OperEnviado, DBOperadoresDicInfo.OperCasa, DBOperadoresDicInfo.OperCasaID, DBOperadoresDicInfo.OperCasaCodigo, DBOperadoresDicInfo.OperIsNovo, DBOperadoresDicInfo.OperCliente, DBOperadoresDicInfo.OperGrupo, DBOperadoresDicInfo.OperNome, DBOperadoresDicInfo.OperEMail, DBOperadoresDicInfo.OperSenha, DBOperadoresDicInfo.OperAtivado, DBOperadoresDicInfo.OperAtualizarSenha, DBOperadoresDicInfo.OperSenha256, DBOperadoresDicInfo.OperSuporteSenha256, DBOperadoresDicInfo.OperSuporteMaxAge];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "operCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBOperadoresDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "operCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBOperadoresDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
