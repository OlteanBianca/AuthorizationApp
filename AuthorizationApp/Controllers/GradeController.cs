using AuthorizationApp.DTOs;
using AuthorizationApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationApp.Controllers
{
    [ApiController]
    [Route("grades")]
    [Authorize]
    public class GradeController : ControllerBase
    {
        #region Private Fields
        private readonly IGradeService _gradeService;
        #endregion

        #region Constructors
        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }
        #endregion

        #region Public Methods

        [HttpPost("add/{id}")]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> AddGrade(GradeDTO gradeDTO, int id)
        {
            if (gradeDTO == null)
            {
                return BadRequest("Grade can't be null!");
            }

            if (!await _gradeService.IsStudentIdValid(id))
            {
                return NotFound("There is no student with that id!");
            }

            if (gradeDTO.Value < 1)
            {
                return BadRequest("Grade can't be negative!");
            }

            if (!await _gradeService.AddGrade(gradeDTO, id))
            {
                return BadRequest("Grade couldn't be added!");
            }

            return Ok("Grade added successfully!");
        }

        #endregion
    }
}
