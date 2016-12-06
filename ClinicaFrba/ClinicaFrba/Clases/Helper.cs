using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClinicaFrba.Clases
{
    static public class  Helper
    {
        public static void permitir_numeros(KeyPressEventArgs evt )
        {
            if (Char.IsDigit(evt.KeyChar) || Char.IsControl(evt.KeyChar))
            {
                evt.Handled = false;
            }
            else
            {
                evt.Handled = true;
            }
        }

        public static void permitir_letras(KeyPressEventArgs evt)
        {
            if (Char.IsLetter(evt.KeyChar) || Char.IsControl(evt.KeyChar) || Char.IsWhiteSpace(evt.KeyChar) || (evt.KeyChar == '.'))
            {
                evt.Handled = false;
            }
            else
            {
                evt.Handled = true;
            }
        }

        public static void permitir_letras_y_numeros(KeyPressEventArgs evt)
        {
            if (Char.IsLetterOrDigit(evt.KeyChar) || Char.IsControl(evt.KeyChar) || Char.IsWhiteSpace(evt.KeyChar) || (evt.KeyChar == '.'))
            {
                evt.Handled = false;
            }
            else
            {
                evt.Handled = true;
            }
        }

        public static void permitir_letras_y_arroba(KeyPressEventArgs evt)
        {
            if (Char.IsLetter(evt.KeyChar) || Char.IsControl(evt.KeyChar) || Char.IsWhiteSpace(evt.KeyChar) || evt.KeyChar == '@' || evt.KeyChar == '.')
            {
                evt.Handled = false;
            }
            else
            {
                evt.Handled = true;
            }
        }
    }
}
