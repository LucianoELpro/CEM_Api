using AutoMapper;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO.DocumentType;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO.Province;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO.Region;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO.Ubigeo;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO.User;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
    public class LibeyUserAggregate : ILibeyUserAggregate
    {
        private readonly ILibeyUserRepository _repository;
        private readonly IMapper _mapper;
        public LibeyUserAggregate(ILibeyUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public int Create(UserUpdateorCreateCommand command)
        {
            var resp = _repository.Create(_mapper.Map<LibeyUser>(command));
            return resp;
        }
        public LibeyUserResponse FindResponse(string documentNumber)
        {
            var row = _repository.FindResponse(documentNumber);
            return row;
        }
        public List<DocumentTypeResponse> GetAllDocumentTypes()
        {
            var list = _repository.GetAllDocumentTypes();
            return list;
        }

        public List<RegionResponse> GetAllRegions()
        {
            var list = _repository.GetAllRegions();
            return list;
        }
        public List<ProvinceResponse> GetProvincesByCode(string regionCode)
        {
            var list = _repository.GetProvincesByCode(regionCode);
            return list;
        }

        public List<UbigeoResponse> GetUbigeosByCode(string provinceCode, string regionCode)
        {
            var list = _repository.GetUbigeosByCode(provinceCode, regionCode);
            return list;
        }

        public List<UserResponse> GetAllUsers()
        {
            var list = _repository.GetAllUsers();
            return list;
        }


        public int UpdateUser(UserUpdateorCreateCommand command)
        {
            var resp = _repository.UpdateUser(_mapper.Map<LibeyUser>(command));
            return resp;
        }

        public int DeleteUser(string documentNumber)
        {
            var resp = _repository.DeleteUser(documentNumber);
            return resp;
        }

        
    }
}