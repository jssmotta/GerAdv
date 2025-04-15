//using MenphisSI.GerMDS;

//namespace webapi;

//public static class DripDiva

//{
//    public static void Drop()
//    {

//        var oCnn = Configuracoes.GetConnectionByUriRw("MNU");

//        ConfiguracoesDBT.ExecuteSqlCreate("drop table CargosEsc", oCnn);
//        ConfiguracoesDBT.ExecuteSqlCreate("drop table CargosEscClass", oCnn);
//    }
//}
//public class Models
//{
//}

//public class Writer
//{
//    public void Write(Agenda agenda, int auditorQuem, SqlConnection oCnn)
//    { 
//        var dbRec = agenda.Id == 0 ? new DBAgenda() : new DBAgenda(agenda.Id, oCnn);

//        dbRec.FCancelou = agenda.Cancelou;

//        dbRec.AuditorQuem = auditorQuem;

//        dbRec.Update(oCnn);
//    }


//}



//public class Reader
//{
//    public Agenda Read(int id, string uri)
//    {
//        using var oCnn = Configuracoes.GetConnectionByUri(uri);

//        var dbRec = new DBAgenda(id, oCnn);
//        var agenda = new Agenda
//        {
//            Cancelou = dbRec.FCancelou
//        };

//        var auditor = new Auditor
//        {
//            Visto = dbRec.FVisto,
//            QuemCad = dbRec.FQuemCad
//        };
//        if (auditor.QuemAtu > 0)
//            auditor.QuemAtu = dbRec.FQuemAtu;
//        if (dbRec.FDtCad.NotIsEmpty())
//            auditor.DtCad = Convert.ToDateTime(dbRec.FDtCad);
//        if (dbRec.FDtAtu is not null)
//            auditor.DtAtu = Convert.ToDateTime(dbRec.FDtAtu);
//        agenda.Auditor = auditor;

//        return agenda;
//    }


//}
