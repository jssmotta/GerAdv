#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IEnderecosWriter
{
    Entity.DBEnderecos Write(Models.Enderecos enderecos, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(EnderecosResponse enderecos, int operadorId, MsiSqlConnection oCnn);
}

public class Enderecos : IEnderecosWriter
{
    public void Delete(EnderecosResponse enderecos, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[Enderecos] WHERE endCodigo={enderecos.Id};", oCnn);
    }

    public Entity.DBEnderecos Write(Models.Enderecos enderecos, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = enderecos.Id.IsEmptyIDNumber() ? new Entity.DBEnderecos() : new Entity.DBEnderecos(enderecos.Id, oCnn);
        dbRec.FTopIndex = enderecos.TopIndex;
        dbRec.FDescricao = enderecos.Descricao;
        dbRec.FContato = enderecos.Contato;
        if (enderecos.DtNasc != null)
            dbRec.FDtNasc = enderecos.DtNasc.ToString();
        dbRec.FEndereco = enderecos.Endereco;
        dbRec.FBairro = enderecos.Bairro;
        dbRec.FPrivativo = enderecos.Privativo;
        dbRec.FAddContato = enderecos.AddContato;
        dbRec.FCEP = enderecos.CEP.ClearInputCep();
        dbRec.FOAB = enderecos.OAB;
        dbRec.FOBS = enderecos.OBS;
        dbRec.FFone = enderecos.Fone;
        dbRec.FFax = enderecos.Fax;
        dbRec.FTratamento = enderecos.Tratamento;
        dbRec.FCidade = enderecos.Cidade;
        dbRec.FSite = enderecos.Site;
        dbRec.FEMail = enderecos.EMail;
        dbRec.FQuem = enderecos.Quem;
        dbRec.FQuemIndicou = enderecos.QuemIndicou;
        dbRec.FReportECBOnly = enderecos.ReportECBOnly;
        dbRec.FEtiqueta = enderecos.Etiqueta;
        dbRec.FAni = enderecos.Ani;
        dbRec.FBold = enderecos.Bold;
        dbRec.FGUID = enderecos.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}