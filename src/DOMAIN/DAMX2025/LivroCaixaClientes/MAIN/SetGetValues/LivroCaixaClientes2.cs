namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBLivroCaixaClientes
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBLivroCaixaClientesDicInfo.LivroCaixa:
                FLivroCaixa = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBLivroCaixaClientesDicInfo.Cliente:
                FCliente = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBLivroCaixaClientesDicInfo.Lancado:
                FLancado = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBLivroCaixaClientesDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBLivroCaixaClientesDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBLivroCaixaClientesDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBLivroCaixaClientesDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBLivroCaixaClientesDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBLivroCaixaClientesDicInfo.LivroCaixa => NFLivroCaixa(),
        DBLivroCaixaClientesDicInfo.Cliente => NFCliente(),
        DBLivroCaixaClientesDicInfo.Lancado => FLancado.ToString(),
        DBLivroCaixaClientesDicInfo.QuemCad => NFQuemCad(),
        DBLivroCaixaClientesDicInfo.DtCad => MDtCad,
        DBLivroCaixaClientesDicInfo.QuemAtu => NFQuemAtu(),
        DBLivroCaixaClientesDicInfo.DtAtu => MDtAtu,
        DBLivroCaixaClientesDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}