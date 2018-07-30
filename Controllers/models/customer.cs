
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace premiumgenerator.api.Controllers.models
{
     public class Customer
    {
     
        [Required]
        [StringLength(10)]
        public string Name { get; set; }
        private decimal _PremiumAmount;

        public virtual decimal PremiumAmount
        {
            get { return _PremiumAmount; }
            set 
            {              
                _PremiumAmount = value; 
            }
        }      
         public int Age { get; set; }

         public DateTime DOB { get; set; }

         public string Gender { get; set; }
        protected Boolean _IsEligible = false;
        public Boolean IsEligible 
        { 
            get 
            {
                return _IsEligible;
            }    
             set 
            {              
                IsEligible = value; 
            }
        }
    }
    
    public class MaleCustomer : Customer
    {
       public override decimal PremiumAmount
        {
            get
            {
                return base.PremiumAmount;
            }
            set
            {     
                if(this.Age >= 18 &  this.Age <= 65)
                {
                    this.IsEligible = true; 
                } 
                base.PremiumAmount =Convert.ToDecimal(Age * 1.2 * 100);
            }
        }
    }
    
    public class FemaleCustomer : Customer
    {
        public override decimal PremiumAmount
        {
            get
            {
                return base.PremiumAmount;
            }
            set
            {            
                if(this.Age >= 18 &  this.Age <= 65)
                {
                    this.IsEligible = true; 
                } 
                base.PremiumAmount = Convert.ToDecimal(Age * 1.1 * 100);
            }
        }
    }
      
}