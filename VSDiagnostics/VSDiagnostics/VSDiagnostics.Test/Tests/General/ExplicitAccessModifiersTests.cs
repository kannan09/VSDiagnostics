﻿using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoslynTester.Helpers.CSharp;
using VSDiagnostics.Diagnostics.General.ExplicitAccessModifiers;

namespace VSDiagnostics.Test.Tests.General
{
    [TestClass]
    public class ExplicitAccessModifiersTests : CSharpCodeFixVerifier
    {
        protected override DiagnosticAnalyzer DiagnosticAnalyzer => new ExplicitAccessModifiersAnalyzer();

        protected override CodeFixProvider CodeFixProvider => new ExplicitAccessModifiersCodeFix();

        [TestMethod]
        public void ExplicitAccessModifiers_ClassDeclaration_InvokesWarning()
        {
            var original = @"
namespace ConsoleApplication1
{
    class MyClass
    {
    }
}";

            var result = @"
namespace ConsoleApplication1
{
    internal class MyClass
    {
    }
}";

            VerifyDiagnostic(original, string.Format(ExplicitAccessModifiersAnalyzer.Rule.MessageFormat.ToString(), "internal"));
            VerifyFix(original, result);
        }

        [TestMethod]
        public void ExplicitAccessModifiers_ClassDeclaration_ContainsNonAccessModifier_InvokesWarning()
        {
            var original = @"
namespace ConsoleApplication1
{
    static class MyClass
    {
    }
}";

            var result = @"
namespace ConsoleApplication1
{
    static internal class MyClass
    {
    }
}";

            VerifyDiagnostic(original, string.Format(ExplicitAccessModifiersAnalyzer.Rule.MessageFormat.ToString(), "internal"));
            VerifyFix(original, result);
        }

        [TestMethod]
        public void ExplicitAccessModifiers_ClassDeclaration_ContainsAccessModifier_DoesNotInvokeWarning()
        {
            var original = @"
namespace ConsoleApplication1
{
    public class MyClass
    {
    }
}";

            VerifyDiagnostic(original);
        }

        [TestMethod]
        public void ExplicitAccessModifiers_ClassDeclaration_OnlyChangesAccessModifiers_InvokesWarning()
        {
            var original = @"
using System;

namespace ConsoleApplication1
{
    [Obsolete]
    class MyClass
    {
        void Method() { }
    }
}";

            var result = @"
using System;

namespace ConsoleApplication1
{
    [Obsolete]
    internal class MyClass
    {
        void Method() { }
    }
}";

            VerifyDiagnostic(original, string.Format(ExplicitAccessModifiersAnalyzer.Rule.MessageFormat.ToString(), "internal"));
            VerifyFix(original, result);
        }

        [TestMethod]
        public void ExplicitAccessModifiers_StructDeclaration_InvokesWarning()
        {
            var original = @"
namespace ConsoleApplication1
{
    struct MyStruct
    {
    }
}";

            var result = @"
namespace ConsoleApplication1
{
    internal struct MyStruct
    {
    }
}";

            VerifyDiagnostic(original, string.Format(ExplicitAccessModifiersAnalyzer.Rule.MessageFormat.ToString(), "internal"));
            VerifyFix(original, result);
        }

        [TestMethod]
        public void ExplicitAccessModifiers_StructDeclaration_ContainsNonAccessModifier_InvokesWarning()
        {
            var original = @"
namespace ConsoleApplication1
{
    static struct MyStruct
    {
    }
}";

            var result = @"
namespace ConsoleApplication1
{
    static internal struct MyStruct
    {
    }
}";

            VerifyDiagnostic(original, string.Format(ExplicitAccessModifiersAnalyzer.Rule.MessageFormat.ToString(), "internal"));
            VerifyFix(original, result);
        }

        [TestMethod]
        public void ExplicitAccessModifiers_StructDeclaration_ContainsAccessModifier_DoesNotInvokeWarning()
        {
            var original = @"
namespace ConsoleApplication1
{
    public struct MyStruct
    {
    }
}";

            VerifyDiagnostic(original);
        }

        [TestMethod]
        public void ExplicitAccessModifiers_StructDeclaration_OnlyChangesAccessModifiers_InvokesWarning()
        {
            var original = @"
using System;

namespace ConsoleApplication1
{
    [Obsolete]
    struct MyStruct
    {
        public int Position;
    }
}";

            var result = @"
using System;

namespace ConsoleApplication1
{
    [Obsolete]
    internal struct MyStruct
    {
        public int Position;
    }
}";

            VerifyDiagnostic(original, string.Format(ExplicitAccessModifiersAnalyzer.Rule.MessageFormat.ToString(), "internal"));
            VerifyFix(original, result);
        }

        [TestMethod]
        public void ExplicitAccessModifiers_EnumDeclaration_InvokesWarning()
        {
            var original = @"
namespace ConsoleApplication1
{
    enum MyEnum
    {
    }
}";

            var result = @"
namespace ConsoleApplication1
{
    internal enum MyEnum
    {
    }
}";

            VerifyDiagnostic(original, string.Format(ExplicitAccessModifiersAnalyzer.Rule.MessageFormat.ToString(), "internal"));
            VerifyFix(original, result);
        }

        [TestMethod]
        public void ExplicitAccessModifiers_EnumDeclaration_ContainsNonAccessModifier_InvokesWarning()
        {
            var original = @"
namespace ConsoleApplication1
{
    static enum MyEnum
    {
    }
}";

            var result = @"
namespace ConsoleApplication1
{
    static internal enum MyEnum
    {
    }
}";

            VerifyDiagnostic(original, string.Format(ExplicitAccessModifiersAnalyzer.Rule.MessageFormat.ToString(), "internal"));
            VerifyFix(original, result);
        }

        [TestMethod]
        public void ExplicitAccessModifiers_EnumDeclaration_ContainsAccessModifier_DoesNotInvokeWarning()
        {
            var original = @"
namespace ConsoleApplication1
{
    public enum MyEnum
    {
    }
}";

            VerifyDiagnostic(original);
        }

        [TestMethod]
        public void ExplicitAccessModifiers_EnumDeclaration_OnlyChangesAccessModifiers_InvokesWarning()
        {
            var original = @"
using System;

namespace ConsoleApplication1
{
    [Obsolete]
    enum MyEnum
    {
        Foo, Bar, Baz, Biz
    }
}";

            var result = @"
using System;

namespace ConsoleApplication1
{
    [Obsolete]
    internal enum MyEnum
    {
        Foo, Bar, Baz, Biz
    }
}";

            VerifyDiagnostic(original, string.Format(ExplicitAccessModifiersAnalyzer.Rule.MessageFormat.ToString(), "internal"));
            VerifyFix(original, result);
        }

        [TestMethod]
        public void ExplicitAccessModifiers_InterfaceDeclaration_InvokesWarning()
        {
            var original = @"
namespace ConsoleApplication1
{
    interface IMyInterface
    {
    }
}";

            var result = @"
namespace ConsoleApplication1
{
    internal interface IMyInterface
    {
    }
}";

            VerifyDiagnostic(original, string.Format(ExplicitAccessModifiersAnalyzer.Rule.MessageFormat.ToString(), "internal"));
            VerifyFix(original, result);
        }

        [TestMethod]
        public void ExplicitAccessModifiers_InterfaceDeclaration_ContainsNonAccessModifier_InvokesWarning()
        {
            var original = @"
namespace ConsoleApplication1
{
    static interface IMyInterface
    {
    }
}";

            var result = @"
namespace ConsoleApplication1
{
    static internal interface IMyInterface
    {
    }
}";

            VerifyDiagnostic(original, string.Format(ExplicitAccessModifiersAnalyzer.Rule.MessageFormat.ToString(), "internal"));
            VerifyFix(original, result);
        }

        [TestMethod]
        public void ExplicitAccessModifiers_InterfaceDeclaration_ContainsAccessModifier_DoesNotInvokeWarning()
        {
            var original = @"
namespace ConsoleApplication1
{
    public interface IMyInterface
    {
    }
}";

            VerifyDiagnostic(original);
        }

        [TestMethod]
        public void ExplicitAccessModifiers_InterfaceDeclaration_OnlyChangesAccessModifiers_InvokesWarning()
        {
            var original = @"
using System;

namespace ConsoleApplication1
{
    [Obsolete]
    interface IMyInterface
    {
        int Position();
    }
}";

            var result = @"
using System;

namespace ConsoleApplication1
{
    [Obsolete]
    internal interface IMyInterface
    {
        int Position();
    }
}";

            VerifyDiagnostic(original, string.Format(ExplicitAccessModifiersAnalyzer.Rule.MessageFormat.ToString(), "internal"));
            VerifyFix(original, result);
        }

        [TestMethod]
        public void ExplicitAccessModifiers_NestedClassDeclaration_InvokesWarning()
        {
            var original = @"
namespace ConsoleApplication1
{
    class MyClass
    {
        class MyInternalClass
        {
        }
    }
}";

            var result = @"
namespace ConsoleApplication1
{
    internal class MyClass
    {
        private class MyInternalClass
        {
        }
    }
}";

            VerifyDiagnostic(original,
                string.Format(ExplicitAccessModifiersAnalyzer.Rule.MessageFormat.ToString(), "internal"),
                string.Format(ExplicitAccessModifiersAnalyzer.Rule.MessageFormat.ToString(), "private"));
            VerifyFix(original, result);
        }

        [TestMethod]
        public void ExplicitAccessModifiers_NestedClassDeclaration_ContainsNonAccessModifier_InvokesWarning()
        {
            var original = @"
namespace ConsoleApplication1
{
    class MyClass
    {
        static class MyInternalClass
        {
        }
    }
}";

            var result = @"
namespace ConsoleApplication1
{
    internal class MyClass
    {
        static private class MyInternalClass
        {
        }
    }
}";

            VerifyDiagnostic(original,
                string.Format(ExplicitAccessModifiersAnalyzer.Rule.MessageFormat.ToString(), "internal"),
                string.Format(ExplicitAccessModifiersAnalyzer.Rule.MessageFormat.ToString(), "private"));
            VerifyFix(original, result);
        }

        [TestMethod]
        public void ExplicitAccessModifiers_NestedClassDeclaration_ContainsAccessModifier_DoesNotInvokeWarning()
        {
            var original = @"
namespace ConsoleApplication1
{
    internal class MyClass
    {
        private class MyInternalClass
        {
        }
    }
}";

            VerifyDiagnostic(original);
        }

        [TestMethod]
        public void ExplicitAccessModifiers_NestedClassDeclaration_OnlyChangesAccessModifiers_InvokesWarning()
        {
            var original = @"
using System;

namespace ConsoleApplication1
{
    [Obsolete]
    class MyClass
    {
        [Obsolete]
        class MyInternalClass
        {
            void Method();
        }
    }
}";

            var result = @"
using System;

namespace ConsoleApplication1
{
    [Obsolete]
    internal class MyClass
    {
        [Obsolete]
        private class MyInternalClass
        {
            void Method();
        }
    }
}";

            VerifyDiagnostic(original,
                string.Format(ExplicitAccessModifiersAnalyzer.Rule.MessageFormat.ToString(), "internal"),
                string.Format(ExplicitAccessModifiersAnalyzer.Rule.MessageFormat.ToString(), "private"));
            VerifyFix(original, result);
        }

        [TestMethod]
        public void ExplicitAccessModifiers_NestedStructDeclaration_InvokesWarning()
        {
            var original = @"
namespace ConsoleApplication1
{
    class MyClass
    {
        struct MyInternalStruct
        {
        }
    }
}";

            var result = @"
namespace ConsoleApplication1
{
    internal class MyClass
    {
        private struct MyInternalStruct
        {
        }
    }
}";

            VerifyDiagnostic(original,
                string.Format(ExplicitAccessModifiersAnalyzer.Rule.MessageFormat.ToString(), "internal"),
                string.Format(ExplicitAccessModifiersAnalyzer.Rule.MessageFormat.ToString(), "private"));
            VerifyFix(original, result);
        }

        [TestMethod]
        public void ExplicitAccessModifiers_NestedStructDeclaration_ContainsNonAccessModifier_InvokesWarning()
        {
            var original = @"
namespace ConsoleApplication1
{
    class MyClass
    {
        static struct MyInternalStruct
        {
        }
    }
}";

            var result = @"
namespace ConsoleApplication1
{
    internal class MyClass
    {
        static private struct MyInternalStruct
        {
        }
    }
}";

            VerifyDiagnostic(original,
                string.Format(ExplicitAccessModifiersAnalyzer.Rule.MessageFormat.ToString(), "internal"),
                string.Format(ExplicitAccessModifiersAnalyzer.Rule.MessageFormat.ToString(), "private"));
            VerifyFix(original, result);
        }

        [TestMethod]
        public void ExplicitAccessModifiers_NestedStructDeclaration_ContainsAccessModifier_DoesNotInvokeWarning()
        {
            var original = @"
namespace ConsoleApplication1
{
    internal class MyClass
    {
        private struct MyInternalStruct
        {
        }
    }
}";

            VerifyDiagnostic(original);
        }

        [TestMethod]
        public void ExplicitAccessModifiers_NestedStructDeclaration_OnlyChangesAccessModifiers_InvokesWarning()
        {
            var original = @"
using System;

namespace ConsoleApplication1
{
    [Obsolete]
    class MyClass
    {
        [Obsolete]
        struct MyInternalStruct
        {
            void Method();
        }
    }
}";

            var result = @"
using System;

namespace ConsoleApplication1
{
    [Obsolete]
    internal class MyClass
    {
        [Obsolete]
        private struct MyInternalStruct
        {
            void Method();
        }
    }
}";

            VerifyDiagnostic(original,
                string.Format(ExplicitAccessModifiersAnalyzer.Rule.MessageFormat.ToString(), "internal"),
                string.Format(ExplicitAccessModifiersAnalyzer.Rule.MessageFormat.ToString(), "private"));
            VerifyFix(original, result);
        }

        [TestMethod]
        public void ExplicitAccessModifiers_NestedEnumDeclaration_ContainsNonAccessModifier_InvokesWarning()
        {
            var original = @"
namespace ConsoleApplication1
{
    class MyClass
    {
        static enum MyInternalEnum
        {
        }
    }
}";

            var result = @"
namespace ConsoleApplication1
{
    internal class MyClass
    {
        static private enum MyInternalEnum
        {
        }
    }
}";

            VerifyDiagnostic(original,
                string.Format(ExplicitAccessModifiersAnalyzer.Rule.MessageFormat.ToString(), "internal"),
                string.Format(ExplicitAccessModifiersAnalyzer.Rule.MessageFormat.ToString(), "private"));
            VerifyFix(original, result);
        }

        [TestMethod]
        public void ExplicitAccessModifiers_NestedEnumDeclaration_ContainsAccessModifier_DoesNotInvokeWarning()
        {
            var original = @"
namespace ConsoleApplication1
{
    internal class MyClass
    {
        private enum MyInternalEnum
        {
        }
    }
}";

            VerifyDiagnostic(original);
        }

        [TestMethod]
        public void ExplicitAccessModifiers_NestedEnumDeclaration_OnlyChangesAccessModifiers_InvokesWarning()
        {
            var original = @"
using System;

namespace ConsoleApplication1
{
    [Obsolete]
    class MyClass
    {
        [Obsolete]
        enum MyInternalEnum
        {
            Foo, Bar, Baz, Biz
        }
    }
}";

            var result = @"
using System;

namespace ConsoleApplication1
{
    [Obsolete]
    internal class MyClass
    {
        [Obsolete]
        private enum MyInternalEnum
        {
            Foo, Bar, Baz, Biz
        }
    }
}";

            VerifyDiagnostic(original,
                string.Format(ExplicitAccessModifiersAnalyzer.Rule.MessageFormat.ToString(), "internal"),
                string.Format(ExplicitAccessModifiersAnalyzer.Rule.MessageFormat.ToString(), "private"));
            VerifyFix(original, result);
        }



        [TestMethod]
        public void ExplicitAccessModifiers_NestedInterfaceDeclaration_ContainsNonAccessModifier_InvokesWarning()
        {
            var original = @"
namespace ConsoleApplication1
{
    class MyClass
    {
        static interface MyInternalInterface
        {
        }
    }
}";

            var result = @"
namespace ConsoleApplication1
{
    internal class MyClass
    {
        static private interface MyInternalInterface
        {
        }
    }
}";

            VerifyDiagnostic(original,
                string.Format(ExplicitAccessModifiersAnalyzer.Rule.MessageFormat.ToString(), "internal"),
                string.Format(ExplicitAccessModifiersAnalyzer.Rule.MessageFormat.ToString(), "private"));
            VerifyFix(original, result);
        }

        [TestMethod]
        public void ExplicitAccessModifiers_NestedInterfaceDeclaration_ContainsAccessModifier_DoesNotInvokeWarning()
        {
            var original = @"
namespace ConsoleApplication1
{
    internal class MyClass
    {
        private interface MyInternalInterface
        {
        }
    }
}";

            VerifyDiagnostic(original);
        }

        [TestMethod]
        public void ExplicitAccessModifiers_NestedInterfaceDeclaration_OnlyChangesAccessModifiers_InvokesWarning()
        {
            var original = @"
using System;

namespace ConsoleApplication1
{
    [Obsolete]
    class MyClass
    {
        [Obsolete]
        interface MyInternalInterface
        {
            int Buzz();
        }
    }
}";

            var result = @"
using System;

namespace ConsoleApplication1
{
    [Obsolete]
    internal class MyClass
    {
        [Obsolete]
        private interface MyInternalInterface
        {
            int Buzz();
        }
    }
}";

            VerifyDiagnostic(original,
                string.Format(ExplicitAccessModifiersAnalyzer.Rule.MessageFormat.ToString(), "internal"),
                string.Format(ExplicitAccessModifiersAnalyzer.Rule.MessageFormat.ToString(), "private"));
            VerifyFix(original, result);
        }
    }
}