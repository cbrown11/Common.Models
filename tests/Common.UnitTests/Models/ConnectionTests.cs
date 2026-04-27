using System.Xml.Linq;
using FluentAssertions;
using Common.Models.Paging;
using Common.UnitTests.Stubs;

namespace Common.UnitTests.Models
{
    [TestClass]
    public class ConnectionTests
    {
        List<object> _nodes;

        [TestInitialize]
        public void Setup()
        {
            _nodes = new List<object>();
            _nodes.Add(new object());

        }

        [TestMethod]
        public void SimpleConnectionCreate()
        {
            var pageInfo = new PageInfo();
            var connection = new Connection<object>(_nodes, pageInfo);

            connection.Should().NotBeNull();
            connection.PageInfo.Should().BeEquivalentTo(pageInfo);
            connection.Nodes.Should().BeEquivalentTo(_nodes);
        }

        [TestMethod]
        public void ConnectionCreateWithCustomPageInfo()
        {
            var pageInfo = new TestGraphPageInfo(null,"", true);
            var connection = new Connection<object, string>(_nodes, pageInfo);

            connection.Should().NotBeNull();
            connection.PageInfo.Should().BeEquivalentTo(pageInfo);
            connection.Nodes.Should().BeEquivalentTo(_nodes);
        }

    }
}