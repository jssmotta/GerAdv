#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBAgendaFinanceiroODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBAgendaFinanceiroDicInfo.TabelaNome;
    public string ICampoCodigo() => DBAgendaFinanceiroDicInfo.CampoCodigo;
    public string IPrefixo() => DBAgendaFinanceiroDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBAgendaFinanceiroDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBAgendaFinanceiroDicInfo.IDCOB => DBAgendaFinanceiroDicInfo.AgeIDCOB,
        DBAgendaFinanceiroDicInfo.IDNE => DBAgendaFinanceiroDicInfo.AgeIDNE,
        DBAgendaFinanceiroDicInfo.PrazoProvisionado => DBAgendaFinanceiroDicInfo.AgePrazoProvisionado,
        DBAgendaFinanceiroDicInfo.Cidade => DBAgendaFinanceiroDicInfo.AgeCidade,
        DBAgendaFinanceiroDicInfo.Oculto => DBAgendaFinanceiroDicInfo.AgeOculto,
        DBAgendaFinanceiroDicInfo.CartaPrecatoria => DBAgendaFinanceiroDicInfo.AgeCartaPrecatoria,
        DBAgendaFinanceiroDicInfo.RepetirDias => DBAgendaFinanceiroDicInfo.AgeRepetirDias,
        DBAgendaFinanceiroDicInfo.HrFinal => DBAgendaFinanceiroDicInfo.AgeHrFinal,
        DBAgendaFinanceiroDicInfo.Repetir => DBAgendaFinanceiroDicInfo.AgeRepetir,
        DBAgendaFinanceiroDicInfo.Advogado => DBAgendaFinanceiroDicInfo.AgeAdvogado,
        DBAgendaFinanceiroDicInfo.EventoGerador => DBAgendaFinanceiroDicInfo.AgeEventoGerador,
        DBAgendaFinanceiroDicInfo.EventoData => DBAgendaFinanceiroDicInfo.AgeEventoData,
        DBAgendaFinanceiroDicInfo.Funcionario => DBAgendaFinanceiroDicInfo.AgeFuncionario,
        DBAgendaFinanceiroDicInfo.Data => DBAgendaFinanceiroDicInfo.AgeData,
        DBAgendaFinanceiroDicInfo.EventoPrazo => DBAgendaFinanceiroDicInfo.AgeEventoPrazo,
        DBAgendaFinanceiroDicInfo.Hora => DBAgendaFinanceiroDicInfo.AgeHora,
        DBAgendaFinanceiroDicInfo.Compromisso => DBAgendaFinanceiroDicInfo.AgeCompromisso,
        DBAgendaFinanceiroDicInfo.TipoCompromisso => DBAgendaFinanceiroDicInfo.AgeTipoCompromisso,
        DBAgendaFinanceiroDicInfo.Cliente => DBAgendaFinanceiroDicInfo.AgeCliente,
        DBAgendaFinanceiroDicInfo.DDias => DBAgendaFinanceiroDicInfo.AgeDDias,
        DBAgendaFinanceiroDicInfo.Dias => DBAgendaFinanceiroDicInfo.AgeDias,
        DBAgendaFinanceiroDicInfo.Liberado => DBAgendaFinanceiroDicInfo.AgeLiberado,
        DBAgendaFinanceiroDicInfo.Importante => DBAgendaFinanceiroDicInfo.AgeImportante,
        DBAgendaFinanceiroDicInfo.Concluido => DBAgendaFinanceiroDicInfo.AgeConcluido,
        DBAgendaFinanceiroDicInfo.Area => DBAgendaFinanceiroDicInfo.AgeArea,
        DBAgendaFinanceiroDicInfo.Justica => DBAgendaFinanceiroDicInfo.AgeJustica,
        DBAgendaFinanceiroDicInfo.Processo => DBAgendaFinanceiroDicInfo.AgeProcesso,
        DBAgendaFinanceiroDicInfo.IDHistorico => DBAgendaFinanceiroDicInfo.AgeIDHistorico,
        DBAgendaFinanceiroDicInfo.IDInsProcesso => DBAgendaFinanceiroDicInfo.AgeIDInsProcesso,
        DBAgendaFinanceiroDicInfo.Usuario => DBAgendaFinanceiroDicInfo.AgeUsuario,
        DBAgendaFinanceiroDicInfo.Preposto => DBAgendaFinanceiroDicInfo.AgePreposto,
        DBAgendaFinanceiroDicInfo.QuemID => DBAgendaFinanceiroDicInfo.AgeQuemID,
        DBAgendaFinanceiroDicInfo.QuemCodigo => DBAgendaFinanceiroDicInfo.AgeQuemCodigo,
        DBAgendaFinanceiroDicInfo.Status => DBAgendaFinanceiroDicInfo.AgeStatus,
        DBAgendaFinanceiroDicInfo.Valor => DBAgendaFinanceiroDicInfo.AgeValor,
        DBAgendaFinanceiroDicInfo.CompromissoHTML => DBAgendaFinanceiroDicInfo.AgeCompromissoHTML,
        DBAgendaFinanceiroDicInfo.Decisao => DBAgendaFinanceiroDicInfo.AgeDecisao,
        DBAgendaFinanceiroDicInfo.Revisar => DBAgendaFinanceiroDicInfo.AgeRevisar,
        DBAgendaFinanceiroDicInfo.RevisarP2 => DBAgendaFinanceiroDicInfo.AgeRevisarP2,
        DBAgendaFinanceiroDicInfo.Sempre => DBAgendaFinanceiroDicInfo.AgeSempre,
        DBAgendaFinanceiroDicInfo.PrazoDias => DBAgendaFinanceiroDicInfo.AgePrazoDias,
        DBAgendaFinanceiroDicInfo.ProtocoloIntegrado => DBAgendaFinanceiroDicInfo.AgeProtocoloIntegrado,
        DBAgendaFinanceiroDicInfo.DataInicioPrazo => DBAgendaFinanceiroDicInfo.AgeDataInicioPrazo,
        DBAgendaFinanceiroDicInfo.UsuarioCiente => DBAgendaFinanceiroDicInfo.AgeUsuarioCiente,
        DBAgendaFinanceiroDicInfo.GUID => DBAgendaFinanceiroDicInfo.AgeGUID,
        DBAgendaFinanceiroDicInfo.QuemCad => DBAgendaFinanceiroDicInfo.AgeQuemCad,
        DBAgendaFinanceiroDicInfo.DtCad => DBAgendaFinanceiroDicInfo.AgeDtCad,
        DBAgendaFinanceiroDicInfo.QuemAtu => DBAgendaFinanceiroDicInfo.AgeQuemAtu,
        DBAgendaFinanceiroDicInfo.DtAtu => DBAgendaFinanceiroDicInfo.AgeDtAtu,
        DBAgendaFinanceiroDicInfo.Visto => DBAgendaFinanceiroDicInfo.AgeVisto,
        _ => null
    };
    public static string TCampoCodigo => DBAgendaFinanceiroDicInfo.CampoCodigo;
    public static string TCampoNome => DBAgendaFinanceiroDicInfo.CampoNome;
    public static string TTabelaNome => DBAgendaFinanceiroDicInfo.TabelaNome;
    public static string TTablePrefix => DBAgendaFinanceiroDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBAgendaFinanceiroDicInfo.AgeIDCOB, DBAgendaFinanceiroDicInfo.AgeIDNE, DBAgendaFinanceiroDicInfo.AgePrazoProvisionado, DBAgendaFinanceiroDicInfo.AgeCidade, DBAgendaFinanceiroDicInfo.AgeOculto, DBAgendaFinanceiroDicInfo.AgeCartaPrecatoria, DBAgendaFinanceiroDicInfo.AgeRepetirDias, DBAgendaFinanceiroDicInfo.AgeHrFinal, DBAgendaFinanceiroDicInfo.AgeRepetir, DBAgendaFinanceiroDicInfo.AgeAdvogado, DBAgendaFinanceiroDicInfo.AgeEventoGerador, DBAgendaFinanceiroDicInfo.AgeEventoData, DBAgendaFinanceiroDicInfo.AgeFuncionario, DBAgendaFinanceiroDicInfo.AgeData, DBAgendaFinanceiroDicInfo.AgeEventoPrazo, DBAgendaFinanceiroDicInfo.AgeHora, DBAgendaFinanceiroDicInfo.AgeCompromisso, DBAgendaFinanceiroDicInfo.AgeTipoCompromisso, DBAgendaFinanceiroDicInfo.AgeCliente, DBAgendaFinanceiroDicInfo.AgeDDias, DBAgendaFinanceiroDicInfo.AgeDias, DBAgendaFinanceiroDicInfo.AgeLiberado, DBAgendaFinanceiroDicInfo.AgeImportante, DBAgendaFinanceiroDicInfo.AgeConcluido, DBAgendaFinanceiroDicInfo.AgeArea, DBAgendaFinanceiroDicInfo.AgeJustica, DBAgendaFinanceiroDicInfo.AgeProcesso, DBAgendaFinanceiroDicInfo.AgeIDHistorico, DBAgendaFinanceiroDicInfo.AgeIDInsProcesso, DBAgendaFinanceiroDicInfo.AgeUsuario, DBAgendaFinanceiroDicInfo.AgePreposto, DBAgendaFinanceiroDicInfo.AgeQuemID, DBAgendaFinanceiroDicInfo.AgeQuemCodigo, DBAgendaFinanceiroDicInfo.AgeStatus, DBAgendaFinanceiroDicInfo.AgeValor, DBAgendaFinanceiroDicInfo.AgeCompromissoHTML, DBAgendaFinanceiroDicInfo.AgeDecisao, DBAgendaFinanceiroDicInfo.AgeRevisar, DBAgendaFinanceiroDicInfo.AgeRevisarP2, DBAgendaFinanceiroDicInfo.AgeSempre, DBAgendaFinanceiroDicInfo.AgePrazoDias, DBAgendaFinanceiroDicInfo.AgeProtocoloIntegrado, DBAgendaFinanceiroDicInfo.AgeDataInicioPrazo, DBAgendaFinanceiroDicInfo.AgeUsuarioCiente, DBAgendaFinanceiroDicInfo.AgeGUID, DBAgendaFinanceiroDicInfo.AgeQuemCad, DBAgendaFinanceiroDicInfo.AgeDtCad, DBAgendaFinanceiroDicInfo.AgeQuemAtu, DBAgendaFinanceiroDicInfo.AgeDtAtu, DBAgendaFinanceiroDicInfo.AgeVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBAgendaFinanceiroDicInfo.AgeIDCOB, DBAgendaFinanceiroDicInfo.AgeIDNE, DBAgendaFinanceiroDicInfo.AgePrazoProvisionado, DBAgendaFinanceiroDicInfo.AgeCidade, DBAgendaFinanceiroDicInfo.AgeOculto, DBAgendaFinanceiroDicInfo.AgeCartaPrecatoria, DBAgendaFinanceiroDicInfo.AgeRepetirDias, DBAgendaFinanceiroDicInfo.AgeHrFinal, DBAgendaFinanceiroDicInfo.AgeRepetir, DBAgendaFinanceiroDicInfo.AgeAdvogado, DBAgendaFinanceiroDicInfo.AgeEventoGerador, DBAgendaFinanceiroDicInfo.AgeEventoData, DBAgendaFinanceiroDicInfo.AgeFuncionario, DBAgendaFinanceiroDicInfo.AgeData, DBAgendaFinanceiroDicInfo.AgeEventoPrazo, DBAgendaFinanceiroDicInfo.AgeHora, DBAgendaFinanceiroDicInfo.AgeCompromisso, DBAgendaFinanceiroDicInfo.AgeTipoCompromisso, DBAgendaFinanceiroDicInfo.AgeCliente, DBAgendaFinanceiroDicInfo.AgeDDias, DBAgendaFinanceiroDicInfo.AgeDias, DBAgendaFinanceiroDicInfo.AgeLiberado, DBAgendaFinanceiroDicInfo.AgeImportante, DBAgendaFinanceiroDicInfo.AgeConcluido, DBAgendaFinanceiroDicInfo.AgeArea, DBAgendaFinanceiroDicInfo.AgeJustica, DBAgendaFinanceiroDicInfo.AgeProcesso, DBAgendaFinanceiroDicInfo.AgeIDHistorico, DBAgendaFinanceiroDicInfo.AgeIDInsProcesso, DBAgendaFinanceiroDicInfo.AgeUsuario, DBAgendaFinanceiroDicInfo.AgePreposto, DBAgendaFinanceiroDicInfo.AgeQuemID, DBAgendaFinanceiroDicInfo.AgeQuemCodigo, DBAgendaFinanceiroDicInfo.AgeStatus, DBAgendaFinanceiroDicInfo.AgeValor, DBAgendaFinanceiroDicInfo.AgeCompromissoHTML, DBAgendaFinanceiroDicInfo.AgeDecisao, DBAgendaFinanceiroDicInfo.AgeRevisar, DBAgendaFinanceiroDicInfo.AgeRevisarP2, DBAgendaFinanceiroDicInfo.AgeSempre, DBAgendaFinanceiroDicInfo.AgePrazoDias, DBAgendaFinanceiroDicInfo.AgeProtocoloIntegrado, DBAgendaFinanceiroDicInfo.AgeDataInicioPrazo, DBAgendaFinanceiroDicInfo.AgeUsuarioCiente, DBAgendaFinanceiroDicInfo.AgeGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "ageCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBAgendaFinanceiroDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "ageCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBAgendaFinanceiroDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
