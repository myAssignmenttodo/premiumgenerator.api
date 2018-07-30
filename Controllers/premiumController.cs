using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using premiumgenerator.api.Controllers.models;
using System.Web;
using Microsoft.AspNetCore.Http;
using premiumgenerator.api.Controllers.models.utilities;

namespace premiumgenerator.api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class premiumController
    {
        public Customer _customer { get; set; }

        public premiumController([ModelBinder(typeof(CustomerBinder))] Customer customer)
        {
            
            _customer = FactoryCustomer.Create(customer.Gender);

        }

         [HttpGet()]
        public Customer Get([ModelBinder(typeof(CustomerBinder))] Customer objCustomer)
        {

          objCustomer.Age = _customer.DOB.CalculateAge();
          objCustomer.PremiumAmount = _customer.PremiumAmount;
          objCustomer.IsEligible = _customer.IsEligible;
          objCustomer.Name  = _customer.Name;
          objCustomer.DOB = _customer.DOB;
          return objCustomer;
        }
        public class CustomerBinder : IModelBinder
        {
            public CustomerBinder()
            {
            }

            public object BindModelAsync(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
               HttpContext  objContext  = controllerContext.HttpContext;
               string strGender = objContext.Request.QueryString[];
               Customer objCustomer = new Customer();
               //TODO: Read paarams from querystring
               //assign the parameters to 
              return objCustomer;

            }

            public Task BindModelAsync(ModelBindingContext bindingContext)
            {
                throw new NotImplementedException();
            }
        }
    }

}
