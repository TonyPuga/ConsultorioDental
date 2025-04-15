using ConsultorioDental.WPF.ViewModels.PatientViewModels.PacienteViewModels;
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

        private void DocumentoPaciente_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void DocumentoPaciente_Pasting(object sender, DataObjectPastingEventArgs e)
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

        private void DocumentoApoderado_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void DocumentoApoderado_Pasting(object sender, DataObjectPastingEventArgs e)
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
    }
}
