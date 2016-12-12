using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.DAL;
using Shop.DAL.Repository;
using Shop.Models;

namespace Shop.BLL
{
    public class OrderDomainModel : BaseDomainModel
    {
        public IEnumerable<Models.OrderModel> GetAll()
        {
            using (var repository = new BaseRepository<DAL.Order, long>())
            {
                var list = repository.Query().Select(x => new Models.OrderModel
                {
                    Order_id=x.Order_id,
                    Surname = x.Surname,
                    Name = x.Name,
                    Address = x.Address,
                    Email = x.Email,
                    Phone = x.Phone,
                    Comment = x.Comment
                }).ToList();
                return list;
            }
        }
        public Models.OrderModel GetOne(long cart_id)
        {
            OrderModel list1 = new OrderModel();
            using (var repStates = new BaseRepository<OrderState, int>())
            using (var repository = new BaseRepository<OrderCart, int>())
            {
                var list = repository.Query().Where(x=>x.Orders_id==cart_id).Select(x => new Models.OrderCartModel
                {
                    Orders_id = x.Orders_id,
                    Order_Cart_id = x.Order_Cart_id,
                    Order_id = x.Order_id
                }).FirstOrDefault();
                var repository1 = new BaseRepository<Order, int>();


                list1 = repository1.Query().Where(x => x.Order_id == list.Order_id).Select(x => new Models.OrderModel
                {
                    Address = x.Address,
                    Comment = x.Comment,
                    Email=x.Email,
                    Name=x.Name,
                    Order_id=x.Order_id,
                    Phone=x.Phone,
                    Surname=x.Surname
                            }).FirstOrDefault();
                        

                

            }
            return list1;
        }
    }
}
