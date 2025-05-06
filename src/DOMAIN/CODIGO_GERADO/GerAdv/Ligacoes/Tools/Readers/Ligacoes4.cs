#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ILigacoesReader
{
    LigacoesResponse? Read(int id, SqlConnection oCnn);
    LigacoesResponse? Read(string where, SqlConnection oCnn);
    LigacoesResponse? Read(Entity.DBLigacoes dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    LigacoesResponse? Read(DBLigacoes dbRec);
}

public partial class Ligacoes : ILigacoesReader
{
    public LigacoesResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBLigacoes(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public LigacoesResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBLigacoes(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public LigacoesResponse? Read(Entity.DBLigacoes dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var ligacoes = new LigacoesResponse
        {
            Id = dbRec.ID,
            Assunto = dbRec.FAssunto ?? string.Empty,
            AgeClienteAvisado = dbRec.FAgeClienteAvisado,
            Celular = dbRec.FCelular,
            Cliente = dbRec.FCliente,
            Contato = dbRec.FContato ?? string.Empty,
            QuemID = dbRec.FQuemID,
            Telefonista = dbRec.FTelefonista,
            Nome = dbRec.FNome ?? string.Empty,
            QuemCodigo = dbRec.FQuemCodigo,
            Solicitante = dbRec.FSolicitante,
            Para = dbRec.FPara ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Ramal = dbRec.FRamal,
            Particular = dbRec.FParticular,
            Realizada = dbRec.FRealizada,
            Status = dbRec.FStatus ?? string.Empty,
            Urgente = dbRec.FUrgente,
            LigarPara = dbRec.FLigarPara ?? string.Empty,
            Processo = dbRec.FProcesso,
            StartScreen = dbRec.FStartScreen,
            Emotion = dbRec.FEmotion,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataRealizada, out _))
            ligacoes.DataRealizada = dbRec.FDataRealizada;
        if (DateTime.TryParse(dbRec.FUltimoAviso, out _))
            ligacoes.UltimoAviso = dbRec.FUltimoAviso;
        if (DateTime.TryParse(dbRec.FHoraFinal, out _))
            ligacoes.HoraFinal = dbRec.FHoraFinal;
        if (DateTime.TryParse(dbRec.FData, out _))
            ligacoes.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FHora, out _))
            ligacoes.Hora = dbRec.FHora;
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
        ligacoes.Auditor = auditor;
        return ligacoes;
    }

    public LigacoesResponse? Read(DBLigacoes dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var ligacoes = new LigacoesResponse
        {
            Id = dbRec.ID,
            Assunto = dbRec.FAssunto ?? string.Empty,
            AgeClienteAvisado = dbRec.FAgeClienteAvisado,
            Celular = dbRec.FCelular,
            Cliente = dbRec.FCliente,
            Contato = dbRec.FContato ?? string.Empty,
            QuemID = dbRec.FQuemID,
            Telefonista = dbRec.FTelefonista,
            Nome = dbRec.FNome ?? string.Empty,
            QuemCodigo = dbRec.FQuemCodigo,
            Solicitante = dbRec.FSolicitante,
            Para = dbRec.FPara ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Ramal = dbRec.FRamal,
            Particular = dbRec.FParticular,
            Realizada = dbRec.FRealizada,
            Status = dbRec.FStatus ?? string.Empty,
            Urgente = dbRec.FUrgente,
            LigarPara = dbRec.FLigarPara ?? string.Empty,
            Processo = dbRec.FProcesso,
            StartScreen = dbRec.FStartScreen,
            Emotion = dbRec.FEmotion,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataRealizada, out _))
            ligacoes.DataRealizada = dbRec.FDataRealizada;
        if (DateTime.TryParse(dbRec.FUltimoAviso, out _))
            ligacoes.UltimoAviso = dbRec.FUltimoAviso;
        if (DateTime.TryParse(dbRec.FHoraFinal, out _))
            ligacoes.HoraFinal = dbRec.FHoraFinal;
        if (DateTime.TryParse(dbRec.FData, out _))
            ligacoes.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FHora, out _))
            ligacoes.Hora = dbRec.FHora;
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
        ligacoes.Auditor = auditor;
        return ligacoes;
    }
}