#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBPontoVirtualODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBPontoVirtualDicInfo.TabelaNome;
    public string ICampoCodigo() => DBPontoVirtualDicInfo.CampoCodigo;
    public string IPrefixo() => DBPontoVirtualDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => false;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBPontoVirtualDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => false;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBPontoVirtualDicInfo.HoraEntrada => DBPontoVirtualDicInfo.PvtHoraEntrada,
        DBPontoVirtualDicInfo.HoraSaida => DBPontoVirtualDicInfo.PvtHoraSaida,
        DBPontoVirtualDicInfo.Operador => DBPontoVirtualDicInfo.PvtOperador,
        DBPontoVirtualDicInfo.Key => DBPontoVirtualDicInfo.PvtKey,
        _ => null
    };
    public static string TCampoCodigo => DBPontoVirtualDicInfo.CampoCodigo;
    public static string TCampoNome => DBPontoVirtualDicInfo.CampoNome;
    public static string TTabelaNome => DBPontoVirtualDicInfo.TabelaNome;
    public static string TTablePrefix => DBPontoVirtualDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBPontoVirtualDicInfo.PvtHoraEntrada, DBPontoVirtualDicInfo.PvtHoraSaida, DBPontoVirtualDicInfo.PvtOperador, DBPontoVirtualDicInfo.PvtKey];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBPontoVirtualDicInfo.PvtHoraEntrada, DBPontoVirtualDicInfo.PvtHoraSaida, DBPontoVirtualDicInfo.PvtOperador, DBPontoVirtualDicInfo.PvtKey];

    public static List<DBInfoSystem> ListPk() => [];
    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "pvtCodigo",
            "pvtKey"
        };
        var result = campos.Where(campo => !campo.Equals(DBPontoVirtualDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
