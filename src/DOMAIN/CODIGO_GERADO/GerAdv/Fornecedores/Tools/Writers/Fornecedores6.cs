#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IFornecedoresWriter
{
    Entity.DBFornecedores Write(Models.Fornecedores fornecedores, int auditorQuem, SqlConnection oCnn);
}

public class Fornecedores : IFornecedoresWriter
{
    public Entity.DBFornecedores Write(Models.Fornecedores fornecedores, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = fornecedores.Id.IsEmptyIDNumber() ? new Entity.DBFornecedores() : new Entity.DBFornecedores(fornecedores.Id, oCnn);
        dbRec.FGrupo = fornecedores.Grupo;
        dbRec.FNome = fornecedores.Nome;
        dbRec.FSubGrupo = fornecedores.SubGrupo;
        dbRec.FTipo = fornecedores.Tipo;
        dbRec.FSexo = fornecedores.Sexo;
        dbRec.FCNPJ = fornecedores.CNPJ.ClearInputCnpj();
        dbRec.FInscEst = fornecedores.InscEst;
        dbRec.FCPF = fornecedores.CPF.ClearInputCpf();
        dbRec.FRG = fornecedores.RG;
        dbRec.FEndereco = fornecedores.Endereco;
        dbRec.FBairro = fornecedores.Bairro;
        dbRec.FCEP = fornecedores.CEP.ClearInputCep();
        dbRec.FCidade = fornecedores.Cidade;
        dbRec.FFone = fornecedores.Fone;
        dbRec.FFax = fornecedores.Fax;
        dbRec.FEmail = fornecedores.Email;
        dbRec.FSite = fornecedores.Site;
        dbRec.FObs = fornecedores.Obs;
        dbRec.FProdutos = fornecedores.Produtos;
        dbRec.FContatos = fornecedores.Contatos;
        dbRec.FEtiqueta = fornecedores.Etiqueta;
        dbRec.FBold = fornecedores.Bold;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}