namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBGruposEmpresas
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBGruposEmpresasDicInfo.EMail:
                FEMail = $"{value}"; // rgo J3: string
                return;
            case DBGruposEmpresasDicInfo.Inativo:
                FInativo = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBGruposEmpresasDicInfo.Oponente:
                FOponente = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBGruposEmpresasDicInfo.Descricao:
                FDescricao = $"{value}"; // rgo J3: string
                return;
            case DBGruposEmpresasDicInfo.Observacoes:
                FObservacoes = $"{value}"; // rgo J3: string
                return;
            case DBGruposEmpresasDicInfo.Cliente:
                FCliente = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBGruposEmpresasDicInfo.Icone:
                FIcone = $"{value}"; // rgo J3: string
                return;
            case DBGruposEmpresasDicInfo.DespesaUnificada:
                FDespesaUnificada = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBGruposEmpresasDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBGruposEmpresasDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBGruposEmpresasDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBGruposEmpresasDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBGruposEmpresasDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBGruposEmpresasDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBGruposEmpresasDicInfo.EMail => NFEMail(),
        DBGruposEmpresasDicInfo.Inativo => FInativo.ToString(),
        DBGruposEmpresasDicInfo.Oponente => NFOponente(),
        DBGruposEmpresasDicInfo.Descricao => NFDescricao(),
        DBGruposEmpresasDicInfo.Observacoes => NFObservacoes(),
        DBGruposEmpresasDicInfo.Cliente => NFCliente(),
        DBGruposEmpresasDicInfo.Icone => NFIcone(),
        DBGruposEmpresasDicInfo.DespesaUnificada => FDespesaUnificada.ToString(),
        DBGruposEmpresasDicInfo.GUID => NFGUID(),
        DBGruposEmpresasDicInfo.QuemCad => NFQuemCad(),
        DBGruposEmpresasDicInfo.DtCad => MDtCad,
        DBGruposEmpresasDicInfo.QuemAtu => NFQuemAtu(),
        DBGruposEmpresasDicInfo.DtAtu => MDtAtu,
        DBGruposEmpresasDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}