#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBOperadorGrupoODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBOperadorGrupoDicInfo.TabelaNome;
    public string ICampoCodigo() => DBOperadorGrupoDicInfo.CampoCodigo;
    public string IPrefixo() => DBOperadorGrupoDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBOperadorGrupoDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBOperadorGrupoDicInfo.Operador => DBOperadorGrupoDicInfo.OgrOperador,
        DBOperadorGrupoDicInfo.Grupo => DBOperadorGrupoDicInfo.OgrGrupo,
        DBOperadorGrupoDicInfo.Inativo => DBOperadorGrupoDicInfo.OgrInativo,
        DBOperadorGrupoDicInfo.QuemCad => DBOperadorGrupoDicInfo.OgrQuemCad,
        DBOperadorGrupoDicInfo.DtCad => DBOperadorGrupoDicInfo.OgrDtCad,
        DBOperadorGrupoDicInfo.QuemAtu => DBOperadorGrupoDicInfo.OgrQuemAtu,
        DBOperadorGrupoDicInfo.DtAtu => DBOperadorGrupoDicInfo.OgrDtAtu,
        DBOperadorGrupoDicInfo.Visto => DBOperadorGrupoDicInfo.OgrVisto,
        _ => null
    };
    public static string TCampoCodigo => DBOperadorGrupoDicInfo.CampoCodigo;
    public static string TCampoNome => DBOperadorGrupoDicInfo.CampoNome;
    public static string TTabelaNome => DBOperadorGrupoDicInfo.TabelaNome;
    public static string TTablePrefix => DBOperadorGrupoDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBOperadorGrupoDicInfo.OgrOperador, DBOperadorGrupoDicInfo.OgrGrupo, DBOperadorGrupoDicInfo.OgrInativo, DBOperadorGrupoDicInfo.OgrQuemCad, DBOperadorGrupoDicInfo.OgrDtCad, DBOperadorGrupoDicInfo.OgrQuemAtu, DBOperadorGrupoDicInfo.OgrDtAtu, DBOperadorGrupoDicInfo.OgrVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBOperadorGrupoDicInfo.OgrOperador, DBOperadorGrupoDicInfo.OgrGrupo, DBOperadorGrupoDicInfo.OgrInativo];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "ogrCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBOperadorGrupoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "ogrCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBOperadorGrupoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
