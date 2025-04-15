using MenphisSI.DB;

namespace MenphisSI.GerMDS.Readers;

public partial interface IClientesReader
{
    ClientesResponse? ReadNome(string name, SqlConnection oCnn);
}
public partial class Clientes
{
    public ClientesResponse? ReadNome(string name, SqlConnection oCnn)
    {
        var reg = ConfiguracoesDBT.GetDataTable2($"select TOP 1 cliCodigo FROM ClientesPesq WHERE xxxNome like '{name.PreparaParaSql()}%'", oCnn);
        if (reg?.Rows.Count == 0)
            return null;
        var id = reg?.Rows[0].Field<int>("cliCodigo");
        if (id <= 0) return null;
        var dbRec = new Entity.DBClientes(id ?? 0, oCnn);
        return dbRec.ID == 0 ? null : Read(dbRec);
    }
}
