#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IReuniaoWriter
{
    Entity.DBReuniao Write(Models.Reuniao reuniao, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(ReuniaoResponse reuniao, int operadorId, MsiSqlConnection oCnn);
}

public class Reuniao : IReuniaoWriter
{
    public void Delete(ReuniaoResponse reuniao, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[Reuniao] WHERE renCodigo={reuniao.Id};", oCnn);
    }

    public Entity.DBReuniao Write(Models.Reuniao reuniao, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = reuniao.Id.IsEmptyIDNumber() ? new Entity.DBReuniao() : new Entity.DBReuniao(reuniao.Id, oCnn);
        dbRec.FCliente = reuniao.Cliente;
        dbRec.FIDAgenda = reuniao.IDAgenda;
        if (reuniao.Data != null)
            dbRec.FData = reuniao.Data.ToString();
        dbRec.FPauta = reuniao.Pauta;
        dbRec.FATA = reuniao.ATA;
        if (reuniao.HoraInicial != null)
            dbRec.FHoraInicial = reuniao.HoraInicial.ToString();
        if (reuniao.HoraFinal != null)
            dbRec.FHoraFinal = reuniao.HoraFinal.ToString();
        dbRec.FExterna = reuniao.Externa;
        if (reuniao.HoraSaida != null)
            dbRec.FHoraSaida = reuniao.HoraSaida.ToString();
        if (reuniao.HoraRetorno != null)
            dbRec.FHoraRetorno = reuniao.HoraRetorno.ToString();
        dbRec.FPrincipaisDecisoes = reuniao.PrincipaisDecisoes;
        dbRec.FBold = reuniao.Bold;
        dbRec.FGUID = reuniao.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}