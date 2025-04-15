#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBContatoCRMODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBContatoCRMDicInfo.TabelaNome;
    public string ICampoCodigo() => DBContatoCRMDicInfo.CampoCodigo;
    public string IPrefixo() => DBContatoCRMDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBContatoCRMDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBContatoCRMDicInfo.AgeClienteAvisado => DBContatoCRMDicInfo.CtcAgeClienteAvisado,
        DBContatoCRMDicInfo.DocsViaRecebimento => DBContatoCRMDicInfo.CtcDocsViaRecebimento,
        DBContatoCRMDicInfo.NaoPublicavel => DBContatoCRMDicInfo.CtcNaoPublicavel,
        DBContatoCRMDicInfo.Notificar => DBContatoCRMDicInfo.CtcNotificar,
        DBContatoCRMDicInfo.Ocultar => DBContatoCRMDicInfo.CtcOcultar,
        DBContatoCRMDicInfo.Assunto => DBContatoCRMDicInfo.CtcAssunto,
        DBContatoCRMDicInfo.IsDocsRecebidos => DBContatoCRMDicInfo.CtcIsDocsRecebidos,
        DBContatoCRMDicInfo.QuemNotificou => DBContatoCRMDicInfo.CtcQuemNotificou,
        DBContatoCRMDicInfo.DataNotificou => DBContatoCRMDicInfo.CtcDataNotificou,
        DBContatoCRMDicInfo.Operador => DBContatoCRMDicInfo.CtcOperador,
        DBContatoCRMDicInfo.Cliente => DBContatoCRMDicInfo.CtcCliente,
        DBContatoCRMDicInfo.HoraNotificou => DBContatoCRMDicInfo.CtcHoraNotificou,
        DBContatoCRMDicInfo.ObjetoNotificou => DBContatoCRMDicInfo.CtcObjetoNotificou,
        DBContatoCRMDicInfo.PessoaContato => DBContatoCRMDicInfo.CtcPessoaContato,
        DBContatoCRMDicInfo.Data => DBContatoCRMDicInfo.CtcData,
        DBContatoCRMDicInfo.Tempo => DBContatoCRMDicInfo.CtcTempo,
        DBContatoCRMDicInfo.HoraInicial => DBContatoCRMDicInfo.CtcHoraInicial,
        DBContatoCRMDicInfo.HoraFinal => DBContatoCRMDicInfo.CtcHoraFinal,
        DBContatoCRMDicInfo.Processo => DBContatoCRMDicInfo.CtcProcesso,
        DBContatoCRMDicInfo.Importante => DBContatoCRMDicInfo.CtcImportante,
        DBContatoCRMDicInfo.Urgente => DBContatoCRMDicInfo.CtcUrgente,
        DBContatoCRMDicInfo.GerarHoraTrabalhada => DBContatoCRMDicInfo.CtcGerarHoraTrabalhada,
        DBContatoCRMDicInfo.ExibirNoTopo => DBContatoCRMDicInfo.CtcExibirNoTopo,
        DBContatoCRMDicInfo.TipoContatoCRM => DBContatoCRMDicInfo.CtcTipoContatoCRM,
        DBContatoCRMDicInfo.Contato => DBContatoCRMDicInfo.CtcContato,
        DBContatoCRMDicInfo.Emocao => DBContatoCRMDicInfo.CtcEmocao,
        DBContatoCRMDicInfo.Continuar => DBContatoCRMDicInfo.CtcContinuar,
        DBContatoCRMDicInfo.Bold => DBContatoCRMDicInfo.CtcBold,
        DBContatoCRMDicInfo.GUID => DBContatoCRMDicInfo.CtcGUID,
        DBContatoCRMDicInfo.QuemCad => DBContatoCRMDicInfo.CtcQuemCad,
        DBContatoCRMDicInfo.DtCad => DBContatoCRMDicInfo.CtcDtCad,
        DBContatoCRMDicInfo.QuemAtu => DBContatoCRMDicInfo.CtcQuemAtu,
        DBContatoCRMDicInfo.DtAtu => DBContatoCRMDicInfo.CtcDtAtu,
        DBContatoCRMDicInfo.Visto => DBContatoCRMDicInfo.CtcVisto,
        _ => null
    };
    public static string TCampoCodigo => DBContatoCRMDicInfo.CampoCodigo;
    public static string TCampoNome => DBContatoCRMDicInfo.CampoNome;
    public static string TTabelaNome => DBContatoCRMDicInfo.TabelaNome;
    public static string TTablePrefix => DBContatoCRMDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBContatoCRMDicInfo.CtcAgeClienteAvisado, DBContatoCRMDicInfo.CtcDocsViaRecebimento, DBContatoCRMDicInfo.CtcNaoPublicavel, DBContatoCRMDicInfo.CtcNotificar, DBContatoCRMDicInfo.CtcOcultar, DBContatoCRMDicInfo.CtcAssunto, DBContatoCRMDicInfo.CtcIsDocsRecebidos, DBContatoCRMDicInfo.CtcQuemNotificou, DBContatoCRMDicInfo.CtcDataNotificou, DBContatoCRMDicInfo.CtcOperador, DBContatoCRMDicInfo.CtcCliente, DBContatoCRMDicInfo.CtcHoraNotificou, DBContatoCRMDicInfo.CtcObjetoNotificou, DBContatoCRMDicInfo.CtcPessoaContato, DBContatoCRMDicInfo.CtcData, DBContatoCRMDicInfo.CtcTempo, DBContatoCRMDicInfo.CtcHoraInicial, DBContatoCRMDicInfo.CtcHoraFinal, DBContatoCRMDicInfo.CtcProcesso, DBContatoCRMDicInfo.CtcImportante, DBContatoCRMDicInfo.CtcUrgente, DBContatoCRMDicInfo.CtcGerarHoraTrabalhada, DBContatoCRMDicInfo.CtcExibirNoTopo, DBContatoCRMDicInfo.CtcTipoContatoCRM, DBContatoCRMDicInfo.CtcContato, DBContatoCRMDicInfo.CtcEmocao, DBContatoCRMDicInfo.CtcContinuar, DBContatoCRMDicInfo.CtcBold, DBContatoCRMDicInfo.CtcGUID, DBContatoCRMDicInfo.CtcQuemCad, DBContatoCRMDicInfo.CtcDtCad, DBContatoCRMDicInfo.CtcQuemAtu, DBContatoCRMDicInfo.CtcDtAtu, DBContatoCRMDicInfo.CtcVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBContatoCRMDicInfo.CtcAgeClienteAvisado, DBContatoCRMDicInfo.CtcDocsViaRecebimento, DBContatoCRMDicInfo.CtcNaoPublicavel, DBContatoCRMDicInfo.CtcNotificar, DBContatoCRMDicInfo.CtcOcultar, DBContatoCRMDicInfo.CtcAssunto, DBContatoCRMDicInfo.CtcIsDocsRecebidos, DBContatoCRMDicInfo.CtcQuemNotificou, DBContatoCRMDicInfo.CtcDataNotificou, DBContatoCRMDicInfo.CtcOperador, DBContatoCRMDicInfo.CtcCliente, DBContatoCRMDicInfo.CtcHoraNotificou, DBContatoCRMDicInfo.CtcObjetoNotificou, DBContatoCRMDicInfo.CtcPessoaContato, DBContatoCRMDicInfo.CtcData, DBContatoCRMDicInfo.CtcTempo, DBContatoCRMDicInfo.CtcHoraInicial, DBContatoCRMDicInfo.CtcHoraFinal, DBContatoCRMDicInfo.CtcProcesso, DBContatoCRMDicInfo.CtcImportante, DBContatoCRMDicInfo.CtcUrgente, DBContatoCRMDicInfo.CtcGerarHoraTrabalhada, DBContatoCRMDicInfo.CtcExibirNoTopo, DBContatoCRMDicInfo.CtcTipoContatoCRM, DBContatoCRMDicInfo.CtcContato, DBContatoCRMDicInfo.CtcEmocao, DBContatoCRMDicInfo.CtcContinuar, DBContatoCRMDicInfo.CtcBold];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "ctcCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBContatoCRMDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "ctcCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBContatoCRMDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
