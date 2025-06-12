#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPosicaoOutrasPartesWriter
{
    Entity.DBPosicaoOutrasPartes Write(Models.PosicaoOutrasPartes posicaooutraspartes, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(PosicaoOutrasPartesResponse posicaooutraspartes, int operadorId, MsiSqlConnection oCnn);
}

public class PosicaoOutrasPartes : IPosicaoOutrasPartesWriter
{
    public void Delete(PosicaoOutrasPartesResponse posicaooutraspartes, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[PosicaoOutrasPartes] WHERE posCodigo={posicaooutraspartes.Id};", oCnn);
    }

    public Entity.DBPosicaoOutrasPartes Write(Models.PosicaoOutrasPartes posicaooutraspartes, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = posicaooutraspartes.Id.IsEmptyIDNumber() ? new Entity.DBPosicaoOutrasPartes() : new Entity.DBPosicaoOutrasPartes(posicaooutraspartes.Id, oCnn);
        dbRec.FDescricao = posicaooutraspartes.Descricao;
        dbRec.FBold = posicaooutraspartes.Bold;
        dbRec.FGUID = posicaooutraspartes.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}