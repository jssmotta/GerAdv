#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgendaRepetirWriter
{
    Entity.DBAgendaRepetir Write(Models.AgendaRepetir agendarepetir, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(AgendaRepetirResponse agendarepetir, int operadorId, MsiSqlConnection oCnn);
}

public class AgendaRepetir : IAgendaRepetirWriter
{
    public void Delete(AgendaRepetirResponse agendarepetir, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[AgendaRepetir] WHERE rptCodigo={agendarepetir.Id};", oCnn);
    }

    public Entity.DBAgendaRepetir Write(Models.AgendaRepetir agendarepetir, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = agendarepetir.Id.IsEmptyIDNumber() ? new Entity.DBAgendaRepetir() : new Entity.DBAgendaRepetir(agendarepetir.Id, oCnn);
        dbRec.FAdvogado = agendarepetir.Advogado;
        dbRec.FCliente = agendarepetir.Cliente;
        if (agendarepetir.DataFinal != null)
            dbRec.FDataFinal = agendarepetir.DataFinal.ToString();
        dbRec.FFuncionario = agendarepetir.Funcionario;
        if (agendarepetir.HoraFinal != null)
            dbRec.FHoraFinal = agendarepetir.HoraFinal.ToString();
        dbRec.FProcesso = agendarepetir.Processo;
        dbRec.FPessoal = agendarepetir.Pessoal;
        dbRec.FFrequencia = agendarepetir.Frequencia;
        dbRec.FDia = agendarepetir.Dia;
        dbRec.FMes = agendarepetir.Mes;
        if (agendarepetir.Hora != null)
            dbRec.FHora = agendarepetir.Hora.ToString();
        dbRec.FIDQuem = agendarepetir.IDQuem;
        dbRec.FIDQuem2 = agendarepetir.IDQuem2;
        dbRec.FMensagem = agendarepetir.Mensagem;
        dbRec.FIDTipo = agendarepetir.IDTipo;
        dbRec.FID1 = agendarepetir.ID1;
        dbRec.FID2 = agendarepetir.ID2;
        dbRec.FID3 = agendarepetir.ID3;
        dbRec.FID4 = agendarepetir.ID4;
        dbRec.FSegunda = agendarepetir.Segunda;
        dbRec.FQuarta = agendarepetir.Quarta;
        dbRec.FQuinta = agendarepetir.Quinta;
        dbRec.FSexta = agendarepetir.Sexta;
        dbRec.FSabado = agendarepetir.Sabado;
        dbRec.FDomingo = agendarepetir.Domingo;
        dbRec.FTerca = agendarepetir.Terca;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}