using BusinessObject;
using DAL.DTO;
using DAL.DTO.Shift;
using DAL.DTO.ShiftDTO;
using Repository;
using Repository.HandleException;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
                    throw new Repository.HandleException.ErrorException(404, "Date cannot be before the current date.");
                }

                if (shiftRequest.EndTime < shiftRequest.StartTime)
                {
                    throw new Repository.HandleException.ErrorException(404, "EndTime cannot be before StartTime.");
                }
                if (shiftRequest.MaxStaff < shiftRequest.MinStaff)
                {
                    throw new Repository.HandleException.ErrorException(404, "MaxStaff cannot be less than MinStaff.");
                }
                if (shiftRequest.MaxTherapist < shiftRequest.MinTherapist)
                {
                    throw new Repository.HandleException.ErrorException(404, "MaxTherapist cannot be less than MinTherapist.");
                }

                Shift shift = new Shift
                {
                    Name = shiftRequest.Name,
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
                responseDTO.Name = shift.Name;
                responseDTO.Date = shift.Date;
                responseDTO.StartTime = shift.StartTime;
                responseDTO.EndTime = shift.EndTime;
                responseDTO.MinStaff = shift.MinStaff;
                responseDTO.MaxStaff = shift.MaxStaff;
                responseDTO.MinTherapist = shift.MinTherapist;
                responseDTO.MaxTherapist = shift.MaxTherapist;
                responseDTO.Status = shift.Status;

                return new ResponseDTO(200,"Add Successfully!", responseDTO); // Trả về 200 OK kèm dữ liệu

            }
            catch (ErrorException ex)
            {
                var errorData = new ErrorResponseDTO(ex.ErrorCode, ex.Message); 
                return new ResponseDTO(404,"Cannot Add!", errorData); 
            }
            catch (Exception ex) 
            {
                var errorData = new ErrorResponseDTO(500, "Lỗi hệ thống"); 
                return new ResponseDTO(500,"Cannot Add!", errorData); 
            }

        }

        public ResponseDTO DeleteAsync(int id)
        {
            try
            {
                Shift shift = _shiftRepo.GetShiftById(id);

                if (shift == null)
                {
                    throw new Repository.HandleException.ErrorException(404, "Shift not available!");
                }

                _shiftRepo.DeleteAsync(shift);
                return new ResponseDTO(200, "Delete Successfully!", "This is shift " + shift.Name);
            }
            catch (ErrorException ex)
            {
                var errorData = new ErrorResponseDTO(ex.ErrorCode, ex.Message);
                return new ResponseDTO(404, "Cannot find Shift!", errorData);
            }
        }

        public List<Shift> GetAllShift()
        {
            return _shiftRepo.GetAllShift();
        }

        public ResponseDTO GetShiftById(int id)
        {
            try
            {
                Shift shift = _shiftRepo.GetShiftById(id);

                if (shift == null)
                {
                    throw new Repository.HandleException.ErrorException(404, "Shift not available!");
                }

                ShiftResponseDTO responseDTO = new ShiftResponseDTO();
                responseDTO.Name = shift.Name;
                responseDTO.Date = shift.Date;
                responseDTO.StartTime = shift.StartTime;
                responseDTO.EndTime = shift.EndTime;
                responseDTO.MinStaff = shift.MinStaff;
                responseDTO.MaxStaff = shift.MaxStaff;
                responseDTO.MinTherapist = shift.MinTherapist;
                responseDTO.MaxTherapist = shift.MaxTherapist;
                responseDTO.Status = shift.Status;

                return new ResponseDTO(200, "Shift " + shift.Name, responseDTO);
            }
            catch (ErrorException ex)
            {
                var errorData = new ErrorResponseDTO(ex.ErrorCode, ex.Message);
                return new ResponseDTO(404, "Cannot find Shift!", errorData);
            }
        }

        public ResponseDTO UpdateAsync(int id, ShiftRequestDTO shiftRequest)
        {
            try
            {
                Shift shift = _shiftRepo.GetShiftById(id);

                if(shift == null)
                {
                    throw new Repository.HandleException.ErrorException(404, "Shift not available!");
                }
                if (shiftRequest.Date < DateTime.Today)
                {
                    throw new Repository.HandleException.ErrorException(404, "Date cannot be before the current date.");
                }

                if (shiftRequest.EndTime < shiftRequest.StartTime)
                {
                    throw new Repository.HandleException.ErrorException(404, "EndTime cannot be before StartTime.");
                }
                if (shiftRequest.MaxStaff < shiftRequest.MinStaff)
                {
                    throw new Repository.HandleException.ErrorException(404, "MaxStaff cannot be less than MinStaff.");
                }
                if (shiftRequest.MaxTherapist < shiftRequest.MinTherapist)
                {
                    throw new Repository.HandleException.ErrorException(404, "MaxTherapist cannot be less than MinTherapist.");
                }

                shift.Name = shiftRequest.Name;
                shift.Date = shiftRequest.Date;
                shift.StartTime = shiftRequest.StartTime;
                shift.EndTime = shiftRequest.EndTime;
                shift.MinStaff = shiftRequest.MinStaff;
                shift.MaxStaff = shiftRequest.MaxStaff;
                shift.MinTherapist = shiftRequest.MinTherapist;
                shift.MaxTherapist = shiftRequest.MaxTherapist;
                shift.Status = shiftRequest.Status;

                _shiftRepo.UpdateAsync(shift);

                ShiftResponseDTO responseDTO = new ShiftResponseDTO();
                responseDTO.Name = shift.Name;
                responseDTO.Date = shift.Date;
                responseDTO.StartTime = shift.StartTime;
                responseDTO.EndTime = shift.EndTime;
                responseDTO.MinStaff = shift.MinStaff;
                responseDTO.MaxStaff = shift.MaxStaff;
                responseDTO.MinTherapist = shift.MinTherapist;
                responseDTO.MaxTherapist = shift.MaxTherapist;
                responseDTO.Status = shift.Status;

                return new ResponseDTO(200, "Update successfully!", responseDTO); // Trả về 200 OK kèm dữ liệu

            }
            catch (ErrorException ex)
            {
                var errorData = new ErrorResponseDTO(ex.ErrorCode, ex.Message);
                return new ResponseDTO(404, "Cannot Update!", errorData);
            }
            catch (Exception ex)
            {
                var errorData = new ErrorResponseDTO(500, "Lỗi hệ thống");
                return new ResponseDTO(500, "Cannot Update!", errorData);
            }
        }
    }
}
