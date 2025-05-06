#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBGUTAtividadesODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBGUTAtividadesDicInfo.TabelaNome;
    public string ICampoCodigo() => DBGUTAtividadesDicInfo.CampoCodigo;
    public string IPrefixo() => DBGUTAtividadesDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBGUTAtividadesDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBGUTAtividadesDicInfo.Nome => DBGUTAtividadesDicInfo.AgtNome,
        DBGUTAtividadesDicInfo.Observacao => DBGUTAtividadesDicInfo.AgtObservacao,
        DBGUTAtividadesDicInfo.GUTGrupo => DBGUTAtividadesDicInfo.AgtGUTGrupo,
        DBGUTAtividadesDicInfo.GUTPeriodicidade => DBGUTAtividadesDicInfo.AgtGUTPeriodicidade,
        DBGUTAtividadesDicInfo.Operador => DBGUTAtividadesDicInfo.AgtOperador,
        DBGUTAtividadesDicInfo.Concluido => DBGUTAtividadesDicInfo.AgtConcluido,
        DBGUTAtividadesDicInfo.DataConcluido => DBGUTAtividadesDicInfo.AgtDataConcluido,
        DBGUTAtividadesDicInfo.DiasParaIniciar => DBGUTAtividadesDicInfo.AgtDiasParaIniciar,
        DBGUTAtividadesDicInfo.MinutosParaRealizar => DBGUTAtividadesDicInfo.AgtMinutosParaRealizar,
        DBGUTAtividadesDicInfo.GUID => DBGUTAtividadesDicInfo.AgtGUID,
        DBGUTAtividadesDicInfo.QuemCad => DBGUTAtividadesDicInfo.AgtQuemCad,
        DBGUTAtividadesDicInfo.DtCad => DBGUTAtividadesDicInfo.AgtDtCad,
        DBGUTAtividadesDicInfo.QuemAtu => DBGUTAtividadesDicInfo.AgtQuemAtu,
        DBGUTAtividadesDicInfo.DtAtu => DBGUTAtividadesDicInfo.AgtDtAtu,
        DBGUTAtividadesDicInfo.Visto => DBGUTAtividadesDicInfo.AgtVisto,
        _ => null
    };
    public static string TCampoCodigo => DBGUTAtividadesDicInfo.CampoCodigo;
    public static string TCampoNome => DBGUTAtividadesDicInfo.CampoNome;
    public static string TTabelaNome => DBGUTAtividadesDicInfo.TabelaNome;
    public static string TTablePrefix => DBGUTAtividadesDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBGUTAtividadesDicInfo.AgtNome, DBGUTAtividadesDicInfo.AgtObservacao, DBGUTAtividadesDicInfo.AgtGUTGrupo, DBGUTAtividadesDicInfo.AgtGUTPeriodicidade, DBGUTAtividadesDicInfo.AgtOperador, DBGUTAtividadesDicInfo.AgtConcluido, DBGUTAtividadesDicInfo.AgtDataConcluido, DBGUTAtividadesDicInfo.AgtDiasParaIniciar, DBGUTAtividadesDicInfo.AgtMinutosParaRealizar, DBGUTAtividadesDicInfo.AgtGUID, DBGUTAtividadesDicInfo.AgtQuemCad, DBGUTAtividadesDicInfo.AgtDtCad, DBGUTAtividadesDicInfo.AgtQuemAtu, DBGUTAtividadesDicInfo.AgtDtAtu, DBGUTAtividadesDicInfo.AgtVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBGUTAtividadesDicInfo.AgtNome, DBGUTAtividadesDicInfo.AgtObservacao, DBGUTAtividadesDicInfo.AgtGUTGrupo, DBGUTAtividadesDicInfo.AgtGUTPeriodicidade, DBGUTAtividadesDicInfo.AgtOperador, DBGUTAtividadesDicInfo.AgtConcluido, DBGUTAtividadesDicInfo.AgtDataConcluido, DBGUTAtividadesDicInfo.AgtDiasParaIniciar, DBGUTAtividadesDicInfo.AgtMinutosParaRealizar, DBGUTAtividadesDicInfo.AgtGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "agtCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBGUTAtividadesDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "agtCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBGUTAtividadesDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
