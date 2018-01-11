using ByteBank.Agencias.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ByteBank.Agencias
{
    /// <summary>
    /// Interaction logic for EdicaoAgencia.xaml
    /// </summary>
    public partial class EdicaoAgencia : Window
    {
        private readonly Agencia _agencia;

        public EdicaoAgencia(Agencia agencia)
        {
            InitializeComponent();

            _agencia = agencia ?? throw new ArgumentNullException(nameof(agencia));
            AtualizarCamposDeTexto();
            AtualizarControles();
        }

        private void AtualizarCamposDeTexto()
        {
            txtNumero.Text = _agencia.Numero;
            txtNome.Text = _agencia.Nome;
            txtTelefone.Text = _agencia.Telefone;
            txtEndereco.Text = _agencia.Endereco;
            txtDescricao.Text = _agencia.Descricao;
        }

        private void AtualizarControles()
        {
            RoutedEventHandler dialogResultTrue = (o, e) => DialogResult = true;
            RoutedEventHandler dialogResultFalse = (o, e) => DialogResult = false;

            var okEventHandler = dialogResultTrue + Fechar;
            var cancelarEventHandler = dialogResultFalse + Fechar;

            btnOk.Click += okEventHandler;
            btnCancelar.Click += cancelarEventHandler;

            txtNome.TextChanged += TxtNome_TextChanged;
            txtDescricao.TextChanged += TxtDescricao_TextChanged;
            txtEndereco.TextChanged += TxtEndereco_TextChanged;
            txtNumero.TextChanged += TxtNumero_TextChanged;
            txtTelefone.TextChanged += TxtTelefone_TextChanged;
        }

        private void TxtTelefone_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textoEstaVazio = String.IsNullOrEmpty(txtTelefone.Text);

            if (textoEstaVazio)
                txtTelefone.Background = new SolidColorBrush(Colors.OrangeRed);
            else
                txtTelefone.Background = new SolidColorBrush(Colors.White);
        }

        private void TxtNumero_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textoEstaVazio = String.IsNullOrEmpty(txtNumero.Text);

            if (textoEstaVazio)
                txtNumero.Background = new SolidColorBrush(Colors.OrangeRed);
            else
                txtNumero.Background = new SolidColorBrush(Colors.White);
        }

        private void TxtEndereco_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textoEstaVazio = String.IsNullOrEmpty(txtEndereco.Text);

            if (textoEstaVazio)
                txtEndereco.Background = new SolidColorBrush(Colors.OrangeRed);
            else
                txtEndereco.Background = new SolidColorBrush(Colors.White);
        }

        private void TxtDescricao_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textoEstaVazio = String.IsNullOrEmpty(txtDescricao.Text);

            if (textoEstaVazio)
                txtDescricao.Background = new SolidColorBrush(Colors.OrangeRed);
            else
                txtDescricao.Background = new SolidColorBrush(Colors.White);
        }

        private void TxtNome_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textoEstaVazio = String.IsNullOrEmpty(txtNome.Text);

            if (textoEstaVazio)
                txtNome.Background = new SolidColorBrush(Colors.OrangeRed);
            else
                txtNome.Background = new SolidColorBrush(Colors.White);
        }

        private void Fechar(object sender, EventArgs e) =>
            Close();
    }
}