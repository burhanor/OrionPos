using OrionPos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionPos.Entity.Entities
{
    public class TelephoneDirectory:EntityBase
    {
        public TelephoneDirectory()
        {
            
        }
        public TelephoneDirectory(string firstName, string lastName, string telephoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            TelephoneNumber = telephoneNumber;
        }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string TelephoneNumber { get; set; } = string.Empty;


        #region Navigation Properties

        public AppUser CreatedUser { get; set; }

        #endregion
    }
}
