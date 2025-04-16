#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBCargosEscClassODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBCargosEscClassDicInfo.TabelaNome;
    public string ICampoCodigo() => DBCargosEscClassDicInfo.CampoCodigo;
    public string IPrefixo() => DBCargosEscClassDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBCargosEscClassDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBCargosEscClassDicInfo.Nome => DBCargosEscClassDicInfo.CecNome,
        DBCargosEscClassDicInfo.GUID => DBCargosEscClassDicInfo.CecGUID,
        DBCargosEscClassDicInfo.QuemCad => DBCargosEscClassDicInfo.CecQuemCad,
        DBCargosEscClassDicInfo.DtCad => DBCargosEscClassDicInfo.CecDtCad,
        DBCargosEscClassDicInfo.QuemAtu => DBCargosEscClassDicInfo.CecQuemAtu,
        DBCargosEscClassDicInfo.DtAtu => DBCargosEscClassDicInfo.CecDtAtu,
        DBCargosEscClassDicInfo.Visto => DBCargosEscClassDicInfo.CecVisto,
        _ => null
    };
    public static string TCampoCodigo => DBCargosEscClassDicInfo.CampoCodigo;
    public static string TCampoNome => DBCargosEscClassDicInfo.CampoNome;
    public static string TTabelaNome => DBCargosEscClassDicInfo.TabelaNome;
    public static string TTablePrefix => DBCargosEscClassDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBCargosEscClassDicInfo.CecNome, DBCargosEscClassDicInfo.CecGUID, DBCargosEscClassDicInfo.CecQuemCad, DBCargosEscClassDicInfo.CecDtCad, DBCargosEscClassDicInfo.CecQuemAtu, DBCargosEscClassDicInfo.CecDtAtu, DBCargosEscClassDicInfo.CecVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBCargosEscClassDicInfo.CecNome];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "cecCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBCargosEscClassDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "cecCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBCargosEscClassDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
