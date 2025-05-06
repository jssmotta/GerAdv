#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IDivisaoTribunalReader
{
    DivisaoTribunalResponse? Read(int id, SqlConnection oCnn);
    DivisaoTribunalResponse? Read(string where, SqlConnection oCnn);
    DivisaoTribunalResponse? Read(Entity.DBDivisaoTribunal dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    DivisaoTribunalResponse? Read(DBDivisaoTribunal dbRec);
}

public partial class DivisaoTribunal : IDivisaoTribunalReader
{
    public DivisaoTribunalResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBDivisaoTribunal(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public DivisaoTribunalResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBDivisaoTribunal(sqlWhere: where, oCnn: oCnn);
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
            CEP = dbRec.FCEP ?? string.Empty,
            Obs = dbRec.FObs ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Andar = dbRec.FAndar ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        var auditor = new Auditor
        {
            Visto = dbRec.FVisto,
            QuemCad = dbRec.FQuemCad
        };
        if (auditor.QuemAtu > 0)
            auditor.QuemAtu = dbRec.FQuemAtu;
        if (dbRec.FDtCad.NotIsEmpty())
            auditor.DtCad = Convert.ToDateTime(dbRec.FDtCad);
        if (!(dbRec.FDtAtu is { }))
            auditor.DtAtu = Convert.ToDateTime(dbRec.FDtAtu);
        divisaotribunal.Auditor = auditor;
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
            CEP = dbRec.FCEP ?? string.Empty,
            Obs = dbRec.FObs ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Andar = dbRec.FAndar ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        var auditor = new Auditor
        {
            Visto = dbRec.FVisto,
            QuemCad = dbRec.FQuemCad
        };
        if (auditor.QuemAtu > 0)
            auditor.QuemAtu = dbRec.FQuemAtu;
        if (dbRec.FDtCad.NotIsEmpty())
            auditor.DtCad = Convert.ToDateTime(dbRec.FDtCad);
        if (!(dbRec.FDtAtu is { }))
            auditor.DtAtu = Convert.ToDateTime(dbRec.FDtAtu);
        divisaotribunal.Auditor = auditor;
        return divisaotribunal;
    }
}