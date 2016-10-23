using FluentAssertions;
using Laboratorium.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Laboratorium.Tests
{
    [TestClass]
    public class NameManagerTests
    {
        private NameManager nameManager;

        [TestInitialize]
        public void Init()
        {
            nameManager = new NameManager();
        }

        [TestMethod]
        public void FirstName()
        {
            nameManager
                .GetNextName()
                .Should()
                .Be("a");
        }

        [TestMethod]
        public void Reset()
        {
            nameManager.GetNextName();

            nameManager.Reset();

            nameManager
                .GetNextName()
                .Should()
                .Be("a");
        }

        [TestMethod]
        public void LastSimpleName()
        {
            for (int i = 1; i <= 25; i++)
            {
                nameManager.GetNextName();
            }

            nameManager
                .GetNextName()
                .Should()
                .Be("z");
        }

        [TestMethod]
        public void ExtendedNames()
        {
            for (int i = 1; i <= 26; i++)
            {
                nameManager.GetNextName();
            }

            nameManager
                .GetNextName()
                .Should()
                .Be("x1");

            for (int i = 1; i <= 9; i++)
            {
                nameManager.GetNextName();
            }

            nameManager
                .GetNextName()
                .Should()
                .Be("x11");
        }
    }
}
