using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Service.Interfaces;
using Company.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Company.Service.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Add(DepartmentDto entityDto)
        {
            /*var MappedDepartment = new Department
            {
                Code = entity.Code,
                Name = entity.Name,
                CreatedAt = DateTime.Now
            };*/
            Department department = _mapper.Map<Department>(entityDto);
            _unitOfWork.departmentRepository.Add(department);
            _unitOfWork.Complete();
        }

        public void Delete(DepartmentDto entityDto)
        {
            /*Department dept = new Department
            {
                Name = entity.Name,
                Code = entity.Code,
                CreatedAt = DateTime.Now,
                Id = entity.Id

            };*/
            Department department = _mapper.Map<Department>(entityDto);
            _unitOfWork.departmentRepository.Delete(department);
          _unitOfWork.Complete();
        }

        public IEnumerable<DepartmentDto> GetAll()
        {
            var dept = _unitOfWork.departmentRepository.GetAll()/*.Where(x=>x.IsDeleted != true)*/;

            /* var MappedEmployee = dept.Select(x => new DepartmentDto
             {
                 Code=x.Code,
                 Name=x.Name,
                 Id=x.Id
             });*/
            IEnumerable<DepartmentDto> MappedDepartment = _mapper.Map<IEnumerable<DepartmentDto>>(dept);
            return MappedDepartment;
        }

        public DepartmentDto GetById(int? id)
        {
            if (id is null)
            {
                return null;
            }
            var dept = _unitOfWork.departmentRepository.GetById(id.Value);
            if(dept is null)
            return null;

            DepartmentDto deptTo = _mapper.Map<DepartmentDto>(dept);
            return deptTo;
        }

        /*public void Update(Department entity)
        {
            var dept = GetById(entity.Id);
            if (dept.Name != entity.Name)
            {
                if (GetAll().Any(x => x.Name == entity.Name)) 
                {
                    throw new Exception("DublicatedDepartmentsName");
                }
            }
            dept.Name = entity.Name;
            dept.Code = entity.Code;

            _unitOfWork.departmentRepository.Update(dept);
            _unitOfWork.Complete();
        }*/
    }
}
