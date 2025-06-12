#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IForoWriter
{
    Entity.DBForo Write(Models.Foro foro, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(ForoResponse foro, int operadorId, MsiSqlConnection oCnn);
}

public class Foro : IForoWriter
{
    public void Delete(ForoResponse foro, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[Foro] WHERE forCodigo={foro.Id};", oCnn);
    }

    public Entity.DBForo Write(Models.Foro foro, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = foro.Id.IsEmptyIDNumber() ? new Entity.DBForo() : new Entity.DBForo(foro.Id, oCnn);
        dbRec.FEMail = foro.EMail;
        dbRec.FNome = foro.Nome;
        dbRec.FUnico = foro.Unico;
        dbRec.FCidade = foro.Cidade;
        dbRec.FSite = foro.Site;
        dbRec.FEndereco = foro.Endereco;
        dbRec.FBairro = foro.Bairro;
        dbRec.FFone = foro.Fone;
        dbRec.FFax = foro.Fax;
        dbRec.FCEP = foro.CEP.ClearInputCep();
        dbRec.FOBS = foro.OBS;
        dbRec.FUnicoConfirmado = foro.UnicoConfirmado;
        dbRec.FWeb = foro.Web;
        dbRec.FEtiqueta = foro.Etiqueta;
        dbRec.FBold = foro.Bold;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}