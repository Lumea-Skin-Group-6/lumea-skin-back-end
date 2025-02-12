using BusinessObject;
using DAL.DTO;
using DAL.DTO.Shift;
using DAL.DTO.ShiftDTO;
using Repository;
using Repository.HandleException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Service
{
    public class ShiftService : IShiftService
    {

        private readonly IShiftRepository _shiftRepo;

        public ShiftService(IShiftRepository shiftRepo)
        {
            _shiftRepo = shiftRepo;
        }

        public ResponseDTO AddShift(ShiftRequestDTO shiftRequest)
        {
            try
            {
                if (shiftRequest.Date < DateTime.Today)
                {
                    throw new ShiftException(1001, "Date cannot be before the current date.");
                }

                if (shiftRequest.EndTime < shiftRequest.StartTime)
                {
                    throw new ShiftException(1001, "EndTime cannot be before StartTime.");
                }
                if (shiftRequest.MaxStaff < shiftRequest.MinStaff)
                {
                    throw new ShiftException(1001, "MaxStaff cannot be less than MinStaff.");
                }
                if (shiftRequest.MaxTherapist < shiftRequest.MinTherapist)
                {
                    throw new ShiftException(1001, "MaxTherapist cannot be less than MinTherapist.");
                }

                Shift shift = new Shift
                {
                    Date = shiftRequest.Date,
                    StartTime = shiftRequest.StartTime,
                    EndTime = shiftRequest.EndTime,
                    MinStaff = shiftRequest.MinStaff,
                    MaxStaff = shiftRequest.MaxStaff,
                    MinTherapist = shiftRequest.MinTherapist,
                    MaxTherapist = shiftRequest.MaxTherapist,
                    Status = shiftRequest.Status
                };

                _shiftRepo.AddAsync(shift);

                ShiftResponseDTO responseDTO = new ShiftResponseDTO();
                responseDTO.Date = shift.Date;
                responseDTO.StartTime = shift.StartTime;
                responseDTO.EndTime = shift.EndTime;
                responseDTO.MinStaff = shift.MinStaff;
                responseDTO.MaxStaff = shift.MaxStaff;
                responseDTO.MinTherapist = shift.MinTherapist;
                responseDTO.MaxTherapist = shift.MaxTherapist;
                responseDTO.Status = shift.Status;

                return new ResponseDTO(200, responseDTO); // Trả về 200 OK kèm dữ liệu

            }
            catch (ShiftException ex)
            {
                var errorData = new ErrorResponseDTO(ex.ErrorCode, ex.Message); 
                return new ResponseDTO(400, errorData); 
            }
            catch (Exception ex) 
            {
                var errorData = new ErrorResponseDTO(500, "Lỗi hệ thống"); 
                return new ResponseDTO(500, errorData); 
            }

        }

        public void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public List<Shift> GetAllShift()
        {
            return _shiftRepo.GetAllShift();
        }

        public Shift GetShiftById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(Shift shift)
        {
            throw new NotImplementedException();
        }
    }
}
