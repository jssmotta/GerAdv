#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IHorasTrabWriter
{
    Entity.DBHorasTrab Write(Models.HorasTrab horastrab, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(HorasTrabResponse horastrab, int operadorId, MsiSqlConnection oCnn);
}

public class HorasTrab : IHorasTrabWriter
{
    public void Delete(HorasTrabResponse horastrab, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[HorasTrab] WHERE htbCodigo={horastrab.Id};", oCnn);
    }

    public Entity.DBHorasTrab Write(Models.HorasTrab horastrab, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = horastrab.Id.IsEmptyIDNumber() ? new Entity.DBHorasTrab() : new Entity.DBHorasTrab(horastrab.Id, oCnn);
        dbRec.FIDContatoCRM = horastrab.IDContatoCRM;
        dbRec.FHonorario = horastrab.Honorario;
        dbRec.FIDAgenda = horastrab.IDAgenda;
        if (horastrab.Data != null)
            dbRec.FData = horastrab.Data.ToString();
        dbRec.FCliente = horastrab.Cliente;
        dbRec.FStatus = horastrab.Status;
        dbRec.FProcesso = horastrab.Processo;
        dbRec.FAdvogado = horastrab.Advogado;
        dbRec.FFuncionario = horastrab.Funcionario;
        dbRec.FHrIni = horastrab.HrIni;
        dbRec.FHrFim = horastrab.HrFim;
        dbRec.FTempo = horastrab.Tempo;
        dbRec.FValor = horastrab.Valor;
        dbRec.FOBS = horastrab.OBS;
        dbRec.FAnexo = horastrab.Anexo;
        dbRec.FAnexoComp = horastrab.AnexoComp;
        dbRec.FAnexoUNC = horastrab.AnexoUNC;
        dbRec.FServico = horastrab.Servico;
        dbRec.FGUID = horastrab.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}