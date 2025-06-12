#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IDivisaoTribunalReader
{
    DivisaoTribunalResponse? Read(int id, MsiSqlConnection oCnn);
    DivisaoTribunalResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    DivisaoTribunalResponse? Read(Entity.DBDivisaoTribunal dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    DivisaoTribunalResponse? Read(DBDivisaoTribunal dbRec);
    DivisaoTribunalResponseAll? ReadAll(DBDivisaoTribunal dbRec, DataRow dr);
}

public partial class DivisaoTribunal : IDivisaoTribunalReader
{
    public DivisaoTribunalResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBDivisaoTribunal(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public DivisaoTribunalResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBDivisaoTribunal(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public DivisaoTribunalResponse? Read(Entity.DBDivisaoTribunal dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var divisaotribunal = new DivisaoTribunalResponse
        {
            Id = dbRec.ID,
            NumCodigo = dbRec.FNumCodigo,
            Justica = dbRec.FJustica,
            NomeEspecial = dbRec.FNomeEspecial ?? string.Empty,
            Area = dbRec.FArea,
            Cidade = dbRec.FCidade,
            Foro = dbRec.FForo,
            Tribunal = dbRec.FTribunal,
            CodigoDiv = dbRec.FCodigoDiv ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Obs = dbRec.FObs ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Andar = dbRec.FAndar ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return divisaotribunal;
    }

    public DivisaoTribunalResponse? Read(DBDivisaoTribunal dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var divisaotribunal = new DivisaoTribunalResponse
        {
            Id = dbRec.ID,
            NumCodigo = dbRec.FNumCodigo,
            Justica = dbRec.FJustica,
            NomeEspecial = dbRec.FNomeEspecial ?? string.Empty,
            Area = dbRec.FArea,
            Cidade = dbRec.FCidade,
            Foro = dbRec.FForo,
            Tribunal = dbRec.FTribunal,
            CodigoDiv = dbRec.FCodigoDiv ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Obs = dbRec.FObs ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Andar = dbRec.FAndar ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return divisaotribunal;
    }

    public DivisaoTribunalResponseAll? ReadAll(DBDivisaoTribunal dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var divisaotribunal = new DivisaoTribunalResponseAll
        {
            Id = dbRec.ID,
            NumCodigo = dbRec.FNumCodigo,
            Justica = dbRec.FJustica,
            NomeEspecial = dbRec.FNomeEspecial ?? string.Empty,
            Area = dbRec.FArea,
            Cidade = dbRec.FCidade,
            Foro = dbRec.FForo,
            Tribunal = dbRec.FTribunal,
            CodigoDiv = dbRec.FCodigoDiv ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Obs = dbRec.FObs ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Andar = dbRec.FAndar ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        divisaotribunal.NomeJustica = dr["jusNome"]?.ToString() ?? string.Empty;
        divisaotribunal.DescricaoArea = dr["areDescricao"]?.ToString() ?? string.Empty;
        divisaotribunal.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        divisaotribunal.NomeForo = dr["forNome"]?.ToString() ?? string.Empty;
        divisaotribunal.NomeTribunal = dr["triNome"]?.ToString() ?? string.Empty;
        return divisaotribunal;
    }
}