﻿using AutoMapper;
using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Service.Dto;
using Company.Service.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Add(EmployeeDto entityDto)
        {
            //Manual Mapping
           /* Employee employee = new Employee
            {
                Address = entityDto.Address,
                Age = entityDto.Age,
                DepartmentId = entityDto.DepartmentId,
                Email = entityDto.Email,
                HiringDate = entityDto.HiringDate,
                ImageUrl= entityDto.ImageUrl,
                Name = entityDto.Name,
                PhoneNumber = entityDto.PhoneNumber,
                Salary = entityDto.Salary
            };*/
            Employee employee = _mapper.Map<Employee>(entityDto);
            _unitOfWork.employeeRepository.Add(employee);
            _unitOfWork.Complete();
        }
        public void Delete(EmployeeDto entityDto)
        {
            /*Employee employee = new Employee
            {
                Address = entity.Address,
                Age = entity.Age,
                DepartmentId = entity.DepartmentId,
                Email = entity.Email,
                HiringDate = entity.HiringDate,
                ImageUrl = entity.ImageUrl,
                Name = entity.Name,
                PhoneNumber = entity.PhoneNumber,
                Salary = entity.Salary
            };*/
            Employee employee = _mapper.Map<Employee>(entityDto); 
            _unitOfWork.employeeRepository.Delete(employee);
            _unitOfWork.Complete();
        }

        public IEnumerable<EmployeeDto> GetAll()
        {
            var emp = _unitOfWork.employeeRepository.GetAll();
           /* var MappedEmployee = emp.Select(x=> new EmployeeDto
            {
                DepartmentId = x.DepartmentId,
                Address = x.Address,
                Salary = x.Salary,
                HiringDate= x.HiringDate,
                ImageUrl= x.ImageUrl,
                Name = x.Name,
                PhoneNumber = x.PhoneNumber,
                CreatedAt = x.CreatedAt
            });*/

            IEnumerable<EmployeeDto> MappedEmployee = _mapper.Map<IEnumerable<EmployeeDto>>(emp);
            return MappedEmployee;
        }

        public EmployeeDto GetById(int? id)
        {
            if (id is null)
            {
                return null;
            }
            var emp = _unitOfWork.employeeRepository.GetById(id.Value);
            if (emp is null)
                return null;

            /*EmployeeDto employeeDto = new EmployeeDto
            {
                    Address = emp.Address,
                    Age = emp.Age,
                    DepartmentId = emp.DepartmentId,
                    Email = emp.Email,
                    HiringDate = emp.HiringDate,
                    ImageUrl = emp.ImageUrl,
                    Name = emp.Name,
                    PhoneNumber = emp.PhoneNumber,
                    Salary = emp.Salary
                };*/
            EmployeeDto employeedto = _mapper.Map<EmployeeDto>(emp);
                return employeedto;

        }

        public IEnumerable<EmployeeDto> GetEmployeeByName(string name)
        {
            var emp = _unitOfWork.employeeRepository.GetEmployeeByName(name);

            IEnumerable<EmployeeDto> MappedEmployee = _mapper.Map<IEnumerable<EmployeeDto>>(emp);
            return MappedEmployee;
        }

       /* public void Update(EmployeeDto entity)
        {
            _unitOfWork.employeeRepository.Update(entity);
            _unitOfWork.Complete();
        }*/
    }
}
