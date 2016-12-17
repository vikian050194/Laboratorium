using FluentAssertions;
using Laboratorium.Core;
using Laboratorium.Core.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Laboratorium.Tests
{
    [TestClass]
    public class NameManagerTest
    {
        private NameManager _nameManager;

        [TestInitialize]
        public void Init()
        {
            _nameManager = new NameManager();
        }

        [TestMethod]
        public void FirstName()
        {
            _nameManager
                .GetNextName()
                .Should()
                .Be("a");
        }

        [TestMethod]
        public void Reset()
        {
            _nameManager.GetNextName();

            _nameManager.Reset();

            _nameManager
                .GetNextName()
                .Should()
                .Be("a");
        }

        [TestMethod]
        public void LastSimpleName()
        {
            for (int i = 1; i <= 25; i++)
            {
                _nameManager.GetNextName();
            }

            _nameManager
                .GetNextName()
                .Should()
                .Be("z");
        }

        [TestMethod]
        public void ExtendedNames()
        {
            for (int i = 1; i <= 26; i++)
            {
                _nameManager.GetNextName();
            }

            _nameManager
                .GetNextName()
                .Should()
                .Be("x1");

            for (int i = 1; i <= 9; i++)
            {
                _nameManager.GetNextName();
            }

            _nameManager
                .GetNextName()
                .Should()
                .Be("x11");
        }
    }
}
