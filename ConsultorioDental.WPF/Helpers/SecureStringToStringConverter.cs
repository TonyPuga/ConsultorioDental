using System.Globalization;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Data;

namespace ConsultorioDental.WPF.Helpers;

public class SecureStringToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is SecureString secureString)
        {
            return ConvertToUnsecureString(secureString);
        }
        return string.Empty;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string str)
        {
            return ConvertToSecureString(str);
        }
        return null;
    }

    private string ConvertToUnsecureString(SecureString secureString)
    {
        IntPtr unmanagedString = IntPtr.Zero;
        try
        {
            unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
            return Marshal.PtrToStringUni(unmanagedString);
        }
        finally
        {
            Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
        }
    }

    private SecureString ConvertToSecureString(string str)
    {
        var secureString = new SecureString();
        foreach (char c in str)
        {
            secureString.AppendChar(c);
        }
        secureString.MakeReadOnly();
        return secureString;
    }
}