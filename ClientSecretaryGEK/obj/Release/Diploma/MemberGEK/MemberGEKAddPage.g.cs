﻿#pragma checksum "..\..\..\..\Diploma\MemberGEK\MemberGEKAddPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7A6AB013FB3E2C11317E5B589DFC77C4F3E8D1A8AEA3EFC9BBCE5F949158E0F4"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ClientSecretaryGEK.Diploma.MemberGEK;
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


namespace ClientSecretaryGEK.Diploma.MemberGEK {
    
    
    /// <summary>
    /// MemberGEKAddPage
    /// </summary>
    public partial class MemberGEKAddPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\..\Diploma\MemberGEK\MemberGEKAddPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboSurmane;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Diploma\MemberGEK\MemberGEKAddPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboSP;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Diploma\MemberGEK\MemberGEKAddPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Work_PM;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Diploma\MemberGEK\MemberGEKAddPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Post_PM;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Diploma\MemberGEK\MemberGEKAddPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnAdd;
        
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
            System.Uri resourceLocater = new System.Uri("/ClientSecretaryGEK;component/diploma/membergek/membergekaddpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Diploma\MemberGEK\MemberGEKAddPage.xaml"
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
            this.ComboSurmane = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.ComboSP = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.Work_PM = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Post_PM = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.BtnAdd = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\..\Diploma\MemberGEK\MemberGEKAddPage.xaml"
            this.BtnAdd.Click += new System.Windows.RoutedEventHandler(this.BtnAdd_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
