#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IColaboradoresWriter
{
    Entity.DBColaboradores Write(Models.Colaboradores colaboradores, int auditorQuem, SqlConnection oCnn);
}

public class Colaboradores : IColaboradoresWriter
{
    public Entity.DBColaboradores Write(Models.Colaboradores colaboradores, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = colaboradores.Id.IsEmptyIDNumber() ? new Entity.DBColaboradores() : new Entity.DBColaboradores(colaboradores.Id, oCnn);
        dbRec.FCargo = colaboradores.Cargo;
        dbRec.FCliente = colaboradores.Cliente;
        dbRec.FSexo = colaboradores.Sexo;
        dbRec.FNome = colaboradores.Nome;
        dbRec.FCPF = colaboradores.CPF.ClearInputCpf();
        dbRec.FRG = colaboradores.RG;
        if (colaboradores.DtNasc != null)
            dbRec.FDtNasc = colaboradores.DtNasc.ToString();
        dbRec.FIdade = colaboradores.Idade;
        dbRec.FEndereco = colaboradores.Endereco;
        dbRec.FBairro = colaboradores.Bairro;
        dbRec.FCEP = colaboradores.CEP.ClearInputCep();
        dbRec.FCidade = colaboradores.Cidade;
        dbRec.FFone = colaboradores.Fone;
        dbRec.FObservacao = colaboradores.Observacao;
        dbRec.FEMail = colaboradores.EMail;
        dbRec.FCNH = colaboradores.CNH;
        dbRec.FClass = colaboradores.Class;
        dbRec.FEtiqueta = colaboradores.Etiqueta;
        dbRec.FAni = colaboradores.Ani;
        dbRec.FBold = colaboradores.Bold;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}