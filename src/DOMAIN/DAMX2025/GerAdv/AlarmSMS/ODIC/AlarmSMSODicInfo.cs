#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBAlarmSMSODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBAlarmSMSDicInfo.TabelaNome;
    public string ICampoCodigo() => DBAlarmSMSDicInfo.CampoCodigo;
    public string IPrefixo() => DBAlarmSMSDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBAlarmSMSDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBAlarmSMSDicInfo.Descricao => DBAlarmSMSDicInfo.AlrDescricao,
        DBAlarmSMSDicInfo.Hora => DBAlarmSMSDicInfo.AlrHora,
        DBAlarmSMSDicInfo.Minuto => DBAlarmSMSDicInfo.AlrMinuto,
        DBAlarmSMSDicInfo.D1 => DBAlarmSMSDicInfo.AlrD1,
        DBAlarmSMSDicInfo.D2 => DBAlarmSMSDicInfo.AlrD2,
        DBAlarmSMSDicInfo.D3 => DBAlarmSMSDicInfo.AlrD3,
        DBAlarmSMSDicInfo.D4 => DBAlarmSMSDicInfo.AlrD4,
        DBAlarmSMSDicInfo.D5 => DBAlarmSMSDicInfo.AlrD5,
        DBAlarmSMSDicInfo.D6 => DBAlarmSMSDicInfo.AlrD6,
        DBAlarmSMSDicInfo.D7 => DBAlarmSMSDicInfo.AlrD7,
        DBAlarmSMSDicInfo.EMail => DBAlarmSMSDicInfo.AlrEMail,
        DBAlarmSMSDicInfo.Desativar => DBAlarmSMSDicInfo.AlrDesativar,
        DBAlarmSMSDicInfo.Today => DBAlarmSMSDicInfo.AlrToday,
        DBAlarmSMSDicInfo.ExcetoDiasFelizes => DBAlarmSMSDicInfo.AlrExcetoDiasFelizes,
        DBAlarmSMSDicInfo.Desktop => DBAlarmSMSDicInfo.AlrDesktop,
        DBAlarmSMSDicInfo.AlertarDataHora => DBAlarmSMSDicInfo.AlrAlertarDataHora,
        DBAlarmSMSDicInfo.Operador => DBAlarmSMSDicInfo.AlrOperador,
        DBAlarmSMSDicInfo.GuidExo => DBAlarmSMSDicInfo.AlrGuidExo,
        DBAlarmSMSDicInfo.Agenda => DBAlarmSMSDicInfo.AlrAgenda,
        DBAlarmSMSDicInfo.Recado => DBAlarmSMSDicInfo.AlrRecado,
        DBAlarmSMSDicInfo.Emocao => DBAlarmSMSDicInfo.AlrEmocao,
        DBAlarmSMSDicInfo.GUID => DBAlarmSMSDicInfo.AlrGUID,
        DBAlarmSMSDicInfo.QuemCad => DBAlarmSMSDicInfo.AlrQuemCad,
        DBAlarmSMSDicInfo.DtCad => DBAlarmSMSDicInfo.AlrDtCad,
        DBAlarmSMSDicInfo.QuemAtu => DBAlarmSMSDicInfo.AlrQuemAtu,
        DBAlarmSMSDicInfo.DtAtu => DBAlarmSMSDicInfo.AlrDtAtu,
        DBAlarmSMSDicInfo.Visto => DBAlarmSMSDicInfo.AlrVisto,
        _ => null
    };
    public static string TCampoCodigo => DBAlarmSMSDicInfo.CampoCodigo;
    public static string TCampoNome => DBAlarmSMSDicInfo.CampoNome;
    public static string TTabelaNome => DBAlarmSMSDicInfo.TabelaNome;
    public static string TTablePrefix => DBAlarmSMSDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBAlarmSMSDicInfo.AlrDescricao, DBAlarmSMSDicInfo.AlrHora, DBAlarmSMSDicInfo.AlrMinuto, DBAlarmSMSDicInfo.AlrD1, DBAlarmSMSDicInfo.AlrD2, DBAlarmSMSDicInfo.AlrD3, DBAlarmSMSDicInfo.AlrD4, DBAlarmSMSDicInfo.AlrD5, DBAlarmSMSDicInfo.AlrD6, DBAlarmSMSDicInfo.AlrD7, DBAlarmSMSDicInfo.AlrEMail, DBAlarmSMSDicInfo.AlrDesativar, DBAlarmSMSDicInfo.AlrToday, DBAlarmSMSDicInfo.AlrExcetoDiasFelizes, DBAlarmSMSDicInfo.AlrDesktop, DBAlarmSMSDicInfo.AlrAlertarDataHora, DBAlarmSMSDicInfo.AlrOperador, DBAlarmSMSDicInfo.AlrGuidExo, DBAlarmSMSDicInfo.AlrAgenda, DBAlarmSMSDicInfo.AlrRecado, DBAlarmSMSDicInfo.AlrEmocao, DBAlarmSMSDicInfo.AlrGUID, DBAlarmSMSDicInfo.AlrQuemCad, DBAlarmSMSDicInfo.AlrDtCad, DBAlarmSMSDicInfo.AlrQuemAtu, DBAlarmSMSDicInfo.AlrDtAtu, DBAlarmSMSDicInfo.AlrVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBAlarmSMSDicInfo.AlrDescricao, DBAlarmSMSDicInfo.AlrHora, DBAlarmSMSDicInfo.AlrMinuto, DBAlarmSMSDicInfo.AlrD1, DBAlarmSMSDicInfo.AlrD2, DBAlarmSMSDicInfo.AlrD3, DBAlarmSMSDicInfo.AlrD4, DBAlarmSMSDicInfo.AlrD5, DBAlarmSMSDicInfo.AlrD6, DBAlarmSMSDicInfo.AlrD7, DBAlarmSMSDicInfo.AlrEMail, DBAlarmSMSDicInfo.AlrDesativar, DBAlarmSMSDicInfo.AlrToday, DBAlarmSMSDicInfo.AlrExcetoDiasFelizes, DBAlarmSMSDicInfo.AlrDesktop, DBAlarmSMSDicInfo.AlrAlertarDataHora, DBAlarmSMSDicInfo.AlrOperador, DBAlarmSMSDicInfo.AlrGuidExo, DBAlarmSMSDicInfo.AlrAgenda, DBAlarmSMSDicInfo.AlrRecado, DBAlarmSMSDicInfo.AlrEmocao, DBAlarmSMSDicInfo.AlrGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "alrCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBAlarmSMSDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "alrCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBAlarmSMSDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
