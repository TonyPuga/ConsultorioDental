﻿using System.Windows.Controls;
using System.Windows;

namespace ConsultorioDental.WPF.Helpers;

public class PasswordBoxHelper
{
    public static readonly DependencyProperty BoundPasswordProperty =
            DependencyProperty.RegisterAttached("BoundPassword", typeof(string), typeof(PasswordBoxHelper), new PropertyMetadata(string.Empty, OnBoundPasswordChanged));

    public static readonly DependencyProperty BindPasswordProperty =
        DependencyProperty.RegisterAttached("BindPassword", typeof(bool), typeof(PasswordBoxHelper), new PropertyMetadata(false, OnBindPasswordChanged));

    private static readonly DependencyProperty UpdatingPasswordProperty =
        DependencyProperty.RegisterAttached("UpdatingPassword", typeof(bool), typeof(PasswordBoxHelper), new PropertyMetadata(false));

    public static string GetBoundPassword(DependencyObject dp)
    {
        return (string)dp.GetValue(BoundPasswordProperty);
    }

    public static void SetBoundPassword(DependencyObject dp, string value)
    {
        dp.SetValue(BoundPasswordProperty, value);
    }

    public static bool GetBindPassword(DependencyObject dp)
    {
        return (bool)dp.GetValue(BindPasswordProperty);
    }

    public static void SetBindPassword(DependencyObject dp, bool value)
    {
        dp.SetValue(BindPasswordProperty, value);
    }

    private static bool GetUpdatingPassword(DependencyObject dp)
    {
        return (bool)dp.GetValue(UpdatingPasswordProperty);
    }

    private static void SetUpdatingPassword(DependencyObject dp, bool value)
    {
        dp.SetValue(UpdatingPasswordProperty, value);
    }

    private static void OnBoundPasswordChanged(DependencyObject dp, DependencyPropertyChangedEventArgs e)
    {
        var box = dp as PasswordBox;
        if (box == null || !GetBindPassword(dp)) return;

        box.PasswordChanged -= HandlePasswordChanged;

        var newPassword = (string)e.NewValue;

        if (!GetUpdatingPassword(box))
        {
            box.Password = newPassword;
        }

        box.PasswordChanged += HandlePasswordChanged;
    }

    private static void OnBindPasswordChanged(DependencyObject dp, DependencyPropertyChangedEventArgs e)
    {
        var box = dp as PasswordBox;
        if (box == null) return;

        var wasBound = (bool)(e.OldValue);
        var needToBind = (bool)(e.NewValue);

        if (wasBound)
        {
            box.PasswordChanged -= HandlePasswordChanged;
        }

        if (needToBind)
        {
            box.PasswordChanged += HandlePasswordChanged;
        }
    }

    private static void HandlePasswordChanged(object sender, RoutedEventArgs e)
    {
        var box = sender as PasswordBox;
        SetUpdatingPassword(box, true);
        SetBoundPassword(box, box.Password);
        SetUpdatingPassword(box, false);
    }
}