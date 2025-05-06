#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBProcessosODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBProcessosDicInfo.TabelaNome;
    public string ICampoCodigo() => DBProcessosDicInfo.CampoCodigo;
    public string IPrefixo() => DBProcessosDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBProcessosDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBProcessosDicInfo.AdvParc => DBProcessosDicInfo.ProAdvParc,
        DBProcessosDicInfo.AJGPedidoNegado => DBProcessosDicInfo.ProAJGPedidoNegado,
        DBProcessosDicInfo.AJGCliente => DBProcessosDicInfo.ProAJGCliente,
        DBProcessosDicInfo.AJGPedidoNegadoOPO => DBProcessosDicInfo.ProAJGPedidoNegadoOPO,
        DBProcessosDicInfo.NotificarPOE => DBProcessosDicInfo.ProNotificarPOE,
        DBProcessosDicInfo.ValorProvisionado => DBProcessosDicInfo.ProValorProvisionado,
        DBProcessosDicInfo.AJGOponente => DBProcessosDicInfo.ProAJGOponente,
        DBProcessosDicInfo.ValorCacheCalculo => DBProcessosDicInfo.ProValorCacheCalculo,
        DBProcessosDicInfo.AJGPedidoOPO => DBProcessosDicInfo.ProAJGPedidoOPO,
        DBProcessosDicInfo.ValorCacheCalculoProv => DBProcessosDicInfo.ProValorCacheCalculoProv,
        DBProcessosDicInfo.ConsiderarParado => DBProcessosDicInfo.ProConsiderarParado,
        DBProcessosDicInfo.ValorCalculado => DBProcessosDicInfo.ProValorCalculado,
        DBProcessosDicInfo.AJGConcedidoOPO => DBProcessosDicInfo.ProAJGConcedidoOPO,
        DBProcessosDicInfo.Cobranca => DBProcessosDicInfo.ProCobranca,
        DBProcessosDicInfo.DataEntrada => DBProcessosDicInfo.ProDataEntrada,
        DBProcessosDicInfo.Penhora => DBProcessosDicInfo.ProPenhora,
        DBProcessosDicInfo.AJGPedido => DBProcessosDicInfo.ProAJGPedido,
        DBProcessosDicInfo.TipoBaixa => DBProcessosDicInfo.ProTipoBaixa,
        DBProcessosDicInfo.ClassRisco => DBProcessosDicInfo.ProClassRisco,
        DBProcessosDicInfo.IsApenso => DBProcessosDicInfo.ProIsApenso,
        DBProcessosDicInfo.ValorCausaInicial => DBProcessosDicInfo.ProValorCausaInicial,
        DBProcessosDicInfo.AJGConcedido => DBProcessosDicInfo.ProAJGConcedido,
        DBProcessosDicInfo.ObsBCX => DBProcessosDicInfo.ProObsBCX,
        DBProcessosDicInfo.ValorCausaDefinitivo => DBProcessosDicInfo.ProValorCausaDefinitivo,
        DBProcessosDicInfo.PercProbExito => DBProcessosDicInfo.ProPercProbExito,
        DBProcessosDicInfo.MNA => DBProcessosDicInfo.ProMNA,
        DBProcessosDicInfo.PercExito => DBProcessosDicInfo.ProPercExito,
        DBProcessosDicInfo.NroExtra => DBProcessosDicInfo.ProNroExtra,
        DBProcessosDicInfo.AdvOpo => DBProcessosDicInfo.ProAdvOpo,
        DBProcessosDicInfo.Extra => DBProcessosDicInfo.ProExtra,
        DBProcessosDicInfo.Justica => DBProcessosDicInfo.ProJustica,
        DBProcessosDicInfo.Advogado => DBProcessosDicInfo.ProAdvogado,
        DBProcessosDicInfo.NroCaixa => DBProcessosDicInfo.ProNroCaixa,
        DBProcessosDicInfo.Preposto => DBProcessosDicInfo.ProPreposto,
        DBProcessosDicInfo.Cliente => DBProcessosDicInfo.ProCliente,
        DBProcessosDicInfo.Oponente => DBProcessosDicInfo.ProOponente,
        DBProcessosDicInfo.Area => DBProcessosDicInfo.ProArea,
        DBProcessosDicInfo.Cidade => DBProcessosDicInfo.ProCidade,
        DBProcessosDicInfo.Situacao => DBProcessosDicInfo.ProSituacao,
        DBProcessosDicInfo.IDSituacao => DBProcessosDicInfo.ProIDSituacao,
        DBProcessosDicInfo.Valor => DBProcessosDicInfo.ProValor,
        DBProcessosDicInfo.Rito => DBProcessosDicInfo.ProRito,
        DBProcessosDicInfo.Fato => DBProcessosDicInfo.ProFato,
        DBProcessosDicInfo.NroPasta => DBProcessosDicInfo.ProNroPasta,
        DBProcessosDicInfo.Atividade => DBProcessosDicInfo.ProAtividade,
        DBProcessosDicInfo.CaixaMorto => DBProcessosDicInfo.ProCaixaMorto,
        DBProcessosDicInfo.Baixado => DBProcessosDicInfo.ProBaixado,
        DBProcessosDicInfo.DtBaixa => DBProcessosDicInfo.ProDtBaixa,
        DBProcessosDicInfo.MotivoBaixa => DBProcessosDicInfo.ProMotivoBaixa,
        DBProcessosDicInfo.OBS => DBProcessosDicInfo.ProOBS,
        DBProcessosDicInfo.Printed => DBProcessosDicInfo.ProPrinted,
        DBProcessosDicInfo.ZKey => DBProcessosDicInfo.ProZKey,
        DBProcessosDicInfo.ZKeyQuem => DBProcessosDicInfo.ProZKeyQuem,
        DBProcessosDicInfo.ZKeyQuando => DBProcessosDicInfo.ProZKeyQuando,
        DBProcessosDicInfo.Resumo => DBProcessosDicInfo.ProResumo,
        DBProcessosDicInfo.NaoImprimir => DBProcessosDicInfo.ProNaoImprimir,
        DBProcessosDicInfo.Eletronico => DBProcessosDicInfo.ProEletronico,
        DBProcessosDicInfo.NroContrato => DBProcessosDicInfo.ProNroContrato,
        DBProcessosDicInfo.PercProbExitoJustificativa => DBProcessosDicInfo.ProPercProbExitoJustificativa,
        DBProcessosDicInfo.HonorarioValor => DBProcessosDicInfo.ProHonorarioValor,
        DBProcessosDicInfo.HonorarioPercentual => DBProcessosDicInfo.ProHonorarioPercentual,
        DBProcessosDicInfo.HonorarioSucumbencia => DBProcessosDicInfo.ProHonorarioSucumbencia,
        DBProcessosDicInfo.FaseAuditoria => DBProcessosDicInfo.ProFaseAuditoria,
        DBProcessosDicInfo.ValorCondenacao => DBProcessosDicInfo.ProValorCondenacao,
        DBProcessosDicInfo.ValorCondenacaoCalculado => DBProcessosDicInfo.ProValorCondenacaoCalculado,
        DBProcessosDicInfo.ValorCondenacaoProvisorio => DBProcessosDicInfo.ProValorCondenacaoProvisorio,
        DBProcessosDicInfo.GUID => DBProcessosDicInfo.ProGUID,
        DBProcessosDicInfo.QuemCad => DBProcessosDicInfo.ProQuemCad,
        DBProcessosDicInfo.DtCad => DBProcessosDicInfo.ProDtCad,
        DBProcessosDicInfo.QuemAtu => DBProcessosDicInfo.ProQuemAtu,
        DBProcessosDicInfo.DtAtu => DBProcessosDicInfo.ProDtAtu,
        DBProcessosDicInfo.Visto => DBProcessosDicInfo.ProVisto,
        _ => null
    };
    public static string TCampoCodigo => DBProcessosDicInfo.CampoCodigo;
    public static string TCampoNome => DBProcessosDicInfo.CampoNome;
    public static string TTabelaNome => DBProcessosDicInfo.TabelaNome;
    public static string TTablePrefix => DBProcessosDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBProcessosDicInfo.ProAdvParc, DBProcessosDicInfo.ProAJGPedidoNegado, DBProcessosDicInfo.ProAJGCliente, DBProcessosDicInfo.ProAJGPedidoNegadoOPO, DBProcessosDicInfo.ProNotificarPOE, DBProcessosDicInfo.ProValorProvisionado, DBProcessosDicInfo.ProAJGOponente, DBProcessosDicInfo.ProValorCacheCalculo, DBProcessosDicInfo.ProAJGPedidoOPO, DBProcessosDicInfo.ProValorCacheCalculoProv, DBProcessosDicInfo.ProConsiderarParado, DBProcessosDicInfo.ProValorCalculado, DBProcessosDicInfo.ProAJGConcedidoOPO, DBProcessosDicInfo.ProCobranca, DBProcessosDicInfo.ProDataEntrada, DBProcessosDicInfo.ProPenhora, DBProcessosDicInfo.ProAJGPedido, DBProcessosDicInfo.ProTipoBaixa, DBProcessosDicInfo.ProClassRisco, DBProcessosDicInfo.ProIsApenso, DBProcessosDicInfo.ProValorCausaInicial, DBProcessosDicInfo.ProAJGConcedido, DBProcessosDicInfo.ProObsBCX, DBProcessosDicInfo.ProValorCausaDefinitivo, DBProcessosDicInfo.ProPercProbExito, DBProcessosDicInfo.ProMNA, DBProcessosDicInfo.ProPercExito, DBProcessosDicInfo.ProNroExtra, DBProcessosDicInfo.ProAdvOpo, DBProcessosDicInfo.ProExtra, DBProcessosDicInfo.ProJustica, DBProcessosDicInfo.ProAdvogado, DBProcessosDicInfo.ProNroCaixa, DBProcessosDicInfo.ProPreposto, DBProcessosDicInfo.ProCliente, DBProcessosDicInfo.ProOponente, DBProcessosDicInfo.ProArea, DBProcessosDicInfo.ProCidade, DBProcessosDicInfo.ProSituacao, DBProcessosDicInfo.ProIDSituacao, DBProcessosDicInfo.ProValor, DBProcessosDicInfo.ProRito, DBProcessosDicInfo.ProFato, DBProcessosDicInfo.ProNroPasta, DBProcessosDicInfo.ProAtividade, DBProcessosDicInfo.ProCaixaMorto, DBProcessosDicInfo.ProBaixado, DBProcessosDicInfo.ProDtBaixa, DBProcessosDicInfo.ProMotivoBaixa, DBProcessosDicInfo.ProOBS, DBProcessosDicInfo.ProPrinted, DBProcessosDicInfo.ProZKey, DBProcessosDicInfo.ProZKeyQuem, DBProcessosDicInfo.ProZKeyQuando, DBProcessosDicInfo.ProResumo, DBProcessosDicInfo.ProNaoImprimir, DBProcessosDicInfo.ProEletronico, DBProcessosDicInfo.ProNroContrato, DBProcessosDicInfo.ProPercProbExitoJustificativa, DBProcessosDicInfo.ProHonorarioValor, DBProcessosDicInfo.ProHonorarioPercentual, DBProcessosDicInfo.ProHonorarioSucumbencia, DBProcessosDicInfo.ProFaseAuditoria, DBProcessosDicInfo.ProValorCondenacao, DBProcessosDicInfo.ProValorCondenacaoCalculado, DBProcessosDicInfo.ProValorCondenacaoProvisorio, DBProcessosDicInfo.ProGUID, DBProcessosDicInfo.ProQuemCad, DBProcessosDicInfo.ProDtCad, DBProcessosDicInfo.ProQuemAtu, DBProcessosDicInfo.ProDtAtu, DBProcessosDicInfo.ProVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBProcessosDicInfo.ProAdvParc, DBProcessosDicInfo.ProAJGPedidoNegado, DBProcessosDicInfo.ProAJGCliente, DBProcessosDicInfo.ProAJGPedidoNegadoOPO, DBProcessosDicInfo.ProNotificarPOE, DBProcessosDicInfo.ProValorProvisionado, DBProcessosDicInfo.ProAJGOponente, DBProcessosDicInfo.ProValorCacheCalculo, DBProcessosDicInfo.ProAJGPedidoOPO, DBProcessosDicInfo.ProValorCacheCalculoProv, DBProcessosDicInfo.ProConsiderarParado, DBProcessosDicInfo.ProValorCalculado, DBProcessosDicInfo.ProAJGConcedidoOPO, DBProcessosDicInfo.ProCobranca, DBProcessosDicInfo.ProDataEntrada, DBProcessosDicInfo.ProPenhora, DBProcessosDicInfo.ProAJGPedido, DBProcessosDicInfo.ProTipoBaixa, DBProcessosDicInfo.ProClassRisco, DBProcessosDicInfo.ProIsApenso, DBProcessosDicInfo.ProValorCausaInicial, DBProcessosDicInfo.ProAJGConcedido, DBProcessosDicInfo.ProObsBCX, DBProcessosDicInfo.ProValorCausaDefinitivo, DBProcessosDicInfo.ProPercProbExito, DBProcessosDicInfo.ProMNA, DBProcessosDicInfo.ProPercExito, DBProcessosDicInfo.ProNroExtra, DBProcessosDicInfo.ProAdvOpo, DBProcessosDicInfo.ProExtra, DBProcessosDicInfo.ProJustica, DBProcessosDicInfo.ProAdvogado, DBProcessosDicInfo.ProNroCaixa, DBProcessosDicInfo.ProPreposto, DBProcessosDicInfo.ProCliente, DBProcessosDicInfo.ProOponente, DBProcessosDicInfo.ProArea, DBProcessosDicInfo.ProCidade, DBProcessosDicInfo.ProSituacao, DBProcessosDicInfo.ProIDSituacao, DBProcessosDicInfo.ProValor, DBProcessosDicInfo.ProRito, DBProcessosDicInfo.ProFato, DBProcessosDicInfo.ProNroPasta, DBProcessosDicInfo.ProAtividade, DBProcessosDicInfo.ProCaixaMorto, DBProcessosDicInfo.ProBaixado, DBProcessosDicInfo.ProDtBaixa, DBProcessosDicInfo.ProMotivoBaixa, DBProcessosDicInfo.ProOBS, DBProcessosDicInfo.ProPrinted, DBProcessosDicInfo.ProZKey, DBProcessosDicInfo.ProZKeyQuem, DBProcessosDicInfo.ProZKeyQuando, DBProcessosDicInfo.ProResumo, DBProcessosDicInfo.ProNaoImprimir, DBProcessosDicInfo.ProEletronico, DBProcessosDicInfo.ProNroContrato, DBProcessosDicInfo.ProPercProbExitoJustificativa, DBProcessosDicInfo.ProHonorarioValor, DBProcessosDicInfo.ProHonorarioPercentual, DBProcessosDicInfo.ProHonorarioSucumbencia, DBProcessosDicInfo.ProFaseAuditoria, DBProcessosDicInfo.ProValorCondenacao, DBProcessosDicInfo.ProValorCondenacaoCalculado, DBProcessosDicInfo.ProValorCondenacaoProvisorio, DBProcessosDicInfo.ProGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "proCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBProcessosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "proCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBProcessosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
