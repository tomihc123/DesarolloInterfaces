﻿#pragma checksum "C:\Users\thuecas\Desktop\DesarolloInterfaces\Proyecto\Uwp\Views\MainPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "22E2297A9647BCED6FB9C2BF4D3B3C03457C67885F79D7EE5200774E071B9C80"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Uwp.Views
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
            case 2: // Views\MainPage.xaml line 12
                {
                    this.NavigationPrinciapl = (global::Windows.UI.Xaml.Controls.NavigationView)(target);
                    ((global::Windows.UI.Xaml.Controls.NavigationView)this.NavigationPrinciapl).SelectionChanged += this.NavigationPrinciapl_SelectionChanged;
                }
                break;
            case 3: // Views\MainPage.xaml line 16
                {
                    this.NavPersonas = (global::Windows.UI.Xaml.Controls.NavigationViewItem)(target);
                }
                break;
            case 4: // Views\MainPage.xaml line 17
                {
                    this.NavDepartamentos = (global::Windows.UI.Xaml.Controls.NavigationViewItem)(target);
                }
                break;
            case 5: // Views\MainPage.xaml line 20
                {
                    this.ContentFrame = (global::Windows.UI.Xaml.Controls.Frame)(target);
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
