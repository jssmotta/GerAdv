#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IForoWriter
{
    Entity.DBForo Write(Models.Foro foro, int auditorQuem, SqlConnection oCnn);
}

public class Foro : IForoWriter
{
    public Entity.DBForo Write(Models.Foro foro, int auditorQuem, SqlConnection oCnn)
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