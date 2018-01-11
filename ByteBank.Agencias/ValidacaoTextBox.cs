using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace ByteBank.Agencias
{
    public delegate bool ValidacaoEventHandler(string texto);

    public class ValidacaoTextBox : TextBox
    {
        public event ValidacaoEventHandler Validacao;

        public ValidacaoTextBox()
        {
            TextChanged += ValidacaoTextBox_TextChanged;
        }

        private void ValidacaoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(Validacao != null)
            {
                var ehValido = Validacao(Text);

                Background = ehValido
                    ? new SolidColorBrush(Colors.White)
                    : new SolidColorBrush(Colors.OrangeRed);
            }
        }
    }
}
