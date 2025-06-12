#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITerceirosWriter
{
    Entity.DBTerceiros Write(Models.Terceiros terceiros, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(TerceirosResponse terceiros, int operadorId, MsiSqlConnection oCnn);
}

public class Terceiros : ITerceirosWriter
{
    public void Delete(TerceirosResponse terceiros, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[Terceiros] WHERE terCodigo={terceiros.Id};", oCnn);
    }

    public Entity.DBTerceiros Write(Models.Terceiros terceiros, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = terceiros.Id.IsEmptyIDNumber() ? new Entity.DBTerceiros() : new Entity.DBTerceiros(terceiros.Id, oCnn);
        dbRec.FProcesso = terceiros.Processo;
        dbRec.FNome = terceiros.Nome;
        dbRec.FSituacao = terceiros.Situacao;
        dbRec.FCidade = terceiros.Cidade;
        dbRec.FEndereco = terceiros.Endereco;
        dbRec.FBairro = terceiros.Bairro;
        dbRec.FCEP = terceiros.CEP.ClearInputCep();
        dbRec.FFone = terceiros.Fone;
        dbRec.FFax = terceiros.Fax;
        dbRec.FOBS = terceiros.OBS;
        dbRec.FEMail = terceiros.EMail;
        dbRec.FClass = terceiros.Class;
        dbRec.FVaraForoComarca = terceiros.VaraForoComarca;
        dbRec.FSexo = terceiros.Sexo;
        dbRec.FBold = terceiros.Bold;
        dbRec.FGUID = terceiros.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}