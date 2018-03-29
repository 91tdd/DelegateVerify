using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace DelegateVerify
{
    [TestClass]
    public class OrderConrollertTests
    {
        [TestMethod]
        public void exist_order_should_update()
        {
            //TODO
            var model = Substitute.For<IOrderModel>();
            var orderController = new OrderController(model);

            orderController.Save(new Order {Id = 91, Amount = 100});
        }


        [TestMethod]
        public void no_exist_order_should_insert()
        {
            //TODO
            var model = Substitute.For<IOrderModel>();
            var orderController = new OrderController(model);

            orderController.Save(new Order {Id = 91, Amount = 100});
        }
    }
}