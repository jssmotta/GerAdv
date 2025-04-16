#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IDivisaoTribunalWriter
{
    Entity.DBDivisaoTribunal Write(Models.DivisaoTribunal divisaotribunal, int auditorQuem, SqlConnection oCnn);
}

public class DivisaoTribunal : IDivisaoTribunalWriter
{
    public Entity.DBDivisaoTribunal Write(Models.DivisaoTribunal divisaotribunal, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = divisaotribunal.Id.IsEmptyIDNumber() ? new Entity.DBDivisaoTribunal() : new Entity.DBDivisaoTribunal(divisaotribunal.Id, oCnn);
        dbRec.FNumCodigo = divisaotribunal.NumCodigo;
        dbRec.FJustica = divisaotribunal.Justica;
        dbRec.FNomeEspecial = divisaotribunal.NomeEspecial;
        dbRec.FArea = divisaotribunal.Area;
        dbRec.FCidade = divisaotribunal.Cidade;
        dbRec.FForo = divisaotribunal.Foro;
        dbRec.FTribunal = divisaotribunal.Tribunal;
        dbRec.FCodigoDiv = divisaotribunal.CodigoDiv;
        dbRec.FEndereco = divisaotribunal.Endereco;
        dbRec.FFone = divisaotribunal.Fone;
        dbRec.FFax = divisaotribunal.Fax;
        dbRec.FCEP = divisaotribunal.CEP.ClearInputCep();
        dbRec.FObs = divisaotribunal.Obs;
        dbRec.FEMail = divisaotribunal.EMail;
        dbRec.FAndar = divisaotribunal.Andar;
        dbRec.FEtiqueta = divisaotribunal.Etiqueta;
        dbRec.FBold = divisaotribunal.Bold;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}