﻿#pragma checksum "..\..\..\View\GamesView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1C55F22EDEA18C09C3E6057F55BB4C821CD57B5EDC5784C72F14E5E1CD57FA6A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
    /// GamesView
    /// </summary>
    public partial class GamesView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\View\GamesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxUsername;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\View\GamesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSnake;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\View\GamesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnTicTacToe;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\View\GamesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnTetris;
        
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
            System.Uri resourceLocater = new System.Uri("/GameLauncher;component/view/gamesview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\GamesView.xaml"
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
            this.tbxUsername = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.btnSnake = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\..\View\GamesView.xaml"
            this.btnSnake.Click += new System.Windows.RoutedEventHandler(this.btnSnake_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnTicTacToe = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\..\View\GamesView.xaml"
            this.btnTicTacToe.Click += new System.Windows.RoutedEventHandler(this.btnTicTacToe_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnTetris = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\..\View\GamesView.xaml"
            this.btnTetris.Click += new System.Windows.RoutedEventHandler(this.btnTetris_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

