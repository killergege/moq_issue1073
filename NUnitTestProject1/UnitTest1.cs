using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace NUnitTestProject1
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var mock = new Mock<IClassA>();
            mock.Setup(x => x.Items.Count).Returns(1);
            mock.Setup(x => x.Method()).Verifiable();

            mock.Object.Method();
            //var val = mock.Object.Items.Count;

            //Expected to pass
            //Passes in 4.13, but fails in 4.14 : IClassA x => x.Items: This setup was not matched.
            //Assert.That(val, Is.EqualTo(1));
            mock.Verify();
        }
    }

    public interface IClassA
    {
        public IList<string> Items { get; set; }
        public void Method();
    }
}