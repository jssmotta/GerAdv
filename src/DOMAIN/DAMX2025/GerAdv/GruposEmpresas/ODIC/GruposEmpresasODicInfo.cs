#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBGruposEmpresasODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBGruposEmpresasDicInfo.TabelaNome;
    public string ICampoCodigo() => DBGruposEmpresasDicInfo.CampoCodigo;
    public string IPrefixo() => DBGruposEmpresasDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBGruposEmpresasDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBGruposEmpresasDicInfo.EMail => DBGruposEmpresasDicInfo.GrpEMail,
        DBGruposEmpresasDicInfo.Inativo => DBGruposEmpresasDicInfo.GrpInativo,
        DBGruposEmpresasDicInfo.Oponente => DBGruposEmpresasDicInfo.GrpOponente,
        DBGruposEmpresasDicInfo.Descricao => DBGruposEmpresasDicInfo.GrpDescricao,
        DBGruposEmpresasDicInfo.Observacoes => DBGruposEmpresasDicInfo.GrpObservacoes,
        DBGruposEmpresasDicInfo.Cliente => DBGruposEmpresasDicInfo.GrpCliente,
        DBGruposEmpresasDicInfo.Icone => DBGruposEmpresasDicInfo.GrpIcone,
        DBGruposEmpresasDicInfo.DespesaUnificada => DBGruposEmpresasDicInfo.GrpDespesaUnificada,
        DBGruposEmpresasDicInfo.GUID => DBGruposEmpresasDicInfo.GrpGUID,
        DBGruposEmpresasDicInfo.QuemCad => DBGruposEmpresasDicInfo.GrpQuemCad,
        DBGruposEmpresasDicInfo.DtCad => DBGruposEmpresasDicInfo.GrpDtCad,
        DBGruposEmpresasDicInfo.QuemAtu => DBGruposEmpresasDicInfo.GrpQuemAtu,
        DBGruposEmpresasDicInfo.DtAtu => DBGruposEmpresasDicInfo.GrpDtAtu,
        DBGruposEmpresasDicInfo.Visto => DBGruposEmpresasDicInfo.GrpVisto,
        _ => null
    };
    public static string TCampoCodigo => DBGruposEmpresasDicInfo.CampoCodigo;
    public static string TCampoNome => DBGruposEmpresasDicInfo.CampoNome;
    public static string TTabelaNome => DBGruposEmpresasDicInfo.TabelaNome;
    public static string TTablePrefix => DBGruposEmpresasDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBGruposEmpresasDicInfo.GrpEMail, DBGruposEmpresasDicInfo.GrpInativo, DBGruposEmpresasDicInfo.GrpOponente, DBGruposEmpresasDicInfo.GrpDescricao, DBGruposEmpresasDicInfo.GrpObservacoes, DBGruposEmpresasDicInfo.GrpCliente, DBGruposEmpresasDicInfo.GrpIcone, DBGruposEmpresasDicInfo.GrpDespesaUnificada, DBGruposEmpresasDicInfo.GrpGUID, DBGruposEmpresasDicInfo.GrpQuemCad, DBGruposEmpresasDicInfo.GrpDtCad, DBGruposEmpresasDicInfo.GrpQuemAtu, DBGruposEmpresasDicInfo.GrpDtAtu, DBGruposEmpresasDicInfo.GrpVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBGruposEmpresasDicInfo.GrpEMail, DBGruposEmpresasDicInfo.GrpInativo, DBGruposEmpresasDicInfo.GrpOponente, DBGruposEmpresasDicInfo.GrpDescricao, DBGruposEmpresasDicInfo.GrpObservacoes, DBGruposEmpresasDicInfo.GrpCliente, DBGruposEmpresasDicInfo.GrpIcone, DBGruposEmpresasDicInfo.GrpDespesaUnificada, DBGruposEmpresasDicInfo.GrpGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "grpCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBGruposEmpresasDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "grpCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBGruposEmpresasDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
