﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Services
{
    public static class RegexValidationService
    {
        public static bool IsValidPassword(string password)
        {
            // Regla de contraseña: mínimo 8 caracteres, al menos una letra mayuscula y un número
            string passwordPattern = @"^(?=.*[A-Z])(?=.*\d).{8,}$";
            return Regex.IsMatch(password, passwordPattern);
        }

        public static bool IsValidDni(string dni) 
        {
            string dniPattern = @"^\d{8}";
            return Regex.IsMatch(dni, dniPattern);
        }

        public static bool IsValidEmail(string email) 
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, emailPattern);
        }

        public static bool IsValidContact(string contacto) 
        {
            string contactPattern = @"^\d{10}$";
            return Regex.IsMatch(contacto, contactPattern);
        }

        // Valida si es visa, master o amex
        public static bool IsValidCard(string card)
        {
            string cardPattern = @"^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|3[47][0-9]{13})$";
            return Regex.IsMatch(card, cardPattern);
        }
    }
}
