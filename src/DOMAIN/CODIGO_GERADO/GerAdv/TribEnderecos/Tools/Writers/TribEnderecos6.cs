#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITribEnderecosWriter
{
    Entity.DBTribEnderecos Write(Models.TribEnderecos tribenderecos, SqlConnection oCnn);
}

public class TribEnderecos : ITribEnderecosWriter
{
    public Entity.DBTribEnderecos Write(Models.TribEnderecos tribenderecos, SqlConnection oCnn)
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