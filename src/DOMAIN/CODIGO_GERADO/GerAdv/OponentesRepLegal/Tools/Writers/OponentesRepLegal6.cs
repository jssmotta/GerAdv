#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOponentesRepLegalWriter
{
    Entity.DBOponentesRepLegal Write(Models.OponentesRepLegal oponentesreplegal, int auditorQuem, SqlConnection oCnn);
}

public class OponentesRepLegal : IOponentesRepLegalWriter
{
    public Entity.DBOponentesRepLegal Write(Models.OponentesRepLegal oponentesreplegal, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = oponentesreplegal.Id.IsEmptyIDNumber() ? new Entity.DBOponentesRepLegal() : new Entity.DBOponentesRepLegal(oponentesreplegal.Id, oCnn);
        dbRec.FNome = oponentesreplegal.Nome;
        dbRec.FFone = oponentesreplegal.Fone;
        dbRec.FOponente = oponentesreplegal.Oponente;
        dbRec.FSexo = oponentesreplegal.Sexo;
        dbRec.FCPF = oponentesreplegal.CPF.ClearInputCpf();
        dbRec.FRG = oponentesreplegal.RG;
        dbRec.FEndereco = oponentesreplegal.Endereco;
        dbRec.FBairro = oponentesreplegal.Bairro;
        dbRec.FCEP = oponentesreplegal.CEP.ClearInputCep();
        dbRec.FCidade = oponentesreplegal.Cidade;
        dbRec.FFax = oponentesreplegal.Fax;
        dbRec.FEMail = oponentesreplegal.EMail;
        dbRec.FSite = oponentesreplegal.Site;
        dbRec.FObservacao = oponentesreplegal.Observacao;
        dbRec.FBold = oponentesreplegal.Bold;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}