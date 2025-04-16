#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBContaCorrenteODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBContaCorrenteDicInfo.TabelaNome;
    public string ICampoCodigo() => DBContaCorrenteDicInfo.CampoCodigo;
    public string IPrefixo() => DBContaCorrenteDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBContaCorrenteDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBContaCorrenteDicInfo.CIAcordo => DBContaCorrenteDicInfo.CtoCIAcordo,
        DBContaCorrenteDicInfo.Quitado => DBContaCorrenteDicInfo.CtoQuitado,
        DBContaCorrenteDicInfo.IDContrato => DBContaCorrenteDicInfo.CtoIDContrato,
        DBContaCorrenteDicInfo.QuitadoID => DBContaCorrenteDicInfo.CtoQuitadoID,
        DBContaCorrenteDicInfo.DebitoID => DBContaCorrenteDicInfo.CtoDebitoID,
        DBContaCorrenteDicInfo.LivroCaixaID => DBContaCorrenteDicInfo.CtoLivroCaixaID,
        DBContaCorrenteDicInfo.Sucumbencia => DBContaCorrenteDicInfo.CtoSucumbencia,
        DBContaCorrenteDicInfo.DistRegra => DBContaCorrenteDicInfo.CtoDistRegra,
        DBContaCorrenteDicInfo.DtOriginal => DBContaCorrenteDicInfo.CtoDtOriginal,
        DBContaCorrenteDicInfo.Processo => DBContaCorrenteDicInfo.CtoProcesso,
        DBContaCorrenteDicInfo.ParcelaX => DBContaCorrenteDicInfo.CtoParcelaX,
        DBContaCorrenteDicInfo.Valor => DBContaCorrenteDicInfo.CtoValor,
        DBContaCorrenteDicInfo.Data => DBContaCorrenteDicInfo.CtoData,
        DBContaCorrenteDicInfo.Cliente => DBContaCorrenteDicInfo.CtoCliente,
        DBContaCorrenteDicInfo.Historico => DBContaCorrenteDicInfo.CtoHistorico,
        DBContaCorrenteDicInfo.Contrato => DBContaCorrenteDicInfo.CtoContrato,
        DBContaCorrenteDicInfo.Pago => DBContaCorrenteDicInfo.CtoPago,
        DBContaCorrenteDicInfo.Distribuir => DBContaCorrenteDicInfo.CtoDistribuir,
        DBContaCorrenteDicInfo.LC => DBContaCorrenteDicInfo.CtoLC,
        DBContaCorrenteDicInfo.IDHTrab => DBContaCorrenteDicInfo.CtoIDHTrab,
        DBContaCorrenteDicInfo.NroParcelas => DBContaCorrenteDicInfo.CtoNroParcelas,
        DBContaCorrenteDicInfo.ValorPrincipal => DBContaCorrenteDicInfo.CtoValorPrincipal,
        DBContaCorrenteDicInfo.ParcelaPrincipalID => DBContaCorrenteDicInfo.CtoParcelaPrincipalID,
        DBContaCorrenteDicInfo.Hide => DBContaCorrenteDicInfo.CtoHide,
        DBContaCorrenteDicInfo.DataPgto => DBContaCorrenteDicInfo.CtoDataPgto,
        DBContaCorrenteDicInfo.GUID => DBContaCorrenteDicInfo.CtoGUID,
        DBContaCorrenteDicInfo.QuemCad => DBContaCorrenteDicInfo.CtoQuemCad,
        DBContaCorrenteDicInfo.DtCad => DBContaCorrenteDicInfo.CtoDtCad,
        DBContaCorrenteDicInfo.QuemAtu => DBContaCorrenteDicInfo.CtoQuemAtu,
        DBContaCorrenteDicInfo.DtAtu => DBContaCorrenteDicInfo.CtoDtAtu,
        DBContaCorrenteDicInfo.Visto => DBContaCorrenteDicInfo.CtoVisto,
        _ => null
    };
    public static string TCampoCodigo => DBContaCorrenteDicInfo.CampoCodigo;
    public static string TCampoNome => DBContaCorrenteDicInfo.CampoNome;
    public static string TTabelaNome => DBContaCorrenteDicInfo.TabelaNome;
    public static string TTablePrefix => DBContaCorrenteDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBContaCorrenteDicInfo.CtoCIAcordo, DBContaCorrenteDicInfo.CtoQuitado, DBContaCorrenteDicInfo.CtoIDContrato, DBContaCorrenteDicInfo.CtoQuitadoID, DBContaCorrenteDicInfo.CtoDebitoID, DBContaCorrenteDicInfo.CtoLivroCaixaID, DBContaCorrenteDicInfo.CtoSucumbencia, DBContaCorrenteDicInfo.CtoDistRegra, DBContaCorrenteDicInfo.CtoDtOriginal, DBContaCorrenteDicInfo.CtoProcesso, DBContaCorrenteDicInfo.CtoParcelaX, DBContaCorrenteDicInfo.CtoValor, DBContaCorrenteDicInfo.CtoData, DBContaCorrenteDicInfo.CtoCliente, DBContaCorrenteDicInfo.CtoHistorico, DBContaCorrenteDicInfo.CtoContrato, DBContaCorrenteDicInfo.CtoPago, DBContaCorrenteDicInfo.CtoDistribuir, DBContaCorrenteDicInfo.CtoLC, DBContaCorrenteDicInfo.CtoIDHTrab, DBContaCorrenteDicInfo.CtoNroParcelas, DBContaCorrenteDicInfo.CtoValorPrincipal, DBContaCorrenteDicInfo.CtoParcelaPrincipalID, DBContaCorrenteDicInfo.CtoHide, DBContaCorrenteDicInfo.CtoDataPgto, DBContaCorrenteDicInfo.CtoGUID, DBContaCorrenteDicInfo.CtoQuemCad, DBContaCorrenteDicInfo.CtoDtCad, DBContaCorrenteDicInfo.CtoQuemAtu, DBContaCorrenteDicInfo.CtoDtAtu, DBContaCorrenteDicInfo.CtoVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBContaCorrenteDicInfo.CtoCIAcordo, DBContaCorrenteDicInfo.CtoQuitado, DBContaCorrenteDicInfo.CtoIDContrato, DBContaCorrenteDicInfo.CtoQuitadoID, DBContaCorrenteDicInfo.CtoDebitoID, DBContaCorrenteDicInfo.CtoLivroCaixaID, DBContaCorrenteDicInfo.CtoSucumbencia, DBContaCorrenteDicInfo.CtoDistRegra, DBContaCorrenteDicInfo.CtoDtOriginal, DBContaCorrenteDicInfo.CtoProcesso, DBContaCorrenteDicInfo.CtoParcelaX, DBContaCorrenteDicInfo.CtoValor, DBContaCorrenteDicInfo.CtoData, DBContaCorrenteDicInfo.CtoCliente, DBContaCorrenteDicInfo.CtoHistorico, DBContaCorrenteDicInfo.CtoContrato, DBContaCorrenteDicInfo.CtoPago, DBContaCorrenteDicInfo.CtoDistribuir, DBContaCorrenteDicInfo.CtoLC, DBContaCorrenteDicInfo.CtoIDHTrab, DBContaCorrenteDicInfo.CtoNroParcelas, DBContaCorrenteDicInfo.CtoValorPrincipal, DBContaCorrenteDicInfo.CtoParcelaPrincipalID, DBContaCorrenteDicInfo.CtoHide, DBContaCorrenteDicInfo.CtoDataPgto];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "ctoCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBContaCorrenteDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "ctoCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBContaCorrenteDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
