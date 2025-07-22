#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBAnexamentoRegistrosODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBAnexamentoRegistrosDicInfo.TabelaNome;
    public string ICampoCodigo() => DBAnexamentoRegistrosDicInfo.CampoCodigo;
    public string IPrefixo() => DBAnexamentoRegistrosDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBAnexamentoRegistrosDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBAnexamentoRegistrosDicInfo.Cliente => DBAnexamentoRegistrosDicInfo.AxrCliente,
        DBAnexamentoRegistrosDicInfo.GUIDReg => DBAnexamentoRegistrosDicInfo.AxrGUIDReg,
        DBAnexamentoRegistrosDicInfo.CodigoReg => DBAnexamentoRegistrosDicInfo.AxrCodigoReg,
        DBAnexamentoRegistrosDicInfo.IDReg => DBAnexamentoRegistrosDicInfo.AxrIDReg,
        DBAnexamentoRegistrosDicInfo.Data => DBAnexamentoRegistrosDicInfo.AxrData,
        DBAnexamentoRegistrosDicInfo.GUID => DBAnexamentoRegistrosDicInfo.AxrGUID,
        DBAnexamentoRegistrosDicInfo.QuemCad => DBAnexamentoRegistrosDicInfo.AxrQuemCad,
        DBAnexamentoRegistrosDicInfo.DtCad => DBAnexamentoRegistrosDicInfo.AxrDtCad,
        DBAnexamentoRegistrosDicInfo.QuemAtu => DBAnexamentoRegistrosDicInfo.AxrQuemAtu,
        DBAnexamentoRegistrosDicInfo.DtAtu => DBAnexamentoRegistrosDicInfo.AxrDtAtu,
        DBAnexamentoRegistrosDicInfo.Visto => DBAnexamentoRegistrosDicInfo.AxrVisto,
        _ => null
    };
    public static string TCampoCodigo => DBAnexamentoRegistrosDicInfo.CampoCodigo;
    public static string TCampoNome => DBAnexamentoRegistrosDicInfo.CampoNome;
    public static string TTabelaNome => DBAnexamentoRegistrosDicInfo.TabelaNome;
    public static string TTablePrefix => DBAnexamentoRegistrosDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBAnexamentoRegistrosDicInfo.AxrCliente, DBAnexamentoRegistrosDicInfo.AxrGUIDReg, DBAnexamentoRegistrosDicInfo.AxrCodigoReg, DBAnexamentoRegistrosDicInfo.AxrIDReg, DBAnexamentoRegistrosDicInfo.AxrData, DBAnexamentoRegistrosDicInfo.AxrGUID, DBAnexamentoRegistrosDicInfo.AxrQuemCad, DBAnexamentoRegistrosDicInfo.AxrDtCad, DBAnexamentoRegistrosDicInfo.AxrQuemAtu, DBAnexamentoRegistrosDicInfo.AxrDtAtu, DBAnexamentoRegistrosDicInfo.AxrVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBAnexamentoRegistrosDicInfo.AxrCliente, DBAnexamentoRegistrosDicInfo.AxrGUIDReg, DBAnexamentoRegistrosDicInfo.AxrCodigoReg, DBAnexamentoRegistrosDicInfo.AxrIDReg, DBAnexamentoRegistrosDicInfo.AxrData, DBAnexamentoRegistrosDicInfo.AxrGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "axrCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBAnexamentoRegistrosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "axrCodigo",
            "axrCodigoReg",
            "axrGUIDReg",
            "axrIDReg"
        };
        var result = campos.Where(campo => !campo.Equals(DBAnexamentoRegistrosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
