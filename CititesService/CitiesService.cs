using ServiceContracts;

namespace Services
{
    public class CitiesService : ICitiesService, IDisposable
    {
        private List<string> _cities;

        private Guid _serviceInstanceId;

        public Guid ServiceInstanceId 
        { 
            get
            {
                return _serviceInstanceId;
            }
        }

        public CitiesService()
        {
            _serviceInstanceId = Guid.NewGuid();
            _cities = new List<string>()
            {
                "London",
                "Ottawa",
                "Winnipeg",
                "Kyiv",
                "Simferopol'"
            };
        }

        public void Dispose()
        {
            // add logic to close db connection
        }

        public List<string> GetCities()
        {
            return _cities;
        }
    }
}