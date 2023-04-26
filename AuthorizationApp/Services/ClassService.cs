using AuthorizationApp.DTOs;
using AuthorizationApp.Mappings;
using AuthorizationApp.Models;
using AuthorizationApp.Repositories;

namespace AuthorizationApp.Services
{
    public class ClassService : BaseService, IClassService
    {
        #region Constructors
        public ClassService(UnitOfWork unitOfWork, IAuthorizationService authService) : base(unitOfWork, authService)
        {
        }   
        #endregion

        #region Public Methods
        public async Task<List<ClassDTO?>> GetAllClassesWithStudentsCount()
        {
            List<Class> classes = await _unitOfWork.Classes.GetAll();
            return classes.Select(val => val.ToClassDTO()).ToList();
        }

        public async Task<bool> AddClass(ClassDTO classDTO)
        {
            if(classDTO == null)
            {
                return false;
            }

            if (!IsNameUnique(classDTO.Name))
            {
                return false;
            }

            Class? newClass = classDTO.ToClass();
            if(newClass == null)
            {
                return false;
            }

            await _unitOfWork.Classes.Insert(newClass);
            await _unitOfWork.SaveChanges();
            return true;
        }

        public async Task<List<ClassDTO?>> GetAll()
        {
            return (await _unitOfWork.Classes.GetAll()).ToClassesDTO();
        }

        public bool IsNameUnique(string name)
        {
            return !_unitOfWork.Classes.Any(c => c.Name == name);
        }
        #endregion
    }
}
