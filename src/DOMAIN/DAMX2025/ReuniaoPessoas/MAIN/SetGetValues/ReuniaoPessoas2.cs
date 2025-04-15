namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBReuniaoPessoas
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBReuniaoPessoasDicInfo.Reuniao:
                FReuniao = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBReuniaoPessoasDicInfo.Operador:
                FOperador = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBReuniaoPessoasDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBReuniaoPessoasDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBReuniaoPessoasDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBReuniaoPessoasDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBReuniaoPessoasDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBReuniaoPessoasDicInfo.Reuniao => NFReuniao(),
        DBReuniaoPessoasDicInfo.Operador => NFOperador(),
        DBReuniaoPessoasDicInfo.QuemCad => NFQuemCad(),
        DBReuniaoPessoasDicInfo.DtCad => MDtCad,
        DBReuniaoPessoasDicInfo.QuemAtu => NFQuemAtu(),
        DBReuniaoPessoasDicInfo.DtAtu => MDtAtu,
        DBReuniaoPessoasDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}