#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBContratosODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBContratosDicInfo.TabelaNome;
    public string ICampoCodigo() => DBContratosDicInfo.CampoCodigo;
    public string IPrefixo() => DBContratosDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBContratosDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBContratosDicInfo.Processo => DBContratosDicInfo.CttProcesso,
        DBContratosDicInfo.Cliente => DBContratosDicInfo.CttCliente,
        DBContratosDicInfo.Advogado => DBContratosDicInfo.CttAdvogado,
        DBContratosDicInfo.Dia => DBContratosDicInfo.CttDia,
        DBContratosDicInfo.Valor => DBContratosDicInfo.CttValor,
        DBContratosDicInfo.DataInicio => DBContratosDicInfo.CttDataInicio,
        DBContratosDicInfo.DataTermino => DBContratosDicInfo.CttDataTermino,
        DBContratosDicInfo.OcultarRelatorio => DBContratosDicInfo.CttOcultarRelatorio,
        DBContratosDicInfo.PercEscritorio => DBContratosDicInfo.CttPercEscritorio,
        DBContratosDicInfo.ValorConsultoria => DBContratosDicInfo.CttValorConsultoria,
        DBContratosDicInfo.TipoCobranca => DBContratosDicInfo.CttTipoCobranca,
        DBContratosDicInfo.Protestar => DBContratosDicInfo.CttProtestar,
        DBContratosDicInfo.Juros => DBContratosDicInfo.CttJuros,
        DBContratosDicInfo.ValorRealizavel => DBContratosDicInfo.CttValorRealizavel,
        DBContratosDicInfo.DOCUMENTO => DBContratosDicInfo.CttDOCUMENTO,
        DBContratosDicInfo.EMail1 => DBContratosDicInfo.CttEMail1,
        DBContratosDicInfo.EMail2 => DBContratosDicInfo.CttEMail2,
        DBContratosDicInfo.EMail3 => DBContratosDicInfo.CttEMail3,
        DBContratosDicInfo.Pessoa1 => DBContratosDicInfo.CttPessoa1,
        DBContratosDicInfo.Pessoa2 => DBContratosDicInfo.CttPessoa2,
        DBContratosDicInfo.Pessoa3 => DBContratosDicInfo.CttPessoa3,
        DBContratosDicInfo.OBS => DBContratosDicInfo.CttOBS,
        DBContratosDicInfo.ClienteContrato => DBContratosDicInfo.CttClienteContrato,
        DBContratosDicInfo.IdExtrangeiro => DBContratosDicInfo.CttIdExtrangeiro,
        DBContratosDicInfo.ChaveContrato => DBContratosDicInfo.CttChaveContrato,
        DBContratosDicInfo.Avulso => DBContratosDicInfo.CttAvulso,
        DBContratosDicInfo.Suspenso => DBContratosDicInfo.CttSuspenso,
        DBContratosDicInfo.Multa => DBContratosDicInfo.CttMulta,
        DBContratosDicInfo.Bold => DBContratosDicInfo.CttBold,
        DBContratosDicInfo.GUID => DBContratosDicInfo.CttGUID,
        DBContratosDicInfo.QuemCad => DBContratosDicInfo.CttQuemCad,
        DBContratosDicInfo.DtCad => DBContratosDicInfo.CttDtCad,
        DBContratosDicInfo.QuemAtu => DBContratosDicInfo.CttQuemAtu,
        DBContratosDicInfo.DtAtu => DBContratosDicInfo.CttDtAtu,
        DBContratosDicInfo.Visto => DBContratosDicInfo.CttVisto,
        _ => null
    };
    public static string TCampoCodigo => DBContratosDicInfo.CampoCodigo;
    public static string TCampoNome => DBContratosDicInfo.CampoNome;
    public static string TTabelaNome => DBContratosDicInfo.TabelaNome;
    public static string TTablePrefix => DBContratosDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBContratosDicInfo.CttProcesso, DBContratosDicInfo.CttCliente, DBContratosDicInfo.CttAdvogado, DBContratosDicInfo.CttDia, DBContratosDicInfo.CttValor, DBContratosDicInfo.CttDataInicio, DBContratosDicInfo.CttDataTermino, DBContratosDicInfo.CttOcultarRelatorio, DBContratosDicInfo.CttPercEscritorio, DBContratosDicInfo.CttValorConsultoria, DBContratosDicInfo.CttTipoCobranca, DBContratosDicInfo.CttProtestar, DBContratosDicInfo.CttJuros, DBContratosDicInfo.CttValorRealizavel, DBContratosDicInfo.CttDOCUMENTO, DBContratosDicInfo.CttEMail1, DBContratosDicInfo.CttEMail2, DBContratosDicInfo.CttEMail3, DBContratosDicInfo.CttPessoa1, DBContratosDicInfo.CttPessoa2, DBContratosDicInfo.CttPessoa3, DBContratosDicInfo.CttOBS, DBContratosDicInfo.CttClienteContrato, DBContratosDicInfo.CttIdExtrangeiro, DBContratosDicInfo.CttChaveContrato, DBContratosDicInfo.CttAvulso, DBContratosDicInfo.CttSuspenso, DBContratosDicInfo.CttMulta, DBContratosDicInfo.CttBold, DBContratosDicInfo.CttGUID, DBContratosDicInfo.CttQuemCad, DBContratosDicInfo.CttDtCad, DBContratosDicInfo.CttQuemAtu, DBContratosDicInfo.CttDtAtu, DBContratosDicInfo.CttVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBContratosDicInfo.CttProcesso, DBContratosDicInfo.CttCliente, DBContratosDicInfo.CttAdvogado, DBContratosDicInfo.CttDia, DBContratosDicInfo.CttValor, DBContratosDicInfo.CttDataInicio, DBContratosDicInfo.CttDataTermino, DBContratosDicInfo.CttOcultarRelatorio, DBContratosDicInfo.CttPercEscritorio, DBContratosDicInfo.CttValorConsultoria, DBContratosDicInfo.CttTipoCobranca, DBContratosDicInfo.CttProtestar, DBContratosDicInfo.CttJuros, DBContratosDicInfo.CttValorRealizavel, DBContratosDicInfo.CttDOCUMENTO, DBContratosDicInfo.CttEMail1, DBContratosDicInfo.CttEMail2, DBContratosDicInfo.CttEMail3, DBContratosDicInfo.CttPessoa1, DBContratosDicInfo.CttPessoa2, DBContratosDicInfo.CttPessoa3, DBContratosDicInfo.CttOBS, DBContratosDicInfo.CttClienteContrato, DBContratosDicInfo.CttIdExtrangeiro, DBContratosDicInfo.CttChaveContrato, DBContratosDicInfo.CttAvulso, DBContratosDicInfo.CttSuspenso, DBContratosDicInfo.CttMulta, DBContratosDicInfo.CttGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "cttCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBContratosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "cttCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBContratosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
