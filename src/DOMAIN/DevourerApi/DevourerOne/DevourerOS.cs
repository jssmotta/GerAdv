namespace MenphisSI;

public static partial class DevourerOne
{

    public static bool IsSenhaFraca(this string senha, string nomeOperador)
    {
        if (senha.Length < 8 ||
            senha.IsEquals(DevourerOne.PSenhaReset) ||
            senha.ContemUpper("Advocati") ||
            senha.ContemUpper("Menphis") ||
            senha.Contem("12345") ||
            senha.ContemUpper(nomeOperador.FirstName()) ||
            senha.ContemUpper(nomeOperador.LastName()) ||
            senha.ContemUpper(nomeOperador)
           ) return true;

        

        var nTem3Iguais = 0;
        for (var x = 0; x < senha.Length - 1; x++)
        {
            if (senha.Substring(x, length: 1).Equals(senha.Substring(startIndex: x + 1, length: 1)))
            {
                nTem3Iguais++;
                if (nTem3Iguais == 2) return true;
                continue;
            }

            nTem3Iguais = 0;
        }

        return false;
    }    
}