namespace MenphisSI;

public static partial class DevourerOne
{   
    public static void PopupBox(this string? fNome, string? fMsg)
    {
        Console.WriteLine("PopupBox: " + fNome + " - " + fMsg);
    }
    internal static void ExplodeErrorWindows(string? fNome, int id)
    {
        Console.WriteLine("Erro: " + fNome + " - " + id);    
    }
}
