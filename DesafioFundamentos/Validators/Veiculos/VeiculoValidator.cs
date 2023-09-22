using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DesafioFundamentos.Validators.Veiculos
{
    public static class VeiculoValidator
    {
        private static string pattern { get; } = "^[a-zA-Z]{3}[0-9][A-Za-z0-9][0-9]{2}$";
        public static bool IsValidLicencePlate(string LicencePlate)
        {
            return Regex.IsMatch(LicencePlate, pattern);
        }
    }
}
