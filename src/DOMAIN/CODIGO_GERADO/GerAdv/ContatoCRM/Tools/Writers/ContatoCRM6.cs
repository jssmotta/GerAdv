#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IContatoCRMWriter
{
    Entity.DBContatoCRM Write(Models.ContatoCRM contatocrm, int auditorQuem, SqlConnection oCnn);
}

public class ContatoCRM : IContatoCRMWriter
{
    public Entity.DBContatoCRM Write(Models.ContatoCRM contatocrm, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = contatocrm.Id.IsEmptyIDNumber() ? new Entity.DBContatoCRM() : new Entity.DBContatoCRM(contatocrm.Id, oCnn);
        dbRec.FAgeClienteAvisado = contatocrm.AgeClienteAvisado;
        dbRec.FDocsViaRecebimento = contatocrm.DocsViaRecebimento;
        dbRec.FNaoPublicavel = contatocrm.NaoPublicavel;
        dbRec.FNotificar = contatocrm.Notificar;
        dbRec.FOcultar = contatocrm.Ocultar;
        dbRec.FAssunto = contatocrm.Assunto;
        dbRec.FIsDocsRecebidos = contatocrm.IsDocsRecebidos;
        dbRec.FQuemNotificou = contatocrm.QuemNotificou;
        if (contatocrm.DataNotificou != null)
            dbRec.FDataNotificou = contatocrm.DataNotificou.ToString();
        dbRec.FOperador = contatocrm.Operador;
        dbRec.FCliente = contatocrm.Cliente;
        if (contatocrm.HoraNotificou != null)
            dbRec.FHoraNotificou = contatocrm.HoraNotificou.ToString();
        dbRec.FObjetoNotificou = contatocrm.ObjetoNotificou;
        dbRec.FPessoaContato = contatocrm.PessoaContato;
        if (contatocrm.Data != null)
            dbRec.FData = contatocrm.Data.ToString();
        dbRec.FTempo = contatocrm.Tempo;
        if (contatocrm.HoraInicial != null)
            dbRec.FHoraInicial = contatocrm.HoraInicial.ToString();
        if (contatocrm.HoraFinal != null)
            dbRec.FHoraFinal = contatocrm.HoraFinal.ToString();
        dbRec.FProcesso = contatocrm.Processo;
        dbRec.FImportante = contatocrm.Importante;
        dbRec.FUrgente = contatocrm.Urgente;
        dbRec.FGerarHoraTrabalhada = contatocrm.GerarHoraTrabalhada;
        dbRec.FExibirNoTopo = contatocrm.ExibirNoTopo;
        dbRec.FTipoContatoCRM = contatocrm.TipoContatoCRM;
        dbRec.FContato = contatocrm.Contato;
        dbRec.FEmocao = contatocrm.Emocao;
        dbRec.FContinuar = contatocrm.Continuar;
        dbRec.FBold = contatocrm.Bold;
        dbRec.FGUID = contatocrm.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}