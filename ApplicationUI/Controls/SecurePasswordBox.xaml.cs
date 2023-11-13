﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ApplicationUI.Controls;

/// <summary>
/// Interaction logic for SecurePasswordBox.xaml
/// </summary>
public partial class SecurePasswordBox : UserControl
{
    private bool _isPasswordChanging;

    public static readonly DependencyProperty PasswordProperty =
        DependencyProperty.Register("Password", typeof(string), typeof(SecurePasswordBox),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                PasswordPropertyChanged, null, false, UpdateSourceTrigger.PropertyChanged));

    private static void PasswordPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is SecurePasswordBox passwordBox)
        {
            passwordBox.UpdatePassword();
        }
    }

    public string Password
    {
        get { return (string)GetValue(PasswordProperty); }
        set { SetValue(PasswordProperty, value); }
    }

    public SecurePasswordBox()
    {
        InitializeComponent();
    }

    private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        _isPasswordChanging = true;
        Password = passwordBox.Password;
        _isPasswordChanging = false;
    }

    private void UpdatePassword()
    {
        if (!_isPasswordChanging)
        {
            passwordBox.Password = Password;
        }
    }
}