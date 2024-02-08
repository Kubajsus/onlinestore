using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace onlinestore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController:ControllerBase
    {
        private readonly IStoreService storeService;

        public StoreController(IStoreService storeService)
        {
            this.storeService = storeService;
        }

        [HttpPost("CreateOrder")]
        public ActionResult<Order> CreateOrder([FromBody] OrderRequestModel orderRequest)
        {
            try
            {
                var result = storeService.CreateOrder(orderRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("AddItem")]
        public ActionResult<Item> AddDish([FromBody] Item dish)
        {
            try
            {
                var result = storeService.AddItem(dish);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
