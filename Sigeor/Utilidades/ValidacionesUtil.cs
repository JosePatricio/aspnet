using System;
using System.Text.RegularExpressions;

namespace Sigeor.Utilidades
{
    public class ValidacionesUtil
    {

        public static bool validacionCorreo(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        public static bool validacionCedulaCelular(String stringCedula)
        {
            String expresion;
            expresion = "^[0-9]{10}";
            if (Regex.IsMatch(stringCedula, expresion))
            {
                if (Regex.Replace(stringCedula, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        public static bool validacionStrings(String stringParametro)
        {

            var expresion = "^[A-Z a-z]*${2,50}";
            if (Regex.IsMatch(stringParametro, expresion))
            {
                if (Regex.Replace(stringParametro, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// Valida mediante una expresion regular que la cadena ingresada sean solo numeros, ya sean enteros o decimales
        /// </summary>
        /// <param name="cadena">Cadena a Validar</param>
        /// <returns>True o False</returns>
        public static bool ValidarNumeros(string cadena)
        {
            var rex = new Regex("^[0-9]+([,][0-9]*)?$");
            return rex.IsMatch(cadena);
        }

    }
}