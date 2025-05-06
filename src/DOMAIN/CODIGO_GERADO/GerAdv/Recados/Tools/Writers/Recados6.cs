#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IRecadosWriter
{
    Entity.DBRecados Write(Models.Recados recados, int auditorQuem, SqlConnection oCnn);
}

public class Recados : IRecadosWriter
{
    public Entity.DBRecados Write(Models.Recados recados, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = recados.Id.IsEmptyIDNumber() ? new Entity.DBRecados() : new Entity.DBRecados(recados.Id, oCnn);
        dbRec.FClienteNome = recados.ClienteNome;
        dbRec.FDe = recados.De;
        dbRec.FPara = recados.Para;
        dbRec.FAssunto = recados.Assunto;
        dbRec.FConcluido = recados.Concluido;
        dbRec.FProcesso = recados.Processo;
        dbRec.FCliente = recados.Cliente;
        dbRec.FRecado = recados.Recado;
        dbRec.FUrgente = recados.Urgente;
        dbRec.FImportante = recados.Importante;
        if (recados.Hora != null)
            dbRec.FHora = recados.Hora.ToString();
        if (recados.Data != null)
            dbRec.FData = recados.Data.ToString();
        dbRec.FVoltara = recados.Voltara;
        dbRec.FPessoal = recados.Pessoal;
        dbRec.FRetornar = recados.Retornar;
        if (recados.RetornoData != null)
            dbRec.FRetornoData = recados.RetornoData.ToString();
        dbRec.FEmotion = recados.Emotion;
        dbRec.FInternetID = recados.InternetID;
        dbRec.FUploaded = recados.Uploaded;
        dbRec.FNatureza = recados.Natureza;
        dbRec.FBIU = recados.BIU;
        dbRec.FAguardarRetorno = recados.AguardarRetorno;
        dbRec.FAguardarRetornoPara = recados.AguardarRetornoPara;
        dbRec.FAguardarRetornoOK = recados.AguardarRetornoOK;
        dbRec.FParaID = recados.ParaID;
        dbRec.FNaoPublicavel = recados.NaoPublicavel;
        dbRec.FIsContatoCRM = recados.IsContatoCRM;
        dbRec.FMasterID = recados.MasterID;
        dbRec.FListaPara = recados.ListaPara;
        dbRec.FTyped = recados.Typed;
        dbRec.FAssuntoRecado = recados.AssuntoRecado;
        dbRec.FHistorico = recados.Historico;
        dbRec.FContatoCRM = recados.ContatoCRM;
        dbRec.FLigacoes = recados.Ligacoes;
        dbRec.FAgenda = recados.Agenda;
        dbRec.FGUID = recados.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}