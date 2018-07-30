namespace premiumgenerator.api.Controllers.models.utilities
{
    public static class extension
    {
         public static int CalculateAge(this System.DateTime theDateTime)
        {
            var age = System.DateTime.Today.Year - theDateTime.Year;
            if (theDateTime.AddYears(age) > System.DateTime.Today)
                age--;

            return age;
        }
    }
}