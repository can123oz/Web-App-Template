using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Concrete.EntityFramework.Models
{
    public partial class UserOperationClaim
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
