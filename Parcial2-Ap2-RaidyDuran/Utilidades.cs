using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial1_Ap2_RaidyDuran
{
    public class Utilidades
    {
        public static int TOINT(string num)
        {
            int numero = 0;
            int.TryParse(num, out numero);
            return numero;
        }
    }
}