﻿#pragma checksum "..\..\..\..\Views\ProductTryingOnControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FE1BFFD972DF0FEF72E929FEA8D5F0D4"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18063
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using MagicMirror.Views;
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


namespace MagicMirror.Views {
    
    
    /// <summary>
    /// ProductTryingOnControl
    /// </summary>
    public partial class ProductTryingOnControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\..\Views\ProductTryingOnControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbSelProducts;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\..\Views\ProductTryingOnControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image productImages;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\..\Views\ProductTryingOnControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image productMutibarCode;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\..\Views\ProductTryingOnControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbName;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\..\Views\ProductTryingOnControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbDesc;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\..\..\Views\ProductTryingOnControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgProduct;
        
        #line default
        #line hidden
        
        
        #line 139 "..\..\..\..\Views\ProductTryingOnControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbMatchedProoducts;
        
        #line default
        #line hidden
        
        
        #line 142 "..\..\..\..\Views\ProductTryingOnControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MagicMirror.Views.MenuButtonGroupBar menuButtons;
        
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
            System.Uri resourceLocater = new System.Uri("/MagicMirror;component/views/producttryingoncontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\ProductTryingOnControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.lbSelProducts = ((System.Windows.Controls.ListBox)(target));
            
            #line 23 "..\..\..\..\Views\ProductTryingOnControl.xaml"
            this.lbSelProducts.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lbProducts_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.productImages = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.productMutibarCode = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.tbName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.tbDesc = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            
            #line 108 "..\..\..\..\Views\ProductTryingOnControl.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.imgProduct = ((System.Windows.Controls.Image)(target));
            return;
            case 8:
            this.lbMatchedProoducts = ((System.Windows.Controls.ListBox)(target));
            return;
            case 9:
            this.menuButtons = ((MagicMirror.Views.MenuButtonGroupBar)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

