#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBAgendaODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBAgendaDicInfo.TabelaNome;
    public string ICampoCodigo() => DBAgendaDicInfo.CampoCodigo;
    public string IPrefixo() => DBAgendaDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBAgendaDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBAgendaDicInfo.IDCOB => DBAgendaDicInfo.AgeIDCOB,
        DBAgendaDicInfo.ClienteAvisado => DBAgendaDicInfo.AgeClienteAvisado,
        DBAgendaDicInfo.RevisarP2 => DBAgendaDicInfo.AgeRevisarP2,
        DBAgendaDicInfo.IDNE => DBAgendaDicInfo.AgeIDNE,
        DBAgendaDicInfo.Cidade => DBAgendaDicInfo.AgeCidade,
        DBAgendaDicInfo.Oculto => DBAgendaDicInfo.AgeOculto,
        DBAgendaDicInfo.CartaPrecatoria => DBAgendaDicInfo.AgeCartaPrecatoria,
        DBAgendaDicInfo.Revisar => DBAgendaDicInfo.AgeRevisar,
        DBAgendaDicInfo.HrFinal => DBAgendaDicInfo.AgeHrFinal,
        DBAgendaDicInfo.Advogado => DBAgendaDicInfo.AgeAdvogado,
        DBAgendaDicInfo.EventoGerador => DBAgendaDicInfo.AgeEventoGerador,
        DBAgendaDicInfo.EventoData => DBAgendaDicInfo.AgeEventoData,
        DBAgendaDicInfo.Funcionario => DBAgendaDicInfo.AgeFuncionario,
        DBAgendaDicInfo.Data => DBAgendaDicInfo.AgeData,
        DBAgendaDicInfo.EventoPrazo => DBAgendaDicInfo.AgeEventoPrazo,
        DBAgendaDicInfo.Hora => DBAgendaDicInfo.AgeHora,
        DBAgendaDicInfo.Compromisso => DBAgendaDicInfo.AgeCompromisso,
        DBAgendaDicInfo.TipoCompromisso => DBAgendaDicInfo.AgeTipoCompromisso,
        DBAgendaDicInfo.Cliente => DBAgendaDicInfo.AgeCliente,
        DBAgendaDicInfo.Liberado => DBAgendaDicInfo.AgeLiberado,
        DBAgendaDicInfo.Importante => DBAgendaDicInfo.AgeImportante,
        DBAgendaDicInfo.Concluido => DBAgendaDicInfo.AgeConcluido,
        DBAgendaDicInfo.Area => DBAgendaDicInfo.AgeArea,
        DBAgendaDicInfo.Justica => DBAgendaDicInfo.AgeJustica,
        DBAgendaDicInfo.Processo => DBAgendaDicInfo.AgeProcesso,
        DBAgendaDicInfo.IDHistorico => DBAgendaDicInfo.AgeIDHistorico,
        DBAgendaDicInfo.IDInsProcesso => DBAgendaDicInfo.AgeIDInsProcesso,
        DBAgendaDicInfo.Usuario => DBAgendaDicInfo.AgeUsuario,
        DBAgendaDicInfo.Preposto => DBAgendaDicInfo.AgePreposto,
        DBAgendaDicInfo.QuemID => DBAgendaDicInfo.AgeQuemID,
        DBAgendaDicInfo.QuemCodigo => DBAgendaDicInfo.AgeQuemCodigo,
        DBAgendaDicInfo.Status => DBAgendaDicInfo.AgeStatus,
        DBAgendaDicInfo.Valor => DBAgendaDicInfo.AgeValor,
        DBAgendaDicInfo.Decisao => DBAgendaDicInfo.AgeDecisao,
        DBAgendaDicInfo.Sempre => DBAgendaDicInfo.AgeSempre,
        DBAgendaDicInfo.PrazoDias => DBAgendaDicInfo.AgePrazoDias,
        DBAgendaDicInfo.ProtocoloIntegrado => DBAgendaDicInfo.AgeProtocoloIntegrado,
        DBAgendaDicInfo.DataInicioPrazo => DBAgendaDicInfo.AgeDataInicioPrazo,
        DBAgendaDicInfo.UsuarioCiente => DBAgendaDicInfo.AgeUsuarioCiente,
        DBAgendaDicInfo.GUID => DBAgendaDicInfo.AgeGUID,
        DBAgendaDicInfo.QuemCad => DBAgendaDicInfo.AgeQuemCad,
        DBAgendaDicInfo.DtCad => DBAgendaDicInfo.AgeDtCad,
        DBAgendaDicInfo.QuemAtu => DBAgendaDicInfo.AgeQuemAtu,
        DBAgendaDicInfo.DtAtu => DBAgendaDicInfo.AgeDtAtu,
        DBAgendaDicInfo.Visto => DBAgendaDicInfo.AgeVisto,
        _ => null
    };
    public static string TCampoCodigo => DBAgendaDicInfo.CampoCodigo;
    public static string TCampoNome => DBAgendaDicInfo.CampoNome;
    public static string TTabelaNome => DBAgendaDicInfo.TabelaNome;
    public static string TTablePrefix => DBAgendaDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBAgendaDicInfo.AgeIDCOB, DBAgendaDicInfo.AgeClienteAvisado, DBAgendaDicInfo.AgeRevisarP2, DBAgendaDicInfo.AgeIDNE, DBAgendaDicInfo.AgeCidade, DBAgendaDicInfo.AgeOculto, DBAgendaDicInfo.AgeCartaPrecatoria, DBAgendaDicInfo.AgeRevisar, DBAgendaDicInfo.AgeHrFinal, DBAgendaDicInfo.AgeAdvogado, DBAgendaDicInfo.AgeEventoGerador, DBAgendaDicInfo.AgeEventoData, DBAgendaDicInfo.AgeFuncionario, DBAgendaDicInfo.AgeData, DBAgendaDicInfo.AgeEventoPrazo, DBAgendaDicInfo.AgeHora, DBAgendaDicInfo.AgeCompromisso, DBAgendaDicInfo.AgeTipoCompromisso, DBAgendaDicInfo.AgeCliente, DBAgendaDicInfo.AgeLiberado, DBAgendaDicInfo.AgeImportante, DBAgendaDicInfo.AgeConcluido, DBAgendaDicInfo.AgeArea, DBAgendaDicInfo.AgeJustica, DBAgendaDicInfo.AgeProcesso, DBAgendaDicInfo.AgeIDHistorico, DBAgendaDicInfo.AgeIDInsProcesso, DBAgendaDicInfo.AgeUsuario, DBAgendaDicInfo.AgePreposto, DBAgendaDicInfo.AgeQuemID, DBAgendaDicInfo.AgeQuemCodigo, DBAgendaDicInfo.AgeStatus, DBAgendaDicInfo.AgeValor, DBAgendaDicInfo.AgeDecisao, DBAgendaDicInfo.AgeSempre, DBAgendaDicInfo.AgePrazoDias, DBAgendaDicInfo.AgeProtocoloIntegrado, DBAgendaDicInfo.AgeDataInicioPrazo, DBAgendaDicInfo.AgeUsuarioCiente, DBAgendaDicInfo.AgeGUID, DBAgendaDicInfo.AgeQuemCad, DBAgendaDicInfo.AgeDtCad, DBAgendaDicInfo.AgeQuemAtu, DBAgendaDicInfo.AgeDtAtu, DBAgendaDicInfo.AgeVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBAgendaDicInfo.AgeIDCOB, DBAgendaDicInfo.AgeClienteAvisado, DBAgendaDicInfo.AgeRevisarP2, DBAgendaDicInfo.AgeIDNE, DBAgendaDicInfo.AgeCidade, DBAgendaDicInfo.AgeOculto, DBAgendaDicInfo.AgeCartaPrecatoria, DBAgendaDicInfo.AgeRevisar, DBAgendaDicInfo.AgeHrFinal, DBAgendaDicInfo.AgeAdvogado, DBAgendaDicInfo.AgeEventoGerador, DBAgendaDicInfo.AgeEventoData, DBAgendaDicInfo.AgeFuncionario, DBAgendaDicInfo.AgeData, DBAgendaDicInfo.AgeEventoPrazo, DBAgendaDicInfo.AgeHora, DBAgendaDicInfo.AgeCompromisso, DBAgendaDicInfo.AgeTipoCompromisso, DBAgendaDicInfo.AgeCliente, DBAgendaDicInfo.AgeLiberado, DBAgendaDicInfo.AgeImportante, DBAgendaDicInfo.AgeConcluido, DBAgendaDicInfo.AgeArea, DBAgendaDicInfo.AgeJustica, DBAgendaDicInfo.AgeProcesso, DBAgendaDicInfo.AgeIDHistorico, DBAgendaDicInfo.AgeIDInsProcesso, DBAgendaDicInfo.AgeUsuario, DBAgendaDicInfo.AgePreposto, DBAgendaDicInfo.AgeQuemID, DBAgendaDicInfo.AgeQuemCodigo, DBAgendaDicInfo.AgeStatus, DBAgendaDicInfo.AgeValor, DBAgendaDicInfo.AgeDecisao, DBAgendaDicInfo.AgeSempre, DBAgendaDicInfo.AgePrazoDias, DBAgendaDicInfo.AgeProtocoloIntegrado, DBAgendaDicInfo.AgeDataInicioPrazo, DBAgendaDicInfo.AgeUsuarioCiente, DBAgendaDicInfo.AgeGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "ageCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBAgendaDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "ageCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBAgendaDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
