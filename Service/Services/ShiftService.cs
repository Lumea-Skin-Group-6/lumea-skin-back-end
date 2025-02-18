using BusinessObject;
using DAL.DTO;
using DAL.DTO.Shift;
using DAL.DTO.ShiftDTO;
using Repository.HandleException;
using Repository.Interfaces;

namespace Service.Services
{
    public class ShiftService : IShiftService
    {
        private readonly IShiftRepository _shiftRepo;

        public ShiftService(IShiftRepository shiftRepo)
        {
            _shiftRepo = shiftRepo;
        }

        public ShiftResponseModel AddShift(ShiftRequestDTO shiftRequest)
        {
            try
            {
                if (shiftRequest.Date < DateTime.Today)
                {
                    throw new ShiftException(404, "Date cannot be before the current date.");
                }

                if (shiftRequest.EndTime < shiftRequest.StartTime)
                {
                    throw new ShiftException(404, "EndTime cannot be before StartTime.");
                }

                if (shiftRequest.MaxStaff < shiftRequest.MinStaff)
                {
                    throw new ShiftException(404, "MaxStaff cannot be less than MinStaff.");
                }

                if (shiftRequest.MaxTherapist < shiftRequest.MinTherapist)
                {
                    throw new ShiftException(404, "MaxTherapist cannot be less than MinTherapist.");
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

                return new ShiftResponseModel(200, "Add Successfully!", responseDTO); // Trả về 200 OK kèm dữ liệu
            }
            catch (ShiftException ex)
            {
                var errorData = new ErrorResponseModel(ex.ErrorCode, ex.Message);
                return new ShiftResponseModel(404, "Cannot Add!", errorData);
            }
            catch (Exception ex)
            {
                var errorData = new ErrorResponseModel(500, "Lỗi hệ thống");
                return new ShiftResponseModel(500, "Cannot Add!", errorData);
            }
        }

        public ShiftResponseModel DeleteAsync(int id)
        {
            try
            {
                Shift shift = _shiftRepo.GetShiftById(id);

                if (shift == null)
                {
                    throw new ShiftException(404, "Shift not available!");
                }

                _shiftRepo.DeleteAsync(shift);
                return new ShiftResponseModel(200, "Delete Successfully!", "This is shift " + shift.Name);
            }
            catch (ShiftException ex)
            {
                var errorData = new ErrorResponseModel(ex.ErrorCode, ex.Message);
                return new ShiftResponseModel(404, "Cannot find Shift!", errorData);
            }
        }

        public List<Shift> GetAllShift()
        {
            return _shiftRepo.GetAllShift();
        }

        public ShiftResponseModel GetShiftById(int id)
        {
            try
            {
                Shift shift = _shiftRepo.GetShiftById(id);

                if (shift == null)
                {
                    throw new ShiftException(404, "Shift not available!");
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

                return new ShiftResponseModel(200, "Shift " + shift.Name, responseDTO);
            }
            catch (ShiftException ex)
            {
                var errorData = new ErrorResponseModel(ex.ErrorCode, ex.Message);
                return new ShiftResponseModel(404, "Cannot find Shift!", errorData);
            }
        }

        public ShiftResponseModel UpdateAsync(int id, ShiftRequestDTO shiftRequest)
        {
            try
            {
                Shift shift = _shiftRepo.GetShiftById(id);

                if (shift == null)
                {
                    throw new ShiftException(404, "Shift not available!");
                }

                if (shiftRequest.Date < DateTime.Today)
                {
                    throw new ShiftException(404, "Date cannot be before the current date.");
                }

                if (shiftRequest.EndTime < shiftRequest.StartTime)
                {
                    throw new ShiftException(404, "EndTime cannot be before StartTime.");
                }

                if (shiftRequest.MaxStaff < shiftRequest.MinStaff)
                {
                    throw new ShiftException(404, "MaxStaff cannot be less than MinStaff.");
                }

                if (shiftRequest.MaxTherapist < shiftRequest.MinTherapist)
                {
                    throw new ShiftException(404, "MaxTherapist cannot be less than MinTherapist.");
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

                return new ShiftResponseModel(200, "Update successfully!", responseDTO); // Trả về 200 OK kèm dữ liệu
            }
            catch (ShiftException ex)
            {
                var errorData = new ErrorResponseModel(ex.ErrorCode, ex.Message);
                return new ShiftResponseModel(404, "Cannot Update!", errorData);
            }
            catch (Exception ex)
            {
                var errorData = new ErrorResponseModel(500, "Lỗi hệ thống");
                return new ShiftResponseModel(500, "Cannot Update!", errorData);
            }
        }
    }
}