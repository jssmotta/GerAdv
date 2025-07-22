#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBEnderecoSistemaODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBEnderecoSistemaDicInfo.TabelaNome;
    public string ICampoCodigo() => DBEnderecoSistemaDicInfo.CampoCodigo;
    public string IPrefixo() => DBEnderecoSistemaDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBEnderecoSistemaDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBEnderecoSistemaDicInfo.Cadastro => DBEnderecoSistemaDicInfo.EstCadastro,
        DBEnderecoSistemaDicInfo.CadastroExCod => DBEnderecoSistemaDicInfo.EstCadastroExCod,
        DBEnderecoSistemaDicInfo.TipoEnderecoSistema => DBEnderecoSistemaDicInfo.EstTipoEnderecoSistema,
        DBEnderecoSistemaDicInfo.Processo => DBEnderecoSistemaDicInfo.EstProcesso,
        DBEnderecoSistemaDicInfo.Motivo => DBEnderecoSistemaDicInfo.EstMotivo,
        DBEnderecoSistemaDicInfo.ContatoNoLocal => DBEnderecoSistemaDicInfo.EstContatoNoLocal,
        DBEnderecoSistemaDicInfo.Cidade => DBEnderecoSistemaDicInfo.EstCidade,
        DBEnderecoSistemaDicInfo.Endereco => DBEnderecoSistemaDicInfo.EstEndereco,
        DBEnderecoSistemaDicInfo.Bairro => DBEnderecoSistemaDicInfo.EstBairro,
        DBEnderecoSistemaDicInfo.CEP => DBEnderecoSistemaDicInfo.EstCEP,
        DBEnderecoSistemaDicInfo.Fone => DBEnderecoSistemaDicInfo.EstFone,
        DBEnderecoSistemaDicInfo.Fax => DBEnderecoSistemaDicInfo.EstFax,
        DBEnderecoSistemaDicInfo.Observacao => DBEnderecoSistemaDicInfo.EstObservacao,
        DBEnderecoSistemaDicInfo.GUID => DBEnderecoSistemaDicInfo.EstGUID,
        DBEnderecoSistemaDicInfo.QuemCad => DBEnderecoSistemaDicInfo.EstQuemCad,
        DBEnderecoSistemaDicInfo.DtCad => DBEnderecoSistemaDicInfo.EstDtCad,
        DBEnderecoSistemaDicInfo.QuemAtu => DBEnderecoSistemaDicInfo.EstQuemAtu,
        DBEnderecoSistemaDicInfo.DtAtu => DBEnderecoSistemaDicInfo.EstDtAtu,
        DBEnderecoSistemaDicInfo.Visto => DBEnderecoSistemaDicInfo.EstVisto,
        _ => null
    };
    public static string TCampoCodigo => DBEnderecoSistemaDicInfo.CampoCodigo;
    public static string TCampoNome => DBEnderecoSistemaDicInfo.CampoNome;
    public static string TTabelaNome => DBEnderecoSistemaDicInfo.TabelaNome;
    public static string TTablePrefix => DBEnderecoSistemaDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBEnderecoSistemaDicInfo.EstCadastro, DBEnderecoSistemaDicInfo.EstCadastroExCod, DBEnderecoSistemaDicInfo.EstTipoEnderecoSistema, DBEnderecoSistemaDicInfo.EstProcesso, DBEnderecoSistemaDicInfo.EstMotivo, DBEnderecoSistemaDicInfo.EstContatoNoLocal, DBEnderecoSistemaDicInfo.EstCidade, DBEnderecoSistemaDicInfo.EstEndereco, DBEnderecoSistemaDicInfo.EstBairro, DBEnderecoSistemaDicInfo.EstCEP, DBEnderecoSistemaDicInfo.EstFone, DBEnderecoSistemaDicInfo.EstFax, DBEnderecoSistemaDicInfo.EstObservacao, DBEnderecoSistemaDicInfo.EstGUID, DBEnderecoSistemaDicInfo.EstQuemCad, DBEnderecoSistemaDicInfo.EstDtCad, DBEnderecoSistemaDicInfo.EstQuemAtu, DBEnderecoSistemaDicInfo.EstDtAtu, DBEnderecoSistemaDicInfo.EstVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBEnderecoSistemaDicInfo.EstCadastro, DBEnderecoSistemaDicInfo.EstCadastroExCod, DBEnderecoSistemaDicInfo.EstTipoEnderecoSistema, DBEnderecoSistemaDicInfo.EstProcesso, DBEnderecoSistemaDicInfo.EstMotivo, DBEnderecoSistemaDicInfo.EstContatoNoLocal, DBEnderecoSistemaDicInfo.EstCidade, DBEnderecoSistemaDicInfo.EstEndereco, DBEnderecoSistemaDicInfo.EstBairro, DBEnderecoSistemaDicInfo.EstCEP, DBEnderecoSistemaDicInfo.EstFone, DBEnderecoSistemaDicInfo.EstFax, DBEnderecoSistemaDicInfo.EstObservacao, DBEnderecoSistemaDicInfo.EstGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "estCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBEnderecoSistemaDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "estCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBEnderecoSistemaDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
