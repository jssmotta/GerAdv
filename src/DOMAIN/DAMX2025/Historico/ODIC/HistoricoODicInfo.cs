#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBHistoricoODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBHistoricoDicInfo.TabelaNome;
    public string ICampoCodigo() => DBHistoricoDicInfo.CampoCodigo;
    public string IPrefixo() => DBHistoricoDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBHistoricoDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBHistoricoDicInfo.ExtraID => DBHistoricoDicInfo.HisExtraID,
        DBHistoricoDicInfo.IDNE => DBHistoricoDicInfo.HisIDNE,
        DBHistoricoDicInfo.ExtraGUID => DBHistoricoDicInfo.HisExtraGUID,
        DBHistoricoDicInfo.LiminarOrigem => DBHistoricoDicInfo.HisLiminarOrigem,
        DBHistoricoDicInfo.NaoPublicavel => DBHistoricoDicInfo.HisNaoPublicavel,
        DBHistoricoDicInfo.Processo => DBHistoricoDicInfo.HisProcesso,
        DBHistoricoDicInfo.Precatoria => DBHistoricoDicInfo.HisPrecatoria,
        DBHistoricoDicInfo.Apenso => DBHistoricoDicInfo.HisApenso,
        DBHistoricoDicInfo.IDInstProcesso => DBHistoricoDicInfo.HisIDInstProcesso,
        DBHistoricoDicInfo.Fase => DBHistoricoDicInfo.HisFase,
        DBHistoricoDicInfo.Data => DBHistoricoDicInfo.HisData,
        DBHistoricoDicInfo.Observacao => DBHistoricoDicInfo.HisObservacao,
        DBHistoricoDicInfo.Agendado => DBHistoricoDicInfo.HisAgendado,
        DBHistoricoDicInfo.Concluido => DBHistoricoDicInfo.HisConcluido,
        DBHistoricoDicInfo.MesmaAgenda => DBHistoricoDicInfo.HisMesmaAgenda,
        DBHistoricoDicInfo.SAD => DBHistoricoDicInfo.HisSAD,
        DBHistoricoDicInfo.Resumido => DBHistoricoDicInfo.HisResumido,
        DBHistoricoDicInfo.StatusAndamento => DBHistoricoDicInfo.HisStatusAndamento,
        DBHistoricoDicInfo.Top => DBHistoricoDicInfo.HisTop,
        DBHistoricoDicInfo.GUID => DBHistoricoDicInfo.HisGUID,
        DBHistoricoDicInfo.QuemCad => DBHistoricoDicInfo.HisQuemCad,
        DBHistoricoDicInfo.DtCad => DBHistoricoDicInfo.HisDtCad,
        DBHistoricoDicInfo.QuemAtu => DBHistoricoDicInfo.HisQuemAtu,
        DBHistoricoDicInfo.DtAtu => DBHistoricoDicInfo.HisDtAtu,
        DBHistoricoDicInfo.Visto => DBHistoricoDicInfo.HisVisto,
        _ => null
    };
    public static string TCampoCodigo => DBHistoricoDicInfo.CampoCodigo;
    public static string TCampoNome => DBHistoricoDicInfo.CampoNome;
    public static string TTabelaNome => DBHistoricoDicInfo.TabelaNome;
    public static string TTablePrefix => DBHistoricoDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBHistoricoDicInfo.HisExtraID, DBHistoricoDicInfo.HisIDNE, DBHistoricoDicInfo.HisExtraGUID, DBHistoricoDicInfo.HisLiminarOrigem, DBHistoricoDicInfo.HisNaoPublicavel, DBHistoricoDicInfo.HisProcesso, DBHistoricoDicInfo.HisPrecatoria, DBHistoricoDicInfo.HisApenso, DBHistoricoDicInfo.HisIDInstProcesso, DBHistoricoDicInfo.HisFase, DBHistoricoDicInfo.HisData, DBHistoricoDicInfo.HisObservacao, DBHistoricoDicInfo.HisAgendado, DBHistoricoDicInfo.HisConcluido, DBHistoricoDicInfo.HisMesmaAgenda, DBHistoricoDicInfo.HisSAD, DBHistoricoDicInfo.HisResumido, DBHistoricoDicInfo.HisStatusAndamento, DBHistoricoDicInfo.HisTop, DBHistoricoDicInfo.HisGUID, DBHistoricoDicInfo.HisQuemCad, DBHistoricoDicInfo.HisDtCad, DBHistoricoDicInfo.HisQuemAtu, DBHistoricoDicInfo.HisDtAtu, DBHistoricoDicInfo.HisVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBHistoricoDicInfo.HisExtraID, DBHistoricoDicInfo.HisIDNE, DBHistoricoDicInfo.HisExtraGUID, DBHistoricoDicInfo.HisLiminarOrigem, DBHistoricoDicInfo.HisNaoPublicavel, DBHistoricoDicInfo.HisProcesso, DBHistoricoDicInfo.HisPrecatoria, DBHistoricoDicInfo.HisApenso, DBHistoricoDicInfo.HisIDInstProcesso, DBHistoricoDicInfo.HisFase, DBHistoricoDicInfo.HisData, DBHistoricoDicInfo.HisObservacao, DBHistoricoDicInfo.HisAgendado, DBHistoricoDicInfo.HisConcluido, DBHistoricoDicInfo.HisMesmaAgenda, DBHistoricoDicInfo.HisSAD, DBHistoricoDicInfo.HisResumido, DBHistoricoDicInfo.HisStatusAndamento, DBHistoricoDicInfo.HisTop, DBHistoricoDicInfo.HisGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "hisCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBHistoricoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "hisCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBHistoricoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
