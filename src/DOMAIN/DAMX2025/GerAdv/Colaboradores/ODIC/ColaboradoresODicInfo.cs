#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBColaboradoresODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBColaboradoresDicInfo.TabelaNome;
    public string ICampoCodigo() => DBColaboradoresDicInfo.CampoCodigo;
    public string IPrefixo() => DBColaboradoresDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => true;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBColaboradoresDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => true;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBColaboradoresDicInfo.Cargo => DBColaboradoresDicInfo.ColCargo,
        DBColaboradoresDicInfo.Cliente => DBColaboradoresDicInfo.ColCliente,
        DBColaboradoresDicInfo.Sexo => DBColaboradoresDicInfo.ColSexo,
        DBColaboradoresDicInfo.Nome => DBColaboradoresDicInfo.ColNome,
        DBColaboradoresDicInfo.CPF => DBColaboradoresDicInfo.ColCPF,
        DBColaboradoresDicInfo.RG => DBColaboradoresDicInfo.ColRG,
        DBColaboradoresDicInfo.DtNasc => DBColaboradoresDicInfo.ColDtNasc,
        DBColaboradoresDicInfo.Idade => DBColaboradoresDicInfo.ColIdade,
        DBColaboradoresDicInfo.Endereco => DBColaboradoresDicInfo.ColEndereco,
        DBColaboradoresDicInfo.Bairro => DBColaboradoresDicInfo.ColBairro,
        DBColaboradoresDicInfo.CEP => DBColaboradoresDicInfo.ColCEP,
        DBColaboradoresDicInfo.Cidade => DBColaboradoresDicInfo.ColCidade,
        DBColaboradoresDicInfo.Fone => DBColaboradoresDicInfo.ColFone,
        DBColaboradoresDicInfo.Observacao => DBColaboradoresDicInfo.ColObservacao,
        DBColaboradoresDicInfo.EMail => DBColaboradoresDicInfo.ColEMail,
        DBColaboradoresDicInfo.CNH => DBColaboradoresDicInfo.ColCNH,
        DBColaboradoresDicInfo.Class => DBColaboradoresDicInfo.ColClass,
        DBColaboradoresDicInfo.Etiqueta => DBColaboradoresDicInfo.ColEtiqueta,
        DBColaboradoresDicInfo.Ani => DBColaboradoresDicInfo.ColAni,
        DBColaboradoresDicInfo.Bold => DBColaboradoresDicInfo.ColBold,
        DBColaboradoresDicInfo.QuemCad => DBColaboradoresDicInfo.ColQuemCad,
        DBColaboradoresDicInfo.DtCad => DBColaboradoresDicInfo.ColDtCad,
        DBColaboradoresDicInfo.QuemAtu => DBColaboradoresDicInfo.ColQuemAtu,
        DBColaboradoresDicInfo.DtAtu => DBColaboradoresDicInfo.ColDtAtu,
        DBColaboradoresDicInfo.Visto => DBColaboradoresDicInfo.ColVisto,
        _ => null
    };
    public static string TCampoCodigo => DBColaboradoresDicInfo.CampoCodigo;
    public static string TCampoNome => DBColaboradoresDicInfo.CampoNome;
    public static string TTabelaNome => DBColaboradoresDicInfo.TabelaNome;
    public static string TTablePrefix => DBColaboradoresDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBColaboradoresDicInfo.ColCargo, DBColaboradoresDicInfo.ColCliente, DBColaboradoresDicInfo.ColSexo, DBColaboradoresDicInfo.ColNome, DBColaboradoresDicInfo.ColCPF, DBColaboradoresDicInfo.ColRG, DBColaboradoresDicInfo.ColDtNasc, DBColaboradoresDicInfo.ColIdade, DBColaboradoresDicInfo.ColEndereco, DBColaboradoresDicInfo.ColBairro, DBColaboradoresDicInfo.ColCEP, DBColaboradoresDicInfo.ColCidade, DBColaboradoresDicInfo.ColFone, DBColaboradoresDicInfo.ColObservacao, DBColaboradoresDicInfo.ColEMail, DBColaboradoresDicInfo.ColCNH, DBColaboradoresDicInfo.ColClass, DBColaboradoresDicInfo.ColEtiqueta, DBColaboradoresDicInfo.ColAni, DBColaboradoresDicInfo.ColBold, DBColaboradoresDicInfo.ColQuemCad, DBColaboradoresDicInfo.ColDtCad, DBColaboradoresDicInfo.ColQuemAtu, DBColaboradoresDicInfo.ColDtAtu, DBColaboradoresDicInfo.ColVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBColaboradoresDicInfo.ColCargo, DBColaboradoresDicInfo.ColCliente, DBColaboradoresDicInfo.ColSexo, DBColaboradoresDicInfo.ColNome, DBColaboradoresDicInfo.ColCPF, DBColaboradoresDicInfo.ColRG, DBColaboradoresDicInfo.ColDtNasc, DBColaboradoresDicInfo.ColIdade, DBColaboradoresDicInfo.ColEndereco, DBColaboradoresDicInfo.ColBairro, DBColaboradoresDicInfo.ColCEP, DBColaboradoresDicInfo.ColCidade, DBColaboradoresDicInfo.ColFone, DBColaboradoresDicInfo.ColObservacao, DBColaboradoresDicInfo.ColEMail, DBColaboradoresDicInfo.ColCNH, DBColaboradoresDicInfo.ColClass];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "colCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBColaboradoresDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "colCliente",
            "colCodigo",
            "colNome"
        };
        var result = campos.Where(campo => !campo.Equals(DBColaboradoresDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
