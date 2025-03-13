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
        ResponseModel AddTherapist(TherapistRequest employee);

        ResponseModel GetAllTherapist();
    }
}
