#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGruposEmpresasWriter
{
    Entity.DBGruposEmpresas Write(Models.GruposEmpresas gruposempresas, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(GruposEmpresasResponse gruposempresas, int operadorId, MsiSqlConnection oCnn);
}

public class GruposEmpresas : IGruposEmpresasWriter
{
    public void Delete(GruposEmpresasResponse gruposempresas, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[GruposEmpresas] WHERE grpCodigo={gruposempresas.Id};", oCnn);
    }

    public Entity.DBGruposEmpresas Write(Models.GruposEmpresas gruposempresas, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = gruposempresas.Id.IsEmptyIDNumber() ? new Entity.DBGruposEmpresas() : new Entity.DBGruposEmpresas(gruposempresas.Id, oCnn);
        dbRec.FEMail = gruposempresas.EMail;
        dbRec.FInativo = gruposempresas.Inativo;
        dbRec.FOponente = gruposempresas.Oponente;
        dbRec.FDescricao = gruposempresas.Descricao;
        dbRec.FObservacoes = gruposempresas.Observacoes;
        dbRec.FCliente = gruposempresas.Cliente;
        dbRec.FIcone = gruposempresas.Icone;
        dbRec.FDespesaUnificada = gruposempresas.DespesaUnificada;
        dbRec.FGUID = gruposempresas.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}