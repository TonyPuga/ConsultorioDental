using ConsultorioDental.WPF.ViewModels.PatientViewModels.PacienteViewModels;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ConsultorioDental.WPF.Views.PatientViews.PacienteViews
{
    /// <summary>
    /// Lógica de interacción para PacienteView.xaml
    /// </summary>
    public partial class PacienteView : UserControl
    {
        public PacienteView()
        {
            InitializeComponent();
            //DataContext = new PacienteViewModel();
        }

        private void Documento_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (DataContext is not PacienteViewModel vm) return;

            if (vm.PermitirSoloNumerosPaciente)
            {
                e.Handled = !e.Text.All(char.IsDigit);
            }
            else
            {
                e.Handled = !e.Text.All(char.IsLetterOrDigit);
            }
        }

        private void Documento_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (DataContext is not PacienteViewModel vm) return;

            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string pastedText = (string)e.DataObject.GetData(typeof(string))!;
                bool esValido = vm.PermitirSoloNumerosPaciente
                    ? pastedText.All(char.IsDigit)
                    : pastedText.All(char.IsLetterOrDigit);

                if (!esValido)
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }        

        private void TextBoxNumeroTelefonico_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (sender is not TextBox textBox) return;

            string nuevoTexto = textBox.Text.Insert(textBox.SelectionStart, e.Text);

            // Eliminar el "+" para contar solo los dígitos
            string textoSinMas = nuevoTexto.StartsWith("+") ? nuevoTexto.Substring(1) : nuevoTexto;

            Regex regex = new(@"^\+?\d*$");
            bool formatoValido = regex.IsMatch(nuevoTexto);
            bool longitudValida = textoSinMas.Length <= 12;

            e.Handled = !(formatoValido && longitudValida);
        }

        private void TextBoxNumeroTelefonico_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)) && sender is TextBox textBox)
            {
                string pastedText = (string)e.DataObject.GetData(typeof(string))!;
                string nuevoTexto = textBox.Text.Insert(textBox.SelectionStart, pastedText);

                string textoSinMas = nuevoTexto.StartsWith("+") ? nuevoTexto.Substring(1) : nuevoTexto;

                Regex regex = new(@"^\+?\d*$");
                bool formatoValido = regex.IsMatch(nuevoTexto);
                bool longitudValida = textoSinMas.Length <= 12;

                if (!(formatoValido && longitudValida))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }
    }
}
