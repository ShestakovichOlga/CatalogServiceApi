using CatalogService.API.Models;
using CatalogService.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace CatalogService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private IItemService _itemService;
        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }
        [HttpGet]
        public ActionResult GetItems([FromQuery] ItemPaginationRequest itemFilterPaginationRequest)
        {
            var result = _itemService.GetItems(itemFilterPaginationRequest);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult GetItem(Guid id)
        {
            var result = _itemService.GetItem(id);
            return Ok(result);
        }
        [HttpPost]
        public ActionResult AddItem(ItemRequest itemRequest)
        {
            var result = _itemService.AddItem(itemRequest);
            return CreatedAtAction(nameof(GetItem), new { id = result.Id }, result);
        }
        [HttpPut]
        public ActionResult UpdateItem(Guid id, ItemRequest itemRequest)
        {
            _itemService.UpdateItem(id, itemRequest);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            _itemService.DeleteItem(id);
            return NoContent();
        }
    }
}
