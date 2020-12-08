using Core.Entities;
using Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HttpClient httpClient;

        public EmployeeRepository(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        async Task<List<Employee>> IEmployeeRepository.GetEmployees()
        {
            try
            {
                string uri = $"Employees";
                var response = await httpClient.GetAsync(uri);

                response.EnsureSuccessStatusCode();

                var responseTask = await response.Content.ReadAsStringAsync();
                var employees = JsonConvert.DeserializeObject<List<Employee>>(responseTask);

                return employees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~EmployeeRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        #endregion
    }
}
