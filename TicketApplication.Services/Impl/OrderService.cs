using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TicketApplication.Data.Repository.Imp;
using TicketApplication.Data.Repository.IRepository;
using TicketApplication.Models.Models;
using TicketApplication.Models.Relationship;
using TicketApplication.Services.Interface;

namespace TicketApplication.Services.Impl
{
    public class OrderService : IOrderService
    {

        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<MovieShowing> _movieShowingRepository;
        private readonly IRepository<ShowingInOrder> _showingInOrderRepository;
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;



        public OrderService(IRepository<Order> orderRepository, IRepository<MovieShowing> movieShowingRepository,
            IRepository<ShowingInOrder> showingInOrderRepository, IRepository<ShoppingCart> shoppinCartRepository
            )
        {
            _orderRepository = orderRepository;
            _movieShowingRepository = movieShowingRepository;
            _showingInOrderRepository = showingInOrderRepository;
            _shoppingCartRepository = shoppinCartRepository;
        }

        public void Add(Order entity)
        {
            _orderRepository.Add(entity);
        }

        public void AddCartToOrder(string userId, ShoppingCart cart)
        {
            throw new NotImplementedException();
        }

        public void CompleteOrder(string userId)
        {
            // ZEMI SHOPPING CART ZA USER

            ShoppingCart? cart = _shoppingCartRepository.Get(x => x.UserId == userId);


            // NAPRAJ NOV ORDER ZA TOJ USER
            // ADD NA ORDER VO TABELATA

            Order order = new Order
            {
                userId = userId,
                totalSum = cart.totalSum,
                orderDate = DateTime.Now,
            };

            _orderRepository.Add(order);


            // ZA SEKOJ MOVIESHOWING VO SHOPPINGINCART VO TOJ CART NAPRAJ NOV ENTITET VO
            // SHOWING IN ORDER

            foreach(ShowingInShoppingCart obj in cart.showingsInShoppingCarts) {

                ShowingInOrder showing = new ShowingInOrder
                {
                    OrderId = order.Id,
                    MovieShowingId = obj.MovieShowingId,
                };

                // ZA SEKOJ MOVIESHOWING VO SHOPPINGINCART VO TOJ CART ODZEMI MU OD AVAILABLE TICKETS KOLKU SO IMA QUANTITY VO
                // SHOWING IN SHOPPING CART


                obj.MovieShowing.AvailableSeats -= obj.Quantity;
                _movieShowingRepository.Update(obj.MovieShowing);

                // SEKOJ OD TIE SHOWINGS IN ORDER DODAJ GO VO LISTATA VO ORDER


                order.showingsInOrder.Add(showing);
            }
            _showingInOrderRepository.Save();

            // UPDATE NA ORDER
            _orderRepository.Update(order);

            // DELETE NA SHOPPING CART NA TOJ USER

            _shoppingCartRepository.Remove(cart);

            // ADD NA CELOSNIOT ORDER VO ORDERS TABELATA

            _shoppingCartRepository.Save();
            _movieShowingRepository.Save();
            _shoppingCartRepository.Save();


            // SAVE NA ORDER REPOSITORY, SHOPPING CART REPOSITORY I SHOWING IN SHOPPING CART REPOSITORY

        }

        public Order Get(Expression<Func<Order, bool>> filter)
        {
            return _orderRepository.Get(filter);
        }

        public IEnumerable<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public void Remove(Order entity)
        {
            _orderRepository.Remove(entity);
        }

        public void RemoveRange(IEnumerable<Order> entities)
        {
            _orderRepository.RemoveRange(entities);
        }

        public void Save()
        {
            _orderRepository.Save();
        }

        public void Update(Order entity)
        {
            _orderRepository.Update(entity);
        }
    }
}
