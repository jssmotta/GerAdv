#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBProDespesasODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBProDespesasDicInfo.TabelaNome;
    public string ICampoCodigo() => DBProDespesasDicInfo.CampoCodigo;
    public string IPrefixo() => DBProDespesasDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBProDespesasDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBProDespesasDicInfo.LigacaoID => DBProDespesasDicInfo.DesLigacaoID,
        DBProDespesasDicInfo.Cliente => DBProDespesasDicInfo.DesCliente,
        DBProDespesasDicInfo.Corrigido => DBProDespesasDicInfo.DesCorrigido,
        DBProDespesasDicInfo.Data => DBProDespesasDicInfo.DesData,
        DBProDespesasDicInfo.ValorOriginal => DBProDespesasDicInfo.DesValorOriginal,
        DBProDespesasDicInfo.Processo => DBProDespesasDicInfo.DesProcesso,
        DBProDespesasDicInfo.Quitado => DBProDespesasDicInfo.DesQuitado,
        DBProDespesasDicInfo.DataCorrecao => DBProDespesasDicInfo.DesDataCorrecao,
        DBProDespesasDicInfo.Valor => DBProDespesasDicInfo.DesValor,
        DBProDespesasDicInfo.Tipo => DBProDespesasDicInfo.DesTipo,
        DBProDespesasDicInfo.Historico => DBProDespesasDicInfo.DesHistorico,
        DBProDespesasDicInfo.LivroCaixa => DBProDespesasDicInfo.DesLivroCaixa,
        DBProDespesasDicInfo.GUID => DBProDespesasDicInfo.DesGUID,
        DBProDespesasDicInfo.QuemCad => DBProDespesasDicInfo.DesQuemCad,
        DBProDespesasDicInfo.DtCad => DBProDespesasDicInfo.DesDtCad,
        DBProDespesasDicInfo.QuemAtu => DBProDespesasDicInfo.DesQuemAtu,
        DBProDespesasDicInfo.DtAtu => DBProDespesasDicInfo.DesDtAtu,
        DBProDespesasDicInfo.Visto => DBProDespesasDicInfo.DesVisto,
        _ => null
    };
    public static string TCampoCodigo => DBProDespesasDicInfo.CampoCodigo;
    public static string TCampoNome => DBProDespesasDicInfo.CampoNome;
    public static string TTabelaNome => DBProDespesasDicInfo.TabelaNome;
    public static string TTablePrefix => DBProDespesasDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBProDespesasDicInfo.DesLigacaoID, DBProDespesasDicInfo.DesCliente, DBProDespesasDicInfo.DesCorrigido, DBProDespesasDicInfo.DesData, DBProDespesasDicInfo.DesValorOriginal, DBProDespesasDicInfo.DesProcesso, DBProDespesasDicInfo.DesQuitado, DBProDespesasDicInfo.DesDataCorrecao, DBProDespesasDicInfo.DesValor, DBProDespesasDicInfo.DesTipo, DBProDespesasDicInfo.DesHistorico, DBProDespesasDicInfo.DesLivroCaixa, DBProDespesasDicInfo.DesGUID, DBProDespesasDicInfo.DesQuemCad, DBProDespesasDicInfo.DesDtCad, DBProDespesasDicInfo.DesQuemAtu, DBProDespesasDicInfo.DesDtAtu, DBProDespesasDicInfo.DesVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBProDespesasDicInfo.DesLigacaoID, DBProDespesasDicInfo.DesCliente, DBProDespesasDicInfo.DesCorrigido, DBProDespesasDicInfo.DesData, DBProDespesasDicInfo.DesValorOriginal, DBProDespesasDicInfo.DesProcesso, DBProDespesasDicInfo.DesQuitado, DBProDespesasDicInfo.DesDataCorrecao, DBProDespesasDicInfo.DesValor, DBProDespesasDicInfo.DesTipo, DBProDespesasDicInfo.DesHistorico, DBProDespesasDicInfo.DesLivroCaixa];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "desCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBProDespesasDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "desCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBProDespesasDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
