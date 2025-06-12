#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IRecadosReader
{
    RecadosResponse? Read(int id, MsiSqlConnection oCnn);
    RecadosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    RecadosResponse? Read(Entity.DBRecados dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    RecadosResponse? Read(DBRecados dbRec);
    RecadosResponseAll? ReadAll(DBRecados dbRec, DataRow dr);
}

public partial class Recados : IRecadosReader
{
    public RecadosResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBRecados(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public RecadosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBRecados(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public RecadosResponse? Read(Entity.DBRecados dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var recados = new RecadosResponse
        {
            Id = dbRec.ID,
            ClienteNome = dbRec.FClienteNome ?? string.Empty,
            De = dbRec.FDe ?? string.Empty,
            Para = dbRec.FPara ?? string.Empty,
            Assunto = dbRec.FAssunto ?? string.Empty,
            Concluido = dbRec.FConcluido,
            Processo = dbRec.FProcesso,
            Cliente = dbRec.FCliente,
            Recado = dbRec.FRecado ?? string.Empty,
            Urgente = dbRec.FUrgente,
            Importante = dbRec.FImportante,
            Voltara = dbRec.FVoltara,
            Pessoal = dbRec.FPessoal,
            Retornar = dbRec.FRetornar,
            Emotion = dbRec.FEmotion,
            InternetID = dbRec.FInternetID,
            Uploaded = dbRec.FUploaded,
            Natureza = dbRec.FNatureza,
            BIU = dbRec.FBIU,
            AguardarRetorno = dbRec.FAguardarRetorno,
            AguardarRetornoPara = dbRec.FAguardarRetornoPara ?? string.Empty,
            AguardarRetornoOK = dbRec.FAguardarRetornoOK,
            ParaID = dbRec.FParaID,
            NaoPublicavel = dbRec.FNaoPublicavel,
            IsContatoCRM = dbRec.FIsContatoCRM,
            MasterID = dbRec.FMasterID,
            ListaPara = dbRec.FListaPara ?? string.Empty,
            Typed = dbRec.FTyped,
            AssuntoRecado = dbRec.FAssuntoRecado,
            Historico = dbRec.FHistorico,
            ContatoCRM = dbRec.FContatoCRM,
            Ligacoes = dbRec.FLigacoes,
            Agenda = dbRec.FAgenda,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FHora, out _))
            recados.Hora = dbRec.FHora;
        if (DateTime.TryParse(dbRec.FData, out _))
            recados.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FRetornoData, out _))
            recados.RetornoData = dbRec.FRetornoData;
        return recados;
    }

    public RecadosResponse? Read(DBRecados dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var recados = new RecadosResponse
        {
            Id = dbRec.ID,
            ClienteNome = dbRec.FClienteNome ?? string.Empty,
            De = dbRec.FDe ?? string.Empty,
            Para = dbRec.FPara ?? string.Empty,
            Assunto = dbRec.FAssunto ?? string.Empty,
            Concluido = dbRec.FConcluido,
            Processo = dbRec.FProcesso,
            Cliente = dbRec.FCliente,
            Recado = dbRec.FRecado ?? string.Empty,
            Urgente = dbRec.FUrgente,
            Importante = dbRec.FImportante,
            Voltara = dbRec.FVoltara,
            Pessoal = dbRec.FPessoal,
            Retornar = dbRec.FRetornar,
            Emotion = dbRec.FEmotion,
            InternetID = dbRec.FInternetID,
            Uploaded = dbRec.FUploaded,
            Natureza = dbRec.FNatureza,
            BIU = dbRec.FBIU,
            AguardarRetorno = dbRec.FAguardarRetorno,
            AguardarRetornoPara = dbRec.FAguardarRetornoPara ?? string.Empty,
            AguardarRetornoOK = dbRec.FAguardarRetornoOK,
            ParaID = dbRec.FParaID,
            NaoPublicavel = dbRec.FNaoPublicavel,
            IsContatoCRM = dbRec.FIsContatoCRM,
            MasterID = dbRec.FMasterID,
            ListaPara = dbRec.FListaPara ?? string.Empty,
            Typed = dbRec.FTyped,
            AssuntoRecado = dbRec.FAssuntoRecado,
            Historico = dbRec.FHistorico,
            ContatoCRM = dbRec.FContatoCRM,
            Ligacoes = dbRec.FLigacoes,
            Agenda = dbRec.FAgenda,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FHora, out _))
            recados.Hora = dbRec.FHora;
        if (DateTime.TryParse(dbRec.FData, out _))
            recados.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FRetornoData, out _))
            recados.RetornoData = dbRec.FRetornoData;
        return recados;
    }

    public RecadosResponseAll? ReadAll(DBRecados dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var recados = new RecadosResponseAll
        {
            Id = dbRec.ID,
            ClienteNome = dbRec.FClienteNome ?? string.Empty,
            De = dbRec.FDe ?? string.Empty,
            Para = dbRec.FPara ?? string.Empty,
            Assunto = dbRec.FAssunto ?? string.Empty,
            Concluido = dbRec.FConcluido,
            Processo = dbRec.FProcesso,
            Cliente = dbRec.FCliente,
            Recado = dbRec.FRecado ?? string.Empty,
            Urgente = dbRec.FUrgente,
            Importante = dbRec.FImportante,
            Voltara = dbRec.FVoltara,
            Pessoal = dbRec.FPessoal,
            Retornar = dbRec.FRetornar,
            Emotion = dbRec.FEmotion,
            InternetID = dbRec.FInternetID,
            Uploaded = dbRec.FUploaded,
            Natureza = dbRec.FNatureza,
            BIU = dbRec.FBIU,
            AguardarRetorno = dbRec.FAguardarRetorno,
            AguardarRetornoPara = dbRec.FAguardarRetornoPara ?? string.Empty,
            AguardarRetornoOK = dbRec.FAguardarRetornoOK,
            ParaID = dbRec.FParaID,
            NaoPublicavel = dbRec.FNaoPublicavel,
            IsContatoCRM = dbRec.FIsContatoCRM,
            MasterID = dbRec.FMasterID,
            ListaPara = dbRec.FListaPara ?? string.Empty,
            Typed = dbRec.FTyped,
            AssuntoRecado = dbRec.FAssuntoRecado,
            Historico = dbRec.FHistorico,
            ContatoCRM = dbRec.FContatoCRM,
            Ligacoes = dbRec.FLigacoes,
            Agenda = dbRec.FAgenda,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FHora, out _))
            recados.Hora = dbRec.FHora;
        if (DateTime.TryParse(dbRec.FData, out _))
            recados.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FRetornoData, out _))
            recados.RetornoData = dbRec.FRetornoData;
        recados.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        recados.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        recados.NomeLigacoes = dr["ligNome"]?.ToString() ?? string.Empty;
        return recados;
    }
}