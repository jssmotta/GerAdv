#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBProSucumbenciaODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBProSucumbenciaDicInfo.TabelaNome;
    public string ICampoCodigo() => DBProSucumbenciaDicInfo.CampoCodigo;
    public string IPrefixo() => DBProSucumbenciaDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBProSucumbenciaDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBProSucumbenciaDicInfo.Processo => DBProSucumbenciaDicInfo.ScbProcesso,
        DBProSucumbenciaDicInfo.Instancia => DBProSucumbenciaDicInfo.ScbInstancia,
        DBProSucumbenciaDicInfo.Data => DBProSucumbenciaDicInfo.ScbData,
        DBProSucumbenciaDicInfo.Nome => DBProSucumbenciaDicInfo.ScbNome,
        DBProSucumbenciaDicInfo.TipoOrigemSucumbencia => DBProSucumbenciaDicInfo.ScbTipoOrigemSucumbencia,
        DBProSucumbenciaDicInfo.Valor => DBProSucumbenciaDicInfo.ScbValor,
        DBProSucumbenciaDicInfo.Percentual => DBProSucumbenciaDicInfo.ScbPercentual,
        DBProSucumbenciaDicInfo.GUID => DBProSucumbenciaDicInfo.ScbGUID,
        DBProSucumbenciaDicInfo.QuemCad => DBProSucumbenciaDicInfo.ScbQuemCad,
        DBProSucumbenciaDicInfo.DtCad => DBProSucumbenciaDicInfo.ScbDtCad,
        DBProSucumbenciaDicInfo.QuemAtu => DBProSucumbenciaDicInfo.ScbQuemAtu,
        DBProSucumbenciaDicInfo.DtAtu => DBProSucumbenciaDicInfo.ScbDtAtu,
        DBProSucumbenciaDicInfo.Visto => DBProSucumbenciaDicInfo.ScbVisto,
        _ => null
    };
    public static string TCampoCodigo => DBProSucumbenciaDicInfo.CampoCodigo;
    public static string TCampoNome => DBProSucumbenciaDicInfo.CampoNome;
    public static string TTabelaNome => DBProSucumbenciaDicInfo.TabelaNome;
    public static string TTablePrefix => DBProSucumbenciaDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBProSucumbenciaDicInfo.ScbProcesso, DBProSucumbenciaDicInfo.ScbInstancia, DBProSucumbenciaDicInfo.ScbData, DBProSucumbenciaDicInfo.ScbNome, DBProSucumbenciaDicInfo.ScbTipoOrigemSucumbencia, DBProSucumbenciaDicInfo.ScbValor, DBProSucumbenciaDicInfo.ScbPercentual, DBProSucumbenciaDicInfo.ScbGUID, DBProSucumbenciaDicInfo.ScbQuemCad, DBProSucumbenciaDicInfo.ScbDtCad, DBProSucumbenciaDicInfo.ScbQuemAtu, DBProSucumbenciaDicInfo.ScbDtAtu, DBProSucumbenciaDicInfo.ScbVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBProSucumbenciaDicInfo.ScbProcesso, DBProSucumbenciaDicInfo.ScbInstancia, DBProSucumbenciaDicInfo.ScbData, DBProSucumbenciaDicInfo.ScbNome, DBProSucumbenciaDicInfo.ScbTipoOrigemSucumbencia, DBProSucumbenciaDicInfo.ScbValor, DBProSucumbenciaDicInfo.ScbPercentual, DBProSucumbenciaDicInfo.ScbGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "scbCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBProSucumbenciaDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "scbCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBProSucumbenciaDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
