using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace DelegateVerify
{
    [TestClass]
    public class OrderModelTests
    {
        private IRepository<Order> _repository = Substitute.For<IRepository<Order>>();
        private bool _isInsertFired = false;
        private bool _isUpdateFired = false;
        private MyOrderModel _myOrderModel;

        [TestInitialize]
        public void TestInit()
        {
            _myOrderModel = new MyOrderModel(_repository);
        }

        [TestMethod]
        public void insert_order()
        {
            //TODO
            GivenOrderNotExist();

            WhenSave();

            ShouldInsertRepository();

            ShouldInvokeInsertCallback();
            ShouldNotInvokeUpdatecCallback();
        }

        private void WhenSave()
        {
            Action<Order> insertCallback = SimulateInsertCallback();
            Action<Order> updateCallback = SimulateUpdateCallback();

            _myOrderModel.Save(new Order {Amount = 91},
                insertCallback,
                updateCallback);
        }

        private Action<Order> SimulateUpdateCallback()
        {
            return (o) => { _isUpdateFired = true; };
        }

        private Action<Order> SimulateInsertCallback()
        {
            return (o) => { _isInsertFired = true; };
        }

        private void ShouldInsertRepository()
        {
            _repository.ReceivedWithAnyArgs(1).Insert(Arg.Any<Order>());
        }

        private void ShouldNotInvokeUpdatecCallback()
        {
            Assert.IsFalse(_isUpdateFired);
        }

        private void ShouldInvokeInsertCallback()
        {
            Assert.IsTrue(_isInsertFired);
        }

        private void GivenOrderNotExist()
        {
            _repository.IsExist(Arg.Any<Order>()).ReturnsForAnyArgs(false);
        }

        [TestMethod]
        public void update_order()
        {
            //TODO
            var myOrderModel = new MyOrderModel(_repository);
            GivenOrderIsExist();

            var isInsertFired = false;
            var isUpdateFired = false;
            Action<Order> insertCallback = (o) => { isInsertFired = true; };
            Action<Order> updateCallback = (o) => { isUpdateFired = true; };

            myOrderModel.Save(new Order {Amount = 91},
                insertCallback, updateCallback);
            _repository.ReceivedWithAnyArgs(1).Update(Arg.Any<Order>());

            Assert.IsTrue(isUpdateFired);
            Assert.IsFalse(isInsertFired);
        }

        private void GivenOrderIsExist()
        {
            _repository.IsExist(Arg.Any<Order>()).ReturnsForAnyArgs(true);
        }
    }
}