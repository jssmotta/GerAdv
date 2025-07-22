#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBInstanciaODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBInstanciaDicInfo.TabelaNome;
    public string ICampoCodigo() => DBInstanciaDicInfo.CampoCodigo;
    public string IPrefixo() => DBInstanciaDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBInstanciaDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBInstanciaDicInfo.LiminarPedida => DBInstanciaDicInfo.InsLiminarPedida,
        DBInstanciaDicInfo.Objeto => DBInstanciaDicInfo.InsObjeto,
        DBInstanciaDicInfo.StatusResultado => DBInstanciaDicInfo.InsStatusResultado,
        DBInstanciaDicInfo.LiminarPendente => DBInstanciaDicInfo.InsLiminarPendente,
        DBInstanciaDicInfo.InterpusemosRecurso => DBInstanciaDicInfo.InsInterpusemosRecurso,
        DBInstanciaDicInfo.LiminarConcedida => DBInstanciaDicInfo.InsLiminarConcedida,
        DBInstanciaDicInfo.LiminarNegada => DBInstanciaDicInfo.InsLiminarNegada,
        DBInstanciaDicInfo.Processo => DBInstanciaDicInfo.InsProcesso,
        DBInstanciaDicInfo.Data => DBInstanciaDicInfo.InsData,
        DBInstanciaDicInfo.LiminarParcial => DBInstanciaDicInfo.InsLiminarParcial,
        DBInstanciaDicInfo.LiminarResultado => DBInstanciaDicInfo.InsLiminarResultado,
        DBInstanciaDicInfo.NroProcesso => DBInstanciaDicInfo.InsNroProcesso,
        DBInstanciaDicInfo.Divisao => DBInstanciaDicInfo.InsDivisao,
        DBInstanciaDicInfo.LiminarCliente => DBInstanciaDicInfo.InsLiminarCliente,
        DBInstanciaDicInfo.Comarca => DBInstanciaDicInfo.InsComarca,
        DBInstanciaDicInfo.SubDivisao => DBInstanciaDicInfo.InsSubDivisao,
        DBInstanciaDicInfo.Principal => DBInstanciaDicInfo.InsPrincipal,
        DBInstanciaDicInfo.Acao => DBInstanciaDicInfo.InsAcao,
        DBInstanciaDicInfo.Foro => DBInstanciaDicInfo.InsForo,
        DBInstanciaDicInfo.TipoRecurso => DBInstanciaDicInfo.InsTipoRecurso,
        DBInstanciaDicInfo.ZKey => DBInstanciaDicInfo.InsZKey,
        DBInstanciaDicInfo.ZKeyQuem => DBInstanciaDicInfo.InsZKeyQuem,
        DBInstanciaDicInfo.ZKeyQuando => DBInstanciaDicInfo.InsZKeyQuando,
        DBInstanciaDicInfo.NroAntigo => DBInstanciaDicInfo.InsNroAntigo,
        DBInstanciaDicInfo.AccessCode => DBInstanciaDicInfo.InsAccessCode,
        DBInstanciaDicInfo.Julgador => DBInstanciaDicInfo.InsJulgador,
        DBInstanciaDicInfo.ZKeyIA => DBInstanciaDicInfo.InsZKeyIA,
        DBInstanciaDicInfo.GUID => DBInstanciaDicInfo.InsGUID,
        DBInstanciaDicInfo.QuemCad => DBInstanciaDicInfo.InsQuemCad,
        DBInstanciaDicInfo.DtCad => DBInstanciaDicInfo.InsDtCad,
        DBInstanciaDicInfo.QuemAtu => DBInstanciaDicInfo.InsQuemAtu,
        DBInstanciaDicInfo.DtAtu => DBInstanciaDicInfo.InsDtAtu,
        DBInstanciaDicInfo.Visto => DBInstanciaDicInfo.InsVisto,
        _ => null
    };
    public static string TCampoCodigo => DBInstanciaDicInfo.CampoCodigo;
    public static string TCampoNome => DBInstanciaDicInfo.CampoNome;
    public static string TTabelaNome => DBInstanciaDicInfo.TabelaNome;
    public static string TTablePrefix => DBInstanciaDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBInstanciaDicInfo.InsLiminarPedida, DBInstanciaDicInfo.InsObjeto, DBInstanciaDicInfo.InsStatusResultado, DBInstanciaDicInfo.InsLiminarPendente, DBInstanciaDicInfo.InsInterpusemosRecurso, DBInstanciaDicInfo.InsLiminarConcedida, DBInstanciaDicInfo.InsLiminarNegada, DBInstanciaDicInfo.InsProcesso, DBInstanciaDicInfo.InsData, DBInstanciaDicInfo.InsLiminarParcial, DBInstanciaDicInfo.InsLiminarResultado, DBInstanciaDicInfo.InsNroProcesso, DBInstanciaDicInfo.InsDivisao, DBInstanciaDicInfo.InsLiminarCliente, DBInstanciaDicInfo.InsComarca, DBInstanciaDicInfo.InsSubDivisao, DBInstanciaDicInfo.InsPrincipal, DBInstanciaDicInfo.InsAcao, DBInstanciaDicInfo.InsForo, DBInstanciaDicInfo.InsTipoRecurso, DBInstanciaDicInfo.InsZKey, DBInstanciaDicInfo.InsZKeyQuem, DBInstanciaDicInfo.InsZKeyQuando, DBInstanciaDicInfo.InsNroAntigo, DBInstanciaDicInfo.InsAccessCode, DBInstanciaDicInfo.InsJulgador, DBInstanciaDicInfo.InsZKeyIA, DBInstanciaDicInfo.InsGUID, DBInstanciaDicInfo.InsQuemCad, DBInstanciaDicInfo.InsDtCad, DBInstanciaDicInfo.InsQuemAtu, DBInstanciaDicInfo.InsDtAtu, DBInstanciaDicInfo.InsVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBInstanciaDicInfo.InsLiminarPedida, DBInstanciaDicInfo.InsObjeto, DBInstanciaDicInfo.InsStatusResultado, DBInstanciaDicInfo.InsLiminarPendente, DBInstanciaDicInfo.InsInterpusemosRecurso, DBInstanciaDicInfo.InsLiminarConcedida, DBInstanciaDicInfo.InsLiminarNegada, DBInstanciaDicInfo.InsProcesso, DBInstanciaDicInfo.InsData, DBInstanciaDicInfo.InsLiminarParcial, DBInstanciaDicInfo.InsLiminarResultado, DBInstanciaDicInfo.InsNroProcesso, DBInstanciaDicInfo.InsDivisao, DBInstanciaDicInfo.InsLiminarCliente, DBInstanciaDicInfo.InsComarca, DBInstanciaDicInfo.InsSubDivisao, DBInstanciaDicInfo.InsPrincipal, DBInstanciaDicInfo.InsAcao, DBInstanciaDicInfo.InsForo, DBInstanciaDicInfo.InsTipoRecurso, DBInstanciaDicInfo.InsZKey, DBInstanciaDicInfo.InsZKeyQuem, DBInstanciaDicInfo.InsZKeyQuando, DBInstanciaDicInfo.InsNroAntigo, DBInstanciaDicInfo.InsAccessCode, DBInstanciaDicInfo.InsJulgador, DBInstanciaDicInfo.InsZKeyIA, DBInstanciaDicInfo.InsGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "insCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBInstanciaDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "insCodigo",
            "insDivisao",
            "insNroProcesso",
            "insSubDivisao"
        };
        var result = campos.Where(campo => !campo.Equals(DBInstanciaDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
