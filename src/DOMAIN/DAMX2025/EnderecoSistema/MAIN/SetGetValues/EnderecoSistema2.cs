namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBEnderecoSistema
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBEnderecoSistemaDicInfo.Cadastro:
                FCadastro = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBEnderecoSistemaDicInfo.CadastroExCod:
                FCadastroExCod = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBEnderecoSistemaDicInfo.TipoEnderecoSistema:
                FTipoEnderecoSistema = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBEnderecoSistemaDicInfo.Processo:
                FProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBEnderecoSistemaDicInfo.Motivo:
                FMotivo = $"{value}"; // rgo J3: string
                return;
            case DBEnderecoSistemaDicInfo.ContatoNoLocal:
                FContatoNoLocal = $"{value}"; // rgo J3: string
                return;
            case DBEnderecoSistemaDicInfo.Cidade:
                FCidade = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBEnderecoSistemaDicInfo.Endereco:
                FEndereco = $"{value}"; // rgo J3: string
                return;
            case DBEnderecoSistemaDicInfo.Bairro:
                FBairro = $"{value}"; // rgo J3: string
                return;
            case DBEnderecoSistemaDicInfo.CEP:
                FCEP = $"{value}"; // rgo J3: string
                return;
            case DBEnderecoSistemaDicInfo.Fone:
                FFone = $"{value}"; // rgo J3: string
                return;
            case DBEnderecoSistemaDicInfo.Fax:
                FFax = $"{value}"; // rgo J3: string
                return;
            case DBEnderecoSistemaDicInfo.Observacao:
                FObservacao = $"{value}"; // rgo J3: string
                return;
            case DBEnderecoSistemaDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBEnderecoSistemaDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBEnderecoSistemaDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBEnderecoSistemaDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBEnderecoSistemaDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBEnderecoSistemaDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBEnderecoSistemaDicInfo.Cadastro => NFCadastro(),
        DBEnderecoSistemaDicInfo.CadastroExCod => NFCadastroExCod(),
        DBEnderecoSistemaDicInfo.TipoEnderecoSistema => NFTipoEnderecoSistema(),
        DBEnderecoSistemaDicInfo.Processo => NFProcesso(),
        DBEnderecoSistemaDicInfo.Motivo => NFMotivo(),
        DBEnderecoSistemaDicInfo.ContatoNoLocal => NFContatoNoLocal(),
        DBEnderecoSistemaDicInfo.Cidade => NFCidade(),
        DBEnderecoSistemaDicInfo.Endereco => NFEndereco(),
        DBEnderecoSistemaDicInfo.Bairro => NFBairro(),
        DBEnderecoSistemaDicInfo.CEP => NFCEP(),
        DBEnderecoSistemaDicInfo.Fone => NFFone(),
        DBEnderecoSistemaDicInfo.Fax => NFFax(),
        DBEnderecoSistemaDicInfo.Observacao => NFObservacao(),
        DBEnderecoSistemaDicInfo.GUID => NFGUID(),
        DBEnderecoSistemaDicInfo.QuemCad => NFQuemCad(),
        DBEnderecoSistemaDicInfo.DtCad => MDtCad,
        DBEnderecoSistemaDicInfo.QuemAtu => NFQuemAtu(),
        DBEnderecoSistemaDicInfo.DtAtu => MDtAtu,
        DBEnderecoSistemaDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}