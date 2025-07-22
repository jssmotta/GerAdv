#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBHorasTrabODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBHorasTrabDicInfo.TabelaNome;
    public string ICampoCodigo() => DBHorasTrabDicInfo.CampoCodigo;
    public string IPrefixo() => DBHorasTrabDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBHorasTrabDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBHorasTrabDicInfo.IDContatoCRM => DBHorasTrabDicInfo.HtbIDContatoCRM,
        DBHorasTrabDicInfo.Honorario => DBHorasTrabDicInfo.HtbHonorario,
        DBHorasTrabDicInfo.IDAgenda => DBHorasTrabDicInfo.HtbIDAgenda,
        DBHorasTrabDicInfo.Data => DBHorasTrabDicInfo.HtbData,
        DBHorasTrabDicInfo.Cliente => DBHorasTrabDicInfo.HtbCliente,
        DBHorasTrabDicInfo.Status => DBHorasTrabDicInfo.HtbStatus,
        DBHorasTrabDicInfo.Processo => DBHorasTrabDicInfo.HtbProcesso,
        DBHorasTrabDicInfo.Advogado => DBHorasTrabDicInfo.HtbAdvogado,
        DBHorasTrabDicInfo.Funcionario => DBHorasTrabDicInfo.HtbFuncionario,
        DBHorasTrabDicInfo.HrIni => DBHorasTrabDicInfo.HtbHrIni,
        DBHorasTrabDicInfo.HrFim => DBHorasTrabDicInfo.HtbHrFim,
        DBHorasTrabDicInfo.Tempo => DBHorasTrabDicInfo.HtbTempo,
        DBHorasTrabDicInfo.Valor => DBHorasTrabDicInfo.HtbValor,
        DBHorasTrabDicInfo.OBS => DBHorasTrabDicInfo.HtbOBS,
        DBHorasTrabDicInfo.Anexo => DBHorasTrabDicInfo.HtbAnexo,
        DBHorasTrabDicInfo.AnexoComp => DBHorasTrabDicInfo.HtbAnexoComp,
        DBHorasTrabDicInfo.AnexoUNC => DBHorasTrabDicInfo.HtbAnexoUNC,
        DBHorasTrabDicInfo.Servico => DBHorasTrabDicInfo.HtbServico,
        DBHorasTrabDicInfo.GUID => DBHorasTrabDicInfo.HtbGUID,
        DBHorasTrabDicInfo.QuemCad => DBHorasTrabDicInfo.HtbQuemCad,
        DBHorasTrabDicInfo.DtCad => DBHorasTrabDicInfo.HtbDtCad,
        DBHorasTrabDicInfo.QuemAtu => DBHorasTrabDicInfo.HtbQuemAtu,
        DBHorasTrabDicInfo.DtAtu => DBHorasTrabDicInfo.HtbDtAtu,
        DBHorasTrabDicInfo.Visto => DBHorasTrabDicInfo.HtbVisto,
        _ => null
    };
    public static string TCampoCodigo => DBHorasTrabDicInfo.CampoCodigo;
    public static string TCampoNome => DBHorasTrabDicInfo.CampoNome;
    public static string TTabelaNome => DBHorasTrabDicInfo.TabelaNome;
    public static string TTablePrefix => DBHorasTrabDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBHorasTrabDicInfo.HtbIDContatoCRM, DBHorasTrabDicInfo.HtbHonorario, DBHorasTrabDicInfo.HtbIDAgenda, DBHorasTrabDicInfo.HtbData, DBHorasTrabDicInfo.HtbCliente, DBHorasTrabDicInfo.HtbStatus, DBHorasTrabDicInfo.HtbProcesso, DBHorasTrabDicInfo.HtbAdvogado, DBHorasTrabDicInfo.HtbFuncionario, DBHorasTrabDicInfo.HtbHrIni, DBHorasTrabDicInfo.HtbHrFim, DBHorasTrabDicInfo.HtbTempo, DBHorasTrabDicInfo.HtbValor, DBHorasTrabDicInfo.HtbOBS, DBHorasTrabDicInfo.HtbAnexo, DBHorasTrabDicInfo.HtbAnexoComp, DBHorasTrabDicInfo.HtbAnexoUNC, DBHorasTrabDicInfo.HtbServico, DBHorasTrabDicInfo.HtbGUID, DBHorasTrabDicInfo.HtbQuemCad, DBHorasTrabDicInfo.HtbDtCad, DBHorasTrabDicInfo.HtbQuemAtu, DBHorasTrabDicInfo.HtbDtAtu, DBHorasTrabDicInfo.HtbVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBHorasTrabDicInfo.HtbIDContatoCRM, DBHorasTrabDicInfo.HtbHonorario, DBHorasTrabDicInfo.HtbIDAgenda, DBHorasTrabDicInfo.HtbData, DBHorasTrabDicInfo.HtbCliente, DBHorasTrabDicInfo.HtbStatus, DBHorasTrabDicInfo.HtbProcesso, DBHorasTrabDicInfo.HtbAdvogado, DBHorasTrabDicInfo.HtbFuncionario, DBHorasTrabDicInfo.HtbHrIni, DBHorasTrabDicInfo.HtbHrFim, DBHorasTrabDicInfo.HtbTempo, DBHorasTrabDicInfo.HtbValor, DBHorasTrabDicInfo.HtbOBS, DBHorasTrabDicInfo.HtbAnexo, DBHorasTrabDicInfo.HtbAnexoComp, DBHorasTrabDicInfo.HtbAnexoUNC, DBHorasTrabDicInfo.HtbServico, DBHorasTrabDicInfo.HtbGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "htbCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBHorasTrabDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "htbCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBHorasTrabDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
