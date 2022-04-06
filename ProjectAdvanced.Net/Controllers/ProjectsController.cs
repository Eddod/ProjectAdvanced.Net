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
    public class ProjectsController : ControllerBase
    {
        private ILogic<Project> _plogic;
        public ProjectsController(ILogic<Project> pLogic)
        {
            _plogic = pLogic;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            try
            {
                return Ok(await _plogic.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to retrieve employeedata");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProjectsById(int id)
        {
            try
            {
                var result = await _plogic.GetSingle(id);
                if (result != null)
                {
                    return Ok(result);
                }
                return null;

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to retrieve projectdata");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Project>> AddProject(Project newProject)
        {
            try
            {
                var result = await _plogic.Add(newProject);
                if (result == null)
                {
                    return BadRequest();
                }
                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to add data to project");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Project>> UpdateProject(Project updatedProject)
        {
            try
            {
                var result = await _plogic.Update(updatedProject);
                if (result == null)
                {
                    return BadRequest();
                }
                return Ok(result);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to update projectdata");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Project>> DeleteProject(int id)
        {

            try
            {
                var employeeToDelete = await _plogic.GetSingle(id);
                if (employeeToDelete == null)
                {
                    return NotFound($"Project with ID {id} not found");
                }
                return await _plogic.Delete(id);


            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Server error, unable to delete data from projects");
            }
        }
    }
}
