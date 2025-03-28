﻿using BusinessObject;
using DAL.DTO;
using DAL.DTOs.RequestModel;
using DAL.DTOs.ResponseModel;
using Repository.HandleException;
using Repository.Interfaces;
using Service.Interfaces;
using System;

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

        public ResponseModel AddShift(ShiftRequestDTO shiftRequest)
        {
            try
            {
                if(shiftRequest.StartTime <  DateTime.Now)
                {
                    throw new ErrorException(404, "Start time must be in the future!");
                }

                if (shiftRequest.EndTime < shiftRequest.StartTime)
                {
                    throw new ErrorException(404, "EndTime cannot be before StartTime.");
                }

                if (shiftRequest.MinStaff <= 0)
                {
                    throw new ErrorException(404, "MinStaff must have at least one person.");
                }

                if (shiftRequest.MaxStaff < shiftRequest.MinStaff)
                {
                    throw new ErrorException(404, "MaxStaff cannot be less than MinStaff.");
                }

                if (shiftRequest.MinTherapist <= 0)
                {
                    throw new ErrorException(404, "MinTherapist must have at least one person.");
                }

                if (shiftRequest.MaxTherapist < shiftRequest.MinTherapist)
                {
                    throw new ErrorException(404, "MaxTherapist cannot be less than MinTherapist.");
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

        public ResponseModel AddShiftToTherapistShift(int id, int shiftID)
        {
            try
            {
                TherapistShift therapistShift = _shiftRepo.GetTherapistShift(id);

                if (therapistShift == null)
                {
                    throw new ErrorException(404, "No one registered to work in this date!");
                }
                Shift shift = _shiftRepo.GetShiftById(shiftID);

                if (therapistShift == null)
                {
                    throw new ErrorException(404, "Shift not available!");
                }

                therapistShift.shift_id = shift.Id;
                _shiftRepo.UpdateTherapistShift(therapistShift);
                return new ResponseModel(200, "Add Sfhit to TherapistShift successfully!!", therapistShift);
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

                if (shiftRequest.MinStaff <= 0)
                {
                    throw new ErrorException(404, "MinStaff must have at least one person.");
                }

                if (shiftRequest.MaxStaff < shiftRequest.MinStaff)
                {
                    throw new ErrorException(404, "MaxStaff cannot be less than MinStaff.");
                }

                if (shiftRequest.MinTherapist <= 0)
                {
                    throw new ErrorException(404, "MinTherapist must have at least one person.");
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

                return new ResponseModel(200, "Update successfully!", responseDTO);
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

        public ResponseModel DeleteTherapistShift(int therapistID)
        {
            try
            {
                TherapistShift therapistShift = _shiftRepo.GetTherapistShift(therapistID);

                if (therapistShift == null)
                {
                    throw new ErrorException(404, "Day not available!");
                }

                _shiftRepo.DeleteTherapistShift(therapistShift);
                return new ResponseModel(200, "Delete Successfully!", "Day: " + therapistShift.Date);
            }catch(ErrorException ex)
            {
                var errorData = new ErrorResponseModel(ex.ErrorCode, ex.Message);
                return new ResponseModel(404, "Cannot find therapist shift!", errorData);
            }
        }

        public ResponseModel UpdateTherapistShift(int TherapistID, int therapistShiftID, DateTime Datetime)
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


                TherapistShift therapistShift = _shiftRepo.GetTherapistShift(therapistShiftID);
                therapistShift.therapist = employee;
                therapistShift.therapist_id = employee.Id;
                therapistShift.Date = Datetime;
                _shiftRepo.UpdateTherapistShift(therapistShift);

                return new ResponseModel(202, "Update successfully!", therapistShift);

            }
            catch (ErrorException ex)
            {
                var errorData = new ErrorResponseModel(ex.ErrorCode, ex.Message);
                return new ResponseModel(404, "Can not update!", errorData);

            }
        }

        public ResponseModel AddTherapistShift(int therapistID, int shiftID, TherapistShiftDateRequest dateTimes)
        {
            try
            {
                if (dateTimes?.Dates == null || !dateTimes.Dates.Any())
                {
                    throw new ErrorException(400, "DateTimes list cannot be empty!");
                }

                // Lấy thông tin Therapist
                Employee employee = _employeeRepo.GetEmployeeByAccountId(therapistID);
                if (employee == null)
                {
                    throw new ErrorException(404, "Therapist does not exist!");
                }

                // Lấy thông tin Shift
                Shift existShift = _shiftRepo.GetShiftById(shiftID);
                if (existShift == null)
                {
                    throw new ErrorException(404, "You have to choose shift!");
                }

                List<TherapistShift> addedShifts = new List<TherapistShift>();

                foreach (var dateTime in dateTimes.Dates)
                {
                    if (dateTime < DateTime.UtcNow)
                    {
                        throw new ErrorException(400, "Date cannot be earlier than the current date!");
                    }

                    TherapistShift therapistShift1 = _shiftRepo.GetTherapistShiftByDate(dateTime);

                    if (therapistShift1 != null && therapistShift1.shift_id == shiftID && therapistShift1.therapist.AccountId == therapistID)
                    {
                        throw new ErrorException(400, "You have already registered for this date and shift!");
                    }

                    // Lấy danh sách tất cả các shift trong cùng ngày
                    List<Shift> allShiftsInDay = _shiftRepo.GetAllShift();

                    // Kiểm tra giới hạn theo từng ca
                    foreach (var shift in allShiftsInDay)
                    {
                        int currentTherapistCount = _shiftRepo.GetTherapistCountByShiftAndDate(shift.Id, dateTime);
                        int currentStaffCount = _shiftRepo.GetStaffCountByShiftAndDate(shift.Id, dateTime);

                        // Kiểm tra giới hạn Therapist trong từng ca
                        if (employee.Type == "Therapist" && currentTherapistCount >= shift.MaxTherapist && shift.Id == shiftID)
                        {
                            throw new ErrorException(400, $"Cannot register shift on {dateTime:yyyy-MM-dd} for {shift.Name}, Therapist limit reached!");
                        }

                        // Kiểm tra giới hạn Staff trong từng ca
                        if (employee.Type == "Staff" && currentStaffCount >= shift.MaxStaff && shift.Id == shiftID)
                        {
                            throw new ErrorException(400, $"Cannot register shift on {dateTime:yyyy-MM-dd} for {shift.Name}, Staff limit reached!");
                        }
                    }

                    // Nếu chưa vượt quá giới hạn, thêm TherapistShift
                    TherapistShift therapistShift = new TherapistShift
                    {
                        therapist = employee,
                        therapist_id = employee.Id,
                        Date = dateTime,
                        shift_id = existShift.Id,
                        shift = existShift,
                    };

                    _shiftRepo.AddTherapistShift(therapistShift);
                    addedShifts.Add(therapistShift);
                }

                return new ResponseModel(202, "Add successfully!", addedShifts);
            }
            catch (ErrorException ex)
            {
                var errorData = new ErrorResponseModel(ex.ErrorCode, ex.Message);
                return new ResponseModel(404, "Cannot register date!", errorData);
            }
            catch (Exception ex)
            {
                var errorData = new ErrorResponseModel(500, ex.Message);
                return new ResponseModel(500, "An unexpected error occurred!", errorData);
            }
        }

    

    public async Task AutoCheckSlotsWhenPassDay()
        {
            await _shiftRepo.AutoCheckSlotsWhenPassDay();
        }
    }
}