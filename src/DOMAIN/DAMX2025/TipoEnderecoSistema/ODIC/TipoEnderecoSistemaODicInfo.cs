#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBTipoEnderecoSistemaODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBTipoEnderecoSistemaDicInfo.TabelaNome;
    public string ICampoCodigo() => DBTipoEnderecoSistemaDicInfo.CampoCodigo;
    public string IPrefixo() => DBTipoEnderecoSistemaDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBTipoEnderecoSistemaDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBTipoEnderecoSistemaDicInfo.Nome => DBTipoEnderecoSistemaDicInfo.TesNome,
        DBTipoEnderecoSistemaDicInfo.GUID => DBTipoEnderecoSistemaDicInfo.TesGUID,
        DBTipoEnderecoSistemaDicInfo.QuemCad => DBTipoEnderecoSistemaDicInfo.TesQuemCad,
        DBTipoEnderecoSistemaDicInfo.DtCad => DBTipoEnderecoSistemaDicInfo.TesDtCad,
        DBTipoEnderecoSistemaDicInfo.QuemAtu => DBTipoEnderecoSistemaDicInfo.TesQuemAtu,
        DBTipoEnderecoSistemaDicInfo.DtAtu => DBTipoEnderecoSistemaDicInfo.TesDtAtu,
        DBTipoEnderecoSistemaDicInfo.Visto => DBTipoEnderecoSistemaDicInfo.TesVisto,
        _ => null
    };
    public static string TCampoCodigo => DBTipoEnderecoSistemaDicInfo.CampoCodigo;
    public static string TCampoNome => DBTipoEnderecoSistemaDicInfo.CampoNome;
    public static string TTabelaNome => DBTipoEnderecoSistemaDicInfo.TabelaNome;
    public static string TTablePrefix => DBTipoEnderecoSistemaDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBTipoEnderecoSistemaDicInfo.TesNome, DBTipoEnderecoSistemaDicInfo.TesGUID, DBTipoEnderecoSistemaDicInfo.TesQuemCad, DBTipoEnderecoSistemaDicInfo.TesDtCad, DBTipoEnderecoSistemaDicInfo.TesQuemAtu, DBTipoEnderecoSistemaDicInfo.TesDtAtu, DBTipoEnderecoSistemaDicInfo.TesVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBTipoEnderecoSistemaDicInfo.TesNome, DBTipoEnderecoSistemaDicInfo.TesGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "tesCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBTipoEnderecoSistemaDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "tesCodigo",
            "tesNome"
        };
        var result = campos.Where(campo => !campo.Equals(DBTipoEnderecoSistemaDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
