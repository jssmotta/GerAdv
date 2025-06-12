#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITribEnderecosWriter
{
    Entity.DBTribEnderecos Write(Models.TribEnderecos tribenderecos, MsiSqlConnection oCnn);
    void Delete(TribEnderecosResponse tribenderecos, int operadorId, MsiSqlConnection oCnn);
}

public class TribEnderecos : ITribEnderecosWriter
{
    public void Delete(TribEnderecosResponse tribenderecos, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[TribEnderecos] WHERE treCodigo={tribenderecos.Id};", oCnn);
    }

    public Entity.DBTribEnderecos Write(Models.TribEnderecos tribenderecos, MsiSqlConnection oCnn)
    {
        var dbRec = tribenderecos.Id.IsEmptyIDNumber() ? new Entity.DBTribEnderecos() : new Entity.DBTribEnderecos(tribenderecos.Id, oCnn);
        dbRec.FTribunal = tribenderecos.Tribunal;
        dbRec.FCidade = tribenderecos.Cidade;
        dbRec.FEndereco = tribenderecos.Endereco;
        dbRec.FCEP = tribenderecos.CEP.ClearInputCep();
        dbRec.FFone = tribenderecos.Fone;
        dbRec.FFax = tribenderecos.Fax;
        dbRec.FOBS = tribenderecos.OBS;
        dbRec.Update(oCnn);
        return dbRec;
    }
}