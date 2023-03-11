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

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        // Producing response for the action addItem() called from billdataRepository
        public IActionResult CreateItem([FromBody] Airbnb item)
        {
            if (item == null)
            {
                return BadRequest("Data is null");
            }
            bool result = _billRepository.AddItem(item);
            return result ? Ok(result) : BadRequest();
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
