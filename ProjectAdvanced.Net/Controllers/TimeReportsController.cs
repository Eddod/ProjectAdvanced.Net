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
    public class TimeReportsController : ControllerBase
    {
        private ITimeReport<TimeReport> _trlogic;

        public TimeReportsController(ITimeReport<TimeReport> trLogic)
        {
            _trlogic = trLogic;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllTR()
        {
            try
            {
                return Ok(await _trlogic.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to retrieve timereportdata");
            }
        }

        [HttpGet("{person}/{id}")]
        public async Task<ActionResult<TimeReport>> GetTRByEmpId(int id)
        {
            try
            {
                var result = await _trlogic.GetSingle(id);
                if (result != null)
                {
                    return Ok(result);
                }
                return null;

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to retrieve Timereportdata");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TimeReport>> AddTR(TimeReport newTR)
        {
            try
            {
                var result = await _trlogic.Add(newTR);
                if (result == null)
                {
                    return BadRequest();
                }
                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to add data to Timereports");
            }
        }

        [HttpPut]
        public async Task<ActionResult<TimeReport>> UpdateTR(TimeReport updatedTR)
        {
            try
            {
                var result = await _trlogic.Update(updatedTR);
                if (result == null)
                {
                    return BadRequest();
                }
                return Ok(result);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to update timereportdata");
            }
        }

        [HttpDelete("{delete}/{id}")]
        public async Task<ActionResult<TimeReport>> DeleteTR(int id)
        {

            try
            {
                var employeeToDelete = await _trlogic.GetSingle(id);
                if (employeeToDelete == null)
                {
                    return NotFound($"Employee with ID {id} not found");
                }
                return await _trlogic.Delete(id);


            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Server error, unable to delete data from timereports");
            }
        }


        [HttpGet("{person}/{id}/{week}")]
        public async Task<ActionResult<TimeReport>> GetworkHoursbyEmpId(int id, int week)
        {

            try
            {
                var result = await _trlogic.GetPersonHours(id, week);
                if (result != null)
                {
                    return Ok(result);
                }
                return null;

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to retrieve Timereportdata");
            }
            
        }
    }
}
