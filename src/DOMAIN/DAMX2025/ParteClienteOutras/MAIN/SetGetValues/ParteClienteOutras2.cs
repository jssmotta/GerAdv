namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBParteClienteOutras
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBParteClienteOutrasDicInfo.Cliente:
                FCliente = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBParteClienteOutrasDicInfo.Processo:
                FProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBParteClienteOutrasDicInfo.PrimeiraReclamada:
                FPrimeiraReclamada = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBParteClienteOutrasDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBParteClienteOutrasDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBParteClienteOutrasDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBParteClienteOutrasDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBParteClienteOutrasDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBParteClienteOutrasDicInfo.Cliente => NFCliente(),
        DBParteClienteOutrasDicInfo.Processo => NFProcesso(),
        DBParteClienteOutrasDicInfo.PrimeiraReclamada => FPrimeiraReclamada.ToString(),
        DBParteClienteOutrasDicInfo.QuemCad => NFQuemCad(),
        DBParteClienteOutrasDicInfo.DtCad => MDtCad,
        DBParteClienteOutrasDicInfo.QuemAtu => NFQuemAtu(),
        DBParteClienteOutrasDicInfo.DtAtu => MDtAtu,
        DBParteClienteOutrasDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}