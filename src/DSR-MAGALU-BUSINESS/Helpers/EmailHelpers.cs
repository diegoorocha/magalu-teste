using System.ComponentModel.DataAnnotations;

namespace DSR_MAGALU_BUSINESS.Helpers
{
    public static class EmailHelpers
    {
        public static bool ValidarEmail(string email)
        {
            if (email == null)
            {
                return false;
            }

            if (new EmailAddressAttribute().IsValid(email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
