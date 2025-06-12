#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ISMSAliceWhere
{
    SMSAliceResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class SMSAlice : ISMSAliceWhere
{
    public SMSAliceResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBSMSAlice(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var smsalice = new SMSAliceResponse
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Nome = dbRec.FNome ?? string.Empty,
            TipoEMail = dbRec.FTipoEMail,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return smsalice;
    }
}