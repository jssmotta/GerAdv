#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgendaWriter
{
    Entity.DBAgenda Write(Models.Agenda agenda, int auditorQuem, SqlConnection oCnn);
}

public class Agenda : IAgendaWriter
{
    public Entity.DBAgenda Write(Models.Agenda agenda, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = agenda.Id.IsEmptyIDNumber() ? new Entity.DBAgenda() : new Entity.DBAgenda(agenda.Id, oCnn);
        dbRec.FIDCOB = agenda.IDCOB;
        dbRec.FClienteAvisado = agenda.ClienteAvisado;
        dbRec.FRevisarP2 = agenda.RevisarP2;
        dbRec.FIDNE = agenda.IDNE;
        dbRec.FCidade = agenda.Cidade;
        dbRec.FOculto = agenda.Oculto;
        dbRec.FCartaPrecatoria = agenda.CartaPrecatoria;
        dbRec.FRevisar = agenda.Revisar;
        if (agenda.HrFinal != null)
            dbRec.FHrFinal = agenda.HrFinal.ToString();
        dbRec.FAdvogado = agenda.Advogado;
        dbRec.FEventoGerador = agenda.EventoGerador;
        if (agenda.EventoData != null)
            dbRec.FEventoData = agenda.EventoData.ToString();
        dbRec.FFuncionario = agenda.Funcionario;
        if (agenda.Data != null)
            dbRec.FData = agenda.Data.ToString();
        dbRec.FEventoPrazo = agenda.EventoPrazo;
        if (agenda.Hora != null)
            dbRec.FHora = agenda.Hora.ToString();
        dbRec.FCompromisso = agenda.Compromisso;
        dbRec.FTipoCompromisso = agenda.TipoCompromisso;
        dbRec.FCliente = agenda.Cliente;
        dbRec.FLiberado = agenda.Liberado;
        dbRec.FImportante = agenda.Importante;
        dbRec.FConcluido = agenda.Concluido;
        dbRec.FArea = agenda.Area;
        dbRec.FJustica = agenda.Justica;
        dbRec.FProcesso = agenda.Processo;
        dbRec.FIDHistorico = agenda.IDHistorico;
        dbRec.FIDInsProcesso = agenda.IDInsProcesso;
        dbRec.FUsuario = agenda.Usuario;
        dbRec.FPreposto = agenda.Preposto;
        dbRec.FQuemID = agenda.QuemID;
        dbRec.FQuemCodigo = agenda.QuemCodigo;
        dbRec.FStatus = agenda.Status;
        dbRec.FValor = agenda.Valor;
        dbRec.FDecisao = agenda.Decisao;
        dbRec.FSempre = agenda.Sempre;
        dbRec.FPrazoDias = agenda.PrazoDias;
        dbRec.FProtocoloIntegrado = agenda.ProtocoloIntegrado;
        if (agenda.DataInicioPrazo != null)
            dbRec.FDataInicioPrazo = agenda.DataInicioPrazo.ToString();
        dbRec.FUsuarioCiente = agenda.UsuarioCiente;
        dbRec.FGUID = agenda.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}