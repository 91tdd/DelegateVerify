using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace DelegateVerify
{
    [TestClass]
    public class OrderModelTests
    {
        private IRepository<Order> _repository = Substitute.For<IRepository<Order>>();

        [TestMethod]
        public void insert_order()
        {
            //TODO
            var myOrderModel = new MyOrderModel(_repository);
        }

        [TestMethod]
        public void update_order()
        {
            //TODO
            var myOrderModel = new MyOrderModel(_repository);
        }
    }
}