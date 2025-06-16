using System;
using System.Linq;
using System.Windows.Forms;

namespace Control_de_Ventas_Online
{
    class MoneyTextBox : TextBox
    {
        private bool _isFormatting; // Bandera para evitar reentradas durante el formateo

        public decimal Value
        {
            get
            {
                return GetNumericValue(); // Utiliza GetNumericValue para obtener el valor numérico
            }
            set
            {
                _isFormatting = true;
                Text = $"{value:F2} $"; // Aplica el formato con el símbolo $
                SelectionStart = Text.Length;
                _isFormatting = false;
            }
        }

        /// <summary>
        /// Obtiene el valor numérico del texto actual en el control.
        /// </summary>
        /// <returns>Un número decimal representando el valor actual. Si el texto no es válido, retorna 0.</returns>
        public decimal GetNumericValue()
        {
            // Extrae solo los caracteres válidos: dígitos y el punto decimal
            string numericText = new string(Text.Where(c => char.IsDigit(c) || c == '.').ToArray());

            // Intenta convertir el texto en un valor decimal
            return decimal.TryParse(numericText, out decimal value) ? value : 0m;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (_isFormatting) return;

            _isFormatting = true;

            try
            {
                base.OnTextChanged(e);

                string textoSinSimbolos = new string(Text.Where(c => char.IsDigit(c) || c == '.').ToArray());

                // Permite que el usuario escriba números sin sobrescribir mientras escribe
                if (decimal.TryParse(textoSinSimbolos, out decimal numero))
                {
                    Text = $"{textoSinSimbolos} $"; // Mantiene el símbolo $ mientras escribes
                    SelectionStart = Text.Length; // Mantiene la posición del cursor
                }
                else
                {
                    Text = "$"; // Si el texto es inválido, muestra solo el símbolo $
                    SelectionStart = Text.Length;
                }
            }
            finally
            {
                _isFormatting = false;
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            // Permitir solo números, punto decimal y backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Bloquea cualquier otra tecla
            }

            // Evitar múltiples puntos decimales
            if (e.KeyChar == '.' && Text.Contains('.'))
            {
                e.Handled = true;
            }
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);

            // Aplica el formato final al perder el foco
            string textoSinSimbolos = new string(Text.Where(c => char.IsDigit(c) || c == '.').ToArray());

            if (decimal.TryParse(textoSinSimbolos, out decimal numero))
            {
                Text = $"{numero:F2} $"; // Formato final con símbolo $
            }
            else
            {
                Text = "0.00 $"; // Valor predeterminado si la entrada es inválida
            }
        }
    }
}
