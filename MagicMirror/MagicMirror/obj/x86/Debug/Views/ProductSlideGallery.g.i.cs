﻿#pragma checksum "..\..\..\..\Views\ProductSlideGallery.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "423B0935D70A790E612C887C5DFA5C66"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18063
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using MagicMirror.Util;
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
    /// ProductSlideGallery
    /// </summary>
    public partial class ProductSlideGallery : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 44 "..\..\..\..\Views\ProductSlideGallery.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid RootGrid;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\Views\ProductSlideGallery.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Viewport3D viewport3D;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\Views\ProductSlideGallery.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.Media3D.ModelVisual3D mainScene;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\..\Views\ProductSlideGallery.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.Media3D.AxisAngleRotation3D angleRotation;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\Views\ProductSlideGallery.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.Media3D.TranslateTransform3D sceneTransform3d;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\..\Views\ProductSlideGallery.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MagicMirror.Views.MainButtonMenuBar menuButtons;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\..\Views\ProductSlideGallery.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid busyGrid;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\..\Views\ProductSlideGallery.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MagicMirror.Views.LoadingWait viewLoading;
        
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
            System.Uri resourceLocater = new System.Uri("/MagicMirror;component/views/productslidegallery.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\ProductSlideGallery.xaml"
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
            
            #line 8 "..\..\..\..\Views\ProductSlideGallery.xaml"
            ((MagicMirror.Views.ProductSlideGallery)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.RootGrid_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.RootGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.viewport3D = ((System.Windows.Controls.Viewport3D)(target));
            
            #line 45 "..\..\..\..\Views\ProductSlideGallery.xaml"
            this.viewport3D.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.viewport3D_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.mainScene = ((System.Windows.Media.Media3D.ModelVisual3D)(target));
            return;
            case 5:
            this.angleRotation = ((System.Windows.Media.Media3D.AxisAngleRotation3D)(target));
            return;
            case 6:
            this.sceneTransform3d = ((System.Windows.Media.Media3D.TranslateTransform3D)(target));
            return;
            case 7:
            this.menuButtons = ((MagicMirror.Views.MainButtonMenuBar)(target));
            return;
            case 8:
            this.busyGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 9:
            this.viewLoading = ((MagicMirror.Views.LoadingWait)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

