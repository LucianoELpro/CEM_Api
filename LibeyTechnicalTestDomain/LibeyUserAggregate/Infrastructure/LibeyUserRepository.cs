using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO.DocumentType;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO.Province;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO.Region;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO.Ubigeo;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO.User;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using System;
using System.Net;
using System.Numerics;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class LibeyUserRepository : ILibeyUserRepository
    {
        private readonly Context _context;
        public LibeyUserRepository(Context context)
        {
            _context = context;
        }
        public int Create(LibeyUser libeyUser)
        {
            try
            {
                var resp = _context.LibeyUsers.Add(libeyUser);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        
        }
        public LibeyUserResponse FindResponse(string documentNumber)
        {

            var q = from libeyUser in _context.LibeyUsers.Where(x => x.DocumentNumber.Equals(documentNumber))
                    select new LibeyUserResponse()
                    {
                        DocumentNumber = libeyUser.DocumentNumber,
                        Active = libeyUser.Active,
                        Address = libeyUser.Address,
                        DocumentTypeId = libeyUser.DocumentTypeId,
                        Email = libeyUser.Email,
                        FathersLastName = libeyUser.FathersLastName,
                        MothersLastName = libeyUser.MothersLastName,
                        Name = libeyUser.Name,
                        Password = libeyUser.Password,
                        Phone = libeyUser.Phone
                    };
            var list = q.ToList();
            if (list.Any()) return list.First();
            else return new LibeyUserResponse();
        }

        public List<DocumentTypeResponse> GetAllDocumentTypes() {

            var q = from documentType in _context.DocumentTypes
                    select new DocumentTypeResponse()
                    {
                        DocumentTypeId = documentType.DocumentTypeId,
                        DocumentTypeDescription = documentType.DocumentTypeDescription
                   
                    };
            var list = q.ToList();
            if (list.Any()) return list;
            else return new List<DocumentTypeResponse>();
        }


        public List<RegionResponse> GetAllRegions()
        {

            var q = from region in _context.Regions
                    select new RegionResponse()
                    {
                        RegionCode = region.RegionCode,
                        RegionDescription = region.RegionDescription

                    };
            var list = q.ToList();
            if (list.Any()) return list;
            else return new List<RegionResponse>();
        }


        public List<ProvinceResponse> GetProvincesByCode(string regionCode)
        {

            var q = from province in _context.Provinces.Where(x => x.RegionCode.Equals(regionCode))
                    select new ProvinceResponse()
                    {
                        ProvinceCode = province.ProvinceCode,
                        RegionCode = province.RegionCode,
                        ProvinceDescription = province.ProvinceDescription

                    };
            var list = q.ToList();
            if (list.Any()) return list;
            else return new List<ProvinceResponse>();
        }

        public List<UbigeoResponse> GetUbigeosByCode(string ProvinceCode,string RegionCode)
        {

            var q = from ubigeo in _context.Ubigeos.Where(x => x.ProvinceCode.Equals(ProvinceCode) && x.RegionCode.Equals(RegionCode) )
                    select new UbigeoResponse()
                    {
                        UbigeoCode = ubigeo.UbigeoCode,
                        UbigeoDescription = ubigeo.UbigeoDescription,                    
                    };
            var list = q.ToList();
            if (list.Any()) return list;
            else return new List<UbigeoResponse>();
        }

        public List<UserResponse> GetAllUsers()
        {

            var q = (from libeyUser in _context.LibeyUsers
                     join ubigeo in _context.Ubigeos on libeyUser.UbigeoCode equals ubigeo.UbigeoCode
                     where libeyUser.Active == true
                     select new UserResponse()
                     {
                         DocumentNumber = libeyUser.DocumentNumber,
                         DocumentTypeId = libeyUser.DocumentTypeId,
                         Name = libeyUser.Name,
                         FathersLastName = libeyUser.FathersLastName,
                         MothersLastName = libeyUser.MothersLastName,
                         Address = libeyUser.Address,
                         UbigeoCode = libeyUser.UbigeoCode,
                         Phone = libeyUser.Phone,
                         Email = libeyUser.Email,
                         Password = libeyUser.Password,
                         Active = libeyUser.Active,
                         RegionCode = ubigeo.RegionCode,
                         ProvinceCode =ubigeo.ProvinceCode
                     });

            var list = q.ToList();
            if (list.Any()) return list;
            else return new List<UserResponse>();
        }


        public int UpdateUser(LibeyUser libeyUser)
        {
           
            try
            {
                var existingUser = _context.LibeyUsers.Where(x => x.DocumentNumber.Equals(libeyUser.DocumentNumber)).SingleOrDefault();

                if (existingUser != null)
                {
           
                    existingUser.Name = libeyUser.Name;
                    existingUser.FathersLastName = libeyUser.FathersLastName;
                    existingUser.MothersLastName = libeyUser.MothersLastName;
                    existingUser.Address = libeyUser.Address;
                    existingUser.UbigeoCode = libeyUser.UbigeoCode;
                    existingUser.Phone = libeyUser.Phone;
                    existingUser.Email = libeyUser.Email;

                    _context.LibeyUsers.Update(existingUser);
                    _context.SaveChanges();
                    return 1;
                }
                return 0;
               
            }
            catch (Exception ex)
            {

                return 0; 
            }
        }


        public int DeleteUser(string documentNumber)
        {

            try
            {
                var existingUser = _context.LibeyUsers.Where(x => x.DocumentNumber.Equals(documentNumber)).SingleOrDefault();

                if (existingUser != null)
                {
         
                    existingUser.Active = false;
                
                    _context.LibeyUsers.Update(existingUser);
                    _context.SaveChanges();
                    return 1;
                }
                return 0;

            }
            catch (Exception ex)
            {

                return 0;
            }
        }

    }
}

