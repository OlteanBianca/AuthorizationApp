using AuthorizationApp.Models;
using AuthorizationApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationApp.Controllers
{
    [ApiController]
    [Route("student")]
    [Authorize]
    public class StudentController : ControllerBase
    {
        #region Private Fields
        private readonly StudentService _studentService;
        #endregion

        #region Constructors
        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }
        #endregion

        #region Public Methods
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
