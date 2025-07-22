#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBHonorariosDadosContratoODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBHonorariosDadosContratoDicInfo.TabelaNome;
    public string ICampoCodigo() => DBHonorariosDadosContratoDicInfo.CampoCodigo;
    public string IPrefixo() => DBHonorariosDadosContratoDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBHonorariosDadosContratoDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBHonorariosDadosContratoDicInfo.Cliente => DBHonorariosDadosContratoDicInfo.HdcCliente,
        DBHonorariosDadosContratoDicInfo.Fixo => DBHonorariosDadosContratoDicInfo.HdcFixo,
        DBHonorariosDadosContratoDicInfo.Variavel => DBHonorariosDadosContratoDicInfo.HdcVariavel,
        DBHonorariosDadosContratoDicInfo.PercSucesso => DBHonorariosDadosContratoDicInfo.HdcPercSucesso,
        DBHonorariosDadosContratoDicInfo.Processo => DBHonorariosDadosContratoDicInfo.HdcProcesso,
        DBHonorariosDadosContratoDicInfo.ArquivoContrato => DBHonorariosDadosContratoDicInfo.HdcArquivoContrato,
        DBHonorariosDadosContratoDicInfo.TextoContrato => DBHonorariosDadosContratoDicInfo.HdcTextoContrato,
        DBHonorariosDadosContratoDicInfo.ValorFixo => DBHonorariosDadosContratoDicInfo.HdcValorFixo,
        DBHonorariosDadosContratoDicInfo.Observacao => DBHonorariosDadosContratoDicInfo.HdcObservacao,
        DBHonorariosDadosContratoDicInfo.DataContrato => DBHonorariosDadosContratoDicInfo.HdcDataContrato,
        DBHonorariosDadosContratoDicInfo.GUID => DBHonorariosDadosContratoDicInfo.HdcGUID,
        DBHonorariosDadosContratoDicInfo.QuemCad => DBHonorariosDadosContratoDicInfo.HdcQuemCad,
        DBHonorariosDadosContratoDicInfo.DtCad => DBHonorariosDadosContratoDicInfo.HdcDtCad,
        DBHonorariosDadosContratoDicInfo.QuemAtu => DBHonorariosDadosContratoDicInfo.HdcQuemAtu,
        DBHonorariosDadosContratoDicInfo.DtAtu => DBHonorariosDadosContratoDicInfo.HdcDtAtu,
        DBHonorariosDadosContratoDicInfo.Visto => DBHonorariosDadosContratoDicInfo.HdcVisto,
        _ => null
    };
    public static string TCampoCodigo => DBHonorariosDadosContratoDicInfo.CampoCodigo;
    public static string TCampoNome => DBHonorariosDadosContratoDicInfo.CampoNome;
    public static string TTabelaNome => DBHonorariosDadosContratoDicInfo.TabelaNome;
    public static string TTablePrefix => DBHonorariosDadosContratoDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBHonorariosDadosContratoDicInfo.HdcCliente, DBHonorariosDadosContratoDicInfo.HdcFixo, DBHonorariosDadosContratoDicInfo.HdcVariavel, DBHonorariosDadosContratoDicInfo.HdcPercSucesso, DBHonorariosDadosContratoDicInfo.HdcProcesso, DBHonorariosDadosContratoDicInfo.HdcArquivoContrato, DBHonorariosDadosContratoDicInfo.HdcTextoContrato, DBHonorariosDadosContratoDicInfo.HdcValorFixo, DBHonorariosDadosContratoDicInfo.HdcObservacao, DBHonorariosDadosContratoDicInfo.HdcDataContrato, DBHonorariosDadosContratoDicInfo.HdcGUID, DBHonorariosDadosContratoDicInfo.HdcQuemCad, DBHonorariosDadosContratoDicInfo.HdcDtCad, DBHonorariosDadosContratoDicInfo.HdcQuemAtu, DBHonorariosDadosContratoDicInfo.HdcDtAtu, DBHonorariosDadosContratoDicInfo.HdcVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBHonorariosDadosContratoDicInfo.HdcCliente, DBHonorariosDadosContratoDicInfo.HdcFixo, DBHonorariosDadosContratoDicInfo.HdcVariavel, DBHonorariosDadosContratoDicInfo.HdcPercSucesso, DBHonorariosDadosContratoDicInfo.HdcProcesso, DBHonorariosDadosContratoDicInfo.HdcArquivoContrato, DBHonorariosDadosContratoDicInfo.HdcTextoContrato, DBHonorariosDadosContratoDicInfo.HdcValorFixo, DBHonorariosDadosContratoDicInfo.HdcObservacao, DBHonorariosDadosContratoDicInfo.HdcDataContrato, DBHonorariosDadosContratoDicInfo.HdcGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "hdcCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBHonorariosDadosContratoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "hdcCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBHonorariosDadosContratoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
