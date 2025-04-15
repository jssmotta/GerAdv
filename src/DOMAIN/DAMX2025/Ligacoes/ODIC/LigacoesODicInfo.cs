#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBLigacoesODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBLigacoesDicInfo.TabelaNome;
    public string ICampoCodigo() => DBLigacoesDicInfo.CampoCodigo;
    public string IPrefixo() => DBLigacoesDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBLigacoesDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBLigacoesDicInfo.Assunto => DBLigacoesDicInfo.LigAssunto,
        DBLigacoesDicInfo.AgeClienteAvisado => DBLigacoesDicInfo.LigAgeClienteAvisado,
        DBLigacoesDicInfo.Celular => DBLigacoesDicInfo.LigCelular,
        DBLigacoesDicInfo.Cliente => DBLigacoesDicInfo.LigCliente,
        DBLigacoesDicInfo.Contato => DBLigacoesDicInfo.LigContato,
        DBLigacoesDicInfo.DataRealizada => DBLigacoesDicInfo.LigDataRealizada,
        DBLigacoesDicInfo.QuemID => DBLigacoesDicInfo.LigQuemID,
        DBLigacoesDicInfo.Telefonista => DBLigacoesDicInfo.LigTelefonista,
        DBLigacoesDicInfo.UltimoAviso => DBLigacoesDicInfo.LigUltimoAviso,
        DBLigacoesDicInfo.HoraFinal => DBLigacoesDicInfo.LigHoraFinal,
        DBLigacoesDicInfo.Nome => DBLigacoesDicInfo.LigNome,
        DBLigacoesDicInfo.QuemCodigo => DBLigacoesDicInfo.LigQuemCodigo,
        DBLigacoesDicInfo.Solicitante => DBLigacoesDicInfo.LigSolicitante,
        DBLigacoesDicInfo.Para => DBLigacoesDicInfo.LigPara,
        DBLigacoesDicInfo.Fone => DBLigacoesDicInfo.LigFone,
        DBLigacoesDicInfo.Ramal => DBLigacoesDicInfo.LigRamal,
        DBLigacoesDicInfo.Particular => DBLigacoesDicInfo.LigParticular,
        DBLigacoesDicInfo.Realizada => DBLigacoesDicInfo.LigRealizada,
        DBLigacoesDicInfo.Status => DBLigacoesDicInfo.LigStatus,
        DBLigacoesDicInfo.Data => DBLigacoesDicInfo.LigData,
        DBLigacoesDicInfo.Hora => DBLigacoesDicInfo.LigHora,
        DBLigacoesDicInfo.Urgente => DBLigacoesDicInfo.LigUrgente,
        DBLigacoesDicInfo.LigarPara => DBLigacoesDicInfo.LigLigarPara,
        DBLigacoesDicInfo.Processo => DBLigacoesDicInfo.LigProcesso,
        DBLigacoesDicInfo.StartScreen => DBLigacoesDicInfo.LigStartScreen,
        DBLigacoesDicInfo.Emotion => DBLigacoesDicInfo.LigEmotion,
        DBLigacoesDicInfo.Bold => DBLigacoesDicInfo.LigBold,
        DBLigacoesDicInfo.GUID => DBLigacoesDicInfo.LigGUID,
        DBLigacoesDicInfo.QuemCad => DBLigacoesDicInfo.LigQuemCad,
        DBLigacoesDicInfo.DtCad => DBLigacoesDicInfo.LigDtCad,
        DBLigacoesDicInfo.QuemAtu => DBLigacoesDicInfo.LigQuemAtu,
        DBLigacoesDicInfo.DtAtu => DBLigacoesDicInfo.LigDtAtu,
        DBLigacoesDicInfo.Visto => DBLigacoesDicInfo.LigVisto,
        _ => null
    };
    public static string TCampoCodigo => DBLigacoesDicInfo.CampoCodigo;
    public static string TCampoNome => DBLigacoesDicInfo.CampoNome;
    public static string TTabelaNome => DBLigacoesDicInfo.TabelaNome;
    public static string TTablePrefix => DBLigacoesDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBLigacoesDicInfo.LigAssunto, DBLigacoesDicInfo.LigAgeClienteAvisado, DBLigacoesDicInfo.LigCelular, DBLigacoesDicInfo.LigCliente, DBLigacoesDicInfo.LigContato, DBLigacoesDicInfo.LigDataRealizada, DBLigacoesDicInfo.LigQuemID, DBLigacoesDicInfo.LigTelefonista, DBLigacoesDicInfo.LigUltimoAviso, DBLigacoesDicInfo.LigHoraFinal, DBLigacoesDicInfo.LigNome, DBLigacoesDicInfo.LigQuemCodigo, DBLigacoesDicInfo.LigSolicitante, DBLigacoesDicInfo.LigPara, DBLigacoesDicInfo.LigFone, DBLigacoesDicInfo.LigRamal, DBLigacoesDicInfo.LigParticular, DBLigacoesDicInfo.LigRealizada, DBLigacoesDicInfo.LigStatus, DBLigacoesDicInfo.LigData, DBLigacoesDicInfo.LigHora, DBLigacoesDicInfo.LigUrgente, DBLigacoesDicInfo.LigLigarPara, DBLigacoesDicInfo.LigProcesso, DBLigacoesDicInfo.LigStartScreen, DBLigacoesDicInfo.LigEmotion, DBLigacoesDicInfo.LigBold, DBLigacoesDicInfo.LigGUID, DBLigacoesDicInfo.LigQuemCad, DBLigacoesDicInfo.LigDtCad, DBLigacoesDicInfo.LigQuemAtu, DBLigacoesDicInfo.LigDtAtu, DBLigacoesDicInfo.LigVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBLigacoesDicInfo.LigAssunto, DBLigacoesDicInfo.LigAgeClienteAvisado, DBLigacoesDicInfo.LigCelular, DBLigacoesDicInfo.LigCliente, DBLigacoesDicInfo.LigContato, DBLigacoesDicInfo.LigDataRealizada, DBLigacoesDicInfo.LigQuemID, DBLigacoesDicInfo.LigTelefonista, DBLigacoesDicInfo.LigUltimoAviso, DBLigacoesDicInfo.LigHoraFinal, DBLigacoesDicInfo.LigNome, DBLigacoesDicInfo.LigQuemCodigo, DBLigacoesDicInfo.LigSolicitante, DBLigacoesDicInfo.LigPara, DBLigacoesDicInfo.LigFone, DBLigacoesDicInfo.LigRamal, DBLigacoesDicInfo.LigParticular, DBLigacoesDicInfo.LigRealizada, DBLigacoesDicInfo.LigStatus, DBLigacoesDicInfo.LigData, DBLigacoesDicInfo.LigHora, DBLigacoesDicInfo.LigUrgente, DBLigacoesDicInfo.LigLigarPara, DBLigacoesDicInfo.LigProcesso, DBLigacoesDicInfo.LigStartScreen, DBLigacoesDicInfo.LigEmotion, DBLigacoesDicInfo.LigBold];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "ligCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBLigacoesDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "ligCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBLigacoesDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
