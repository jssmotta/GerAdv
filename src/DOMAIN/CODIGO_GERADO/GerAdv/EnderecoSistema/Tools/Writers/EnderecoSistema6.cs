#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IEnderecoSistemaWriter
{
    Entity.DBEnderecoSistema Write(Models.EnderecoSistema enderecosistema, int auditorQuem, SqlConnection oCnn);
}

public class EnderecoSistema : IEnderecoSistemaWriter
{
    public Entity.DBEnderecoSistema Write(Models.EnderecoSistema enderecosistema, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = enderecosistema.Id.IsEmptyIDNumber() ? new Entity.DBEnderecoSistema() : new Entity.DBEnderecoSistema(enderecosistema.Id, oCnn);
        dbRec.FCadastro = enderecosistema.Cadastro;
        dbRec.FCadastroExCod = enderecosistema.CadastroExCod;
        dbRec.FTipoEnderecoSistema = enderecosistema.TipoEnderecoSistema;
        dbRec.FProcesso = enderecosistema.Processo;
        dbRec.FMotivo = enderecosistema.Motivo;
        dbRec.FContatoNoLocal = enderecosistema.ContatoNoLocal;
        dbRec.FCidade = enderecosistema.Cidade;
        dbRec.FEndereco = enderecosistema.Endereco;
        dbRec.FBairro = enderecosistema.Bairro;
        dbRec.FCEP = enderecosistema.CEP.ClearInputCep();
        dbRec.FFone = enderecosistema.Fone;
        dbRec.FFax = enderecosistema.Fax;
        dbRec.FObservacao = enderecosistema.Observacao;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}