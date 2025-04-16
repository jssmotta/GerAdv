namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBDadosProcuracao
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBDadosProcuracaoDicInfo.Cliente:
                FCliente = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBDadosProcuracaoDicInfo.EstadoCivil:
                FEstadoCivil = $"{value}"; // rgo J3: string
                return;
            case DBDadosProcuracaoDicInfo.Nacionalidade:
                FNacionalidade = $"{value}"; // rgo J3: string
                return;
            case DBDadosProcuracaoDicInfo.Profissao:
                FProfissao = $"{value}"; // rgo J3: string
                return;
            case DBDadosProcuracaoDicInfo.CTPS:
                FCTPS = $"{value}"; // rgo J3: string
                return;
            case DBDadosProcuracaoDicInfo.PisPasep:
                FPisPasep = $"{value}"; // rgo J3: string
                return;
            case DBDadosProcuracaoDicInfo.Remuneracao:
                FRemuneracao = $"{value}"; // rgo J3: string
                return;
            case DBDadosProcuracaoDicInfo.Objeto:
                FObjeto = $"{value}"; // rgo J3: string
                return;
            case DBDadosProcuracaoDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBDadosProcuracaoDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBDadosProcuracaoDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBDadosProcuracaoDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBDadosProcuracaoDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBDadosProcuracaoDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBDadosProcuracaoDicInfo.Cliente => NFCliente(),
        DBDadosProcuracaoDicInfo.EstadoCivil => NFEstadoCivil(),
        DBDadosProcuracaoDicInfo.Nacionalidade => NFNacionalidade(),
        DBDadosProcuracaoDicInfo.Profissao => NFProfissao(),
        DBDadosProcuracaoDicInfo.CTPS => NFCTPS(),
        DBDadosProcuracaoDicInfo.PisPasep => NFPisPasep(),
        DBDadosProcuracaoDicInfo.Remuneracao => NFRemuneracao(),
        DBDadosProcuracaoDicInfo.Objeto => NFObjeto(),
        DBDadosProcuracaoDicInfo.GUID => NFGUID(),
        DBDadosProcuracaoDicInfo.QuemCad => NFQuemCad(),
        DBDadosProcuracaoDicInfo.DtCad => MDtCad,
        DBDadosProcuracaoDicInfo.QuemAtu => NFQuemAtu(),
        DBDadosProcuracaoDicInfo.DtAtu => MDtAtu,
        DBDadosProcuracaoDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}