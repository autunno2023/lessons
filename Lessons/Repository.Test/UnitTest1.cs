using DataLayer.DbContext;
using DataLayer.Dto;
using DataLayer.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Repository.Test
{
    public class HumanResouresDbContextTests
    {
        [Fact]
        public void GetEmployees_ReturnsAllEmployees()
        {
            // Arrange
            var mockContext = new Mock<HumanResouresDbContext>("testPath");
            var employees = new List<Employee>
        {
            new Employee {  Id = 1 , Name = "Bruno Ferreira" },
            new Employee { Id = 2 , Name = "Marco Rossi" }
        };

            mockContext.Setup(c => c.ReadFromDb<Employee>(It.IsAny<string>())).Returns(employees);
            mockContext.Object.Employees = employees; // Directly setting the Employees property

            // Act
            var result = mockContext.Object.GetEmployees;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(employees.Count, result.Count);
            // Further assertions to check if Employees are correctly transformed to EmployeeDTOs
        }
        [Fact]
        public void GetEmployees_ReturnsTransformedEmployeeDTOs()
        {
            // Arrange
            var mockContext = new Mock<HumanResouresDbContext>("testPath");
            var employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "John Doe", /* other properties */ },
            new Employee { Id = 2, Name = "Jane Smith", /* other properties */ }
        };

            mockContext.Setup(c => c.ReadFromDb<Employee>(It.IsAny<string>())).Returns(employees);
            mockContext.Object.Employees = employees;

            // Act
            var result = mockContext.Object.GetEmployees;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(employees.Count, result.Count);
            Assert.IsType<EmployeesServiceDTo>(result.FirstOrDefault());



            Type employeeDTOType = typeof(EmployeesServiceDTo);
            string propertyName = "PropertyThatShouldNotExist";

            // Act
            var propertyInfo = employeeDTOType.GetProperty(propertyName);

            // Assert
            Assert.Null(propertyInfo); // Asserts that the property does not exist
            for (int i = 0; i < employees.Count; i++)
            {
                var expectedEmployee = employees[i];
                var actualDTO = result[i];



                Assert.Equal(expectedEmployee.Id, actualDTO.Id);
                Assert.Equal(expectedEmployee.Name, actualDTO.Name);

            }
        }
    }

}
