using System.Text.RegularExpressions;

namespace EXPRESIONESREGULARES
{
    public class expresiones
    {
        public static bool placa(string placa)
        {
            return Regex.IsMatch(placa, @"^[PCOMA]\d{3}[A-Z]{3}$");
        }

        public static bool fechas(string fechas)
        {
            return Regex.IsMatch(fechas, @"^\d{4}/(0[1-9]|1[0-2])/(0[1-9]|[12][0-9]|3[01]) (2[0-3]|[01][0-9]):[0-5][0-9]:[0-5][0-9]$");
        }

        public static bool set(string input, int x)
        {
            var pattern = @"^SETS$";
            var pattern2 = @"^\s*([a-zA-Z_]+)\s*=\s*((('[a-zA-Z]')(\s*\.\.\s*('[a-zA-Z]'))?)|('[_]'))(\s*\+\s*((('[a-zA-Z]')(\s*\.\.\s*('[a-zA-Z]'))?)|('[_]')))*\s*$";
            var pattern3 = @"^\s*([a-zA-Z_]+)\s*=\s*('[0-9]')(\s*\.\.\s*('[0-9]'))?\s*$";
            var pattern4 = @"^\s*([a-zA-Z_]+)\s*=\s*CHR\(\d+\)\.\.CHR\(\d+\)\s*$";


            int linea = x++;
            if (Regex.IsMatch(input.Trim(), pattern))
            {
                Console.WriteLine("SET valido en la linea : " + linea);
                return true;
            }
            else if (Regex.IsMatch(input.Trim(), pattern2) || Regex.IsMatch(input.Trim(), pattern3) || Regex.IsMatch(input.Trim(), pattern4))
            {
                Console.WriteLine("SET valido en la linea :"+ linea);
                return true;
            }
            else
            {
                Console.WriteLine("No es correcto el SET, error en la linea: " + linea);
                return false;
            }


        }



        //\s 	Coincide con un caracter de espacio en blanco.
    }
}
