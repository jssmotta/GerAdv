#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOponentesWriter
{
    Entity.DBOponentes Write(Models.Oponentes oponentes, int auditorQuem, SqlConnection oCnn);
}

public class Oponentes : IOponentesWriter
{
    public Entity.DBOponentes Write(Models.Oponentes oponentes, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = oponentes.Id.IsEmptyIDNumber() ? new Entity.DBOponentes() : new Entity.DBOponentes(oponentes.Id, oCnn);
        dbRec.FEMPFuncao = oponentes.EMPFuncao;
        dbRec.FCTPSNumero = oponentes.CTPSNumero;
        dbRec.FSite = oponentes.Site;
        dbRec.FCTPSSerie = oponentes.CTPSSerie;
        dbRec.FNome = oponentes.Nome;
        dbRec.FAdv = oponentes.Adv;
        dbRec.FEMPCliente = oponentes.EMPCliente;
        dbRec.FIDRep = oponentes.IDRep;
        dbRec.FPIS = oponentes.PIS;
        dbRec.FContato = oponentes.Contato;
        dbRec.FCNPJ = oponentes.CNPJ.ClearInputCnpj();
        dbRec.FRG = oponentes.RG;
        dbRec.FJuridica = oponentes.Juridica;
        dbRec.FTipo = oponentes.Tipo;
        dbRec.FSexo = oponentes.Sexo;
        dbRec.FCPF = oponentes.CPF.ClearInputCpf();
        dbRec.FEndereco = oponentes.Endereco;
        dbRec.FFone = oponentes.Fone;
        dbRec.FFax = oponentes.Fax;
        dbRec.FCidade = oponentes.Cidade;
        dbRec.FBairro = oponentes.Bairro;
        dbRec.FCEP = oponentes.CEP.ClearInputCep();
        dbRec.FInscEst = oponentes.InscEst;
        dbRec.FObservacao = oponentes.Observacao;
        dbRec.FEMail = oponentes.EMail;
        dbRec.FClass = oponentes.Class;
        dbRec.FTop = oponentes.Top;
        dbRec.FEtiqueta = oponentes.Etiqueta;
        dbRec.FBold = oponentes.Bold;
        dbRec.FGUID = oponentes.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}