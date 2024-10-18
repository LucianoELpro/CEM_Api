using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO.User
{
    public class UserResponse
    {
        public string DocumentNumber { get; set; }
        public int DocumentTypeId { get; set; }
        public string Name { get; set; }
        public string FathersLastName { get; set; }
        public string MothersLastName { get; set; }
        public string Address { get; set; }
        public string UbigeoCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public string RegionCode { get; set; }
        public string ProvinceCode { get; set; }
    }
}
