#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ILigacoesWriter
{
    Entity.DBLigacoes Write(Models.Ligacoes ligacoes, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(LigacoesResponse ligacoes, int operadorId, MsiSqlConnection oCnn);
}

public class Ligacoes : ILigacoesWriter
{
    public void Delete(LigacoesResponse ligacoes, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[Ligacoes] WHERE ligCodigo={ligacoes.Id};", oCnn);
    }

    public Entity.DBLigacoes Write(Models.Ligacoes ligacoes, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = ligacoes.Id.IsEmptyIDNumber() ? new Entity.DBLigacoes() : new Entity.DBLigacoes(ligacoes.Id, oCnn);
        dbRec.FAssunto = ligacoes.Assunto;
        dbRec.FAgeClienteAvisado = ligacoes.AgeClienteAvisado;
        dbRec.FCelular = ligacoes.Celular;
        dbRec.FCliente = ligacoes.Cliente;
        dbRec.FContato = ligacoes.Contato;
        if (ligacoes.DataRealizada != null)
            dbRec.FDataRealizada = ligacoes.DataRealizada.ToString();
        dbRec.FQuemID = ligacoes.QuemID;
        dbRec.FTelefonista = ligacoes.Telefonista;
        if (ligacoes.UltimoAviso != null)
            dbRec.FUltimoAviso = ligacoes.UltimoAviso.ToString();
        if (ligacoes.HoraFinal != null)
            dbRec.FHoraFinal = ligacoes.HoraFinal.ToString();
        dbRec.FNome = ligacoes.Nome;
        dbRec.FQuemCodigo = ligacoes.QuemCodigo;
        dbRec.FSolicitante = ligacoes.Solicitante;
        dbRec.FPara = ligacoes.Para;
        dbRec.FFone = ligacoes.Fone;
        dbRec.FRamal = ligacoes.Ramal;
        dbRec.FParticular = ligacoes.Particular;
        dbRec.FRealizada = ligacoes.Realizada;
        dbRec.FStatus = ligacoes.Status;
        if (ligacoes.Data != null)
            dbRec.FData = ligacoes.Data.ToString();
        if (ligacoes.Hora != null)
            dbRec.FHora = ligacoes.Hora.ToString();
        dbRec.FUrgente = ligacoes.Urgente;
        dbRec.FLigarPara = ligacoes.LigarPara;
        dbRec.FProcesso = ligacoes.Processo;
        dbRec.FStartScreen = ligacoes.StartScreen;
        dbRec.FEmotion = ligacoes.Emotion;
        dbRec.FBold = ligacoes.Bold;
        dbRec.FGUID = ligacoes.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}