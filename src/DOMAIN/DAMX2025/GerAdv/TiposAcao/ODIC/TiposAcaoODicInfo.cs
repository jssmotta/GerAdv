#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBTiposAcaoODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBTiposAcaoDicInfo.TabelaNome;
    public string ICampoCodigo() => DBTiposAcaoDicInfo.CampoCodigo;
    public string IPrefixo() => DBTiposAcaoDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBTiposAcaoDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBTiposAcaoDicInfo.Nome => DBTiposAcaoDicInfo.TacNome,
        DBTiposAcaoDicInfo.Inativo => DBTiposAcaoDicInfo.TacInativo,
        DBTiposAcaoDicInfo.Bold => DBTiposAcaoDicInfo.TacBold,
        DBTiposAcaoDicInfo.GUID => DBTiposAcaoDicInfo.TacGUID,
        DBTiposAcaoDicInfo.QuemCad => DBTiposAcaoDicInfo.TacQuemCad,
        DBTiposAcaoDicInfo.DtCad => DBTiposAcaoDicInfo.TacDtCad,
        DBTiposAcaoDicInfo.QuemAtu => DBTiposAcaoDicInfo.TacQuemAtu,
        DBTiposAcaoDicInfo.DtAtu => DBTiposAcaoDicInfo.TacDtAtu,
        DBTiposAcaoDicInfo.Visto => DBTiposAcaoDicInfo.TacVisto,
        _ => null
    };
    public static string TCampoCodigo => DBTiposAcaoDicInfo.CampoCodigo;
    public static string TCampoNome => DBTiposAcaoDicInfo.CampoNome;
    public static string TTabelaNome => DBTiposAcaoDicInfo.TabelaNome;
    public static string TTablePrefix => DBTiposAcaoDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBTiposAcaoDicInfo.TacNome, DBTiposAcaoDicInfo.TacInativo, DBTiposAcaoDicInfo.TacBold, DBTiposAcaoDicInfo.TacGUID, DBTiposAcaoDicInfo.TacQuemCad, DBTiposAcaoDicInfo.TacDtCad, DBTiposAcaoDicInfo.TacQuemAtu, DBTiposAcaoDicInfo.TacDtAtu, DBTiposAcaoDicInfo.TacVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBTiposAcaoDicInfo.TacNome, DBTiposAcaoDicInfo.TacInativo, DBTiposAcaoDicInfo.TacGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "tacCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBTiposAcaoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "tacCodigo",
            "tacNome"
        };
        var result = campos.Where(campo => !campo.Equals(DBTiposAcaoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
