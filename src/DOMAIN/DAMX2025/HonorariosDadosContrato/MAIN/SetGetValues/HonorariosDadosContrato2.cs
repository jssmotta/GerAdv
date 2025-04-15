namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBHonorariosDadosContrato
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBHonorariosDadosContratoDicInfo.Cliente:
                FCliente = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBHonorariosDadosContratoDicInfo.Fixo:
                FFixo = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBHonorariosDadosContratoDicInfo.Variavel:
                FVariavel = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBHonorariosDadosContratoDicInfo.PercSucesso:
                FPercSucesso = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBHonorariosDadosContratoDicInfo.Processo:
                FProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBHonorariosDadosContratoDicInfo.ArquivoContrato:
                FArquivoContrato = $"{value}"; // rgo J3: string
                return;
            case DBHonorariosDadosContratoDicInfo.TextoContrato:
                FTextoContrato = $"{value}"; // rgo J3: string
                return;
            case DBHonorariosDadosContratoDicInfo.ValorFixo:
                FValorFixo = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBHonorariosDadosContratoDicInfo.Observacao:
                FObservacao = $"{value}"; // rgo J3: string
                return;
            case DBHonorariosDadosContratoDicInfo.DataContrato:
                FDataContrato = $"{value}"; // rgo J3: DateTime
                return;
            case DBHonorariosDadosContratoDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBHonorariosDadosContratoDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBHonorariosDadosContratoDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBHonorariosDadosContratoDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBHonorariosDadosContratoDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBHonorariosDadosContratoDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBHonorariosDadosContratoDicInfo.Cliente => NFCliente(),
        DBHonorariosDadosContratoDicInfo.Fixo => FFixo.ToString(),
        DBHonorariosDadosContratoDicInfo.Variavel => FVariavel.ToString(),
        DBHonorariosDadosContratoDicInfo.PercSucesso => NFPercSucesso(),
        DBHonorariosDadosContratoDicInfo.Processo => NFProcesso(),
        DBHonorariosDadosContratoDicInfo.ArquivoContrato => NFArquivoContrato(),
        DBHonorariosDadosContratoDicInfo.TextoContrato => NFTextoContrato(),
        DBHonorariosDadosContratoDicInfo.ValorFixo => NFValorFixo(),
        DBHonorariosDadosContratoDicInfo.Observacao => NFObservacao(),
        DBHonorariosDadosContratoDicInfo.DataContrato => NFDataContrato(),
        DBHonorariosDadosContratoDicInfo.GUID => NFGUID(),
        DBHonorariosDadosContratoDicInfo.QuemCad => NFQuemCad(),
        DBHonorariosDadosContratoDicInfo.DtCad => MDtCad,
        DBHonorariosDadosContratoDicInfo.QuemAtu => NFQuemAtu(),
        DBHonorariosDadosContratoDicInfo.DtAtu => MDtAtu,
        DBHonorariosDadosContratoDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}