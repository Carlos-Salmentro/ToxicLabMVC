using Microsoft.JSInterop;

namespace ToxicLabMVC.Validadores
{
    public class TesteCpf
    {
        public bool ValidarCpf(string cpf)
        {
            int sum = 0;
            int teste = 0;
            int dig1 = cpf[9] - '0';
            int dig2 = cpf[10] - '0';


            for (int i = 0; i < 9; i++)
            {
                int aux = cpf[i] - '0';
                sum += aux * (i + 1);
            }

            teste = sum % 11;

            if (teste == 10)
                teste = 0;

            if (dig1 != teste)
            {
                return false;
            }

            sum = 0;
            teste = 0;

            for (int i = 0; i < 10; i++)
            {
                int aux = cpf[i] - '0';
                sum += aux * i;
            }

            teste = sum % 11;

            if (teste == 10)
                teste = 0;

            if (dig2 != teste)
            {
                return false;
            }

            return true;
        }
    }
}
