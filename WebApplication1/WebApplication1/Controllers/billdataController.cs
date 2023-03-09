using Microsoft.AspNetCore.Mvc;
using billdataRestAPIMySQL.Models;
using billdataRestAPIMySQL.Data;
using billdataRestAPIMySQL.Interfaces;
namespace billdataRestAPI.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class billdataController : ControllerBase
    {
        private readonly ILogger<billdataController> _logger;
        private readonly IbilldataRepository _billdataRepository;

        public billdataController(ILogger<billdataController> logger, IbilldataRepository billdataRepository)
        {
            _logger = logger;
            _billdataRepository = billdataRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<billdata>))]

        // Producing response for the action getItems() called from billdataRepository
        public IActionResult GetItems()
        {
            _logger.Log(LogLevel.Information, "Get items");
            return Ok(_billdataRepository.getItems());
        }
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(billdata))]
        [ProducesResponseType(404)]

        // Producing response for the action getItem() called from billdataRepository
        public IActionResult GetItem(int id)
        {
            billdata item = _billdataRepository.getItem(id);
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
        public IActionResult CreateItem([FromBody] billdata item)
        {
            if (item == null)
            {
                return BadRequest("Data is null");
            }
            bool result = _billdataRepository.addItem(item);
            return result ? Ok(result) : BadRequest();
        }
        [HttpPut()]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        // Producing response for the action editItem() called from billdataRepository
        public IActionResult UpdateItem([FromBody] billdata item)
        {
            if (item == null)
            {
                return BadRequest("Todo is null");
            }
            bool result = _billdataRepository.editItem(item);
            return result ? Ok(result) : BadRequest();
        }

        //// Producing response for the action deleteItem() called from billdataRepository
        [HttpDelete]
        public IActionResult DeleteItem(int id)
        {
            bool result = _billdataRepository.deleteItem(id);
            return result ? Ok(result) : BadRequest();
        }

        // Producing response for the action MaxElec() called from billdataRepository
        [HttpGet("Maximum Electricity bill")]
        [ProducesResponseType(200, Type = typeof(double))]
        public IActionResult MaxElecItem()
        {
            return Ok(_billdataRepository.MaxElec());
        }

        // Producing response for the action MinGas() called from billdataRepository
        [HttpGet("Minimum Gas bill")]
        [ProducesResponseType(200, Type = typeof(double))]
        public IActionResult MinWaterItem()
        {
            return Ok(_billdataRepository.MinGas());
        }
    }
}