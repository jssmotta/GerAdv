#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBRecadosODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBRecadosDicInfo.TabelaNome;
    public string ICampoCodigo() => DBRecadosDicInfo.CampoCodigo;
    public string IPrefixo() => DBRecadosDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBRecadosDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBRecadosDicInfo.ClienteNome => DBRecadosDicInfo.RecClienteNome,
        DBRecadosDicInfo.De => DBRecadosDicInfo.RecDe,
        DBRecadosDicInfo.Para => DBRecadosDicInfo.RecPara,
        DBRecadosDicInfo.Assunto => DBRecadosDicInfo.RecAssunto,
        DBRecadosDicInfo.Concluido => DBRecadosDicInfo.RecConcluido,
        DBRecadosDicInfo.Processo => DBRecadosDicInfo.RecProcesso,
        DBRecadosDicInfo.Cliente => DBRecadosDicInfo.RecCliente,
        DBRecadosDicInfo.Recado => DBRecadosDicInfo.RecRecado,
        DBRecadosDicInfo.Urgente => DBRecadosDicInfo.RecUrgente,
        DBRecadosDicInfo.Importante => DBRecadosDicInfo.RecImportante,
        DBRecadosDicInfo.Hora => DBRecadosDicInfo.RecHora,
        DBRecadosDicInfo.Data => DBRecadosDicInfo.RecData,
        DBRecadosDicInfo.Voltara => DBRecadosDicInfo.RecVoltara,
        DBRecadosDicInfo.Pessoal => DBRecadosDicInfo.RecPessoal,
        DBRecadosDicInfo.Retornar => DBRecadosDicInfo.RecRetornar,
        DBRecadosDicInfo.RetornoData => DBRecadosDicInfo.RecRetornoData,
        DBRecadosDicInfo.Emotion => DBRecadosDicInfo.RecEmotion,
        DBRecadosDicInfo.InternetID => DBRecadosDicInfo.RecInternetID,
        DBRecadosDicInfo.Uploaded => DBRecadosDicInfo.RecUploaded,
        DBRecadosDicInfo.Natureza => DBRecadosDicInfo.RecNatureza,
        DBRecadosDicInfo.BIU => DBRecadosDicInfo.RecBIU,
        DBRecadosDicInfo.AguardarRetorno => DBRecadosDicInfo.RecAguardarRetorno,
        DBRecadosDicInfo.AguardarRetornoPara => DBRecadosDicInfo.RecAguardarRetornoPara,
        DBRecadosDicInfo.AguardarRetornoOK => DBRecadosDicInfo.RecAguardarRetornoOK,
        DBRecadosDicInfo.ParaID => DBRecadosDicInfo.RecParaID,
        DBRecadosDicInfo.NaoPublicavel => DBRecadosDicInfo.RecNaoPublicavel,
        DBRecadosDicInfo.IsContatoCRM => DBRecadosDicInfo.RecIsContatoCRM,
        DBRecadosDicInfo.MasterID => DBRecadosDicInfo.RecMasterID,
        DBRecadosDicInfo.ListaPara => DBRecadosDicInfo.RecListaPara,
        DBRecadosDicInfo.Typed => DBRecadosDicInfo.RecTyped,
        DBRecadosDicInfo.AssuntoRecado => DBRecadosDicInfo.RecAssuntoRecado,
        DBRecadosDicInfo.Historico => DBRecadosDicInfo.RecHistorico,
        DBRecadosDicInfo.ContatoCRM => DBRecadosDicInfo.RecContatoCRM,
        DBRecadosDicInfo.Ligacoes => DBRecadosDicInfo.RecLigacoes,
        DBRecadosDicInfo.Agenda => DBRecadosDicInfo.RecAgenda,
        DBRecadosDicInfo.GUID => DBRecadosDicInfo.RecGUID,
        DBRecadosDicInfo.QuemCad => DBRecadosDicInfo.RecQuemCad,
        DBRecadosDicInfo.DtCad => DBRecadosDicInfo.RecDtCad,
        DBRecadosDicInfo.QuemAtu => DBRecadosDicInfo.RecQuemAtu,
        DBRecadosDicInfo.DtAtu => DBRecadosDicInfo.RecDtAtu,
        DBRecadosDicInfo.Visto => DBRecadosDicInfo.RecVisto,
        _ => null
    };
    public static string TCampoCodigo => DBRecadosDicInfo.CampoCodigo;
    public static string TCampoNome => DBRecadosDicInfo.CampoNome;
    public static string TTabelaNome => DBRecadosDicInfo.TabelaNome;
    public static string TTablePrefix => DBRecadosDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBRecadosDicInfo.RecClienteNome, DBRecadosDicInfo.RecDe, DBRecadosDicInfo.RecPara, DBRecadosDicInfo.RecAssunto, DBRecadosDicInfo.RecConcluido, DBRecadosDicInfo.RecProcesso, DBRecadosDicInfo.RecCliente, DBRecadosDicInfo.RecRecado, DBRecadosDicInfo.RecUrgente, DBRecadosDicInfo.RecImportante, DBRecadosDicInfo.RecHora, DBRecadosDicInfo.RecData, DBRecadosDicInfo.RecVoltara, DBRecadosDicInfo.RecPessoal, DBRecadosDicInfo.RecRetornar, DBRecadosDicInfo.RecRetornoData, DBRecadosDicInfo.RecEmotion, DBRecadosDicInfo.RecInternetID, DBRecadosDicInfo.RecUploaded, DBRecadosDicInfo.RecNatureza, DBRecadosDicInfo.RecBIU, DBRecadosDicInfo.RecAguardarRetorno, DBRecadosDicInfo.RecAguardarRetornoPara, DBRecadosDicInfo.RecAguardarRetornoOK, DBRecadosDicInfo.RecParaID, DBRecadosDicInfo.RecNaoPublicavel, DBRecadosDicInfo.RecIsContatoCRM, DBRecadosDicInfo.RecMasterID, DBRecadosDicInfo.RecListaPara, DBRecadosDicInfo.RecTyped, DBRecadosDicInfo.RecAssuntoRecado, DBRecadosDicInfo.RecHistorico, DBRecadosDicInfo.RecContatoCRM, DBRecadosDicInfo.RecLigacoes, DBRecadosDicInfo.RecAgenda, DBRecadosDicInfo.RecGUID, DBRecadosDicInfo.RecQuemCad, DBRecadosDicInfo.RecDtCad, DBRecadosDicInfo.RecQuemAtu, DBRecadosDicInfo.RecDtAtu, DBRecadosDicInfo.RecVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBRecadosDicInfo.RecClienteNome, DBRecadosDicInfo.RecDe, DBRecadosDicInfo.RecPara, DBRecadosDicInfo.RecAssunto, DBRecadosDicInfo.RecConcluido, DBRecadosDicInfo.RecProcesso, DBRecadosDicInfo.RecCliente, DBRecadosDicInfo.RecRecado, DBRecadosDicInfo.RecUrgente, DBRecadosDicInfo.RecImportante, DBRecadosDicInfo.RecHora, DBRecadosDicInfo.RecData, DBRecadosDicInfo.RecVoltara, DBRecadosDicInfo.RecPessoal, DBRecadosDicInfo.RecRetornar, DBRecadosDicInfo.RecRetornoData, DBRecadosDicInfo.RecEmotion, DBRecadosDicInfo.RecInternetID, DBRecadosDicInfo.RecUploaded, DBRecadosDicInfo.RecNatureza, DBRecadosDicInfo.RecBIU, DBRecadosDicInfo.RecAguardarRetorno, DBRecadosDicInfo.RecAguardarRetornoPara, DBRecadosDicInfo.RecAguardarRetornoOK, DBRecadosDicInfo.RecParaID, DBRecadosDicInfo.RecNaoPublicavel, DBRecadosDicInfo.RecIsContatoCRM, DBRecadosDicInfo.RecMasterID, DBRecadosDicInfo.RecListaPara, DBRecadosDicInfo.RecTyped, DBRecadosDicInfo.RecAssuntoRecado, DBRecadosDicInfo.RecHistorico, DBRecadosDicInfo.RecContatoCRM, DBRecadosDicInfo.RecLigacoes, DBRecadosDicInfo.RecAgenda, DBRecadosDicInfo.RecGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "recCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBRecadosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "recCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBRecadosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
