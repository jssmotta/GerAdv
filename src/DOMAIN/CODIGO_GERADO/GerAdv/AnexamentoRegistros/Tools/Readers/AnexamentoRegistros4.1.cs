#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class AnexamentoRegistros
{
    public async Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn)
    {
        string query = $@"
SELECT TOP (1) 
    FORMAT(axrDtAtu, 'yyyy-MM-dd-HH-mm-ss')
FROM {oCnn.UseDbo}.AnexamentoRegistros WITH (NOLOCK, INDEX = idx_AnexamentoRegistros_AuditorDtAtu)
WHERE axrCodigo = @id
OPTION (OPTIMIZE FOR (@id UNKNOWN), FAST 1);";
        using var cmd = new SqlCommand(query, oCnn.InnerConnection);
        cmd.Parameters.AddWithValue("@id", id);
        var dataFormatada = $"{await cmd.ExecuteScalarAsync()}";
        return dataFormatada;
    }

    public async Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        string query = $@"
SELECT TOP (1) 
    FORMAT(
        CASE 
            WHEN axrDtAtu IS NULL THEN axrDtCad 
            WHEN axrDtAtu > axrDtCad THEN axrDtAtu 
            ELSE axrDtCad 
        END, 'yyyy-MM-dd-HH-mm-ss') AS data
FROM {oCnn.UseDbo}.AnexamentoRegistros WITH (NOLOCK)
        {(cWhere.Equals("") ? "" : $" WHERE {cWhere}")}
ORDER BY 
    CASE 
        WHEN axrDtAtu IS NULL THEN axrDtCad 
        WHEN axrDtAtu > axrDtCad THEN axrDtAtu 
        ELSE axrDtCad 
    END DESC;";
        using var cmd = new SqlCommand(query, oCnn.InnerConnection);
        foreach (var param in parameters)
        {
            if (!cmd.Parameters.Contains(param.ParameterName))
            {
                var newParam = new SqlParameter(param.ParameterName, param.Value)
                {
                    SqlDbType = param.SqlDbType,
                    Direction = param.Direction,
                    Size = param.Size,
                    Precision = param.Precision,
                    Scale = param.Scale
                };
                cmd.Parameters.Add(newParam);
            }
        }

        var dataFormatada = $"{await cmd.ExecuteScalarAsync()}";
        return dataFormatada;
    }
}