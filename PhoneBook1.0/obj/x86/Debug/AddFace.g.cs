﻿#pragma checksum "E:\大三\phonebook\PhoneBook β1.0\AddFace.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3D6D1D4B4A03EE1F563BBB2B0615C86F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhoneBook_β1._0
{
    partial class AddFace : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    global::Windows.UI.Xaml.Controls.StackPanel element1 = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                    #line 57 "..\..\..\AddFace.xaml"
                    ((global::Windows.UI.Xaml.Controls.StackPanel)element1).Drop += this.StackPanel_Drop;
                    #line 57 "..\..\..\AddFace.xaml"
                    ((global::Windows.UI.Xaml.Controls.StackPanel)element1).DragOver += this.StackPanel_DragOver;
                    #line default
                }
                break;
            case 2:
                {
                    this.textblock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 3:
                {
                    this.ellipseWithImageBrush = (global::Windows.UI.Xaml.Shapes.Ellipse)(target);
                }
                break;
            case 4:
                {
                    this.txtAddName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5:
                {
                    this.txtAddnum = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6:
                {
                    this.txtAddbir = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 7:
                {
                    this.txtAddcity = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 8:
                {
                    this.txtAddmail = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 9:
                {
                    this.AddImage = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 10:
                {
                    this.Addbutton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 89 "..\..\..\AddFace.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.Addbutton).Click += this.BtnAdd_Click;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

