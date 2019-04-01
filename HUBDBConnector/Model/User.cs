using System;
using System.Collections.Generic;
using System.Text;

namespace HUBDBConnector.Model
{
    public class User
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public string FirstName { get; set; }

        public Guid? LocaleId { get; set; }

        public string Email { get; set; }

        public Guid? TenantId { get; set; }

        public string JobTitle { get; set; }

        public string Department { get; set; }

        public string MobilePhone { get; set; }

        public string OfficeLocation { get; set; }

        public string Image { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Modified { get; set; }

        public bool IsAzure { get; set; }

        public bool IsActive { get; set; }

        public bool HasAccess { get; set; }

        public string CompanyName { get; set; }

        public Guid? ManagerId { get; set; }

        public string PrincipalName { get; set; }

    }

}
