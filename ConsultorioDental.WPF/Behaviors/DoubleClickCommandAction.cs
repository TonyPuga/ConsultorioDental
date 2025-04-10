using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace ConsultorioDental.WPF.Behaviors;

public class DoubleClickCommandAction : Behavior<Control>
{
    private bool _isValidEvent = true;

    public ICommand Command
    {
        get { return (ICommand)GetValue(CommandProperty); }
        set { SetValue(CommandProperty, value); }
    }

    public static readonly DependencyProperty CommandProperty =
        DependencyProperty.Register(nameof(Command), typeof(ICommand), typeof(DoubleClickCommandAction), new PropertyMetadata(null));

    public object CommandParameter
    {
        get { return (object)GetValue(CommandParameterProperty); }
        set { SetValue(CommandParameterProperty, value); }
    }

    public static readonly DependencyProperty CommandParameterProperty =
        DependencyProperty.Register(nameof(CommandParameter), typeof(object), typeof(DoubleClickCommandAction), new PropertyMetadata(null));

    protected override void OnAttached()
    {
        base.OnAttached();
        if (this.AssociatedObject != null)
        {
            AssociatedObject.MouseDoubleClick += AssociatedObject_MouseDoubleClick;
            AssociatedObject.Loaded += AssociatedObject_Loaded;
        }                   
    }

    protected override void OnDetaching()
    {
        base.OnDetaching();

        if (AssociatedObject != null)
        {
            AssociatedObject.MouseDoubleClick -= AssociatedObject_MouseDoubleClick;
            AssociatedObject.Loaded -= AssociatedObject_Loaded;
        }
    }


    private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
    {
        if (AssociatedObject is DataGrid dataGrid)
        {
            // Buscamos el ScrollViewer en el template del DataGrid
            var scrollViewer = dataGrid.Template.FindName("DG_ScrollViewer", dataGrid) as ScrollViewer;
            if (scrollViewer != null)
            {
                // Adjuntamos evento en el scrollbar vertical
                var verticalScrollBar = scrollViewer.Template.FindName("PART_VerticalScrollBar", scrollViewer) as ScrollBar;
                if (verticalScrollBar != null)
                {
                    verticalScrollBar.MouseDoubleClick += (s, a) => { _isValidEvent = false; };
                }

                // Adjuntamos evento en el scrollbar horizontal
                var horizontalScrollBar = scrollViewer.Template.FindName("PART_HorizontalScrollBar", scrollViewer) as ScrollBar;
                if (horizontalScrollBar != null)
                {
                    horizontalScrollBar.MouseDoubleClick += (s, a) => { _isValidEvent = false; };
                }

                // Adjuntamos evento en el presentador de cabeceras de columnas
                var headersPresenter = scrollViewer.Template.FindName("PART_ColumnHeadersPresenter", scrollViewer) as DataGridColumnHeadersPresenter;
                if (headersPresenter != null)
                {
                    headersPresenter.MouseDoubleClick += (s, a) => { _isValidEvent = false; };
                }
            }
        }
    }

    private void AssociatedObject_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        // Si el flag indica que es un doble clic válido y el origen
        // no es un ScrollViewer, ejecutamos el comando
        if (_isValidEvent && !(e.OriginalSource is ScrollViewer))
        {
            if (Command != null && Command.CanExecute(CommandParameter))
            {
                Command.Execute(CommandParameter);
            }
        }

        // Reiniciamos el flag para el siguiente doble clic
        _isValidEvent = true;

    }
}
