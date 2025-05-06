#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgendaFinanceiroWriter
{
    Entity.DBAgendaFinanceiro Write(Models.AgendaFinanceiro agendafinanceiro, int auditorQuem, SqlConnection oCnn);
}

public class AgendaFinanceiro : IAgendaFinanceiroWriter
{
    public Entity.DBAgendaFinanceiro Write(Models.AgendaFinanceiro agendafinanceiro, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = agendafinanceiro.Id.IsEmptyIDNumber() ? new Entity.DBAgendaFinanceiro() : new Entity.DBAgendaFinanceiro(agendafinanceiro.Id, oCnn);
        dbRec.FIDCOB = agendafinanceiro.IDCOB;
        dbRec.FIDNE = agendafinanceiro.IDNE;
        dbRec.FPrazoProvisionado = agendafinanceiro.PrazoProvisionado;
        dbRec.FCidade = agendafinanceiro.Cidade;
        dbRec.FOculto = agendafinanceiro.Oculto;
        dbRec.FCartaPrecatoria = agendafinanceiro.CartaPrecatoria;
        dbRec.FRepetirDias = agendafinanceiro.RepetirDias;
        if (agendafinanceiro.HrFinal != null)
            dbRec.FHrFinal = agendafinanceiro.HrFinal.ToString();
        dbRec.FRepetir = agendafinanceiro.Repetir;
        dbRec.FAdvogado = agendafinanceiro.Advogado;
        dbRec.FEventoGerador = agendafinanceiro.EventoGerador;
        if (agendafinanceiro.EventoData != null)
            dbRec.FEventoData = agendafinanceiro.EventoData.ToString();
        dbRec.FFuncionario = agendafinanceiro.Funcionario;
        if (agendafinanceiro.Data != null)
            dbRec.FData = agendafinanceiro.Data.ToString();
        dbRec.FEventoPrazo = agendafinanceiro.EventoPrazo;
        if (agendafinanceiro.Hora != null)
            dbRec.FHora = agendafinanceiro.Hora.ToString();
        dbRec.FCompromisso = agendafinanceiro.Compromisso;
        dbRec.FTipoCompromisso = agendafinanceiro.TipoCompromisso;
        dbRec.FCliente = agendafinanceiro.Cliente;
        if (agendafinanceiro.DDias != null)
            dbRec.FDDias = agendafinanceiro.DDias.ToString();
        dbRec.FDias = agendafinanceiro.Dias;
        dbRec.FLiberado = agendafinanceiro.Liberado;
        dbRec.FImportante = agendafinanceiro.Importante;
        dbRec.FConcluido = agendafinanceiro.Concluido;
        dbRec.FArea = agendafinanceiro.Area;
        dbRec.FJustica = agendafinanceiro.Justica;
        dbRec.FProcesso = agendafinanceiro.Processo;
        dbRec.FIDHistorico = agendafinanceiro.IDHistorico;
        dbRec.FIDInsProcesso = agendafinanceiro.IDInsProcesso;
        dbRec.FUsuario = agendafinanceiro.Usuario;
        dbRec.FPreposto = agendafinanceiro.Preposto;
        dbRec.FQuemID = agendafinanceiro.QuemID;
        dbRec.FQuemCodigo = agendafinanceiro.QuemCodigo;
        dbRec.FStatus = agendafinanceiro.Status;
        dbRec.FValor = agendafinanceiro.Valor;
        dbRec.FCompromissoHTML = agendafinanceiro.CompromissoHTML;
        dbRec.FDecisao = agendafinanceiro.Decisao;
        dbRec.FRevisar = agendafinanceiro.Revisar;
        dbRec.FRevisarP2 = agendafinanceiro.RevisarP2;
        dbRec.FSempre = agendafinanceiro.Sempre;
        dbRec.FPrazoDias = agendafinanceiro.PrazoDias;
        dbRec.FProtocoloIntegrado = agendafinanceiro.ProtocoloIntegrado;
        if (agendafinanceiro.DataInicioPrazo != null)
            dbRec.FDataInicioPrazo = agendafinanceiro.DataInicioPrazo.ToString();
        dbRec.FUsuarioCiente = agendafinanceiro.UsuarioCiente;
        dbRec.FGUID = agendafinanceiro.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}