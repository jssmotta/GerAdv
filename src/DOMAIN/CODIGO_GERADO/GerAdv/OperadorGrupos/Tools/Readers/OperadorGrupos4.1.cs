#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class OperadorGrupos
{
    public async Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn)
    {
        string query = $@"
SELECT TOP (1) 
    FORMAT(opgDtAtu, 'yyyy-MM-dd-HH-mm-ss')
FROM {oCnn.UseDbo}.OperadorGrupos WITH (NOLOCK, INDEX = idx_OperadorGrupos_AuditorDtAtu)
WHERE opgCodigo = @id
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
            WHEN opgDtAtu IS NULL THEN opgDtCad 
            WHEN opgDtAtu > opgDtCad THEN opgDtAtu 
            ELSE opgDtCad 
        END, 'yyyy-MM-dd-HH-mm-ss') AS data
FROM {oCnn.UseDbo}.OperadorGrupos WITH (NOLOCK)
        {(cWhere.Equals("") ? "" : $" WHERE {cWhere}")}
ORDER BY 
    CASE 
        WHEN opgDtAtu IS NULL THEN opgDtCad 
        WHEN opgDtAtu > opgDtCad THEN opgDtAtu 
        ELSE opgDtCad 
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