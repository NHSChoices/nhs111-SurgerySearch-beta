using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using SurgerySearch.Web.Models;
using SurgerySearch.Web.Services;
using SurgerySearch.Web.Filters;

namespace SurgerySearch.Web.Controllers
{
    public class SurgeryController : ApiController
    {
        private SurgeryRepository surgeryRepository;

        public SurgeryController()
        {
            surgeryRepository = new SurgeryRepository();
        }

        public async Task<List<Surgery>> Get([FromUri] SurgeryUriFilter uriParams)
        {
            var pageSize = uriParams.count;
            var pageNumber = uriParams.page;

            if (uriParams.Name != null)
            {
                return await surgeryRepository.SearchSurgeryByName(pageNumber, pageSize, uriParams.Name);
            }

            if (uriParams.Postcode != null)
            {
                // postcode search
            }

            if (uriParams.Text != null)
            {
                // name and zip search
            }

            return await surgeryRepository.GetAllSurgeriesFrom(pageNumber, pageSize);
        }

        public async Task<Surgery> Get(string id)
        {
            return await surgeryRepository.GetSurgery(id);
        }
       
    }
}
