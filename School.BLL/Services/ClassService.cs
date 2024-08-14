using NTierSchool.BLL.DTOs;
using NTierSchool.BLL.DTOs.Class;
using NTierSchool.BLL.DTOs.School;
using NTierSchool.BLL.DTOs.Student;
using NTierSchool.BLL.DTOs.Teacher;
using NTierSchool.BLL.Interfaces;
using NTierSchool.DAL.Repositories;
using NTierSchool.Entity.Models;

namespace NTierSchool.BLL.Services
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;
        private readonly ISchoolRepository _schoolRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IStudentRepository _studentRepository;

        public ClassService(IClassRepository classRepository, ISchoolRepository schoolRepository, ITeacherRepository teacherRepository, IStudentRepository studentRepository)
        {
            _classRepository = classRepository;
            _schoolRepository = schoolRepository;
            _teacherRepository = teacherRepository;
            _studentRepository = studentRepository;
        }

        public async Task<List<ClassBaseDto>> GetAllAsync()
        {
            var classEntities = await _classRepository.GetAllAsync();

            var list = new List<ClassBaseDto>();

            foreach (var classEntity in classEntities.Where(c => !c.IsDeleted))
            {
                list.Add(new ClassBaseDto
                {
                    Id = classEntity.Id,
                    Name = classEntity.Name
                });
            }
            return list;
        }

        public async Task<List<ClassDto>> GetAllWithDetails()
        {
            var classEntities = await _classRepository.GetAllWithDetails();

            var list = new List<ClassDto>();


            foreach (var classEntity in classEntities.Where(c => !c.IsDeleted))
            {

                list.Add(new ClassDto
                {
                    Id = classEntity.Id,
                    Name = classEntity.Name,
                    School = new SchoolBaseDto
                    {
                        Id = classEntity.School.Id,
                        Name = classEntity.School.Name,
                        Address = classEntity.School.Address
                    },
                    Teachers = classEntity.Teachers.Where(t => !t.IsDeleted).Select(y => new TeacherBaseDto
                    {
                        Id = y.Id,
                        Name = y.Name,
                        Age = y.Age,
                        Subject = y.Subject
                    }).ToList(),
                    Students = classEntity.Students.Where(s => !s.IsDeleted).Select(y => new StudentBaseDto
                    {
                        Id = y.Id,
                        Name = y.Name,
                        Age = y.Age
                    }).ToList()
                });
            }
            return list;
        }

        public async Task<ClassDto> GetByIdAsync(int id)
        {
            var classEntity = await _classRepository.GetByIdWithDetails(id);

            if (classEntity == null || classEntity.IsDeleted)
            {
                throw new Exception("Class not found!");
            }

            var classDto = new ClassDto
            {
                Id = classEntity.Id,
                Name = classEntity.Name,
                School = new SchoolBaseDto
                {
                    Id = classEntity.School.Id,
                    Name = classEntity.School.Name,
                    Address = classEntity.School.Address
                },
                Teachers = classEntity.Teachers.Where(t => !t.IsDeleted).Select(t => new TeacherBaseDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    Age = t.Age,
                    Subject = t.Subject
                }).ToList(),
                Students = classEntity.Students.Where(t => !t.IsDeleted).Select(s => new StudentBaseDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Age = s.Age
                }).ToList()
            };

            return classDto;
        }

        public async Task AddAsync(CreateClassDto dto)
        {
            var isSchoolExist = await _schoolRepository.AnyAsync(dto.SchoolId);

            if (!isSchoolExist)
            {
                throw new Exception("School does not exist!");
            }

            var entity = new Class()
            {
                Name = dto.Name,
                SchoolId = dto.SchoolId
            };

            await _classRepository.AddAsync(entity);
        }

        public async Task UpdateAsync(UpdateClassDto dto)
        {
            var classEntity = await _classRepository.GetByIdAsync(dto.Id);

            if (classEntity == null || classEntity.IsDeleted)
            {
                throw new Exception("Class not found!");
            }

            classEntity.Name = dto.Name;

            await _classRepository.UpdateAsync(classEntity);
        }

        public async Task DeleteAsync(int id)
        {
            var classEntity = await _classRepository.GetByIdAsync(id);

            if (classEntity == null || classEntity.IsDeleted)
            {
                throw new Exception($"Unable to delete {id}");
            }

            var teacherList = await _teacherRepository.GetAllByClassIdWithDetails(classEntity.Id);
            var studentList = await _studentRepository.GetAllByClassIdWithDetails(classEntity.Id);

            teacherList.ForEach(x => x.Delete());
            studentList.ForEach(x => x.Delete());

            foreach (var teacher in teacherList)
            {
                await _teacherRepository.UpdateAsync(teacher);
            }

            foreach (var student in studentList)
            {
                await _studentRepository.UpdateAsync(student);
            }

            classEntity.Delete();

            await _classRepository.SaveChangesAsync();
        }
    }
}
