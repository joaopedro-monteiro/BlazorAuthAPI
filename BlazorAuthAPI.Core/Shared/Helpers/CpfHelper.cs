using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAuthAPI.Core.Shared.Helpers
{
    public static class CpfHelper
    {
        private static readonly int[] Multiplicador01 = [10, 9, 8, 7, 6, 5, 4, 3, 2];
        private static readonly int[] Multiplicador02 = [11, 10, 9, 8, 7, 6, 5, 4, 3, 2];

        public static bool IsValid(string? cpf)
        {
            if (string.IsNullOrEmpty(cpf) || cpf.Length != 11)
                return false;

            if (!cpf.HasOnlyNumbers())
                return false;

            var cpfSemDigito = cpf[..9];

            var soma = 0;
            for (var i = 0; i < 9; i++)
                soma += int.Parse(cpfSemDigito[i].ToString()) * Multiplicador01[i];

            var resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            var digito = resto.ToString();
            cpfSemDigito += digito;
            soma = 0;

            for (var i = 0; i < 10; i++)
                soma += int.Parse(cpfSemDigito[i].ToString()) * Multiplicador02[i];

            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;
            digito += resto;

            return cpf.EndsWith(digito);
        }

        public static bool HasOnlyNumbers(this string value)
        {
            return !string.IsNullOrEmpty(value) && value.All(v => v is >= '0' and <= '9');
        }
    }
}
