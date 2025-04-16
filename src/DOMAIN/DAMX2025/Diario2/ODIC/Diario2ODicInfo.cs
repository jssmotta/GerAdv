#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBDiario2ODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBDiario2DicInfo.TabelaNome;
    public string ICampoCodigo() => DBDiario2DicInfo.CampoCodigo;
    public string IPrefixo() => DBDiario2DicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBDiario2DicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBDiario2DicInfo.Data => DBDiario2DicInfo.DiaData,
        DBDiario2DicInfo.Hora => DBDiario2DicInfo.DiaHora,
        DBDiario2DicInfo.Operador => DBDiario2DicInfo.DiaOperador,
        DBDiario2DicInfo.Nome => DBDiario2DicInfo.DiaNome,
        DBDiario2DicInfo.Ocorrencia => DBDiario2DicInfo.DiaOcorrencia,
        DBDiario2DicInfo.Cliente => DBDiario2DicInfo.DiaCliente,
        DBDiario2DicInfo.Bold => DBDiario2DicInfo.DiaBold,
        DBDiario2DicInfo.GUID => DBDiario2DicInfo.DiaGUID,
        DBDiario2DicInfo.QuemCad => DBDiario2DicInfo.DiaQuemCad,
        DBDiario2DicInfo.DtCad => DBDiario2DicInfo.DiaDtCad,
        DBDiario2DicInfo.QuemAtu => DBDiario2DicInfo.DiaQuemAtu,
        DBDiario2DicInfo.DtAtu => DBDiario2DicInfo.DiaDtAtu,
        DBDiario2DicInfo.Visto => DBDiario2DicInfo.DiaVisto,
        _ => null
    };
    public static string TCampoCodigo => DBDiario2DicInfo.CampoCodigo;
    public static string TCampoNome => DBDiario2DicInfo.CampoNome;
    public static string TTabelaNome => DBDiario2DicInfo.TabelaNome;
    public static string TTablePrefix => DBDiario2DicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBDiario2DicInfo.DiaData, DBDiario2DicInfo.DiaHora, DBDiario2DicInfo.DiaOperador, DBDiario2DicInfo.DiaNome, DBDiario2DicInfo.DiaOcorrencia, DBDiario2DicInfo.DiaCliente, DBDiario2DicInfo.DiaBold, DBDiario2DicInfo.DiaGUID, DBDiario2DicInfo.DiaQuemCad, DBDiario2DicInfo.DiaDtCad, DBDiario2DicInfo.DiaQuemAtu, DBDiario2DicInfo.DiaDtAtu, DBDiario2DicInfo.DiaVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBDiario2DicInfo.DiaData, DBDiario2DicInfo.DiaHora, DBDiario2DicInfo.DiaOperador, DBDiario2DicInfo.DiaNome, DBDiario2DicInfo.DiaOcorrencia, DBDiario2DicInfo.DiaCliente, DBDiario2DicInfo.DiaBold];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "diaCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBDiario2DicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "diaCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBDiario2DicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
