﻿#pragma checksum "..\..\Highscore.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E8985C75073C7A752EA55FD7C9D092E3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18063
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace Sudoku {
    
    
    /// <summary>
    /// Highscore
    /// </summary>
    public partial class Highscore : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\Highscore.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.UniformGrid rbGrid;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Highscore.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbL;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Highscore.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbM;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Highscore.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbS;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Highscore.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.FlowDocumentReader highscoreListEasy;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\Highscore.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.TableRowGroup tableRowGroup;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\Highscore.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.TableRowGroup winnersList;
        
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
            System.Uri resourceLocater = new System.Uri("/Sudoku;component/highscore.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Highscore.xaml"
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
            this.rbGrid = ((System.Windows.Controls.Primitives.UniformGrid)(target));
            return;
            case 2:
            this.rbL = ((System.Windows.Controls.RadioButton)(target));
            
            #line 17 "..\..\Highscore.xaml"
            this.rbL.Click += new System.Windows.RoutedEventHandler(this.rb_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.rbM = ((System.Windows.Controls.RadioButton)(target));
            
            #line 18 "..\..\Highscore.xaml"
            this.rbM.Click += new System.Windows.RoutedEventHandler(this.rb_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.rbS = ((System.Windows.Controls.RadioButton)(target));
            
            #line 19 "..\..\Highscore.xaml"
            this.rbS.Click += new System.Windows.RoutedEventHandler(this.rb_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.highscoreListEasy = ((System.Windows.Controls.FlowDocumentReader)(target));
            return;
            case 6:
            this.tableRowGroup = ((System.Windows.Documents.TableRowGroup)(target));
            return;
            case 7:
            this.winnersList = ((System.Windows.Documents.TableRowGroup)(target));
            return;
            case 8:
            
            #line 53 "..\..\Highscore.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.clickOK);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

