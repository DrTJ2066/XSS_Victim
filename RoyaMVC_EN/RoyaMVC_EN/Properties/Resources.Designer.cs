﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RoyaMVC_EN.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("RoyaMVC_EN.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;div style=&quot;direction:rtl;text-align:right&quot;&gt;
        ///	&lt;b&gt;رویا بلاگ&lt;/b&gt;&lt;br&gt;&lt;br&gt;
        ///	&lt;hr&gt;
        ///	&lt;br&gt;
        ///	با سلام خدمت شما کاربر گرامی&lt;br /&gt;
        ///    شما به تازگی در رویا بلاگ ثبت نام کرده اید. &lt;br/&gt;
        ///    جهت ادامه ثبت نام، روی لینک زیر کلیک کنید.&lt;br/&gt;&lt;br/&gt;
        ///	&lt;div style=&quot;text-align:left; direction: ltr&quot;&gt;
        ///		&lt;a href=&quot;{SiteAddress}/Account/Confirm/{ConfirmationToken}&quot; 
        ///           target=&quot;_blank&quot;&gt;{SiteAddress}/Account/Confirm/{ConfirmationToken}&lt;/a&gt;
        ///    &lt;/div&gt;
        ///	&lt;br&gt;&lt;br&gt;&lt;br&gt;
        ///&lt;/div&gt;.
        /// </summary>
        public static string CreateAccountConfirmationEMail {
            get {
                return ResourceManager.GetString("CreateAccountConfirmationEMail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        public static System.Drawing.Bitmap HumanNoPhotoIcon {
            get {
                object obj = ResourceManager.GetObject("HumanNoPhotoIcon", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;!DOCTYPE html PUBLIC &quot;-//W3C//DTD XHTML 1.0 Transitional//EN&quot; &quot;http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd&quot;&gt;
        ///&lt;html xmlns=&quot;http://www.w3.org/1999/xhtml&quot;&gt;
        ///&lt;head&gt;
        ///    &lt;title&gt;New Subdomain!&lt;/title&gt;
        ///&lt;/head&gt;
        ///&lt;body&gt;
        ///    your blog has been made.&lt;br /&gt;
        ///    blog address : {BlogAddress}&lt;br /&gt;
        ///    physical server path: {BlogPhysicalPath}
        ///&lt;/body&gt;
        ///&lt;/html&gt;
        ///.
        /// </summary>
        public static string Index {
            get {
                return ResourceManager.GetString("Index", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        public static System.Drawing.Bitmap NoPhotoIcon {
            get {
                object obj = ResourceManager.GetObject("NoPhotoIcon", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;div style=&quot;direction:rtl;text-align:right&quot;&gt;
        ///	&lt;b&gt;رویا بلاگ&lt;/b&gt;&lt;br&gt;&lt;br&gt;
        ///	&lt;hr&gt;
        ///	&lt;br&gt;
        ///	با سلام خدمت شما کاربر گرامی&lt;br /&gt;
        ///    شما به تازگی درخواست بازیابی گذرواژه داده اید. &lt;br/&gt;
        ///    جهت ادامه عملیات و ثبت گذرواژه جدید، روی لینک زیر کلیک کنید.&lt;br/&gt;&lt;br/&gt;
        ///	&lt;div style=&quot;text-align:left; direction: ltr&quot;&gt;
        ///		&lt;a href=&quot;{SiteAddress}/Account/ResetPassword/{ConfirmationToken}&quot; 
        ///           target=&quot;_blank&quot;&gt;{SiteAddress}/Account/ResetPassword/{ConfirmationToken}&lt;/a&gt;
        ///    &lt;/div&gt;
        ///	&lt;br&gt;&lt;br&gt;&lt;br&gt;
        ///&lt;/div&gt;.
        /// </summary>
        public static string PasswordResetEmail {
            get {
                return ResourceManager.GetString("PasswordResetEmail", resourceCulture);
            }
        }
    }
}