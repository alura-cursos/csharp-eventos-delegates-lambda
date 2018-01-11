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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ByteBank.Agencias
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ByteBankEntities _contextoBancoDeDados = new ByteBankEntities();
        private readonly ListBox lstAgencias;

        public MainWindow()
        {
            InitializeComponent();

            lstAgencias = new ListBox();

            AtualizarControles();
            AtualizarListaDeAgencias();
        }

        private void AtualizarControles()
        {
            lstAgencias.Width = 270;
            lstAgencias.Height = 290;

            Canvas.SetTop(lstAgencias, 15);
            Canvas.SetLeft(lstAgencias, 15);

            lstAgencias.SelectionChanged += new SelectionChangedEventHandler(lstAgencias_SelectionChanged);

            container.Children.Add(lstAgencias);

            btnEditar.Click += new RoutedEventHandler(btnEditar_Click);
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            var agenciaAtual = (Agencia)lstAgencias.SelectedItem;
            var janelaEdicao = new EdicaoAgencia(agenciaAtual);

            var resultado = janelaEdicao.ShowDialog().Value;

            if (resultado)
            {
                // Usuario clicou em Ok
            }
            else
            {
                // Usuario clicou em Cancelar
            }

        }

        private void AtualizarListaDeAgencias()
        {
            lstAgencias.Items.Clear();
            var agencias = _contextoBancoDeDados.Agencias.ToList();
            foreach (var agencia in agencias)
                lstAgencias.Items.Add(agencia);
        }

        private void lstAgencias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var agenciaSelecionada = (Agencia)lstAgencias.SelectedItem;

            txtNumero.Text = agenciaSelecionada.Numero;
            txtNome.Text = agenciaSelecionada.Nome;
            txtTelefone.Text = agenciaSelecionada.Telefone;
            txtEndereco.Text = agenciaSelecionada.Endereco;
            txtDescricao.Text = agenciaSelecionada.Descricao;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var confirmacao = 
                MessageBox.Show(
                    "Você deseja realmente excluir este item?",
                    "Confirmação",
                    MessageBoxButton.YesNo);
            if (confirmacao == MessageBoxResult.Yes)
            {
                //Excluir
            }
            else
            {
                //Não faz nada
            }
        }
    }
}
