using HWK4.Interfaces;
using HWK4.Models;
using HWK4.Repositories;
using Microsoft.AspNetCore.Mvc;

///<summary>
///AirbnbController provides the CRUD operations along with the some data analysis.
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
        /// GetItems is to retrieve all the records of Airbnb data.
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
        /// GetItem function gets the details of the particular Airbnb given their id. It return the bill details of the id if it is found or it returns Notfound.
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
        /// The CreateItem Function adds a new record to the dataset. If the record already exists it returns Not added
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public IActionResult CreateItem([FromBody] Airbnb item)
        {
            if (item == null)
            {
                return BadRequest("Todo is null");
            }
            bool result = _billRepository.CreateItem(item);
            if (result)
            {
                return Ok("Successfully added");
            }
            else
            {
                return BadRequest("item not added");
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
        /// DeleteItem is to delete the Airbnb record value of the given id
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
        /// GetMean method provides the avergae price value for all the records of Airbnb dataset
        /// </summary>
        /// <returns>mean</returns>
        [HttpGet("Analysis-GetMean")]
        [ProducesResponseType(200, Type = typeof(int))]

        public IActionResult GetMean()
        {
            return Ok(_billRepository.getMean());
        }

        /// <summary>
        /// GetHighestAmount method is to get the record of highly priced Airbnb
        /// </summary>
        /// <returns>Item details of the highest value</returns>
        [HttpGet("Analysis-GetHighestAmount")]
        [ProducesResponseType(200, Type = typeof(int))]

        public IActionResult GetHighestAmount()
        {
            return Ok(_billRepository.getMax());
        }
        
        // <summary>
        /// Availability method returns the recors of Airbnb which are available 365 days
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get Availability")]
        [ProducesResponseType(200, Type = typeof(List<Airbnb>))]

        public IActionResult Availability()
        {
            _logger.Log(LogLevel.Information, "Get Availability");
            return Ok(_billRepository.Availability());
        }

        /// <summary>
        /// This method is to filter the details of the airbnb houses based on the provided maximum people. 
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>

        [HttpGet("max_people")]
        [ProducesResponseType(200, Type = typeof(List<Airbnb>))]

        public IActionResult FilterMax(int max)
        {
            _logger.Log(LogLevel.Information, "Get bills");
            return Ok(_billRepository.FilterMax(max));
        }

        /// <summary>
        /// This method provides the details of the airbnb houses that has child safety amenities.
        /// </summary>
        /// <returns></returns>
        [HttpGet("Child Amenities")]
        [ProducesResponseType(200, Type = typeof(List<Airbnb>))]

        public IActionResult IsChildSafety()
        {
            _logger.Log(LogLevel.Information, "Get bills");
            return Ok(_billRepository.IsChildsafety());
        }


    }

}
