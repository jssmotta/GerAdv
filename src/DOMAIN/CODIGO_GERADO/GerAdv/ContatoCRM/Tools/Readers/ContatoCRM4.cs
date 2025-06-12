#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IContatoCRMReader
{
    ContatoCRMResponse? Read(int id, MsiSqlConnection oCnn);
    ContatoCRMResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ContatoCRMResponse? Read(Entity.DBContatoCRM dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ContatoCRMResponse? Read(DBContatoCRM dbRec);
    ContatoCRMResponseAll? ReadAll(DBContatoCRM dbRec, DataRow dr);
}

public partial class ContatoCRM : IContatoCRMReader
{
    public ContatoCRMResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBContatoCRM(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ContatoCRMResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBContatoCRM(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ContatoCRMResponse? Read(Entity.DBContatoCRM dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var contatocrm = new ContatoCRMResponse
        {
            Id = dbRec.ID,
            AgeClienteAvisado = dbRec.FAgeClienteAvisado,
            DocsViaRecebimento = dbRec.FDocsViaRecebimento,
            NaoPublicavel = dbRec.FNaoPublicavel,
            Notificar = dbRec.FNotificar,
            Ocultar = dbRec.FOcultar,
            Assunto = dbRec.FAssunto ?? string.Empty,
            IsDocsRecebidos = dbRec.FIsDocsRecebidos,
            QuemNotificou = dbRec.FQuemNotificou,
            Operador = dbRec.FOperador,
            Cliente = dbRec.FCliente,
            ObjetoNotificou = dbRec.FObjetoNotificou,
            PessoaContato = dbRec.FPessoaContato ?? string.Empty,
            Tempo = dbRec.FTempo,
            Processo = dbRec.FProcesso,
            Importante = dbRec.FImportante,
            Urgente = dbRec.FUrgente,
            GerarHoraTrabalhada = dbRec.FGerarHoraTrabalhada,
            ExibirNoTopo = dbRec.FExibirNoTopo,
            TipoContatoCRM = dbRec.FTipoContatoCRM,
            Contato = dbRec.FContato ?? string.Empty,
            Emocao = dbRec.FEmocao,
            Continuar = dbRec.FContinuar,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataNotificou, out _))
            contatocrm.DataNotificou = dbRec.FDataNotificou;
        if (DateTime.TryParse(dbRec.FHoraNotificou, out _))
            contatocrm.HoraNotificou = dbRec.FHoraNotificou;
        if (DateTime.TryParse(dbRec.FData, out _))
            contatocrm.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FHoraInicial, out _))
            contatocrm.HoraInicial = dbRec.FHoraInicial;
        if (DateTime.TryParse(dbRec.FHoraFinal, out _))
            contatocrm.HoraFinal = dbRec.FHoraFinal;
        return contatocrm;
    }

    public ContatoCRMResponse? Read(DBContatoCRM dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var contatocrm = new ContatoCRMResponse
        {
            Id = dbRec.ID,
            AgeClienteAvisado = dbRec.FAgeClienteAvisado,
            DocsViaRecebimento = dbRec.FDocsViaRecebimento,
            NaoPublicavel = dbRec.FNaoPublicavel,
            Notificar = dbRec.FNotificar,
            Ocultar = dbRec.FOcultar,
            Assunto = dbRec.FAssunto ?? string.Empty,
            IsDocsRecebidos = dbRec.FIsDocsRecebidos,
            QuemNotificou = dbRec.FQuemNotificou,
            Operador = dbRec.FOperador,
            Cliente = dbRec.FCliente,
            ObjetoNotificou = dbRec.FObjetoNotificou,
            PessoaContato = dbRec.FPessoaContato ?? string.Empty,
            Tempo = dbRec.FTempo,
            Processo = dbRec.FProcesso,
            Importante = dbRec.FImportante,
            Urgente = dbRec.FUrgente,
            GerarHoraTrabalhada = dbRec.FGerarHoraTrabalhada,
            ExibirNoTopo = dbRec.FExibirNoTopo,
            TipoContatoCRM = dbRec.FTipoContatoCRM,
            Contato = dbRec.FContato ?? string.Empty,
            Emocao = dbRec.FEmocao,
            Continuar = dbRec.FContinuar,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataNotificou, out _))
            contatocrm.DataNotificou = dbRec.FDataNotificou;
        if (DateTime.TryParse(dbRec.FHoraNotificou, out _))
            contatocrm.HoraNotificou = dbRec.FHoraNotificou;
        if (DateTime.TryParse(dbRec.FData, out _))
            contatocrm.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FHoraInicial, out _))
            contatocrm.HoraInicial = dbRec.FHoraInicial;
        if (DateTime.TryParse(dbRec.FHoraFinal, out _))
            contatocrm.HoraFinal = dbRec.FHoraFinal;
        return contatocrm;
    }

    public ContatoCRMResponseAll? ReadAll(DBContatoCRM dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var contatocrm = new ContatoCRMResponseAll
        {
            Id = dbRec.ID,
            AgeClienteAvisado = dbRec.FAgeClienteAvisado,
            DocsViaRecebimento = dbRec.FDocsViaRecebimento,
            NaoPublicavel = dbRec.FNaoPublicavel,
            Notificar = dbRec.FNotificar,
            Ocultar = dbRec.FOcultar,
            Assunto = dbRec.FAssunto ?? string.Empty,
            IsDocsRecebidos = dbRec.FIsDocsRecebidos,
            QuemNotificou = dbRec.FQuemNotificou,
            Operador = dbRec.FOperador,
            Cliente = dbRec.FCliente,
            ObjetoNotificou = dbRec.FObjetoNotificou,
            PessoaContato = dbRec.FPessoaContato ?? string.Empty,
            Tempo = dbRec.FTempo,
            Processo = dbRec.FProcesso,
            Importante = dbRec.FImportante,
            Urgente = dbRec.FUrgente,
            GerarHoraTrabalhada = dbRec.FGerarHoraTrabalhada,
            ExibirNoTopo = dbRec.FExibirNoTopo,
            TipoContatoCRM = dbRec.FTipoContatoCRM,
            Contato = dbRec.FContato ?? string.Empty,
            Emocao = dbRec.FEmocao,
            Continuar = dbRec.FContinuar,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataNotificou, out _))
            contatocrm.DataNotificou = dbRec.FDataNotificou;
        if (DateTime.TryParse(dbRec.FHoraNotificou, out _))
            contatocrm.HoraNotificou = dbRec.FHoraNotificou;
        if (DateTime.TryParse(dbRec.FData, out _))
            contatocrm.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FHoraInicial, out _))
            contatocrm.HoraInicial = dbRec.FHoraInicial;
        if (DateTime.TryParse(dbRec.FHoraFinal, out _))
            contatocrm.HoraFinal = dbRec.FHoraFinal;
        contatocrm.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        contatocrm.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        contatocrm.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        contatocrm.NomeTipoContatoCRM = dr["tccNome"]?.ToString() ?? string.Empty;
        return contatocrm;
    }
}