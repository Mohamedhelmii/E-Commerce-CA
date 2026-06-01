using AutoMapper;
using E_Commerce.Core.DTOs;
using E_Commerce.Core.Entities.OrderAggregate;
using E_Commerce.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.APIs.Controllers
{
    public class OrderController : BaseApiController
    {
        private readonly IOrderServices _orderServices;
        private readonly IMapper _mapper;
        public OrderController(IOrderServices orderServices, IMapper mapper)
        {
            _orderServices = orderServices;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<OrderToReturnDTO>> CreateOrder([FromBody] OrderDto orderDTO)
        {
            //any email till using Identity
            var fakeEmail = "momo20@gamil.com";
            var address = _mapper.Map<AddressDTO, Address>(orderDTO.ShippingAddress);
            var order = await _orderServices.CreateOrderAsync(fakeEmail, orderDTO.BasketId, orderDTO.DeliveryMethodId, address);
            if (order == null) return BadRequest("Error when order reguest!");
            var map = _mapper.Map<Order, OrderToReturnDTO>(order);
            return Ok(map);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<OrderToReturnDTO>>> GetOrdersForUser()//string buyerEmail)
        {
            string buyerEmail = "momo20@gamil.com";
            var orders = await _orderServices.GetOrderForUserAsync(buyerEmail);
            if (orders == null) return BadRequest();
            var map = _mapper.Map<IReadOnlyList<Order>, IReadOnlyList<OrderToReturnDTO>>(orders);
            return Ok(map);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderToReturnDTO>> GetOrderByIdForUser(Guid id)//, string buyerEmail)
        {
            string buyerEmail = "momo20@gamil.com";
            var order = await _orderServices.GetOrderByIdForUserAsync(id, buyerEmail);
            if (order == null) return BadRequest();
            var map = _mapper.Map<Order, OrderToReturnDTO>(order);
            return Ok(map);
        }

        [HttpGet("deliveryMethod")]
        public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetDeliveryMethods()
        {
            var dm = await _orderServices.GetDeliveryMethodsAsync();
            var map = _mapper.Map<IReadOnlyList<DeliveryMethod>, IReadOnlyList<DeliveryMethodDTO>>(dm);
            return Ok(map);
        }
    }
}
