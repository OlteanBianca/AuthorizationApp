using AuthorizationApp.DTOs;
using AuthorizationApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using IAuthorizationService = AuthorizationApp.Services.IAuthorizationService;

namespace AuthorizationApp.Controllers
{
    [ApiController]
    [Route("students")]
    [Authorize]
    public class StudentController : ControllerBase
    {
        #region Private Fields
        private readonly IStudentService _studentService;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserService _userService;
        #endregion

        #region Constructors
        public StudentController(IStudentService studentService, IAuthorizationService authorizationService, IUserService userService)
        {
            _studentService = studentService;
            _authorizationService = authorizationService;
            _userService = userService;
        }
        #endregion

        #region Public Methods

        [HttpGet("getGrades")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetGradesForStudent()
        {
            string? accessToken = Request.Headers[HeaderNames.Authorization];
            if (accessToken == null)
            {
                return BadRequest("Access denied!");
            }

            int? id = _authorizationService.GetUserFromToken(accessToken);
            if (id == null)
            {
                return NotFound("No user found!");
            }

            List<GradeDTO?> grades = await _studentService.GetGradesById((int)id);

            return Ok(grades);
        }

        [HttpGet("getAllGrades")]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> GetGradesForAllStudents()
        {
            string? accessToken = Request.Headers[HeaderNames.Authorization];
            if (accessToken == null)
            {
                return BadRequest("Access denied!");
            }

            int? id = _authorizationService.GetUserFromToken(accessToken);
            if (id == null)
            {
                return BadRequest("Invalid token!");
            }

            UserDTO? user = await _userService.GetUserById((int)id);
            if (user == null)
            {
                return NotFound("No user found!");
            }

            if (!await _userService.CheckIfItsTeacher(user.RoleId))
            {
                return BadRequest("User is not a teacher!");
            }

            List<StudentGradesDTO?> gradesForAllStudents = await _studentService.GetStudentsGrades();

            return Ok(gradesForAllStudents);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _studentService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            StudentDTO? result = await _studentService.GetById(id);

            if (result == null)
            {
                return BadRequest("Student not fount");
            }
            return Ok(result);
        }
        #endregion
    }
}
