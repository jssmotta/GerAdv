namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBColaboradores
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBColaboradoresDicInfo.Cargo:
                FCargo = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBColaboradoresDicInfo.Cliente:
                FCliente = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBColaboradoresDicInfo.Sexo:
                FSexo = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBColaboradoresDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBColaboradoresDicInfo.CPF:
                FCPF = $"{value}"; // rgo J3: string
                return;
            case DBColaboradoresDicInfo.RG:
                FRG = $"{value}"; // rgo J3: string
                return;
            case DBColaboradoresDicInfo.DtNasc:
                FDtNasc = $"{value}"; // rgo J3: DateTime
                return;
            case DBColaboradoresDicInfo.Idade:
                FIdade = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBColaboradoresDicInfo.Endereco:
                FEndereco = $"{value}"; // rgo J3: string
                return;
            case DBColaboradoresDicInfo.Bairro:
                FBairro = $"{value}"; // rgo J3: string
                return;
            case DBColaboradoresDicInfo.CEP:
                FCEP = $"{value}"; // rgo J3: string
                return;
            case DBColaboradoresDicInfo.Cidade:
                FCidade = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBColaboradoresDicInfo.Fone:
                FFone = $"{value}"; // rgo J3: string
                return;
            case DBColaboradoresDicInfo.Observacao:
                FObservacao = $"{value}"; // rgo J3: string
                return;
            case DBColaboradoresDicInfo.EMail:
                FEMail = $"{value}"; // rgo J3: string
                return;
            case DBColaboradoresDicInfo.CNH:
                FCNH = $"{value}"; // rgo J3: string
                return;
            case DBColaboradoresDicInfo.Class:
                FClass = $"{value}"; // rgo J3: string
                return;
            case DBColaboradoresDicInfo.Etiqueta:
                FEtiqueta = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBColaboradoresDicInfo.Ani:
                FAni = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBColaboradoresDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBColaboradoresDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBColaboradoresDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBColaboradoresDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBColaboradoresDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBColaboradoresDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBColaboradoresDicInfo.Cargo => NFCargo(),
        DBColaboradoresDicInfo.Cliente => NFCliente(),
        DBColaboradoresDicInfo.Sexo => FSexo.ToString(),
        DBColaboradoresDicInfo.Nome => NFNome(),
        DBColaboradoresDicInfo.CPF => NFCPF(),
        DBColaboradoresDicInfo.RG => NFRG(),
        DBColaboradoresDicInfo.DtNasc => NFDtNasc(),
        DBColaboradoresDicInfo.Idade => NFIdade(),
        DBColaboradoresDicInfo.Endereco => NFEndereco(),
        DBColaboradoresDicInfo.Bairro => NFBairro(),
        DBColaboradoresDicInfo.CEP => NFCEP(),
        DBColaboradoresDicInfo.Cidade => NFCidade(),
        DBColaboradoresDicInfo.Fone => NFFone(),
        DBColaboradoresDicInfo.Observacao => NFObservacao(),
        DBColaboradoresDicInfo.EMail => NFEMail(),
        DBColaboradoresDicInfo.CNH => NFCNH(),
        DBColaboradoresDicInfo.Class => NFClass(),
        DBColaboradoresDicInfo.Etiqueta => FEtiqueta.ToString(),
        DBColaboradoresDicInfo.Ani => FAni.ToString(),
        DBColaboradoresDicInfo.Bold => FBold.ToString(),
        DBColaboradoresDicInfo.QuemCad => NFQuemCad(),
        DBColaboradoresDicInfo.DtCad => MDtCad,
        DBColaboradoresDicInfo.QuemAtu => NFQuemAtu(),
        DBColaboradoresDicInfo.DtAtu => MDtAtu,
        DBColaboradoresDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}