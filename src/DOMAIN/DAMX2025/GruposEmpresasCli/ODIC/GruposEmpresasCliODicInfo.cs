#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBGruposEmpresasCliODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBGruposEmpresasCliDicInfo.TabelaNome;
    public string ICampoCodigo() => DBGruposEmpresasCliDicInfo.CampoCodigo;
    public string IPrefixo() => DBGruposEmpresasCliDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBGruposEmpresasCliDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBGruposEmpresasCliDicInfo.Grupo => DBGruposEmpresasCliDicInfo.GecGrupo,
        DBGruposEmpresasCliDicInfo.Cliente => DBGruposEmpresasCliDicInfo.GecCliente,
        DBGruposEmpresasCliDicInfo.Oculto => DBGruposEmpresasCliDicInfo.GecOculto,
        DBGruposEmpresasCliDicInfo.QuemCad => DBGruposEmpresasCliDicInfo.GecQuemCad,
        DBGruposEmpresasCliDicInfo.DtCad => DBGruposEmpresasCliDicInfo.GecDtCad,
        DBGruposEmpresasCliDicInfo.QuemAtu => DBGruposEmpresasCliDicInfo.GecQuemAtu,
        DBGruposEmpresasCliDicInfo.DtAtu => DBGruposEmpresasCliDicInfo.GecDtAtu,
        DBGruposEmpresasCliDicInfo.Visto => DBGruposEmpresasCliDicInfo.GecVisto,
        _ => null
    };
    public static string TCampoCodigo => DBGruposEmpresasCliDicInfo.CampoCodigo;
    public static string TCampoNome => DBGruposEmpresasCliDicInfo.CampoNome;
    public static string TTabelaNome => DBGruposEmpresasCliDicInfo.TabelaNome;
    public static string TTablePrefix => DBGruposEmpresasCliDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBGruposEmpresasCliDicInfo.GecGrupo, DBGruposEmpresasCliDicInfo.GecCliente, DBGruposEmpresasCliDicInfo.GecOculto, DBGruposEmpresasCliDicInfo.GecQuemCad, DBGruposEmpresasCliDicInfo.GecDtCad, DBGruposEmpresasCliDicInfo.GecQuemAtu, DBGruposEmpresasCliDicInfo.GecDtAtu, DBGruposEmpresasCliDicInfo.GecVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBGruposEmpresasCliDicInfo.GecGrupo, DBGruposEmpresasCliDicInfo.GecCliente, DBGruposEmpresasCliDicInfo.GecOculto];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "gecCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBGruposEmpresasCliDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "gecCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBGruposEmpresasCliDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
