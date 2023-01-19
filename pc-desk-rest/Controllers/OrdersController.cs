using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pc_desk_rest.Data;
using pc_desk_rest.Models;

namespace pc_desk_rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly DataContext Context;

        public OrdersController(DataContext context)
        {
            Context = context;
        }

        [HttpGet]
        [Route("/find")]
        public async Task<ActionResult> SearchOrders()
        {
            var order =  await Context.Orders.ToListAsync<Order>();
            return Ok(order);
        }

        [HttpGet]
        [Route("/find/{id}")]
        public async Task<ActionResult> SearchOrder(int id)
        {
            try
            {
                var order = await Context.Orders.SingleAsync<Order>(o => o.OrderId == id);
                return Ok(order);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("/addone")]
        public async Task<ActionResult> AddOrder(Order order)
        {
            if(!ModelState.IsValid)
            {
                return NotFound();
            }
            else
            {
                await Context.Orders.AddAsync(order);
                await Context.SaveChangesAsync();
                return Ok(order);
            }
        }

        [HttpDelete]
        [Route("/delete/{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            try
            { 
                var order = Context.Orders.SingleAsync<Order>(o => o.OrderId == id);
                Context.Remove(order); 
                await Context.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("/update/{id}")]
        public async Task<ActionResult> UpateOrder(int id, Order up_order)
        {
            try
            {
                var order = await Context.Orders.SingleAsync<Order>(o => o.OrderId == id);
                if(order != null)
                {
                    order.DateOut = up_order.DateOut;
                    order.DateIn = up_order.DateIn;
                    order.Sign = up_order.Sign;
                    order.Cost = up_order.Cost;
                    order.UserId = up_order.UserId;

                    await Context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
