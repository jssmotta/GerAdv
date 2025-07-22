#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBReuniaoODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBReuniaoDicInfo.TabelaNome;
    public string ICampoCodigo() => DBReuniaoDicInfo.CampoCodigo;
    public string IPrefixo() => DBReuniaoDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBReuniaoDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBReuniaoDicInfo.Cliente => DBReuniaoDicInfo.RenCliente,
        DBReuniaoDicInfo.IDAgenda => DBReuniaoDicInfo.RenIDAgenda,
        DBReuniaoDicInfo.Data => DBReuniaoDicInfo.RenData,
        DBReuniaoDicInfo.Pauta => DBReuniaoDicInfo.RenPauta,
        DBReuniaoDicInfo.ATA => DBReuniaoDicInfo.RenATA,
        DBReuniaoDicInfo.HoraInicial => DBReuniaoDicInfo.RenHoraInicial,
        DBReuniaoDicInfo.HoraFinal => DBReuniaoDicInfo.RenHoraFinal,
        DBReuniaoDicInfo.Externa => DBReuniaoDicInfo.RenExterna,
        DBReuniaoDicInfo.HoraSaida => DBReuniaoDicInfo.RenHoraSaida,
        DBReuniaoDicInfo.HoraRetorno => DBReuniaoDicInfo.RenHoraRetorno,
        DBReuniaoDicInfo.PrincipaisDecisoes => DBReuniaoDicInfo.RenPrincipaisDecisoes,
        DBReuniaoDicInfo.Bold => DBReuniaoDicInfo.RenBold,
        DBReuniaoDicInfo.GUID => DBReuniaoDicInfo.RenGUID,
        DBReuniaoDicInfo.QuemCad => DBReuniaoDicInfo.RenQuemCad,
        DBReuniaoDicInfo.DtCad => DBReuniaoDicInfo.RenDtCad,
        DBReuniaoDicInfo.QuemAtu => DBReuniaoDicInfo.RenQuemAtu,
        DBReuniaoDicInfo.DtAtu => DBReuniaoDicInfo.RenDtAtu,
        DBReuniaoDicInfo.Visto => DBReuniaoDicInfo.RenVisto,
        _ => null
    };
    public static string TCampoCodigo => DBReuniaoDicInfo.CampoCodigo;
    public static string TCampoNome => DBReuniaoDicInfo.CampoNome;
    public static string TTabelaNome => DBReuniaoDicInfo.TabelaNome;
    public static string TTablePrefix => DBReuniaoDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBReuniaoDicInfo.RenCliente, DBReuniaoDicInfo.RenIDAgenda, DBReuniaoDicInfo.RenData, DBReuniaoDicInfo.RenPauta, DBReuniaoDicInfo.RenATA, DBReuniaoDicInfo.RenHoraInicial, DBReuniaoDicInfo.RenHoraFinal, DBReuniaoDicInfo.RenExterna, DBReuniaoDicInfo.RenHoraSaida, DBReuniaoDicInfo.RenHoraRetorno, DBReuniaoDicInfo.RenPrincipaisDecisoes, DBReuniaoDicInfo.RenBold, DBReuniaoDicInfo.RenGUID, DBReuniaoDicInfo.RenQuemCad, DBReuniaoDicInfo.RenDtCad, DBReuniaoDicInfo.RenQuemAtu, DBReuniaoDicInfo.RenDtAtu, DBReuniaoDicInfo.RenVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBReuniaoDicInfo.RenCliente, DBReuniaoDicInfo.RenIDAgenda, DBReuniaoDicInfo.RenData, DBReuniaoDicInfo.RenPauta, DBReuniaoDicInfo.RenATA, DBReuniaoDicInfo.RenHoraInicial, DBReuniaoDicInfo.RenHoraFinal, DBReuniaoDicInfo.RenExterna, DBReuniaoDicInfo.RenHoraSaida, DBReuniaoDicInfo.RenHoraRetorno, DBReuniaoDicInfo.RenPrincipaisDecisoes, DBReuniaoDicInfo.RenGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "renCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBReuniaoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "renCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBReuniaoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
