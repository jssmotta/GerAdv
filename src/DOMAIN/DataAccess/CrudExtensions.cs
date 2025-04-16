namespace MenphisSI;
public static class CrudExtensions
{
    public static string ClearInputCnpj(this string cnpjWithMask) => cnpjWithMask.Replace(".", "").Replace("/", "").Replace("-", "");
    public static string ClearInputCpf(this string cpfWithMask) => cpfWithMask.Replace(".", "").Replace("-", "");
    public static string ClearInputCep(this string cepWithMask) => cepWithMask.Replace("-", "").Replace(".", "");

    public static bool IsValidCnpj(this string cnpjParam)
    {
        if (string.IsNullOrEmpty(cnpjParam))
        {
            return false;
        }
        var cnpj = cnpjParam.Trim();
        cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
        if (cnpj.Length != 14)
        {
            return false;
        }

        int[] numbers = new int[14];
        for (int i = 0; i < 14; i++)
        {
            numbers[i] = int.Parse(cnpj[i].ToString());
        }

        // Primeiro dígito verificador
        int sum = 0;
        int[] weightsFirstDigit = new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        for (int i = 0; i < 12; i++)
        {
            sum += numbers[i] * weightsFirstDigit[i];
        }
        int result = sum % 11;
        if (result < 2)
        {
            if (numbers[12] != 0)
            {
                return false;
            }
        }
        else
        {
            if (numbers[12] != 11 - result)
            {
                return false;
            }
        }

        // Segundo dígito verificador
        sum = 0;
        int[] weightsSecondDigit = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        for (int i = 0; i < 13; i++)
        {
            sum += numbers[i] * weightsSecondDigit[i];
        }
        result = sum % 11;
        if (result < 2)
        {
            if (numbers[13] != 0)
            {
                return false;
            }
        }
        else
        {
            if (numbers[13] != 11 - result)
            {
                return false;
            }
        }

        return true;
    }

    public static bool IsValidCpf(this string cpf)
    {
        if (string.IsNullOrEmpty(cpf))
        {
            return false;
        }

        cpf = cpf.Trim();
        cpf = cpf.Replace(".", "").Replace("-", "");
        if (cpf.Length != 11)
        {
            return false;
        }
        if (cpf == "00000000000" || cpf == "11111111111" || cpf == "22222222222" || cpf == "33333333333" || cpf == "44444444444" || cpf == "55555555555" || cpf == "66666666666" || cpf == "77777777777" || cpf == "88888888888" || cpf == "99999999999")
        {
            return false;
        }
        int[] numbers = new int[11];
        for (int i = 0; i < 11; i++)
        {
            numbers[i] = int.Parse(cpf[i].ToString());
        }
        int sum = 0;
        for (int i = 0; i < 9; i++)
        {
            sum += numbers[i] * (10 - i);
        }
        int result = sum % 11;
        if (result == 0 || result == 1)
        {
            if (numbers[9] != 0)
            {
                return false;
            }
        }
        else
        {
            if (numbers[9] != 11 - result)
            {
                return false;
            }
        }
        sum = 0;
        for (int i = 0; i < 10; i++)
        {
            sum += numbers[i] * (11 - i);
        }
        result = sum % 11;
        if (result == 0 || result == 1)
        {
            if (numbers[10] != 0)
            {
                return false;
            }
        }
        else
        {
            if (numbers[10] != 11 - result)
            {
                return false;
            }
        }
        return true;
    }


}
