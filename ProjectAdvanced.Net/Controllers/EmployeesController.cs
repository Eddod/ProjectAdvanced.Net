using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectAdvanced.Net.Services;
using ProjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAdvanced.Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private ILogic<Employee> _eLogic;

        public EmployeesController(ILogic<Employee> eLogic)
        {
            this._eLogic = eLogic;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                return Ok(await _eLogic.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,"Unable to retrieve employeedata");
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmpById(int id)
        {
            try
            {
                var result = await _eLogic.GetSingle(id);
                if (result != null)
                {
                    return Ok(result);
                }
                return null;

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to retrieve employeedata");
            }
        }


        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmp(Employee newEmp)
        {
            try
            {
                var result = await _eLogic.Add(newEmp);
                if (result == null)
                {
                    return BadRequest();
                }
                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to add data to employees");
            }
        }


        [HttpPut]
        public async Task<ActionResult<Employee>> UpdateEmp(Employee updatedEmp)
        {
            try
            {
                var result = await _eLogic.Update(updatedEmp);
                if (result == null)
                {
                    return BadRequest();
                }
                return Ok(result);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to update employeedata");
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmp(int id)
        {
            
            try
            {
                var employeeToDelete = await _eLogic.GetSingle(id);
                if (employeeToDelete == null)
                {
                    return NotFound($"Employee with ID {id} not found");
                }
                return await _eLogic.Delete(id);


            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,"Server error, unable to delete data from employees");
            }
        }


    }
}
