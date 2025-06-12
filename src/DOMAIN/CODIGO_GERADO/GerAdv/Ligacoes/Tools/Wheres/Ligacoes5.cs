#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ILigacoesWhere
{
    LigacoesResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class Ligacoes : ILigacoesWhere
{
    public LigacoesResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBLigacoes(sqlWhere: where, parameters: parameters, oCnn: oCnn);
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
        return ligacoes;
    }
}