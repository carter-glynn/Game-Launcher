﻿#pragma checksum "..\..\..\View\ProfileView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DAB0069D45308D3FB36C1B9A470FB0E6F839A6E0D31ECF5B4427A50A470C8FF7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GameLauncher.ValidateRules;
using GameLauncher.ViewModel;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace GameLauncher.View {
    
    
    /// <summary>
    /// ProfileView
    /// </summary>
    public partial class ProfileView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\View\ProfileView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ProfilePic;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\View\ProfileView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxFirstName;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\View\ProfileView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxLastName;
        
        #line default
        #line hidden
        
        
        #line 163 "..\..\..\View\ProfileView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxUsername;
        
        #line default
        #line hidden
        
        
        #line 209 "..\..\..\View\ProfileView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtEmail;
        
        #line default
        #line hidden
        
        
        #line 254 "..\..\..\View\ProfileView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPass;
        
        #line default
        #line hidden
        
        
        #line 305 "..\..\..\View\ProfileView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUpdate;
        
        #line default
        #line hidden
        
        
        #line 339 "..\..\..\View\ProfileView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEdit;
        
        #line default
        #line hidden
        
        
        #line 371 "..\..\..\View\ProfileView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GameLauncher;component/view/profileview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\ProfileView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ProfilePic = ((System.Windows.Controls.Button)(target));
            return;
            case 2:
            this.tbxFirstName = ((System.Windows.Controls.TextBox)(target));
            
            #line 69 "..\..\..\View\ProfileView.xaml"
            this.tbxFirstName.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.textChangedEventHandler);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tbxLastName = ((System.Windows.Controls.TextBox)(target));
            
            #line 117 "..\..\..\View\ProfileView.xaml"
            this.tbxLastName.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.textChangedEventHandler);
            
            #line default
            #line hidden
            return;
            case 4:
            this.tbxUsername = ((System.Windows.Controls.TextBox)(target));
            
            #line 176 "..\..\..\View\ProfileView.xaml"
            this.tbxUsername.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.textChangedEventHandler);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtEmail = ((System.Windows.Controls.TextBox)(target));
            
            #line 221 "..\..\..\View\ProfileView.xaml"
            this.txtEmail.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.textChangedEventHandler);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txtPass = ((System.Windows.Controls.TextBox)(target));
            
            #line 266 "..\..\..\View\ProfileView.xaml"
            this.txtPass.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.textChangedEventHandler);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnUpdate = ((System.Windows.Controls.Button)(target));
            
            #line 314 "..\..\..\View\ProfileView.xaml"
            this.btnUpdate.Click += new System.Windows.RoutedEventHandler(this.btnUpdate_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnEdit = ((System.Windows.Controls.Button)(target));
            
            #line 347 "..\..\..\View\ProfileView.xaml"
            this.btnEdit.Click += new System.Windows.RoutedEventHandler(this.btnEdit_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 380 "..\..\..\View\ProfileView.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.btnCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

