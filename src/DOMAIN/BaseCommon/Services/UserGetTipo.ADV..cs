namespace MenphisSI.BaseCommon;

public static class UserGetTipo
{
    public static string GetTipo(DBOperador user) => user.FCadID == 1 ? "Advogado" : "Funcionario";
}
