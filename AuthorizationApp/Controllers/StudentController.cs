using AuthorizationApp.DTOs;
using AuthorizationApp.Models;
using AuthorizationApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using IAuthorizationService = AuthorizationApp.Services.IAuthorizationService;

namespace AuthorizationApp.Controllers
{
    [ApiController]
    [Route("student")]
    [Authorize]
    public class StudentController : ControllerBase
    {
        #region Private Fields
        private readonly IStudentService _studentService;
        private readonly IAuthorizationService _authorizationService;
        #endregion

        #region Constructors
        public StudentController(IStudentService studentService, IAuthorizationService authorizationService)
        {
            _studentService = studentService;
            _authorizationService = authorizationService;
        }
        #endregion

        #region Public Methods

        [HttpGet("getGrades")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetGrades()
        {
            string? accessToken = Request.Headers[HeaderNames.Authorization];
            if (accessToken == null)
            {
                return BadRequest("Access denied!");
            }

            int? id = _authorizationService.GetUserFromToken(accessToken);
            if(id == null)
            {
                return NotFound("No student found!");
            }

            List<GradeDTO?> grades = await _studentService.GetGradesById((int)id);

            return Ok(grades);
        }

        [HttpGet]
        public ActionResult<List<Student>> GetAll()
        {
            var results = _studentService.GetAll();

            return Ok(results);
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetById(int studentId)
        {
            var result = _studentService.GetById(studentId);

            if (result == null)
            {
                return BadRequest("Student not fount");
            }
            return Ok(result);
        }
        #endregion
    }
}
