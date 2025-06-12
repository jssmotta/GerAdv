#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class PenhoraStatus
{
    public async Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn)
    {
        string query = $@"
SELECT TOP (1) 
    FORMAT(phsDtAtu, 'yyyy-MM-dd-HH-mm-ss')
FROM {oCnn.UseDbo}.PenhoraStatus WITH (NOLOCK, INDEX = idx_PenhoraStatus_AuditorDtAtu)
WHERE phsCodigo = @id
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
            WHEN phsDtAtu IS NULL THEN phsDtCad 
            WHEN phsDtAtu > phsDtCad THEN phsDtAtu 
            ELSE phsDtCad 
        END, 'yyyy-MM-dd-HH-mm-ss') AS data
FROM {oCnn.UseDbo}.PenhoraStatus WITH (NOLOCK)
        {(cWhere.Equals("") ? "" : $" WHERE {cWhere}")}
ORDER BY 
    CASE 
        WHEN phsDtAtu IS NULL THEN phsDtCad 
        WHEN phsDtAtu > phsDtCad THEN phsDtAtu 
        ELSE phsDtCad 
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