﻿#pragma checksum "C:\Users\TxHxTxHxT\Desktop\DesarolloInterfaces\Solaris\Solaris\MainPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5390F1E53231C22C287CC2C1C6126E424AC6C12C96FE80632D360D76B08FB305"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Solaris
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // MainPage.xaml line 20
                {
                    this.bar = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 3: // MainPage.xaml line 29
                {
                    this.Login = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 4: // MainPage.xaml line 45
                {
                    this.txtforgetPassword = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5: // MainPage.xaml line 47
                {
                    this.btnLogin = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnLogin).Click += this.btnLogin_Click;
                }
                break;
            case 6: // MainPage.xaml line 32
                {
                    this.tbxUsername = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 7: // MainPage.xaml line 34
                {
                    this.tbxPassword = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 8: // MainPage.xaml line 36
                {
                    this.txtErrorUser = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 9: // MainPage.xaml line 22
                {
                    this.txtTittle = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

