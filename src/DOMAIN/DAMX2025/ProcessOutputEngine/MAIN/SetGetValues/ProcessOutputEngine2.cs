namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProcessOutputEngine
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBProcessOutputEngineDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBProcessOutputEngineDicInfo.Database:
                FDatabase = $"{value}"; // rgo J3: string
                return;
            case DBProcessOutputEngineDicInfo.Tabela:
                FTabela = $"{value}"; // rgo J3: string
                return;
            case DBProcessOutputEngineDicInfo.Campo:
                FCampo = $"{value}"; // rgo J3: string
                return;
            case DBProcessOutputEngineDicInfo.Valor:
                FValor = $"{value}"; // rgo J3: string
                return;
            case DBProcessOutputEngineDicInfo.Output:
                FOutput = $"{value}"; // rgo J3: string
                return;
            case DBProcessOutputEngineDicInfo.Administrador:
                FAdministrador = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBProcessOutputEngineDicInfo.OutputSource:
                FOutputSource = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProcessOutputEngineDicInfo.DisabledItem:
                FDisabledItem = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBProcessOutputEngineDicInfo.IDModulo:
                FIDModulo = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProcessOutputEngineDicInfo.IsOnlyProcesso:
                FIsOnlyProcesso = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBProcessOutputEngineDicInfo.MyID:
                FMyID = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProcessOutputEngineDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBProcessOutputEngineDicInfo.Nome => NFNome(),
        DBProcessOutputEngineDicInfo.Database => NFDatabase(),
        DBProcessOutputEngineDicInfo.Tabela => NFTabela(),
        DBProcessOutputEngineDicInfo.Campo => NFCampo(),
        DBProcessOutputEngineDicInfo.Valor => NFValor(),
        DBProcessOutputEngineDicInfo.Output => NFOutput(),
        DBProcessOutputEngineDicInfo.Administrador => FAdministrador.ToString(),
        DBProcessOutputEngineDicInfo.OutputSource => NFOutputSource(),
        DBProcessOutputEngineDicInfo.DisabledItem => FDisabledItem.ToString(),
        DBProcessOutputEngineDicInfo.IDModulo => NFIDModulo(),
        DBProcessOutputEngineDicInfo.IsOnlyProcesso => FIsOnlyProcesso.ToString(),
        DBProcessOutputEngineDicInfo.MyID => NFMyID(),
        DBProcessOutputEngineDicInfo.GUID => NFGUID(),
        _ => nameof(GetValueByNameField)};
}