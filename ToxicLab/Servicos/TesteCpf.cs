using Microsoft.JSInterop;

namespace ToxicLab.Servicos
{
    static class TesteCpf
    {
        static bool ValidarCpf(string cpf)
        {
            int sum = 0;

            for (int i = 0; i < 9; i++)
            {
                int aux = Convert.ToInt32(cpf.Substring(i));
                sum += aux * (i + 1);
            }


            return true;
        }
    }
}
