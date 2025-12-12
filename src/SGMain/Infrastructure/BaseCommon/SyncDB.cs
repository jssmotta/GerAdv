using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseSync;

public class SqlServerStructureSync
{
    private readonly string _connectionStringOrigem;
    private readonly string _connectionStringDestino;

    // Buffer de log em memória
    private readonly List<string> _log = new();
    private DateTime _startTime;

    public SqlServerStructureSync(string connectionStringOrigem, string connectionStringDestino)
    {
        _connectionStringOrigem = connectionStringOrigem;
        _connectionStringDestino = connectionStringDestino;
    }

    private void Log(string message)
    {
        var line = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] {message}";
        Console.WriteLine(line);
        _log.Add(line);
    }

    private async Task PersistLogAsync()
    {
        try
        {
            var end = DateTime.Now;
            _log.Insert(0, $"=== SyncDB START {_startTime:O} Machine={Environment.MachineName} User={Environment.UserName} PID={Environment.ProcessId} ===");
            _log.Add($"=== SyncDB END   {end:O} Duration={(end - _startTime)} TotalLines={_log.Count} ===");
            var path = Path.Combine(AppContext.BaseDirectory, "SyncDBLog.txt");
            await File.WriteAllLinesAsync(path, _log);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[LOG-ERROR] Falha ao gravar SyncDBLog.txt: {ex.Message}");
        }
    }

    /// <summary>
    /// Executa a sincronização completa da estrutura (remoção de colunas e tabelas extras)
    /// </summary>
    public async Task SyncStructureAsync()
    {
        _startTime = DateTime.Now;
        try
        {
            Log("Iniciando sincronização da estrutura do banco de dados...");
            Log("[CONFIG] Origem: " + _connectionStringOrigem);
            Log("[CONFIG] Destino: " + _connectionStringDestino);

            Log("[FASE] Remoção de colunas extras");
            await RemoveExtraColumnsAsync();

            Log("[FASE] Remoção de tabelas extras");
            await RemoveExtraTablesAsync();

            Log("Sincronização concluída com sucesso");
        }
        catch (Exception ex)
        {
            Log($"[ERRO] {ex.Message}");
            if (ex.StackTrace is not null) Log(ex.StackTrace);
            throw;
        }
        finally
        {
            await PersistLogAsync();
        }
    }

    /// <summary>
    /// Remove colunas do destino que não existem na origem
    /// </summary>
    private async Task RemoveExtraColumnsAsync()
    {
        using var connOrigem = new SqlConnection(_connectionStringOrigem);
        using var connDestino = new SqlConnection(_connectionStringDestino);

        await connOrigem.OpenAsync();
        await connDestino.OpenAsync();

        var tabelasOrigem = await GetTablesAsync(connOrigem);
        var tabelasDestino = await GetTablesAsync(connDestino);

        var tabelasComuns = tabelasOrigem.Intersect(tabelasDestino, StringComparer.OrdinalIgnoreCase).ToList();
        Log($"Tabelas em comum: {tabelasComuns.Count}");

        foreach (var tabela in tabelasComuns)
        {
            Log($"[TABELA] Verificando colunas extras: {tabela}");
            var colunasOrigem = await GetColumnsAsync(connOrigem, tabela);
            var colunasDestino = await GetColumnsAsync(connDestino, tabela);

            var colunasExtras = colunasDestino.Except(colunasOrigem, StringComparer.OrdinalIgnoreCase).ToList();
            if (colunasExtras.Count == 0)
            {
                Log("  Nenhuma coluna extra");
                continue;
            }
            Log($"  Colunas extras encontradas ({colunasExtras.Count}): {string.Join(',', colunasExtras)}");

            foreach (var coluna in colunasExtras)
            {
                await DropColumnAsync(connDestino, tabela, coluna);
                Log($"  Coluna removida: {tabela}.{coluna}");
            }
        }
    }

    /// <summary>
    /// Remove tabelas do destino que não existem na origem
    /// </summary>
    private async Task RemoveExtraTablesAsync()
    {
        using var connOrigem = new SqlConnection(_connectionStringOrigem);
        using var connDestino = new SqlConnection(_connectionStringDestino);

        await connOrigem.OpenAsync();
        await connDestino.OpenAsync();

        var tabelasOrigem = await GetTablesAsync(connOrigem);
        var tabelasDestino = await GetTablesAsync(connDestino);

        var tabelasExtras = tabelasDestino.Except(tabelasOrigem, StringComparer.OrdinalIgnoreCase).ToList();
        if (tabelasExtras.Count == 0)
        {
            Log("Nenhuma tabela extra no destino");
            return;
        }
        Log($"Tabelas extras (count={tabelasExtras.Count}): {string.Join(',', tabelasExtras)}");

        foreach (var tabela in tabelasExtras)
        {
            await DropTableAsync(connDestino, tabela);
            Log($"Tabela removida: {tabela}");
        }
    }

    /// <summary>
    /// Obtém lista de tabelas do banco de dados
    /// </summary>
    private async Task<HashSet<string>> GetTablesAsync(SqlConnection connection)
    {
        var tables = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        string query = @"
                SELECT 
                    SCHEMA_NAME(schema_id) + '.' + name AS TableName
                FROM 
                    sys.tables
                WHERE 
                    type = 'U'
                ORDER BY 
                    TableName";

        using var cmd = new SqlCommand(query, connection);
        using var reader = await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            tables.Add(reader.GetString(0));
        }

        return tables;
    }

    /// <summary>
    /// Obtém lista de colunas de uma tabela
    /// </summary>
    private async Task<HashSet<string>> GetColumnsAsync(SqlConnection connection, string tableName)
    {
        var columns = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        var parts = tableName.Split('.');
        string schema = parts.Length > 1 ? parts[0] : "dbo";
        string table = parts.Length > 1 ? parts[1] : parts[0];

        string query = @"
                SELECT 
                    COLUMN_NAME
                FROM 
                    INFORMATION_SCHEMA.COLUMNS
                WHERE 
                    TABLE_SCHEMA = @Schema
                    AND TABLE_NAME = @Table
                ORDER BY 
                    ORDINAL_POSITION";

        using var cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@Schema", schema);
        cmd.Parameters.AddWithValue("@Table", table);

        using var reader = await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            columns.Add(reader.GetString(0));
        }

        return columns;
    }

    /// <summary>
    /// Remove uma coluna de uma tabela
    /// </summary>
    private async Task DropColumnAsync(SqlConnection connection, string tableName, string columnName)
    {
        try
        {
            Log($"    Iniciando remoção da coluna {tableName}.{columnName}");
            await DropColumnConstraintsAsync(connection, tableName, columnName);
            string dropQuery = $"ALTER TABLE {tableName} DROP COLUMN [{columnName}]";
            using var cmd = new SqlCommand(dropQuery, connection);
            await cmd.ExecuteNonQueryAsync();
            Log($"    Coluna {tableName}.{columnName} removida");
        }
        catch (Exception ex)
        {
            Log($"    ERRO ao remover coluna {tableName}.{columnName}: {ex.Message}");
            throw;
        }
    }

    /// <summary>
    /// Remove constraints de uma coluna antes de excluí-la (cobre FK referenciada, CHECK, índices não constraint)
    /// </summary>
    private async Task DropColumnConstraintsAsync(SqlConnection connection, string tableName, string columnName)
    {
        var parts = tableName.Split('.');
        string schema = parts.Length > 1 ? parts[0] : "dbo";
        string table = parts.Length > 1 ? parts[1] : parts[0];

        Log($"    Buscando constraints/índices envolvendo {tableName}.{columnName}");

        // Reúne: defaults, key constraints, FK (referencing), FK (referenced), check constraints
        string constraintQuery = @"
            -- Default constraints
            SELECT dc.name AS ConstraintName, dc.type_desc AS ConstraintType
            FROM sys.default_constraints dc
            INNER JOIN sys.columns c ON dc.parent_object_id = c.object_id AND dc.parent_column_id = c.column_id
            INNER JOIN sys.tables t ON c.object_id = t.object_id
            INNER JOIN sys.schemas s ON t.schema_id = s.schema_id
            WHERE s.name = @Schema AND t.name = @Table AND c.name = @Column

            UNION

            -- Key constraints (PK / UNIQUE)
            SELECT kc.name AS ConstraintName, kc.type_desc AS ConstraintType
            FROM sys.key_constraints kc
            INNER JOIN sys.index_columns ic ON kc.parent_object_id = ic.object_id AND kc.unique_index_id = ic.index_id
            INNER JOIN sys.columns c ON ic.object_id = c.object_id AND ic.column_id = c.column_id
            INNER JOIN sys.tables t ON c.object_id = t.object_id
            INNER JOIN sys.schemas s ON t.schema_id = s.schema_id
            WHERE s.name = @Schema AND t.name = @Table AND c.name = @Column

            UNION

            -- Foreign keys (referencing/child)
            SELECT fk.name AS ConstraintName, fk.type_desc AS ConstraintType
            FROM sys.foreign_keys fk
            INNER JOIN sys.foreign_key_columns fkc ON fk.object_id = fkc.constraint_object_id
            INNER JOIN sys.columns c ON fkc.parent_object_id = c.object_id AND fkc.parent_column_id = c.column_id
            INNER JOIN sys.tables t ON c.object_id = t.object_id
            INNER JOIN sys.schemas s ON t.schema_id = s.schema_id
            WHERE s.name = @Schema AND t.name = @Table AND c.name = @Column

            UNION

            -- Foreign keys (referenced/parent)
            SELECT fk.name AS ConstraintName, fk.type_desc AS ConstraintType
            FROM sys.foreign_keys fk
            INNER JOIN sys.foreign_key_columns fkc ON fk.object_id = fkc.constraint_object_id
            INNER JOIN sys.columns c ON fkc.referenced_object_id = c.object_id AND fkc.referenced_column_id = c.column_id
            INNER JOIN sys.tables t ON c.object_id = t.object_id
            INNER JOIN sys.schemas s ON t.schema_id = s.schema_id
            WHERE s.name = @Schema AND t.name = @Table AND c.name = @Column

            UNION

            -- Check constraints contendo a coluna (heurística)
            SELECT cc.name AS ConstraintName, 'CHECK_CONSTRAINT' AS ConstraintType
            FROM sys.check_constraints cc
            INNER JOIN sys.tables t ON cc.parent_object_id = t.object_id
            INNER JOIN sys.schemas s ON t.schema_id = s.schema_id
            WHERE s.name = @Schema AND t.name = @Table AND cc.definition LIKE '%[' + @Column + ']%'";

        var constraints = new List<(string Name, string Type)>();
        using (var cmd = new SqlCommand(constraintQuery, connection))
        {
            cmd.Parameters.AddWithValue("@Schema", schema);
            cmd.Parameters.AddWithValue("@Table", table);
            cmd.Parameters.AddWithValue("@Column", columnName);
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                constraints.Add((reader.GetString(0), reader.GetString(1)));
            }
        }

        const string indexQuery = @"
            SELECT DISTINCT i.name
            FROM sys.indexes i
            INNER JOIN sys.index_columns ic ON i.object_id = ic.object_id AND i.index_id = ic.index_id
            INNER JOIN sys.columns c ON ic.object_id = c.object_id AND ic.column_id = c.column_id
            INNER JOIN sys.tables t ON c.object_id = t.object_id
            INNER JOIN sys.schemas s ON t.schema_id = s.schema_id
            WHERE s.name = @Schema AND t.name = @Table AND c.name = @Column
              AND i.is_primary_key = 0
              AND i.is_unique_constraint = 0
              AND i.name IS NOT NULL";

        var indexes = new List<string>();
        using (var idxCmd = new SqlCommand(indexQuery, connection))
        {
            idxCmd.Parameters.AddWithValue("@Schema", schema);
            idxCmd.Parameters.AddWithValue("@Table", table);
            idxCmd.Parameters.AddWithValue("@Column", columnName);
            using var idxReader = await idxCmd.ExecuteReaderAsync();
            while (await idxReader.ReadAsync())
            {
                indexes.Add(idxReader.GetString(0));
            }
        }

        Log($"    Constraints encontradas: {constraints.Count}; Índices: {indexes.Count}");

        var keyConstraintTypes = new[] { "PRIMARY_KEY_CONSTRAINT", "UNIQUE_CONSTRAINT" };
        var keyConstraints = constraints.Where(c => keyConstraintTypes.Contains(c.Type, StringComparer.OrdinalIgnoreCase)).ToList();
        var otherConstraints = constraints.Where(c => !keyConstraintTypes.Contains(c.Type, StringComparer.OrdinalIgnoreCase)).ToList();

        foreach (var cst in otherConstraints.Distinct())
        {
            string sql = $"ALTER TABLE {tableName} DROP CONSTRAINT [{cst.Name}]";
            using var drop = new SqlCommand(sql, connection);
            await drop.ExecuteNonQueryAsync();
            Log($"      Constraint removida: {cst.Name} ({cst.Type})");
        }

        foreach (var idx in indexes.Distinct())
        {
            string safeIdx = idx.Replace("]", "]]" );
            string sql = $"DROP INDEX [{safeIdx}] ON {tableName}";
            using var drop = new SqlCommand(sql, connection);
            await drop.ExecuteNonQueryAsync();
            Log($"      Índice removido: {idx}");
        }

        foreach (var cst in keyConstraints.Distinct())
        {
            string sql = $"ALTER TABLE {tableName} DROP CONSTRAINT [{cst.Name}]";
            using var drop = new SqlCommand(sql, connection);
            await drop.ExecuteNonQueryAsync();
            Log($"      Constraint (chave) removida: {cst.Name} ({cst.Type})");
        }
    }

    /// <summary>
    /// Remove uma tabela do banco de dados
    /// </summary>
    private async Task DropTableAsync(SqlConnection connection, string tableName)
    {
        try
        {
            Log($"Iniciando remoção da tabela {tableName}");
            await DropTableForeignKeysAsync(connection, tableName);
            string dropQuery = $"DROP TABLE {tableName}";
            using var cmd = new SqlCommand(dropQuery, connection);
            await cmd.ExecuteNonQueryAsync();
            Log($"Tabela removida: {tableName}");
        }
        catch (Exception ex)
        {
            Log($"Erro ao remover tabela {tableName}: {ex.Message}");
            throw;
        }
    }

    /// <summary>
    /// Remove foreign keys que referenciam uma tabela
    /// </summary>
    private async Task DropTableForeignKeysAsync(SqlConnection connection, string tableName)
    {
        var parts = tableName.Split('.');
        string schema = parts.Length > 1 ? parts[0] : "dbo";
        string table = parts.Length > 1 ? parts[1] : parts[0];

        string query = @"
                SELECT 
                    fk.name AS ForeignKeyName,
                    SCHEMA_NAME(t.schema_id) + '.' + t.name AS ReferencingTable
                FROM 
                    sys.foreign_keys fk
                    INNER JOIN sys.tables t ON fk.parent_object_id = t.object_id
                    INNER JOIN sys.tables rt ON fk.referenced_object_id = rt.object_id
                    INNER JOIN sys.schemas rs ON rt.schema_id = rs.schema_id
                WHERE 
                    rs.name = @Schema
                    AND rt.name = @Table";

        using var cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@Schema", schema);
        cmd.Parameters.AddWithValue("@Table", table);

        var foreignKeys = new List<(string Name, string ReferencingTable)>();

        using (var reader = await cmd.ExecuteReaderAsync())
        {
            while (await reader.ReadAsync())
            {
                foreignKeys.Add((reader.GetString(0), reader.GetString(1)));
            }
        }

        if (foreignKeys.Count == 0)
        {
            Log($"  Nenhuma FK referenciando {tableName}");
            return;
        }
        Log($"  FKs referenciando {tableName}: {foreignKeys.Count}");

        foreach (var fk in foreignKeys)
        {
            string dropFkQuery = $"ALTER TABLE {fk.ReferencingTable} DROP CONSTRAINT [{fk.Name}]";
            using var dropCmd = new SqlCommand(dropFkQuery, connection);
            await dropCmd.ExecuteNonQueryAsync();
            Log($"    Foreign Key removida: {fk.Name} da tabela {fk.ReferencingTable}");
        }
    }
}

/*
// Exemplo de uso
public class Program
{
    public static async Task Main(string[] args)
    {
        string connectionStringOrigem = "Server=servidor_origem;Database=banco_origem;Trusted_Connection=true;TrustServerCertificate=true;";
        string connectionStringDestino = "Server=servidor_destino;Database=banco_destino;Trusted_Connection=true;TrustServerCertificate=true;";

        var sync = new SqlServerStructureSync(connectionStringOrigem, connectionStringDestino);

        try
        {
            await sync.SyncStructureAsync();
            Console.WriteLine("Processo finalizado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}
}




async Task DBSyncAsync()
{
    //string connectionStringOrigem = "Server=localhost;Database=MDSNET_MDS;Trusted_Connection=true;TrustServerCertificate=true;";
    //string connectionStringDestino = "Server=localhost;Database=MDSDEMO;Trusted_Connection=true;TrustServerCertificate=true;";

    string connectionStringOrigem = ConfiguracoesSys.GetCachedConnectionString("MDS", true);
    string connectionStringDestino = ConfiguracoesSys.GetCachedConnectionString("MDSDEMO", false); 

    var sync = new SqlServerStructureSync(connectionStringOrigem, connectionStringDestino);

    try
    {
        await sync.SyncStructureAsync();
        Console.WriteLine("Processo finalizado com sucesso!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro: {ex.Message}");
    }
}
*/