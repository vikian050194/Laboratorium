using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Laboratorium.Tests.AlgorithmsLibraryState
{
    [TestClass]
    public abstract class BaseTest
    {
        public TestContext TestContext { get; set; }

        public string Class
        {
            get { return this.TestContext.FullyQualifiedTestClassName; }
        }
        public string Method
        {
            get { return this.TestContext.TestName; }
        }

        protected virtual void Trace(string message)
        {
            System.Diagnostics.Trace.WriteLine(message);
            //Output.Testing.Trace.WriteLine(message);
        }
    }
}