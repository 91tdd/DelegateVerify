using System;

namespace DelegateVerify
{
    public class OrderController
    {
        private readonly IOrderModel _orderModel;
        private readonly ILog _log;

        public OrderController(IOrderModel orderModel, ILog log)
        {
            _orderModel = orderModel;
            _log = log;
        } 

        public void Save(Order order)
        {
            if (_orderModel.IsExistOrder(order))
            {
                _orderModel.Update(order);
                this.UpdateMessage(order);
            }
            else
            {
                _orderModel.Insert(order);
                this.InsertMessage(order);
            }

            _orderModel.Save(order, this.InsertMessage, this.UpdateMessage);
        }

        private void UpdateMessage(Order order)
        {
            _log.Write("update");
            Console.WriteLine($"update order id:{order.Id} with {order.Amount} successfully!");
        }

        private void InsertMessage(Order order)
        {
            Console.WriteLine($"insert order id:{order.Id} with {order.Amount} successfully!");
        }
    }
}