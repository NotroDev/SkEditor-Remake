﻿#pragma checksum "..\..\InformationsWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "893EA241D6569662E832E59DF7A2E51DF02A38253A803A02FB5045E901E8DCA6"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Editing;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Rendering;
using ICSharpCode.AvalonEdit.Search;
using SkEditorRemake;
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


namespace SkEditorRemake {
    
    
    /// <summary>
    /// InformationsWindow
    /// </summary>
    public partial class InformationsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 75 "..\..\InformationsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image closeButton;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\InformationsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ContactText;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\InformationsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ContactSubText;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\InformationsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock GeneralInfoText;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\InformationsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock GeneralInfoSubText;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\InformationsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ChangelogText;
        
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
            System.Uri resourceLocater = new System.Uri("/SkEditorRemake;component/informationswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\InformationsWindow.xaml"
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
            
            #line 8 "..\..\InformationsWindow.xaml"
            ((SkEditorRemake.InformationsWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            
            #line 17 "..\..\InformationsWindow.xaml"
            ((SkEditorRemake.InformationsWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.closeButton = ((System.Windows.Controls.Image)(target));
            
            #line 81 "..\..\InformationsWindow.xaml"
            this.closeButton.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.closeButton_Click);
            
            #line default
            #line hidden
            
            #line 81 "..\..\InformationsWindow.xaml"
            this.closeButton.MouseEnter += new System.Windows.Input.MouseEventHandler(this.closeButton_MouseEnter);
            
            #line default
            #line hidden
            
            #line 81 "..\..\InformationsWindow.xaml"
            this.closeButton.MouseLeave += new System.Windows.Input.MouseEventHandler(this.closeButton_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 82 "..\..\InformationsWindow.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.nameLabelMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ContactText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.ContactSubText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.GeneralInfoText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.GeneralInfoSubText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.ChangelogText = ((System.Windows.Controls.TextBlock)(target));
            
            #line 88 "..\..\InformationsWindow.xaml"
            this.ChangelogText.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ChangelogText_MouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 88 "..\..\InformationsWindow.xaml"
            this.ChangelogText.MouseEnter += new System.Windows.Input.MouseEventHandler(this.ChangelogText_MouseEnter);
            
            #line default
            #line hidden
            
            #line 88 "..\..\InformationsWindow.xaml"
            this.ChangelogText.MouseLeave += new System.Windows.Input.MouseEventHandler(this.ChangelogText_MouseLeave);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
