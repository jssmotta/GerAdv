namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBFornecedores
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBFornecedoresDicInfo.Grupo:
                FGrupo = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBFornecedoresDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBFornecedoresDicInfo.SubGrupo:
                FSubGrupo = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBFornecedoresDicInfo.Tipo:
                FTipo = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBFornecedoresDicInfo.Sexo:
                FSexo = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBFornecedoresDicInfo.CNPJ:
                FCNPJ = $"{value}"; // rgo J3: string
                return;
            case DBFornecedoresDicInfo.InscEst:
                FInscEst = $"{value}"; // rgo J3: string
                return;
            case DBFornecedoresDicInfo.CPF:
                FCPF = $"{value}"; // rgo J3: string
                return;
            case DBFornecedoresDicInfo.RG:
                FRG = $"{value}"; // rgo J3: string
                return;
            case DBFornecedoresDicInfo.Endereco:
                FEndereco = $"{value}"; // rgo J3: string
                return;
            case DBFornecedoresDicInfo.Bairro:
                FBairro = $"{value}"; // rgo J3: string
                return;
            case DBFornecedoresDicInfo.CEP:
                FCEP = $"{value}"; // rgo J3: string
                return;
            case DBFornecedoresDicInfo.Cidade:
                FCidade = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBFornecedoresDicInfo.Fone:
                FFone = $"{value}"; // rgo J3: string
                return;
            case DBFornecedoresDicInfo.Fax:
                FFax = $"{value}"; // rgo J3: string
                return;
            case DBFornecedoresDicInfo.Email:
                FEmail = $"{value}"; // rgo J3: string
                return;
            case DBFornecedoresDicInfo.Site:
                FSite = $"{value}"; // rgo J3: string
                return;
            case DBFornecedoresDicInfo.Obs:
                FObs = $"{value}"; // rgo J3: string
                return;
            case DBFornecedoresDicInfo.Produtos:
                FProdutos = $"{value}"; // rgo J3: string
                return;
            case DBFornecedoresDicInfo.Contatos:
                FContatos = $"{value}"; // rgo J3: string
                return;
            case DBFornecedoresDicInfo.Etiqueta:
                FEtiqueta = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBFornecedoresDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBFornecedoresDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBFornecedoresDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBFornecedoresDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBFornecedoresDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBFornecedoresDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBFornecedoresDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBFornecedoresDicInfo.Grupo => NFGrupo(),
        DBFornecedoresDicInfo.Nome => NFNome(),
        DBFornecedoresDicInfo.SubGrupo => NFSubGrupo(),
        DBFornecedoresDicInfo.Tipo => FTipo.ToString(),
        DBFornecedoresDicInfo.Sexo => FSexo.ToString(),
        DBFornecedoresDicInfo.CNPJ => NFCNPJ(),
        DBFornecedoresDicInfo.InscEst => NFInscEst(),
        DBFornecedoresDicInfo.CPF => NFCPF(),
        DBFornecedoresDicInfo.RG => NFRG(),
        DBFornecedoresDicInfo.Endereco => NFEndereco(),
        DBFornecedoresDicInfo.Bairro => NFBairro(),
        DBFornecedoresDicInfo.CEP => NFCEP(),
        DBFornecedoresDicInfo.Cidade => NFCidade(),
        DBFornecedoresDicInfo.Fone => NFFone(),
        DBFornecedoresDicInfo.Fax => NFFax(),
        DBFornecedoresDicInfo.Email => NFEmail(),
        DBFornecedoresDicInfo.Site => NFSite(),
        DBFornecedoresDicInfo.Obs => NFObs(),
        DBFornecedoresDicInfo.Produtos => NFProdutos(),
        DBFornecedoresDicInfo.Contatos => NFContatos(),
        DBFornecedoresDicInfo.Etiqueta => FEtiqueta.ToString(),
        DBFornecedoresDicInfo.Bold => FBold.ToString(),
        DBFornecedoresDicInfo.GUID => NFGUID(),
        DBFornecedoresDicInfo.QuemCad => NFQuemCad(),
        DBFornecedoresDicInfo.DtCad => MDtCad,
        DBFornecedoresDicInfo.QuemAtu => NFQuemAtu(),
        DBFornecedoresDicInfo.DtAtu => MDtAtu,
        DBFornecedoresDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}