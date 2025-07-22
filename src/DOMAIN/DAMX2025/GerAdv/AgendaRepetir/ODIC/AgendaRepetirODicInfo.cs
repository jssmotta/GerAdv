#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBAgendaRepetirODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBAgendaRepetirDicInfo.TabelaNome;
    public string ICampoCodigo() => DBAgendaRepetirDicInfo.CampoCodigo;
    public string IPrefixo() => DBAgendaRepetirDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBAgendaRepetirDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBAgendaRepetirDicInfo.Advogado => DBAgendaRepetirDicInfo.RptAdvogado,
        DBAgendaRepetirDicInfo.Cliente => DBAgendaRepetirDicInfo.RptCliente,
        DBAgendaRepetirDicInfo.DataFinal => DBAgendaRepetirDicInfo.RptDataFinal,
        DBAgendaRepetirDicInfo.Funcionario => DBAgendaRepetirDicInfo.RptFuncionario,
        DBAgendaRepetirDicInfo.HoraFinal => DBAgendaRepetirDicInfo.RptHoraFinal,
        DBAgendaRepetirDicInfo.Processo => DBAgendaRepetirDicInfo.RptProcesso,
        DBAgendaRepetirDicInfo.Pessoal => DBAgendaRepetirDicInfo.RptPessoal,
        DBAgendaRepetirDicInfo.Frequencia => DBAgendaRepetirDicInfo.RptFrequencia,
        DBAgendaRepetirDicInfo.Dia => DBAgendaRepetirDicInfo.RptDia,
        DBAgendaRepetirDicInfo.Mes => DBAgendaRepetirDicInfo.RptMes,
        DBAgendaRepetirDicInfo.Hora => DBAgendaRepetirDicInfo.RptHora,
        DBAgendaRepetirDicInfo.IDQuem => DBAgendaRepetirDicInfo.RptIDQuem,
        DBAgendaRepetirDicInfo.IDQuem2 => DBAgendaRepetirDicInfo.RptIDQuem2,
        DBAgendaRepetirDicInfo.Mensagem => DBAgendaRepetirDicInfo.RptMensagem,
        DBAgendaRepetirDicInfo.IDTipo => DBAgendaRepetirDicInfo.RptIDTipo,
        DBAgendaRepetirDicInfo.ID1 => DBAgendaRepetirDicInfo.RptID1,
        DBAgendaRepetirDicInfo.ID2 => DBAgendaRepetirDicInfo.RptID2,
        DBAgendaRepetirDicInfo.ID3 => DBAgendaRepetirDicInfo.RptID3,
        DBAgendaRepetirDicInfo.ID4 => DBAgendaRepetirDicInfo.RptID4,
        DBAgendaRepetirDicInfo.Segunda => DBAgendaRepetirDicInfo.RptSegunda,
        DBAgendaRepetirDicInfo.Quarta => DBAgendaRepetirDicInfo.RptQuarta,
        DBAgendaRepetirDicInfo.Quinta => DBAgendaRepetirDicInfo.RptQuinta,
        DBAgendaRepetirDicInfo.Sexta => DBAgendaRepetirDicInfo.RptSexta,
        DBAgendaRepetirDicInfo.Sabado => DBAgendaRepetirDicInfo.RptSabado,
        DBAgendaRepetirDicInfo.Domingo => DBAgendaRepetirDicInfo.RptDomingo,
        DBAgendaRepetirDicInfo.Terca => DBAgendaRepetirDicInfo.RptTerca,
        DBAgendaRepetirDicInfo.QuemCad => DBAgendaRepetirDicInfo.RptQuemCad,
        DBAgendaRepetirDicInfo.DtCad => DBAgendaRepetirDicInfo.RptDtCad,
        DBAgendaRepetirDicInfo.QuemAtu => DBAgendaRepetirDicInfo.RptQuemAtu,
        DBAgendaRepetirDicInfo.DtAtu => DBAgendaRepetirDicInfo.RptDtAtu,
        DBAgendaRepetirDicInfo.Visto => DBAgendaRepetirDicInfo.RptVisto,
        _ => null
    };
    public static string TCampoCodigo => DBAgendaRepetirDicInfo.CampoCodigo;
    public static string TCampoNome => DBAgendaRepetirDicInfo.CampoNome;
    public static string TTabelaNome => DBAgendaRepetirDicInfo.TabelaNome;
    public static string TTablePrefix => DBAgendaRepetirDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBAgendaRepetirDicInfo.RptAdvogado, DBAgendaRepetirDicInfo.RptCliente, DBAgendaRepetirDicInfo.RptDataFinal, DBAgendaRepetirDicInfo.RptFuncionario, DBAgendaRepetirDicInfo.RptHoraFinal, DBAgendaRepetirDicInfo.RptProcesso, DBAgendaRepetirDicInfo.RptPessoal, DBAgendaRepetirDicInfo.RptFrequencia, DBAgendaRepetirDicInfo.RptDia, DBAgendaRepetirDicInfo.RptMes, DBAgendaRepetirDicInfo.RptHora, DBAgendaRepetirDicInfo.RptIDQuem, DBAgendaRepetirDicInfo.RptIDQuem2, DBAgendaRepetirDicInfo.RptMensagem, DBAgendaRepetirDicInfo.RptIDTipo, DBAgendaRepetirDicInfo.RptID1, DBAgendaRepetirDicInfo.RptID2, DBAgendaRepetirDicInfo.RptID3, DBAgendaRepetirDicInfo.RptID4, DBAgendaRepetirDicInfo.RptSegunda, DBAgendaRepetirDicInfo.RptQuarta, DBAgendaRepetirDicInfo.RptQuinta, DBAgendaRepetirDicInfo.RptSexta, DBAgendaRepetirDicInfo.RptSabado, DBAgendaRepetirDicInfo.RptDomingo, DBAgendaRepetirDicInfo.RptTerca, DBAgendaRepetirDicInfo.RptQuemCad, DBAgendaRepetirDicInfo.RptDtCad, DBAgendaRepetirDicInfo.RptQuemAtu, DBAgendaRepetirDicInfo.RptDtAtu, DBAgendaRepetirDicInfo.RptVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBAgendaRepetirDicInfo.RptAdvogado, DBAgendaRepetirDicInfo.RptCliente, DBAgendaRepetirDicInfo.RptDataFinal, DBAgendaRepetirDicInfo.RptFuncionario, DBAgendaRepetirDicInfo.RptHoraFinal, DBAgendaRepetirDicInfo.RptProcesso, DBAgendaRepetirDicInfo.RptPessoal, DBAgendaRepetirDicInfo.RptFrequencia, DBAgendaRepetirDicInfo.RptDia, DBAgendaRepetirDicInfo.RptMes, DBAgendaRepetirDicInfo.RptHora, DBAgendaRepetirDicInfo.RptIDQuem, DBAgendaRepetirDicInfo.RptIDQuem2, DBAgendaRepetirDicInfo.RptMensagem, DBAgendaRepetirDicInfo.RptIDTipo, DBAgendaRepetirDicInfo.RptID1, DBAgendaRepetirDicInfo.RptID2, DBAgendaRepetirDicInfo.RptID3, DBAgendaRepetirDicInfo.RptID4, DBAgendaRepetirDicInfo.RptSegunda, DBAgendaRepetirDicInfo.RptQuarta, DBAgendaRepetirDicInfo.RptQuinta, DBAgendaRepetirDicInfo.RptSexta, DBAgendaRepetirDicInfo.RptSabado, DBAgendaRepetirDicInfo.RptDomingo, DBAgendaRepetirDicInfo.RptTerca];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "rptCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBAgendaRepetirDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "rptCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBAgendaRepetirDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
