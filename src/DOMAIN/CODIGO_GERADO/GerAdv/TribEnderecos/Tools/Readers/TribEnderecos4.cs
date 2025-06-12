#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITribEnderecosReader
{
    TribEnderecosResponse? Read(int id, MsiSqlConnection oCnn);
    TribEnderecosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    TribEnderecosResponse? Read(Entity.DBTribEnderecos dbRec);
    TribEnderecosResponse? Read(DBTribEnderecos dbRec);
    TribEnderecosResponseAll? ReadAll(DBTribEnderecos dbRec, DataRow dr);
}

public partial class TribEnderecos : ITribEnderecosReader
{
    public TribEnderecosResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTribEnderecos(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TribEnderecosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTribEnderecos(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TribEnderecosResponse? Read(Entity.DBTribEnderecos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tribenderecos = new TribEnderecosResponse
        {
            Id = dbRec.ID,
            Tribunal = dbRec.FTribunal,
            Cidade = dbRec.FCidade,
            Endereco = dbRec.FEndereco ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
        };
        return tribenderecos;
    }

    public TribEnderecosResponse? Read(DBTribEnderecos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tribenderecos = new TribEnderecosResponse
        {
            Id = dbRec.ID,
            Tribunal = dbRec.FTribunal,
            Cidade = dbRec.FCidade,
            Endereco = dbRec.FEndereco ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
        };
        return tribenderecos;
    }

    public TribEnderecosResponseAll? ReadAll(DBTribEnderecos dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tribenderecos = new TribEnderecosResponseAll
        {
            Id = dbRec.ID,
            Tribunal = dbRec.FTribunal,
            Cidade = dbRec.FCidade,
            Endereco = dbRec.FEndereco ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
        };
        tribenderecos.NomeTribunal = dr["triNome"]?.ToString() ?? string.Empty;
        tribenderecos.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        return tribenderecos;
    }
}