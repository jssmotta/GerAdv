#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBDadosProcuracaoODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBDadosProcuracaoDicInfo.TabelaNome;
    public string ICampoCodigo() => DBDadosProcuracaoDicInfo.CampoCodigo;
    public string IPrefixo() => DBDadosProcuracaoDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBDadosProcuracaoDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBDadosProcuracaoDicInfo.Cliente => DBDadosProcuracaoDicInfo.PrcCliente,
        DBDadosProcuracaoDicInfo.EstadoCivil => DBDadosProcuracaoDicInfo.PrcEstadoCivil,
        DBDadosProcuracaoDicInfo.Nacionalidade => DBDadosProcuracaoDicInfo.PrcNacionalidade,
        DBDadosProcuracaoDicInfo.Profissao => DBDadosProcuracaoDicInfo.PrcProfissao,
        DBDadosProcuracaoDicInfo.CTPS => DBDadosProcuracaoDicInfo.PrcCTPS,
        DBDadosProcuracaoDicInfo.PisPasep => DBDadosProcuracaoDicInfo.PrcPisPasep,
        DBDadosProcuracaoDicInfo.Remuneracao => DBDadosProcuracaoDicInfo.PrcRemuneracao,
        DBDadosProcuracaoDicInfo.Objeto => DBDadosProcuracaoDicInfo.PrcObjeto,
        DBDadosProcuracaoDicInfo.GUID => DBDadosProcuracaoDicInfo.PrcGUID,
        DBDadosProcuracaoDicInfo.QuemCad => DBDadosProcuracaoDicInfo.PrcQuemCad,
        DBDadosProcuracaoDicInfo.DtCad => DBDadosProcuracaoDicInfo.PrcDtCad,
        DBDadosProcuracaoDicInfo.QuemAtu => DBDadosProcuracaoDicInfo.PrcQuemAtu,
        DBDadosProcuracaoDicInfo.DtAtu => DBDadosProcuracaoDicInfo.PrcDtAtu,
        DBDadosProcuracaoDicInfo.Visto => DBDadosProcuracaoDicInfo.PrcVisto,
        _ => null
    };
    public static string TCampoCodigo => DBDadosProcuracaoDicInfo.CampoCodigo;
    public static string TCampoNome => DBDadosProcuracaoDicInfo.CampoNome;
    public static string TTabelaNome => DBDadosProcuracaoDicInfo.TabelaNome;
    public static string TTablePrefix => DBDadosProcuracaoDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBDadosProcuracaoDicInfo.PrcCliente, DBDadosProcuracaoDicInfo.PrcEstadoCivil, DBDadosProcuracaoDicInfo.PrcNacionalidade, DBDadosProcuracaoDicInfo.PrcProfissao, DBDadosProcuracaoDicInfo.PrcCTPS, DBDadosProcuracaoDicInfo.PrcPisPasep, DBDadosProcuracaoDicInfo.PrcRemuneracao, DBDadosProcuracaoDicInfo.PrcObjeto, DBDadosProcuracaoDicInfo.PrcGUID, DBDadosProcuracaoDicInfo.PrcQuemCad, DBDadosProcuracaoDicInfo.PrcDtCad, DBDadosProcuracaoDicInfo.PrcQuemAtu, DBDadosProcuracaoDicInfo.PrcDtAtu, DBDadosProcuracaoDicInfo.PrcVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBDadosProcuracaoDicInfo.PrcCliente, DBDadosProcuracaoDicInfo.PrcEstadoCivil, DBDadosProcuracaoDicInfo.PrcNacionalidade, DBDadosProcuracaoDicInfo.PrcProfissao, DBDadosProcuracaoDicInfo.PrcCTPS, DBDadosProcuracaoDicInfo.PrcPisPasep, DBDadosProcuracaoDicInfo.PrcRemuneracao, DBDadosProcuracaoDicInfo.PrcObjeto, DBDadosProcuracaoDicInfo.PrcGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "prcCliente"
        };
        var result = campos.Where(campo => !campo.Equals(DBDadosProcuracaoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "prcCliente",
            "prcCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBDadosProcuracaoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
