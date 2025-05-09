﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPaisesWriter
{
    Entity.DBPaises Write(Models.Paises paises, int auditorQuem, SqlConnection oCnn);
}

public class Paises : IPaisesWriter
{
    public Entity.DBPaises Write(Models.Paises paises, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = paises.Id.IsEmptyIDNumber() ? new Entity.DBPaises() : new Entity.DBPaises(paises.Id, oCnn);
        dbRec.FNome = paises.Nome;
        dbRec.FGUID = paises.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}