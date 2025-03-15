using BusinessObject;
using DAL.DTO;
using DAL.DTOs.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ITherapistService
    {
        ResponseModel AddTherapist(AccountRequestModel accountRequest);

        ResponseModel GetAllTherapist();

        ResponseModel GetTherapistById(int id);

        ResponseModel UpdateTherapist(UpdateTherapistRequestModel updateRequest);

        ResponseModel DeleteTherapist(int id);
    }
}
