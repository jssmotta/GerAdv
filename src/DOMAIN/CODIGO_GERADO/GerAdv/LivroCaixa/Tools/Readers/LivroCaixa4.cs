#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ILivroCaixaReader
{
    LivroCaixaResponse? Read(int id, MsiSqlConnection oCnn);
    LivroCaixaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    LivroCaixaResponse? Read(Entity.DBLivroCaixa dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    LivroCaixaResponse? Read(DBLivroCaixa dbRec);
    LivroCaixaResponseAll? ReadAll(DBLivroCaixa dbRec, DataRow dr);
}

public partial class LivroCaixa : ILivroCaixaReader
{
    public LivroCaixaResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBLivroCaixa(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public LivroCaixaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBLivroCaixa(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public LivroCaixaResponse? Read(Entity.DBLivroCaixa dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var livrocaixa = new LivroCaixaResponse
        {
            Id = dbRec.ID,
            IDDes = dbRec.FIDDes,
            Pessoal = dbRec.FPessoal,
            Ajuste = dbRec.FAjuste,
            IDHon = dbRec.FIDHon,
            IDHonParc = dbRec.FIDHonParc,
            IDHonSuc = dbRec.FIDHonSuc,
            Processo = dbRec.FProcesso,
            Valor = dbRec.FValor,
            Tipo = dbRec.FTipo,
            Historico = dbRec.FHistorico ?? string.Empty,
            Grupo = dbRec.FGrupo,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            livrocaixa.Data = dbRec.FData;
        return livrocaixa;
    }

    public LivroCaixaResponse? Read(DBLivroCaixa dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var livrocaixa = new LivroCaixaResponse
        {
            Id = dbRec.ID,
            IDDes = dbRec.FIDDes,
            Pessoal = dbRec.FPessoal,
            Ajuste = dbRec.FAjuste,
            IDHon = dbRec.FIDHon,
            IDHonParc = dbRec.FIDHonParc,
            IDHonSuc = dbRec.FIDHonSuc,
            Processo = dbRec.FProcesso,
            Valor = dbRec.FValor,
            Tipo = dbRec.FTipo,
            Historico = dbRec.FHistorico ?? string.Empty,
            Grupo = dbRec.FGrupo,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            livrocaixa.Data = dbRec.FData;
        return livrocaixa;
    }

    public LivroCaixaResponseAll? ReadAll(DBLivroCaixa dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var livrocaixa = new LivroCaixaResponseAll
        {
            Id = dbRec.ID,
            IDDes = dbRec.FIDDes,
            Pessoal = dbRec.FPessoal,
            Ajuste = dbRec.FAjuste,
            IDHon = dbRec.FIDHon,
            IDHonParc = dbRec.FIDHonParc,
            IDHonSuc = dbRec.FIDHonSuc,
            Processo = dbRec.FProcesso,
            Valor = dbRec.FValor,
            Tipo = dbRec.FTipo,
            Historico = dbRec.FHistorico ?? string.Empty,
            Grupo = dbRec.FGrupo,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            livrocaixa.Data = dbRec.FData;
        livrocaixa.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return livrocaixa;
    }
}