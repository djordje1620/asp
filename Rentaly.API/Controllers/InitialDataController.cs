using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rentaly.Application.Constant;
using Rentaly.Application.DTOs;
using Rentaly.Application.UseCases.Commands;
using Rentaly.Domain.Entities;
using Rentaly.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rentaly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitialDataController(UseCaseHandler handler) : ControllerBase
    {
        private UseCaseHandler _handler = handler;

        /// <summary>
        /// Creates a initial data.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <response code="201">Successfull creation.</response>
        /// <response code="401">Unauthorized access.</response>
        /// <response code="403">Forbidden.</response>
        /// <response code="422">Data sent is invalid.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromServices] ICreateInitialDataCommand command)
        {
            var data = new InitialDataDTO();

            data.Brands = new List<Brand>
            {
                new Brand { Name = "Audi" },
                new Brand { Name = "BMW" },
                new Brand { Name = "Porsche" },
                new Brand { Name = "Mercedes Benz" },
            };

            data.CarTypes = new List<CarType>
            {
                new CarType { Name = "Sedan" },
                new CarType { Name = "Hatchback" },
                new CarType { Name = "Coupe" },
                new CarType { Name = "Convertible" },
                new CarType { Name = "SUV" },
            };

            data.Specifications = new List<Specification>
            {
                new Specification { Name = "Engine Power" },
                new Specification { Name = "Engine Displacement" },
                new Specification { Name = "Maximum Torque" },
                new Specification { Name = "Fuel Type" },
                new Specification { Name = "Number of Gears" },
                new Specification { Name = "Tire Dimensions" },
                new Specification { Name = "Drive System" },
                new Specification { Name = "Fuel Tank Capacity" },
                new Specification { Name = "Vehicle Weight" },
                new Specification { Name = "Seating Capacity" },
                new Specification { Name = "Cargo Capacity" },
                new Specification { Name = "Fuel Efficiency" },
                new Specification { Name = "Safety Systems" }
            };

            data.Roles = new List<Role>
            {
                new Role 
                { 
                    Name = "Admin",
                    RoleUseCases = Constants.AdminUserUseCaseIds.Select(id => new RoleUseCases { UseCaseId = id }).ToList()
                },
                new Role
                { 
                    Name = "User",
                    RoleUseCases = Constants.RegularUserUseCaseIds.Select(id => new RoleUseCases { UseCaseId = id }).ToList()
                }
            };

            data.Accessories = new List<CarAccessory>
            {
                new CarAccessory { Name = "Navigation system with built-in regional map" },
                new CarAccessory { Name = "Bluetooth hands-free kit for safe phone calls while driving" },
                new CarAccessory { Name = "Child seat tailored to the age and size of the child" },
                new CarAccessory { Name = "Pet safety cage for transporting pets securely" },
                new CarAccessory { Name = "Roof racks for transporting bicycles, skis, or other sports equipment" },
                new CarAccessory { Name = "Parking assistance with sensors for easier vehicle maneuvering" },
                new CarAccessory { Name = "In-car Wi-Fi hotspot for connectivity to the internet while driving" },
                new CarAccessory { Name = "Winter weather package including snow tires and a snow shovel" },
                new CarAccessory { Name = "Electric charging compartment for charging mobile devices and other electronics" },
                new CarAccessory { Name = "Additional insurance coverage for damage or theft protection for extra peace of mind during the rental" }
            };

            _handler.HandleCommand(command, data);
            return StatusCode(201);
        }
    }
}
