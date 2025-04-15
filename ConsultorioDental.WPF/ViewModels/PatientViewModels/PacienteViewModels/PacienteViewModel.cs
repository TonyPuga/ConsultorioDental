using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ConsultorioDental.WPF.Models.AdministracionModels.TipoModels;
using ConsultorioDental.WPF.Models.AdministracionModels.UbigeoModels;
using ConsultorioDental.WPF.Models.Enums;
using ConsultorioDental.WPF.Repositories.Administracion.Tipo;
using ConsultorioDental.WPF.Repositories.Administracion.Ubigeo;
using ConsultorioDental.WPF.Views.PatientViews.PacienteViews;
using System.Collections.ObjectModel;

namespace ConsultorioDental.WPF.ViewModels.PatientViewModels.PacienteViewModels;

public partial class PacienteViewModel : ObservableObject
{
    private readonly PatientViewModel _modulo;
    private readonly IDepartamentoRepository _departamentoRepository;
    private readonly IProvinciaRepository _provinciaRepository;
    private readonly IDistritoRepository _distritoRepository;
    private readonly ITipoRepository _tipoRepository;

    public PacienteViewModel(PatientViewModel modulo,
                        IDepartamentoRepository departamentoRepository,
                        IProvinciaRepository provinciaRepository,
                        IDistritoRepository distritoRepository,
                        ITipoRepository tipoRepository)
    {
        _modulo = modulo;
        _departamentoRepository = departamentoRepository;
        _provinciaRepository = provinciaRepository;
        _distritoRepository = distritoRepository;
        _tipoRepository = tipoRepository;

        DepartamentosPaciente = new ObservableCollection<DepartamentoModel>();
        DepartamentosApoderado = new ObservableCollection<DepartamentoModel>();

        FechaNacimientoPacienteSeleccionada = DateTime.Now;
        FechaNacimientoApoderadoSeleccionado = DateTime.Now;

        EsMenorDeEdad = false;
        CargarDepartamentos();
        CargarTipo();
    }

    [ObservableProperty]
    private ObservableCollection<DepartamentoModel> departamentosPaciente;
    
    [ObservableProperty]
    private ObservableCollection<DepartamentoModel> departamentosApoderado;

    [ObservableProperty]
    private ObservableCollection<ProvinciaModel> provinciasPaciente;

    [ObservableProperty]
    private ObservableCollection<ProvinciaModel> provinciasApoderado;

    [ObservableProperty]
    private ObservableCollection<DistritoModel> distritosPaciente;

    [ObservableProperty]
    private ObservableCollection<DistritoModel> distritosApoderado;

    [ObservableProperty]
    private ObservableCollection<TipoModel> tiposDOIPaciente;

    [ObservableProperty]
    private ObservableCollection<TipoModel> tiposDOIApoderado;

    [ObservableProperty]
    private ObservableCollection<TipoModel> tiposParentesco;

    [ObservableProperty]
    private int logitudDocumentoPaciente;

    [ObservableProperty]
    private int logitudDocumentoApoderado;

    [ObservableProperty]
    private bool permitirSoloNumerosPaciente;

    [ObservableProperty]
    private bool permitirSoloNumerosApoderado;

    #region Propiedades Paciente
    [ObservableProperty]
    private string apellidoPaternoPaciente;
    partial void OnApellidoPaternoPacienteChanged(string value) => GuardarCommand.NotifyCanExecuteChanged();

    [ObservableProperty]
    private string apellidoMaternoPaciente;
    partial void OnApellidoMaternoPacienteChanged(string value) => GuardarCommand.NotifyCanExecuteChanged();

    [ObservableProperty]
    private string nombrePaciente;
    partial void OnNombrePacienteChanged(string value) => GuardarCommand.NotifyCanExecuteChanged();

    [ObservableProperty]
    private bool esMenorDeEdad;

    [ObservableProperty]
    private DateTime fechaNacimientoPacienteSeleccionada;
    partial void OnFechaNacimientoPacienteSeleccionadaChanged(DateTime value)
    {
        if (value != null)
        {
            var edad = DateTime.Now.Year - value.Year;
            if (DateTime.Now.DayOfYear < value.DayOfYear)
            {
                edad--;
            }
            EsMenorDeEdad = edad < 18;
        }

        GuardarCommand.NotifyCanExecuteChanged();
    }

    [ObservableProperty]
    private TipoModel tipoDOIPacienteSeleccionado;
    partial void OnTipoDOIPacienteSeleccionadoChanged(TipoModel value)
    {
        if (value != null)
        {
            DocumentoPaciente = string.Empty;

            if(value.Longitud_Tipo != null)
            {
                LogitudDocumentoPaciente = (int)value.Longitud_Tipo;
            }

            PermitirSoloNumerosPaciente = value.IdTipo == (int)TipoDOIEnum.DNI || value.IdTipo == (int)TipoDOIEnum.RUC;
        }
        GuardarCommand.NotifyCanExecuteChanged();
    }

    [ObservableProperty]
    private string documentoPaciente;
    partial void OnDocumentoPacienteChanged(string value)
    {
        if (value != null)
        {
            if (value.Length > LogitudDocumentoPaciente)
            {
                DocumentoPaciente = value.Substring(0, LogitudDocumentoPaciente);
            }
        }
        GuardarCommand.NotifyCanExecuteChanged();
    }

    [ObservableProperty]
    private string direccionPaciente;
    partial void OnDireccionPacienteChanged(string value) => GuardarCommand.NotifyCanExecuteChanged();

    [ObservableProperty]
    private string referenciaDireccionPaciente;
    partial void OnReferenciaDireccionPacienteChanged(string value) => GuardarCommand.NotifyCanExecuteChanged();

    [ObservableProperty]
    private DepartamentoModel? departamentoSeleccionadoPaciente;
    partial void OnDepartamentoSeleccionadoPacienteChanged(DepartamentoModel? value)
    {
        if (value != null)
        {
            CargarProvinciasPaciente(value.IdDepartamento);
        }

        ProvinciaSeleccionadaPaciente = null;
        GuardarCommand.NotifyCanExecuteChanged();
    }

    [ObservableProperty]
    private ProvinciaModel? provinciaSeleccionadaPaciente;
    partial void OnProvinciaSeleccionadaPacienteChanged(ProvinciaModel? value)
    {
        if (value != null)
        {
            CargarDistritosPaciente(value.IdProvincia);
        }

        DistritoSeleccionadoPaciente = null;
        GuardarCommand.NotifyCanExecuteChanged();
    }

    [ObservableProperty]
    private DistritoModel? distritoSeleccionadoPaciente;
    partial void OnDistritoSeleccionadoPacienteChanged(DistritoModel? value) => GuardarCommand.NotifyCanExecuteChanged();

    [ObservableProperty]
    private string emailPaciente;
    partial void OnEmailPacienteChanged(string value) => GuardarCommand.NotifyCanExecuteChanged();

    [ObservableProperty]
    private string telefonoPaciente;
    partial void OnTelefonoPacienteChanged(string value) => GuardarCommand.NotifyCanExecuteChanged();
    #endregion Propiedades Paciente

    #region Propiedades Apoderado
    [ObservableProperty]
    private string apellidoPaternoApoderado;
    partial void OnApellidoPaternoApoderadoChanged(string value) => GuardarCommand.NotifyCanExecuteChanged();

    [ObservableProperty]
    private string apellidoMaternoApoderado;
    partial void OnApellidoMaternoApoderadoChanged(string value) => GuardarCommand.NotifyCanExecuteChanged();

    [ObservableProperty]
    private string nombreApoderado;
    partial void OnNombreApoderadoChanged(string value) => GuardarCommand.NotifyCanExecuteChanged();
        
    [ObservableProperty]
    private DateTime fechaNacimientoApoderadoSeleccionado;
    partial void OnFechaNacimientoApoderadoSeleccionadoChanged(DateTime value) => GuardarCommand.NotifyCanExecuteChanged();

    [ObservableProperty]
    private TipoModel tipoDOIApoderadoSeleccionado;
    partial void OnTipoDOIApoderadoSeleccionadoChanged(TipoModel value)
    {
        if (value != null)
        {
            DocumentoApoderado = string.Empty;
            if (value.Longitud_Tipo != null)
            {
                LogitudDocumentoApoderado = (int)value.Longitud_Tipo;
            }

           PermitirSoloNumerosApoderado = value.IdTipo == (int)TipoDOIEnum.DNI || value.IdTipo == (int)TipoDOIEnum.RUC;
        }
        GuardarCommand.NotifyCanExecuteChanged();
    }

    [ObservableProperty]
    private string documentoApoderado;
    partial void OnDocumentoApoderadoChanged(string value)
    {
        if (value != null)
        {
            if (value.Length > LogitudDocumentoApoderado)
            {
                DocumentoApoderado = value.Substring(0, LogitudDocumentoApoderado);
            }
        }
        GuardarCommand.NotifyCanExecuteChanged();
    }

    [ObservableProperty]
    private int idTipoParentesco;
    partial void OnIdTipoParentescoChanged(int value) => GuardarCommand.NotifyCanExecuteChanged();

    [ObservableProperty]
    private string direccionApoderado;
    partial void OnDireccionApoderadoChanged(string value) => GuardarCommand.NotifyCanExecuteChanged();

    [ObservableProperty]
    private string referenciaDireccionApoderado;
    partial void OnReferenciaDireccionApoderadoChanged(string value) => GuardarCommand.NotifyCanExecuteChanged();

    [ObservableProperty]
    private DepartamentoModel? departamentoSeleccionadoApoderado;
    partial void OnDepartamentoSeleccionadoApoderadoChanged(DepartamentoModel? value)
    {
        if (value != null)
        {
            CargarProvinciasApoderado(value.IdDepartamento);
        }

        ProvinciaSeleccionadaApoderado = null;
        GuardarCommand.NotifyCanExecuteChanged();
    }

    [ObservableProperty]
    private ProvinciaModel? provinciaSeleccionadaApoderado;
    partial void OnProvinciaSeleccionadaApoderadoChanged(ProvinciaModel? value)
    {
        if (value != null)
        {
            CargarDistritosApoderado(value.IdProvincia);
        }

        DistritoSeleccionadoApoderado = null;
        GuardarCommand.NotifyCanExecuteChanged();
    }

    [ObservableProperty]
    private DistritoModel? distritoSeleccionadoApoderado;
    partial void OnDistritoSeleccionadoApoderadoChanged(DistritoModel? value) => GuardarCommand.NotifyCanExecuteChanged();

    [ObservableProperty]
    private string emailApoderado;
    partial void OnEmailApoderadoChanged(string value) => GuardarCommand.NotifyCanExecuteChanged();

    [ObservableProperty]
    private string telefonoApoderado;
    partial void OnTelefonoApoderadoChanged(string value) => GuardarCommand.NotifyCanExecuteChanged();
    #endregion Propiedades Apoderado

    private void CargarProvinciasPaciente(int idDepartamento)
    {
        if (ProvinciasPaciente != null)
        {
            ProvinciasPaciente.Clear();
        }

        ProvinciasPaciente = new ObservableCollection<ProvinciaModel>(_provinciaRepository.ListarProvinciaTodo(idDepartamento));
    }

    private void CargarProvinciasApoderado(int idDepartamento)
    {
        if (ProvinciasApoderado != null)
        {
            ProvinciasApoderado.Clear();
        }

        ProvinciasApoderado = new ObservableCollection<ProvinciaModel>(_provinciaRepository.ListarProvinciaTodo(idDepartamento));
    }

    private void CargarDistritosPaciente(int idProvincia)
    {
        if (DistritosPaciente != null)
        {
            DistritosPaciente.Clear();
        }

        DistritosPaciente = new ObservableCollection<DistritoModel>(_distritoRepository.ListarDistritoTodo(idProvincia));
    }

    private void CargarDistritosApoderado(int idProvincia)
    {
        if (DistritosApoderado != null)
        {
            DistritosApoderado.Clear();
        }

        DistritosApoderado = new ObservableCollection<DistritoModel>(_distritoRepository.ListarDistritoTodo(idProvincia));
    }

    [RelayCommand(CanExecute = nameof(CanGuardar))]
    private void Guardar()
    {

    }

    private bool CanGuardar()
    {
        bool datosPacienteValidos =
        !string.IsNullOrWhiteSpace(ApellidoPaternoPaciente)
        && !string.IsNullOrWhiteSpace(ApellidoMaternoPaciente)
        && !string.IsNullOrWhiteSpace(NombrePaciente)
        && FechaNacimientoPacienteSeleccionada != DateTime.Now
        && TipoDOIPacienteSeleccionado != null
        && !string.IsNullOrWhiteSpace(DocumentoPaciente)
        && !string.IsNullOrWhiteSpace(DireccionPaciente)
        && !string.IsNullOrWhiteSpace(ReferenciaDireccionPaciente)
        && DepartamentoSeleccionadoPaciente != null
        && ProvinciaSeleccionadaPaciente != null
        && DistritoSeleccionadoPaciente != null
        && !string.IsNullOrWhiteSpace(EmailPaciente)
        && !string.IsNullOrWhiteSpace(TelefonoPaciente);

        bool datosApoderadoValidos = true;
        if (EsMenorDeEdad)
        {
            datosApoderadoValidos =
                !string.IsNullOrWhiteSpace(ApellidoPaternoApoderado)
                && !string.IsNullOrWhiteSpace(ApellidoMaternoApoderado)
                && !string.IsNullOrWhiteSpace(NombreApoderado)
                && FechaNacimientoApoderadoSeleccionado != DateTime.Now
                && TipoDOIApoderadoSeleccionado != null
                && !string.IsNullOrWhiteSpace(DocumentoApoderado)
                && IdTipoParentesco != 0
                && !string.IsNullOrWhiteSpace(DireccionApoderado)
                && !string.IsNullOrWhiteSpace(ReferenciaDireccionApoderado)
                && DepartamentoSeleccionadoApoderado != null
                && ProvinciaSeleccionadaApoderado != null
                && DistritoSeleccionadoApoderado != null
                && !string.IsNullOrWhiteSpace(EmailApoderado)
                && !string.IsNullOrWhiteSpace(TelefonoApoderado); 
        }

        return datosPacienteValidos && datosApoderadoValidos;
    }

    [RelayCommand]
    private void Regresar()
    {
        var viewModel = new PacienteBusquedaViewModel(_modulo);
        var view = new PacienteBusquedaView
        {
            DataContext = viewModel
        };

        _modulo.ContenidoActual = view;
    }

    private void CargarDepartamentos()
    {
        DepartamentosPaciente.Clear();
        DepartamentosApoderado.Clear();

        DepartamentosPaciente = new ObservableCollection<DepartamentoModel>(_departamentoRepository.ListarDepartamentoTodo());
        DepartamentosApoderado = new ObservableCollection<DepartamentoModel>(_departamentoRepository.ListarDepartamentoTodo());
    }

    private void CargarTipo()
    {
        TiposDOIPaciente = new ObservableCollection<TipoModel>(_tipoRepository.ListarTipoPorSupertipoId((int)SuperTipoEnum.TipoDOI));
        TiposDOIApoderado = new ObservableCollection<TipoModel>(_tipoRepository.ListarTipoPorSupertipoId((int)SuperTipoEnum.TipoDOI));

        TiposParentesco = new ObservableCollection<TipoModel>(_tipoRepository.ListarTipoPorSupertipoId((int)SuperTipoEnum.Parentesco));
    }
}