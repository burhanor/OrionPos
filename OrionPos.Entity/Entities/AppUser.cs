using Microsoft.AspNetCore.Identity;

namespace OrionPos.Entity.Entities
{
    public class AppUser:IdentityUser<int>
    {
        public string Name { get; set; } = string.Empty;


        #region Navigation Properties
        public  ICollection<TelephoneDirectory> TelephoneDirectories { get; set; }
        #endregion
    }
}
