#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBReuniaoPessoasODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBReuniaoPessoasDicInfo.TabelaNome;
    public string ICampoCodigo() => DBReuniaoPessoasDicInfo.CampoCodigo;
    public string IPrefixo() => DBReuniaoPessoasDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBReuniaoPessoasDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBReuniaoPessoasDicInfo.Reuniao => DBReuniaoPessoasDicInfo.RnpReuniao,
        DBReuniaoPessoasDicInfo.Operador => DBReuniaoPessoasDicInfo.RnpOperador,
        DBReuniaoPessoasDicInfo.QuemCad => DBReuniaoPessoasDicInfo.RnpQuemCad,
        DBReuniaoPessoasDicInfo.DtCad => DBReuniaoPessoasDicInfo.RnpDtCad,
        DBReuniaoPessoasDicInfo.QuemAtu => DBReuniaoPessoasDicInfo.RnpQuemAtu,
        DBReuniaoPessoasDicInfo.DtAtu => DBReuniaoPessoasDicInfo.RnpDtAtu,
        DBReuniaoPessoasDicInfo.Visto => DBReuniaoPessoasDicInfo.RnpVisto,
        _ => null
    };
    public static string TCampoCodigo => DBReuniaoPessoasDicInfo.CampoCodigo;
    public static string TCampoNome => DBReuniaoPessoasDicInfo.CampoNome;
    public static string TTabelaNome => DBReuniaoPessoasDicInfo.TabelaNome;
    public static string TTablePrefix => DBReuniaoPessoasDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBReuniaoPessoasDicInfo.RnpReuniao, DBReuniaoPessoasDicInfo.RnpOperador, DBReuniaoPessoasDicInfo.RnpQuemCad, DBReuniaoPessoasDicInfo.RnpDtCad, DBReuniaoPessoasDicInfo.RnpQuemAtu, DBReuniaoPessoasDicInfo.RnpDtAtu, DBReuniaoPessoasDicInfo.RnpVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBReuniaoPessoasDicInfo.RnpReuniao, DBReuniaoPessoasDicInfo.RnpOperador];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "rnpCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBReuniaoPessoasDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "rnpCodigo",
            "rnpOperador",
            "rnpReuniao"
        };
        var result = campos.Where(campo => !campo.Equals(DBReuniaoPessoasDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
