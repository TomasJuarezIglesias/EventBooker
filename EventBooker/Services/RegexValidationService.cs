using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Services
{
    public class RegexValidationService
    {
        public bool IsValidPassword(string password)
        {
            // Regla de contraseña: mínimo 8 caracteres, al menos una letra y un número
            string passwordPattern = @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$";
            return Regex.IsMatch(password, passwordPattern);
        }
    }
}
