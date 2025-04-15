namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBInstancia
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBInstanciaDicInfo.LiminarPedida:
                FLiminarPedida = $"{value}"; // rgo J3: string
                return;
            case DBInstanciaDicInfo.Objeto:
                FObjeto = $"{value}"; // rgo J3: string
                return;
            case DBInstanciaDicInfo.StatusResultado:
                FStatusResultado = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBInstanciaDicInfo.LiminarPendente:
                FLiminarPendente = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBInstanciaDicInfo.InterpusemosRecurso:
                FInterpusemosRecurso = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBInstanciaDicInfo.LiminarConcedida:
                FLiminarConcedida = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBInstanciaDicInfo.LiminarNegada:
                FLiminarNegada = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBInstanciaDicInfo.Processo:
                FProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBInstanciaDicInfo.Data:
                FData = $"{value}"; // rgo J3: DateTime
                return;
            case DBInstanciaDicInfo.LiminarParcial:
                FLiminarParcial = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBInstanciaDicInfo.LiminarResultado:
                FLiminarResultado = $"{value}"; // rgo J3: string
                return;
            case DBInstanciaDicInfo.NroProcesso:
                FNroProcesso = $"{value}"; // rgo J3: string
                return;
            case DBInstanciaDicInfo.Divisao:
                FDivisao = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBInstanciaDicInfo.LiminarCliente:
                FLiminarCliente = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBInstanciaDicInfo.Comarca:
                FComarca = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBInstanciaDicInfo.SubDivisao:
                FSubDivisao = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBInstanciaDicInfo.Principal:
                FPrincipal = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBInstanciaDicInfo.Acao:
                FAcao = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBInstanciaDicInfo.Foro:
                FForo = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBInstanciaDicInfo.TipoRecurso:
                FTipoRecurso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBInstanciaDicInfo.ZKey:
                FZKey = $"{value}"; // rgo J3: string
                return;
            case DBInstanciaDicInfo.ZKeyQuem:
                FZKeyQuem = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBInstanciaDicInfo.ZKeyQuando:
                FZKeyQuando = $"{value}"; // rgo J3: DateTime
                return;
            case DBInstanciaDicInfo.NroAntigo:
                FNroAntigo = $"{value}"; // rgo J3: string
                return;
            case DBInstanciaDicInfo.AccessCode:
                FAccessCode = $"{value}"; // rgo J3: string
                return;
            case DBInstanciaDicInfo.Julgador:
                FJulgador = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBInstanciaDicInfo.ZKeyIA:
                FZKeyIA = $"{value}"; // rgo J3: string
                return;
            case DBInstanciaDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBInstanciaDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBInstanciaDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBInstanciaDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBInstanciaDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBInstanciaDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBInstanciaDicInfo.LiminarPedida => NFLiminarPedida(),
        DBInstanciaDicInfo.Objeto => NFObjeto(),
        DBInstanciaDicInfo.StatusResultado => NFStatusResultado(),
        DBInstanciaDicInfo.LiminarPendente => FLiminarPendente.ToString(),
        DBInstanciaDicInfo.InterpusemosRecurso => FInterpusemosRecurso.ToString(),
        DBInstanciaDicInfo.LiminarConcedida => FLiminarConcedida.ToString(),
        DBInstanciaDicInfo.LiminarNegada => FLiminarNegada.ToString(),
        DBInstanciaDicInfo.Processo => NFProcesso(),
        DBInstanciaDicInfo.Data => NFData(),
        DBInstanciaDicInfo.LiminarParcial => FLiminarParcial.ToString(),
        DBInstanciaDicInfo.LiminarResultado => NFLiminarResultado(),
        DBInstanciaDicInfo.NroProcesso => NFNroProcesso(),
        DBInstanciaDicInfo.Divisao => NFDivisao(),
        DBInstanciaDicInfo.LiminarCliente => FLiminarCliente.ToString(),
        DBInstanciaDicInfo.Comarca => NFComarca(),
        DBInstanciaDicInfo.SubDivisao => NFSubDivisao(),
        DBInstanciaDicInfo.Principal => FPrincipal.ToString(),
        DBInstanciaDicInfo.Acao => NFAcao(),
        DBInstanciaDicInfo.Foro => NFForo(),
        DBInstanciaDicInfo.TipoRecurso => NFTipoRecurso(),
        DBInstanciaDicInfo.ZKey => NFZKey(),
        DBInstanciaDicInfo.ZKeyQuem => NFZKeyQuem(),
        DBInstanciaDicInfo.ZKeyQuando => NFZKeyQuando(),
        DBInstanciaDicInfo.NroAntigo => NFNroAntigo(),
        DBInstanciaDicInfo.AccessCode => NFAccessCode(),
        DBInstanciaDicInfo.Julgador => NFJulgador(),
        DBInstanciaDicInfo.ZKeyIA => NFZKeyIA(),
        DBInstanciaDicInfo.GUID => NFGUID(),
        DBInstanciaDicInfo.QuemCad => NFQuemCad(),
        DBInstanciaDicInfo.DtCad => MDtCad,
        DBInstanciaDicInfo.QuemAtu => NFQuemAtu(),
        DBInstanciaDicInfo.DtAtu => MDtAtu,
        DBInstanciaDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}