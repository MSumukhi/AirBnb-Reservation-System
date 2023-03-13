using HWK4.Interfaces;
using HWK4.Models;
using HWK4.Repositories;
using Microsoft.AspNetCore.Mvc;

///<summary>
///BillController provides the CRUD operations along with the data analysis.
///</summary>

namespace HWK4.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AirbnbController : ControllerBase
    {
        private readonly ILogger<AirbnbController> _logger;
        private readonly IAirbnbRepository _billRepository;

        public AirbnbController(ILogger<AirbnbController> logger, IAirbnbRepository billRepository)
        {
            _logger = logger;
            _billRepository = billRepository;

        }

        /// <summary>
        /// GetItems is to get all the items in the bill.
        /// </summary>
        /// <returns>Items list</returns>

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Airbnb>))]

        public IActionResult GetBills()
        {
            _logger.Log(LogLevel.Information, "Get bills");
            return Ok(_billRepository.GetItems());
        }


        /// <summary>
        /// GetItem function gets the bill details of the id given.It return the bill details of the id if it is found or it returns Notfound.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>400(notfound) or item</returns>
        
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Airbnb))]
        [ProducesResponseType(400)]

        public IActionResult GetItem(int id)
        {
            Airbnb item = _billRepository.GetItem(id);
            if (item == null)
            {
                return NotFound();

            }
            else
            {
                return Ok(item);
            }
        }

        /// <summary>
        /// CreateItem method is to add the bill values in the list items.It returns Badrequest message if the values are null
        /// and return Successfully added if the items are added.
        /// </summary>
        /// <param name="todo"></param>
        /// <returns>Bad request message or Success message</returns>

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public IActionResult CreateItem([FromBody] Airbnb todo)
        {
            if (todo == null)
            {
                return BadRequest("Todo is null");
            }
            bool result = _billRepository.CreateItem(todo);
            if (result)
            {
                return Ok("Successfully added");
            }
            else
            {
                return BadRequest("Todo not added");
            }
        }

        /// <summary>
        /// UpdateItem method updated the values to the items with the given id. It output if the values are updated or not.
        /// If the given id is not found, it throws Id not found.If updated successfully, it says updated and if the values are
        /// null, it returns badrequest
        /// </summary>
        /// <param name="item"></param>
        /// <param name="item"></param>
        ///<returns>Item is null or No matching id or Successfully updated</returns>

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult UpdateItem([FromBody] Airbnb item)
        {
            if (item == null)
            {
                return BadRequest("Item is null");
            }

            bool isUpdated = _billRepository.editItem(item);

            if (!isUpdated)
            {
                return NotFound("No matching Id");
            }
            else
            {
                return Ok("Successfully updated");
            }
        }

        /// <summary>
        /// DeleteItem is to delete the bill value of the given id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>No maching id or Item deleted</returns>

        [HttpDelete]

        public IActionResult DeleteItem(int Id)
        {
            bool deleted = _billRepository.deleteItem(Id);
            if (!deleted)
            {
                return NotFound("No matching id");
            }

            else
            {
                return Ok("Item deleted");
            }
        }




        /// <summary>
        /// GetMean method is the analysis of data. It outputs the mean amount of the bill.
        /// </summary>
        /// <returns>mean</returns>
        [HttpGet("Analysis-GetMean")]
        [ProducesResponseType(200, Type = typeof(int))]

        public IActionResult GetMean()
        {
            return Ok(_billRepository.getMean());
        }

        /// <summary>
        /// GetHighestAmount method is to get the highest amount in the bill with the item details.
        /// </summary>
        /// <returns>Item details of the highest value</returns>
        [HttpGet("Analysis-GetHighestAmount")]
        [ProducesResponseType(200, Type = typeof(int))]

        public IActionResult GetHighestAmount()
        {
            return Ok(_billRepository.getMax());
        }

    }

}
