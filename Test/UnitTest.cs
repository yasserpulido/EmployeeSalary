using Core.Services;
using Infrastructure.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class UnitTest
    {
        private HttpClient _httpClient;
        private EmployeeService _employeeService;
        private EmployeeRepository _employeeRepository;

        [TestInitialize]
        public void SetUp()
        {

            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new System.Uri("http://masglobaltestapi.azurewebsites.net/api/Employees");
            _employeeRepository = new EmployeeRepository(_httpClient);
            _employeeService = new EmployeeService(_employeeRepository);
        }

        [DataTestMethod]
        [DataRow(null)]
        public async Task GetEmployee_ShouldReturn_Employees(int? value)
        {
            // Act
            var employeeService = new EmployeeService(_employeeRepository);
            var result = await employeeService.GetEmployeeAsync(value);

            // Assert
            Assert.AreEqual(2, result.Count);
        }

        [DataTestMethod]
        [DataRow(0)]
        public async Task GetEmployee_ShouldNotReturn_Employes(int? value)
        {
            // Act
            var employeeService = new EmployeeService(_employeeRepository);
            var result = await employeeService.GetEmployeeAsync(value);

            // Assert
            Assert.AreEqual(0, result.Count);
        }

        [DataTestMethod]
        [DataRow(1)]
        public async Task GetEmployee_ShouldReturn_Juan(int? value)
        {
            // Act
            var employeeService = new EmployeeService(_employeeRepository);
            var result = await employeeService.GetEmployeeAsync(value);

            // Assert
            Assert.AreEqual("Juan",result[0].Name);
        }

        [DataTestMethod]
        [DataRow(2)]
        public async Task GetEmployee_ShouldReturn_Sebastian(int? value)
        {
            // Act
            var employeeService = new EmployeeService(_employeeRepository);
            var result = await employeeService.GetEmployeeAsync(value);

            // Assert
            Assert.AreEqual("Sebastian", result[0].Name);
        }
    }
}
