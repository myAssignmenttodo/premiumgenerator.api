using System.Collections.Generic;
using premiumgenerator.api.Controllers.models;

namespace premiumgenerator.api.Controllers
{
    
    public static class FactoryCustomer
    {
        private static readonly Dictionary<string, Customer> customerTypes = new Dictionary<string,Customer>();

        public static Customer Create(string strGender)
        {
            //Please note: This can even be decoupled and dependancy can be removed  further using dependency injection
            if (customerTypes.Count == 0)
            {
                customerTypes.Add("Male", new MaleCustomer());
                customerTypes.Add("FeMale", new FemaleCustomer());
            }
            return customerTypes[strGender];
        }
    }
}