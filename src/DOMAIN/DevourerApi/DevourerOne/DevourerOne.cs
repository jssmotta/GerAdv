namespace MenphisSI;

public static partial class DevourerOne
{
     

 
    public static bool CPFValido(string cpf) => IsValidCpf2(cpf);
    public static bool CNPJValido(string cnpj) => IsValidCnpj2(cnpj);

    public static bool IsValidCpf2(this string cpf)
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

    public static bool IsValidCnpj2(this string cnpj)
    {
        if (string.IsNullOrEmpty(cnpj))
        {
            return false;
        }
        cnpj = cnpj.Trim();
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
        int sum = 0;
        int[] weights = [5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
        for (int i = 0; i < 12; i++)
        {
            sum += numbers[i] * weights[i];
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
        sum = 0;
        for (int i = 0; i < 13; i++)
        {
            sum += numbers[i] * weights[i];
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
}