#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IEnderecosReader
{
    EnderecosResponse? Read(int id, SqlConnection oCnn);
    EnderecosResponse? Read(string where, SqlConnection oCnn);
    EnderecosResponse? Read(Entity.DBEnderecos dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    EnderecosResponse? Read(DBEnderecos dbRec);
}

public partial class Enderecos : IEnderecosReader
{
    public EnderecosResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBEnderecos(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public EnderecosResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBEnderecos(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public EnderecosResponse? Read(Entity.DBEnderecos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var enderecos = new EnderecosResponse
        {
            Id = dbRec.ID,
            TopIndex = dbRec.FTopIndex,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Contato = dbRec.FContato ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Privativo = dbRec.FPrivativo,
            AddContato = dbRec.FAddContato,
            CEP = dbRec.FCEP ?? string.Empty,
            OAB = dbRec.FOAB ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Tratamento = dbRec.FTratamento ?? string.Empty,
            Cidade = dbRec.FCidade,
            Site = dbRec.FSite ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Quem = dbRec.FQuem,
            QuemIndicou = dbRec.FQuemIndicou ?? string.Empty,
            ReportECBOnly = dbRec.FReportECBOnly,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
            Guid = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            enderecos.DtNasc = dbRec.FDtNasc;
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
        enderecos.Auditor = auditor;
        return enderecos;
    }

    public EnderecosResponse? Read(DBEnderecos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var enderecos = new EnderecosResponse
        {
            Id = dbRec.ID,
            TopIndex = dbRec.FTopIndex,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Contato = dbRec.FContato ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Privativo = dbRec.FPrivativo,
            AddContato = dbRec.FAddContato,
            CEP = dbRec.FCEP ?? string.Empty,
            OAB = dbRec.FOAB ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Tratamento = dbRec.FTratamento ?? string.Empty,
            Cidade = dbRec.FCidade,
            Site = dbRec.FSite ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Quem = dbRec.FQuem,
            QuemIndicou = dbRec.FQuemIndicou ?? string.Empty,
            ReportECBOnly = dbRec.FReportECBOnly,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
            Guid = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            enderecos.DtNasc = dbRec.FDtNasc;
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
        enderecos.Auditor = auditor;
        return enderecos;
    }
}