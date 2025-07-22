#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBPontoVirtualAcessosODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBPontoVirtualAcessosDicInfo.TabelaNome;
    public string ICampoCodigo() => DBPontoVirtualAcessosDicInfo.CampoCodigo;
    public string IPrefixo() => DBPontoVirtualAcessosDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => false;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBPontoVirtualAcessosDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => false;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBPontoVirtualAcessosDicInfo.Operador => DBPontoVirtualAcessosDicInfo.PvaOperador,
        DBPontoVirtualAcessosDicInfo.DataHora => DBPontoVirtualAcessosDicInfo.PvaDataHora,
        DBPontoVirtualAcessosDicInfo.Tipo => DBPontoVirtualAcessosDicInfo.PvaTipo,
        DBPontoVirtualAcessosDicInfo.Origem => DBPontoVirtualAcessosDicInfo.PvaOrigem,
        _ => null
    };
    public static string TCampoCodigo => DBPontoVirtualAcessosDicInfo.CampoCodigo;
    public static string TCampoNome => DBPontoVirtualAcessosDicInfo.CampoNome;
    public static string TTabelaNome => DBPontoVirtualAcessosDicInfo.TabelaNome;
    public static string TTablePrefix => DBPontoVirtualAcessosDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBPontoVirtualAcessosDicInfo.PvaOperador, DBPontoVirtualAcessosDicInfo.PvaDataHora, DBPontoVirtualAcessosDicInfo.PvaTipo, DBPontoVirtualAcessosDicInfo.PvaOrigem];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBPontoVirtualAcessosDicInfo.PvaOperador, DBPontoVirtualAcessosDicInfo.PvaDataHora, DBPontoVirtualAcessosDicInfo.PvaTipo, DBPontoVirtualAcessosDicInfo.PvaOrigem];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "pvaCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBPontoVirtualAcessosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "pvaCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBPontoVirtualAcessosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
