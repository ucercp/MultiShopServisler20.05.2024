using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHadlers;
using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;

namespace MultiShop.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly GetOrderDetailQueryHandler _getOrderDetailQueryHandler;
        private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler;
        private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
        private readonly RemoveOrderDetailCommandHandler _removeOrderDetailCommandHandler;
        private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler;
        private object _getAddressByIdQueryHandler;

        public OrderDetailsController(GetOrderDetailQueryHandler getOrderDetailQueryHandler,
            GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler,
            CreateOrderDetailCommandHandler createOrderDetailCommandHandler,
            RemoveOrderDetailCommandHandler removeOrderDetailCommandHandler,
            UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler)
        {
            _getOrderDetailQueryHandler = getOrderDetailQueryHandler;
            _getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
            _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
            _removeOrderDetailCommandHandler = removeOrderDetailCommandHandler;
            _updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> AddressLİst()
        {
            var values = await _getOrderDetailQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderAddressById(int id)
        {
            var values = await _getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
        {
            await _createOrderDetailCommandHandler.Handle(command);
            return Ok("Sipariş detayı başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveOrderDatail(int id)
        {
            await _removeOrderDetailCommandHandler.Handle(new RemoveOrderDetailCommand(id));
            return Ok("Sipariş başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
        {
            await _updateOrderDetailCommandHandler.Handle(command);
            return Ok("Sipariş detayı başarıyla güncellendi");
        }
    }
}