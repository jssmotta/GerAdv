namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProcessOutputRequest
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBProcessOutputRequestDicInfo.ProcessOutputEngine:
                FProcessOutputEngine = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProcessOutputRequestDicInfo.Operador:
                FOperador = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProcessOutputRequestDicInfo.Processo:
                FProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProcessOutputRequestDicInfo.UltimoIdTabelaExo:
                FUltimoIdTabelaExo = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProcessOutputRequestDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBProcessOutputRequestDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProcessOutputRequestDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBProcessOutputRequestDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProcessOutputRequestDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBProcessOutputRequestDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBProcessOutputRequestDicInfo.ProcessOutputEngine => NFProcessOutputEngine(),
        DBProcessOutputRequestDicInfo.Operador => NFOperador(),
        DBProcessOutputRequestDicInfo.Processo => NFProcesso(),
        DBProcessOutputRequestDicInfo.UltimoIdTabelaExo => NFUltimoIdTabelaExo(),
        DBProcessOutputRequestDicInfo.GUID => NFGUID(),
        DBProcessOutputRequestDicInfo.QuemCad => NFQuemCad(),
        DBProcessOutputRequestDicInfo.DtCad => MDtCad,
        DBProcessOutputRequestDicInfo.QuemAtu => NFQuemAtu(),
        DBProcessOutputRequestDicInfo.DtAtu => MDtAtu,
        DBProcessOutputRequestDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}