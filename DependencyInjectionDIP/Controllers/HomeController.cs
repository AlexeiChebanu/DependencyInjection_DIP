using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using Services;

namespace DependencyInjectionDIP.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICitiesService _citiesService1;
        private readonly ICitiesService _citiesService2;
        private readonly ICitiesService _citiesService3;
        private readonly IServiceScopeFactory _serviceScopeFactory;


        public HomeController(ICitiesService cititesService1, 
            ICitiesService cititesService2, ICitiesService cititesService3,
            IServiceScopeFactory serviceScopeFactory)
        {
            _citiesService1 = cititesService1;
            _citiesService2 = cititesService2;
            _citiesService3 = cititesService3;
            _serviceScopeFactory = serviceScopeFactory;
        }

        [Route("/")]
        public IActionResult Index()
        {
            List<string> cities = _citiesService1.GetCities();
            ViewBag.InstanceId_CitiesService_1 = _citiesService1.ServiceInstanceId;

            ViewBag.InstanceId_CitiesService_2 = _citiesService2.ServiceInstanceId;

            ViewBag.InstanceId_CitiesService_3 = _citiesService3.ServiceInstanceId;

            using (IServiceScope scope = _serviceScopeFactory.CreateScope())
            {
                ICitiesService citiesService = scope.ServiceProvider
                    .GetRequiredService<ICitiesService>();

                ViewBag.InstanceId_CitiesService_InScope = citiesService.ServiceInstanceId;
            }

            return View(cities);
        }
    }
}
