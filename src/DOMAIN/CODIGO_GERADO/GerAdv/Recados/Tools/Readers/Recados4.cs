#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IRecadosReader
{
    RecadosResponse? Read(int id, SqlConnection oCnn);
    RecadosResponse? Read(string where, SqlConnection oCnn);
    RecadosResponse? Read(Entity.DBRecados dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    RecadosResponse? Read(DBRecados dbRec);
}

public partial class Recados : IRecadosReader
{
    public RecadosResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBRecados(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public RecadosResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBRecados(sqlWhere: where, oCnn: oCnn);
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
            Guid = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FHora, out _))
            recados.Hora = dbRec.FHora;
        if (DateTime.TryParse(dbRec.FData, out _))
            recados.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FRetornoData, out _))
            recados.RetornoData = dbRec.FRetornoData;
        var auditor = new Auditor
        {
            Visto = dbRec.FVisto,
            QuemCad = dbRec.FQuemCad
        };
        if (auditor.QuemAtu > 0)
            auditor.QuemAtu = dbRec.FQuemAtu;
        if (dbRec.FDtCad.NotIsEmpty())
            auditor.DtCad = Convert.ToDateTime(dbRec.FDtCad);
        if (!(dbRec.FDtAtu is { }))
            auditor.DtAtu = Convert.ToDateTime(dbRec.FDtAtu);
        recados.Auditor = auditor;
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
            Guid = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FHora, out _))
            recados.Hora = dbRec.FHora;
        if (DateTime.TryParse(dbRec.FData, out _))
            recados.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FRetornoData, out _))
            recados.RetornoData = dbRec.FRetornoData;
        var auditor = new Auditor
        {
            Visto = dbRec.FVisto,
            QuemCad = dbRec.FQuemCad
        };
        if (auditor.QuemAtu > 0)
            auditor.QuemAtu = dbRec.FQuemAtu;
        if (dbRec.FDtCad.NotIsEmpty())
            auditor.DtCad = Convert.ToDateTime(dbRec.FDtCad);
        if (!(dbRec.FDtAtu is { }))
            auditor.DtAtu = Convert.ToDateTime(dbRec.FDtAtu);
        recados.Auditor = auditor;
        return recados;
    }
}