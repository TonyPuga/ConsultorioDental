using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ConsultorioDental.WPF.Controls;

public class PaginacionControl : Control
{
    static PaginacionControl()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(PaginacionControl), new FrameworkPropertyMetadata(typeof(PaginacionControl)));
    }

    public PaginacionControl()
    {
        DependencyPropertyDescriptor dpDescr = DependencyPropertyDescriptor.FromProperty(TextPaginaActualProperty, typeof(PaginacionControl));
        dpDescr.AddValueChanged(this, OnPaginaActualChanged);
    }

    public string TextPaginaActual
    {
        get { return base.GetValue(TextPaginaActualProperty) as string; }
        set
        {
            base.SetValue(TextPaginaActualProperty, value);
        }
    }

    public static readonly DependencyProperty TextPaginaActualProperty =
          DependencyProperty.Register("TextPaginaActual", typeof(string), typeof(PaginacionControl));

    private void OnPaginaActualChanged(object sender, EventArgs e)
    {
        MostrarPaginacion();
    }

    private void OnTotalRegistrosChanged(object sender, EventArgs e)
    {
        MostrarPaginacion();
    }

    private void OnTotalPaginacionChanged(object sender, EventArgs e)
    {
        MostrarPaginacion();
    }

    public string TextTotalRegistros
    {
        get { return base.GetValue(TextTotalRegistrosProperty) as string; }
        set
        {
            base.SetValue(TextTotalRegistrosProperty, value);

        }
    }

    public static readonly DependencyProperty TextTotalRegistrosProperty =
      DependencyProperty.Register("TextTotalRegistros", typeof(string), typeof(PaginacionControl));


    public string TextTotalPaginacion
    {
        get { return (string)base.GetValue(TextTotalPaginacionProperty); }
        set
        {
            base.SetValue(TextTotalPaginacionProperty, value);

        }
    }

    public static readonly DependencyProperty TextTotalPaginacionProperty =
      DependencyProperty.Register("TextTotalPaginacion", typeof(string), typeof(PaginacionControl));


    public object SelectedValueTipoPaginacion
    {
        get { return (object)base.GetValue(SelectedValueTipoPaginacionProperty); }
        set { base.SetValue(SelectedValueTipoPaginacionProperty, value); }
    }

    public static readonly DependencyProperty SelectedValueTipoPaginacionProperty =
      DependencyProperty.Register("SelectedValueTipoPaginacion", typeof(object), typeof(PaginacionControl));


    private void MostrarPaginacion()
    {
        int _paginaActual = Convert.ToInt32(TextPaginaActual);
        int _totalRegistros = Convert.ToInt32(TextTotalRegistros);
        int _totalPaginacion = Convert.ToInt32(TextTotalPaginacion);

        if (_totalPaginacion <= 0)
        {
            return;
        }

        double _totalPaginas = (_totalRegistros / _totalPaginacion);
        double _registroInicialPagina = ((_paginaActual - 1) * _totalPaginacion + 1);
        double _registroFinalPagina = _paginaActual * _totalPaginacion;

        if (_registroFinalPagina > _totalRegistros)
        {
            _registroFinalPagina = ((_paginaActual - 1) * _totalPaginacion) + (_totalRegistros - ((_paginaActual - 1) * _totalPaginacion));
        }

        if (((TextBlock)GetTemplateChild("lblTotalPaginas")) != null)
        {
            TextTotalPaginas = (Math.Truncate(_totalPaginas) + 1).ToString();
            ((TextBlock)GetTemplateChild("lblRegistroInicialVistaActual")).Text = _registroInicialPagina.ToString();
            ((TextBlock)GetTemplateChild("lblRegistroFinalVistaActual")).Text = _registroFinalPagina.ToString();
        }
    }

    public string TextTotalPaginas
    {
        get { return base.GetValue(TextTotalPaginasProperty) as string; }
        set { base.SetValue(TextTotalPaginasProperty, value); }
    }

    public static readonly DependencyProperty TextTotalPaginasProperty =
      DependencyProperty.Register("TextTotalPaginas", typeof(string), typeof(PaginacionControl));

    public ICommand CommandSiguiente
    {
        get { return base.GetValue(CommandSiguienteProperty) as ICommand; }
        set { base.SetValue(CommandSiguienteProperty, value); }
    }

    public static readonly DependencyProperty CommandSiguienteProperty =
      DependencyProperty.Register("CommandSiguiente", typeof(ICommand), typeof(PaginacionControl));

    public ICommand CommandUltimo
    {
        get { return base.GetValue(CommandUltimoProperty) as ICommand; }
        set { base.SetValue(CommandUltimoProperty, value); }
    }

    public static readonly DependencyProperty CommandUltimoProperty =
      DependencyProperty.Register("CommandUltimo", typeof(ICommand), typeof(PaginacionControl));


    public ICommand CommandAnterior
    {
        get { return base.GetValue(CommandAnteriorProperty) as ICommand; }
        set { base.SetValue(CommandAnteriorProperty, value); }
    }

    public static readonly DependencyProperty CommandAnteriorProperty =
      DependencyProperty.Register("CommandAnterior", typeof(ICommand), typeof(PaginacionControl));


    public ICommand CommandPrimero
    {
        get { return base.GetValue(CommandPrimeroProperty) as ICommand; }
        set
        {
            base.SetValue(CommandPrimeroProperty, value);
        }
    }

    public static readonly DependencyProperty CommandPrimeroProperty =
      DependencyProperty.Register("CommandPrimero", typeof(ICommand), typeof(PaginacionControl));
}
