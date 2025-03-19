using BusinessObject;
using DAL.DTO;
using DAL.DTOs.RequestModel;
using DAL.DTOs.ResponseModel;
using Repository.HandleException;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Services
{
    public class ShiftService : IShiftService
    {
        private readonly IShiftRepository _shiftRepo;
        private readonly IEmployeeRepository _employeeRepo;


        public ShiftService(IShiftRepository shiftRepo, IEmployeeRepository employeeRepo)
        {
            _shiftRepo = shiftRepo;
            _employeeRepo = employeeRepo;
        }

        public ResponseModel AddShift(int id, ShiftRequestDTO shiftRequest)
        {
            try
            {

                if (shiftRequest.EndTime < shiftRequest.StartTime)
                {
                    throw new ErrorException(404, "EndTime cannot be before StartTime.");
                }

                if (shiftRequest.MaxStaff < shiftRequest.MinStaff)
                {
                    throw new ErrorException(404, "MaxStaff cannot be less than MinStaff.");
                }

                if (shiftRequest.MaxTherapist < shiftRequest.MinTherapist)
                {
                    throw new ErrorException(404, "MaxTherapist cannot be less than MinTherapist.");
                }

                TherapistShift therapistShift = _shiftRepo.GetTherapistShift(id);

                if (therapistShift == null)
                {
                    throw new ErrorException(404, "No one regis work date!");
                }

                
                Shift shift = new Shift
                {
                    Name = shiftRequest.Name,
                    StartTime = shiftRequest.StartTime,
                    EndTime = shiftRequest.EndTime,
                    MinStaff = shiftRequest.MinStaff,
                    MaxStaff = shiftRequest.MaxStaff,
                    MinTherapist = shiftRequest.MinTherapist,
                    MaxTherapist = shiftRequest.MaxTherapist,
                    Status = shiftRequest.Status
                };



                _shiftRepo.AddShift(shift);

                therapistShift.shift_id = shift.Id;
                _shiftRepo.UpdateTherapistShift(therapistShift);


                ShiftResponseDTO responseDTO = new ShiftResponseDTO();
                responseDTO.Name = shift.Name;
                responseDTO.StartTime = shift.StartTime;
                responseDTO.EndTime = shift.EndTime;
                responseDTO.MinStaff = shift.MinStaff;
                responseDTO.MaxStaff = shift.MaxStaff;
                responseDTO.MinTherapist = shift.MinTherapist;
                responseDTO.MaxTherapist = shift.MaxTherapist;
                responseDTO.Status = shift.Status;

                return new ResponseModel(200, "Add Successfully!", responseDTO); // Trả về 200 OK kèm dữ liệu
            }
            catch (ErrorException ex)
            {
                var errorData = new ErrorResponseModel(ex.ErrorCode, ex.Message);
                return new ResponseModel(404, "Cannot Add!", errorData);
            }

        }



        public ResponseModel DeleteAsync(int id)
        {
            try
            {
                Shift shift = _shiftRepo.GetShiftById(id);

                if (shift == null)
                {
                    throw new ErrorException(404, "Shift not available!");
                }

                _shiftRepo.DeleteAsync(shift);
                return new ResponseModel(200, "Delete Successfully!", "This is shift " + shift.Name);
            }
            catch (ErrorException ex)
            {
                var errorData = new ErrorResponseModel(ex.ErrorCode, ex.Message);
                return new ResponseModel(404, "Cannot find Shift!", errorData);
            }
        }

        public List<Shift> GetAllShift()
        {
            return _shiftRepo.GetAllShift();
        }

        public List<TherapistShiftGroupedDto> GetAllTherapistShift()
        {
            return _shiftRepo.GetAllTherapistShift()
                   .GroupBy(ts => ts.Date)
                   .Select(g => new TherapistShiftGroupedDto
                   {
                       Date = g.Key,
                       TherapistIds = (ICollection<int>)g.Select(ts => ts.therapist_id).ToList()
                   })
                   .ToList();
        }

        public ResponseModel AddTherapistShift(int TherapistID, DateTime Datetime)
        {
            try
            {
                if (Datetime < DateTime.UtcNow)
                {
                    throw new ErrorException(404, "Date regis can not less than current date!");
                }

                Employee employee = _employeeRepo.GetEmployeeByAccountId(TherapistID);

                if (employee == null)
                {
                    throw new ErrorException(404, "Therapist not exist!");
                }

                TherapistShift therapistShift = new TherapistShift();
                therapistShift.therapist = employee;
                therapistShift.therapist_id = employee.Id;
                therapistShift.Date = Datetime;
                _shiftRepo.AddTherapistShift(therapistShift);

                return new ResponseModel(202, "Add successfully!", therapistShift);

            }
            catch (ErrorException ex)
            {
                var errorData = new ErrorResponseModel(ex.ErrorCode, ex.Message);
                return new ResponseModel(404, "Can not add!", errorData);

            }
        }


        public ResponseModel GetShiftById(int id)
        {
            try
            {
                Shift shift = _shiftRepo.GetShiftById(id);

                if (shift == null)
                {
                    throw new ErrorException(404, "Shift not available!");
                }

                ShiftResponseDTO responseDTO = new ShiftResponseDTO();
                responseDTO.Name = shift.Name;

                responseDTO.StartTime = shift.StartTime;
                responseDTO.EndTime = shift.EndTime;
                responseDTO.MinStaff = shift.MinStaff;
                responseDTO.MaxStaff = shift.MaxStaff;
                responseDTO.MinTherapist = shift.MinTherapist;
                responseDTO.MaxTherapist = shift.MaxTherapist;
                responseDTO.Status = shift.Status;

                return new ResponseModel(200, "Shift " + shift.Name, responseDTO);
            }
            catch (ErrorException ex)
            {
                var errorData = new ErrorResponseModel(ex.ErrorCode, ex.Message);
                return new ResponseModel(404, "Cannot find Shift!", errorData);
            }
        }

        public ResponseModel UpdateAsync(int id, ShiftRequestDTO shiftRequest)
        {
            try
            {
                Shift shift = _shiftRepo.GetShiftById(id);

                if (shift == null)
                {
                    throw new ErrorException(404, "Shift not available!");
                }


                if (shiftRequest.EndTime < shiftRequest.StartTime)
                {
                    throw new ErrorException(404, "EndTime cannot be before StartTime.");
                }

                if (shiftRequest.MaxStaff < shiftRequest.MinStaff)
                {
                    throw new ErrorException(404, "MaxStaff cannot be less than MinStaff.");
                }

                if (shiftRequest.MaxTherapist < shiftRequest.MinTherapist)
                {
                    throw new ErrorException(404, "MaxTherapist cannot be less than MinTherapist.");
                }

                shift.Name = shiftRequest.Name;

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

                responseDTO.StartTime = shift.StartTime;
                responseDTO.EndTime = shift.EndTime;
                responseDTO.MinStaff = shift.MinStaff;
                responseDTO.MaxStaff = shift.MaxStaff;
                responseDTO.MinTherapist = shift.MinTherapist;
                responseDTO.MaxTherapist = shift.MaxTherapist;
                responseDTO.Status = shift.Status;

                return new ResponseModel(200, "Update successfully!", responseDTO); // Trả về 200 OK kèm dữ liệu
            }
            catch (ErrorException ex)
            {
                var errorData = new ErrorResponseModel(ex.ErrorCode, ex.Message);
                return new ResponseModel(404, "Cannot Update!", errorData);
            }
            catch (Exception ex)
            {
                var errorData = new ErrorResponseModel(500, "Lỗi hệ thống");
                return new ResponseModel(500, "Cannot Update!", errorData);
            }
        }

        public List<Shift> GetShiftsByTherapistId(int therapistID)
        {
            return _shiftRepo.GetShiftsByTherapistId(therapistID);
        }
    }
}