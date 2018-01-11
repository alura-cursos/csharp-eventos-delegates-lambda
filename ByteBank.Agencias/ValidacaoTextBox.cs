using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace ByteBank.Agencias
{
    public delegate void ValidacaoEventHandler(object sender, ValidacaoEventArgs e);

    public class ValidacaoTextBox : TextBox
    {
        private ValidacaoEventHandler _validacao;
        public event ValidacaoEventHandler Validacao
        {
            add
            {
                _validacao += value;
                OnValidacao();
            }
            remove
            {
                _validacao -= value;
            }
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);
            OnValidacao();
        }

        protected virtual void OnValidacao()
        {
            if (_validacao != null)
            {
                var listaValidacao = _validacao.GetInvocationList();
                var eventArgs = new ValidacaoEventArgs(Text);
                var ehValido = true;

                foreach (ValidacaoEventHandler validacao in listaValidacao)
                {
                    validacao(this, eventArgs);

                    if (!eventArgs.EhValido)
                    {
                        ehValido = false;
                        break;
                    }
                }

                Background = ehValido
                    ? new SolidColorBrush(Colors.White)
                    : new SolidColorBrush(Colors.OrangeRed);
            }
        }
    }
}
