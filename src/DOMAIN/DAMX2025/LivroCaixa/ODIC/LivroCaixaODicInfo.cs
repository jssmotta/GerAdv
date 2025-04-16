#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBLivroCaixaODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBLivroCaixaDicInfo.TabelaNome;
    public string ICampoCodigo() => DBLivroCaixaDicInfo.CampoCodigo;
    public string IPrefixo() => DBLivroCaixaDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBLivroCaixaDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBLivroCaixaDicInfo.IDDes => DBLivroCaixaDicInfo.LivIDDes,
        DBLivroCaixaDicInfo.Pessoal => DBLivroCaixaDicInfo.LivPessoal,
        DBLivroCaixaDicInfo.Ajuste => DBLivroCaixaDicInfo.LivAjuste,
        DBLivroCaixaDicInfo.IDHon => DBLivroCaixaDicInfo.LivIDHon,
        DBLivroCaixaDicInfo.IDHonParc => DBLivroCaixaDicInfo.LivIDHonParc,
        DBLivroCaixaDicInfo.IDHonSuc => DBLivroCaixaDicInfo.LivIDHonSuc,
        DBLivroCaixaDicInfo.Data => DBLivroCaixaDicInfo.LivData,
        DBLivroCaixaDicInfo.Processo => DBLivroCaixaDicInfo.LivProcesso,
        DBLivroCaixaDicInfo.Valor => DBLivroCaixaDicInfo.LivValor,
        DBLivroCaixaDicInfo.Tipo => DBLivroCaixaDicInfo.LivTipo,
        DBLivroCaixaDicInfo.Historico => DBLivroCaixaDicInfo.LivHistorico,
        DBLivroCaixaDicInfo.Previsto => DBLivroCaixaDicInfo.LivPrevisto,
        DBLivroCaixaDicInfo.Grupo => DBLivroCaixaDicInfo.LivGrupo,
        DBLivroCaixaDicInfo.QuemCad => DBLivroCaixaDicInfo.LivQuemCad,
        DBLivroCaixaDicInfo.DtCad => DBLivroCaixaDicInfo.LivDtCad,
        DBLivroCaixaDicInfo.QuemAtu => DBLivroCaixaDicInfo.LivQuemAtu,
        DBLivroCaixaDicInfo.DtAtu => DBLivroCaixaDicInfo.LivDtAtu,
        DBLivroCaixaDicInfo.Visto => DBLivroCaixaDicInfo.LivVisto,
        _ => null
    };
    public static string TCampoCodigo => DBLivroCaixaDicInfo.CampoCodigo;
    public static string TCampoNome => DBLivroCaixaDicInfo.CampoNome;
    public static string TTabelaNome => DBLivroCaixaDicInfo.TabelaNome;
    public static string TTablePrefix => DBLivroCaixaDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBLivroCaixaDicInfo.LivIDDes, DBLivroCaixaDicInfo.LivPessoal, DBLivroCaixaDicInfo.LivAjuste, DBLivroCaixaDicInfo.LivIDHon, DBLivroCaixaDicInfo.LivIDHonParc, DBLivroCaixaDicInfo.LivIDHonSuc, DBLivroCaixaDicInfo.LivData, DBLivroCaixaDicInfo.LivProcesso, DBLivroCaixaDicInfo.LivValor, DBLivroCaixaDicInfo.LivTipo, DBLivroCaixaDicInfo.LivHistorico, DBLivroCaixaDicInfo.LivPrevisto, DBLivroCaixaDicInfo.LivGrupo, DBLivroCaixaDicInfo.LivQuemCad, DBLivroCaixaDicInfo.LivDtCad, DBLivroCaixaDicInfo.LivQuemAtu, DBLivroCaixaDicInfo.LivDtAtu, DBLivroCaixaDicInfo.LivVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBLivroCaixaDicInfo.LivIDDes, DBLivroCaixaDicInfo.LivPessoal, DBLivroCaixaDicInfo.LivAjuste, DBLivroCaixaDicInfo.LivIDHon, DBLivroCaixaDicInfo.LivIDHonParc, DBLivroCaixaDicInfo.LivIDHonSuc, DBLivroCaixaDicInfo.LivData, DBLivroCaixaDicInfo.LivProcesso, DBLivroCaixaDicInfo.LivValor, DBLivroCaixaDicInfo.LivTipo, DBLivroCaixaDicInfo.LivHistorico, DBLivroCaixaDicInfo.LivGrupo];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "livCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBLivroCaixaDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "livCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBLivroCaixaDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
