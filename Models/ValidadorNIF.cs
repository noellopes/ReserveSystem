namespace ReserveSystem.Models
{
    public class ValidadorNIF
    {
        public static bool NIFValido(int NIF)
        {
            if(Convert.ToString(NIF).Length != 9)
            {
                return false;
            }
            var Digito = Convert.ToString(NIF).Select(ch => int.Parse(ch.ToString())).ToArray();
            if (!new[] { 1, 2, 5, 6, 7, 8, 9 }.Contains(Digito[0]))
            {
                return false;
            }
            int VerSoma = 0;
            for (int i = 0; i < 8; i++)
            {
                VerSoma += Digito[i] * (9 - i);
            }
            int VerDigito = 11 - (VerSoma % 11);
            if (VerDigito >= 10)
            {
                VerDigito = 0;
            }
            return VerDigito == Digito[8];
        }
    }
}
