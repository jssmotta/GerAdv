namespace MenphisSI;

public static partial class DevourerOne
{
    public static bool CPFValido(string? cpf) => cpf is null ? false : ValidarCPF(cpf);
    public static bool CNPJValido(string? cnpj) => cnpj is null ? false : ValidarCNPJ(cnpj);

    public static bool ValidarCPF(string cpf)
    {
        // Remove todos os caracteres que não são dígitos
        string cpfLimpo = cpf.WhereDigits().ToArrayString();

        // Verifica se tem exatamente 11 dígitos
        if (cpfLimpo.Length != 11)
            return false;

        // Verifica se não é uma sequência de números iguais (11111111111 até 99999999999)
        if (cpfLimpo.All(c => c == cpfLimpo[0]))
            return false;

        // Converte para array de inteiros
        int[] digitos = cpfLimpo.Select(c => int.Parse(c.ToString())).ToArray();

        // Calcula o primeiro dígito verificador
        int soma1 = 0;
        for (int i = 0; i < 9; i++)
        {
            soma1 += digitos[i] * (10 - i);
        }
        int resto1 = soma1 % 11;
        int dv1 = resto1 < 2 ? 0 : 11 - resto1;

        // Verifica o primeiro dígito verificador
        if (digitos[9] != dv1)
            return false;

        // Calcula o segundo dígito verificador
        int soma2 = 0;
        for (int i = 0; i < 10; i++)
        {
            soma2 += digitos[i] * (11 - i);
        }
        int resto2 = soma2 % 11;
        int dv2 = resto2 < 2 ? 0 : 11 - resto2;

        // Verifica o segundo dígito verificador
        return digitos[10] == dv2;
    }
     

    public static bool ValidarCNPJ(string cnpj)
    {
        // Remove todos os caracteres que não são dígitos
        string cnpjLimpo = cnpj.WhereDigits().ToArrayString();

        // Verifica se tem exatamente 14 dígitos
        if (cnpjLimpo.Length != 14)
            return false;

        // Verifica se não é uma sequência de números iguais (11111111111111 até 99999999999999)
        if (cnpjLimpo.All(c => c == cnpjLimpo[0]))
            return false;

        // Converte para array de inteiros
        int[] digitos = cnpjLimpo.Select(c => int.Parse(c.ToString())).ToArray();

        // Calcula o primeiro dígito verificador
        int[] peso1 = [5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
        int soma1 = 0;
        for (int i = 0; i < 12; i++)
        {
            soma1 += digitos[i] * peso1[i];
        }
        int resto1 = soma1 % 11;
        int dv1 = resto1 < 2 ? 0 : 11 - resto1;

        // Verifica o primeiro dígito verificador
        if (digitos[12] != dv1)
            return false;

        // Calcula o segundo dígito verificador
        int[] peso2 = [6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
        int soma2 = 0;
        for (int i = 0; i < 13; i++)
        {
            soma2 += digitos[i] * peso2[i];
        }
        int resto2 = soma2 % 11;
        int dv2 = resto2 < 2 ? 0 : 11 - resto2;

        // Verifica o segundo dígito verificador
        return digitos[13] == dv2;
    }

    // Método auxiliar para extrair apenas dígitos usando C# 13
    public static string WhereDigits(this string input) =>
        new([.. input.Where(char.IsDigit)]);

    // Método auxiliar para converter array de char para string
    public static string ToArrayString(this IEnumerable<char> chars) =>
        new([.. chars]);
}