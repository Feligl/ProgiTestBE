using API.Enum;
using API.Classes;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleAuctionController : ControllerBase
    {
        private readonly IVehicleAuctionService _vehicleAuctionService;
        private readonly ILogger<VehicleAuctionController> _logger;

        public VehicleAuctionController(IVehicleAuctionService vehicleAuctionService, ILogger<VehicleAuctionController> logger)
        {
            _vehicleAuctionService = vehicleAuctionService;
            _logger = logger;
        }

        [HttpGet("CalculateTotalAuctionPrice")]
        public ApiResult Calculate(double vehicleBasePrice, VehicleType vehicleType)
        {
            try
            {
                return _vehicleAuctionService.CalculateFinalPrice(vehicleBasePrice, vehicleType);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new ApiResult();
            }
        }
    }
}