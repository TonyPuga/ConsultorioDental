using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ConsultorioDental.WPF.Controls;

public class SeccionControl : ContentControl
{
	static SeccionControl()
	{
        DefaultStyleKeyProperty.OverrideMetadata(typeof(SeccionControl), new FrameworkPropertyMetadata(typeof(SeccionControl)));
    }

    public string TituloSeccion
    {
        get { return base.GetValue(TituloSeccionProperty) as string; }
        set { base.SetValue(TituloSeccionProperty, value); }
    }

    public static readonly DependencyProperty TituloSeccionProperty =
      DependencyProperty.Register("TituloSeccion", typeof(string), typeof(SeccionControl));

    public string TituloSeccion1
    {
        get { return base.GetValue(TituloSeccion1Property) as string; }
        set { base.SetValue(TituloSeccion1Property, value); }
    }

    public static readonly DependencyProperty TituloSeccion1Property =
      DependencyProperty.Register("TituloSeccion1", typeof(string), typeof(SeccionControl));

    public ImageSource ImagenSeccion
    {
        get { return base.GetValue(ImagenSeccionProperty) as ImageSource; }
        set { base.SetValue(ImagenSeccionProperty, value); }
    }

    public string ValorTituloSeccion
    {
        get { return base.GetValue(ValorTituloSeccionProperty) as string; }
        set { base.SetValue(ValorTituloSeccionProperty, value); }
    }
    public static readonly DependencyProperty ValorTituloSeccionProperty =
      DependencyProperty.Register("ValorTituloSeccion", typeof(string), typeof(SeccionControl));


    public string ValorTituloSeccion1
    {
        get { return base.GetValue(ValorTituloSeccion1Property) as string; }
        set { base.SetValue(ValorTituloSeccion1Property, value); }
    }
    public static readonly DependencyProperty ValorTituloSeccion1Property =
      DependencyProperty.Register("ValorTituloSeccion1", typeof(string), typeof(SeccionControl));


    public static readonly DependencyProperty ImagenSeccionProperty =
      DependencyProperty.Register("ImagenSeccion", typeof(ImageSource), typeof(SeccionControl));


    public string TituloDerecha
    {
        get { return base.GetValue(TituloDerechaProperty) as string; }
        set { base.SetValue(TituloDerechaProperty, value); }
    }

    public static readonly DependencyProperty TituloDerechaProperty =
      DependencyProperty.Register("TituloDerecha", typeof(string), typeof(SeccionControl));

    public string ValorTituloDerecha
    {
        get { return base.GetValue(ValorTituloDerechaProperty) as string; }
        set { base.SetValue(ValorTituloDerechaProperty, value); }
    }

    public static readonly DependencyProperty ValorTituloDerechaProperty =
      DependencyProperty.Register("ValorTituloDerecha", typeof(string), typeof(SeccionControl));

    public string TituloDerecha1
    {
        get { return base.GetValue(TituloDerecha1Property) as string; }
        set { base.SetValue(TituloDerecha1Property, value); }
    }

    public static readonly DependencyProperty TituloDerecha1Property =
      DependencyProperty.Register("TituloDerecha1", typeof(string), typeof(SeccionControl));

    public string ValorTituloDerecha1
    {
        get { return base.GetValue(ValorTituloDerecha1Property) as string; }
        set { base.SetValue(ValorTituloDerecha1Property, value); }
    }

    public static readonly DependencyProperty ValorTituloDerecha1Property =
      DependencyProperty.Register("ValorTituloDerecha1", typeof(string), typeof(SeccionControl));

}
