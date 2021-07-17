using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DCCS.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the DCCSUser class
    public class DCCSUser : IdentityUser
    {
        public string WeChatId { get; set; }
    }
}
