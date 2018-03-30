using System;
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
            var log = Substitute.For<ILog>();
            var orderController = new OrderController(model, log);

            var order = new Order {Id = 91, Amount = 100};
            model.Save(order, Arg.Any<Action<Order>>(), Arg.Invoke(order) );
            orderController.Save(order);

            log.Received(1).Write(Arg.Is<string>(x => x.Contains("update")));
        }


        [TestMethod]
        public void no_exist_order_should_insert()
        {
            //TODO
            var model = Substitute.For<IOrderModel>();
            var log = Substitute.For<ILog>();
            var orderController = new OrderController(model, log);

            orderController.Save(new Order {Id = 91, Amount = 100});
        }
    }

    public interface ILog
    {
        void Write(string message);
    }
}