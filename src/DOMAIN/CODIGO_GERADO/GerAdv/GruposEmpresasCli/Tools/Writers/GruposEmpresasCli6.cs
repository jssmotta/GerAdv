#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGruposEmpresasCliWriter
{
    Entity.DBGruposEmpresasCli Write(Models.GruposEmpresasCli gruposempresascli, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(GruposEmpresasCliResponse gruposempresascli, int operadorId, MsiSqlConnection oCnn);
}

public class GruposEmpresasCli : IGruposEmpresasCliWriter
{
    public void Delete(GruposEmpresasCliResponse gruposempresascli, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[GruposEmpresasCli] WHERE gecCodigo={gruposempresascli.Id};", oCnn);
    }

    public Entity.DBGruposEmpresasCli Write(Models.GruposEmpresasCli gruposempresascli, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = gruposempresascli.Id.IsEmptyIDNumber() ? new Entity.DBGruposEmpresasCli() : new Entity.DBGruposEmpresasCli(gruposempresascli.Id, oCnn);
        dbRec.FGrupo = gruposempresascli.Grupo;
        dbRec.FCliente = gruposempresascli.Cliente;
        dbRec.FOculto = gruposempresascli.Oculto;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}