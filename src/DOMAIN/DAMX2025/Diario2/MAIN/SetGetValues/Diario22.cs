namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBDiario2
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBDiario2DicInfo.Data:
                FData = $"{value}"; // rgo J3: DateTime
                return;
            case DBDiario2DicInfo.Hora:
                FHora = $"{value}"; // rgo J3: DateTime
                return;
            case DBDiario2DicInfo.Operador:
                FOperador = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBDiario2DicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBDiario2DicInfo.Ocorrencia:
                FOcorrencia = $"{value}"; // rgo J3: string
                return;
            case DBDiario2DicInfo.Cliente:
                FCliente = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBDiario2DicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBDiario2DicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBDiario2DicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBDiario2DicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBDiario2DicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBDiario2DicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBDiario2DicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBDiario2DicInfo.Data => NFData(),
        DBDiario2DicInfo.Hora => NFHora(),
        DBDiario2DicInfo.Operador => NFOperador(),
        DBDiario2DicInfo.Nome => NFNome(),
        DBDiario2DicInfo.Ocorrencia => NFOcorrencia(),
        DBDiario2DicInfo.Cliente => NFCliente(),
        DBDiario2DicInfo.Bold => FBold.ToString(),
        DBDiario2DicInfo.GUID => NFGUID(),
        DBDiario2DicInfo.QuemCad => NFQuemCad(),
        DBDiario2DicInfo.DtCad => MDtCad,
        DBDiario2DicInfo.QuemAtu => NFQuemAtu(),
        DBDiario2DicInfo.DtAtu => MDtAtu,
        DBDiario2DicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}