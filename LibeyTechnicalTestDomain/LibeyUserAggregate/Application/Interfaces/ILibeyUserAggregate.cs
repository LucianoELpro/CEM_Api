using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO.DocumentType;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO.Province;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO.Region;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO.Ubigeo;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO.User;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface ILibeyUserAggregate
    {
        LibeyUserResponse FindResponse(string documentNumber);
        int Create(UserUpdateorCreateCommand command);
        List<DocumentTypeResponse> GetAllDocumentTypes();

        List<RegionResponse> GetAllRegions();

        List<ProvinceResponse> GetProvincesByCode(string regionCode);
        List<UbigeoResponse> GetUbigeosByCode(string provinceCode, string regionCode);

        List<UserResponse> GetAllUsers();

        int UpdateUser(UserUpdateorCreateCommand command);

        int DeleteUser(string documentNumber);

    }
}
