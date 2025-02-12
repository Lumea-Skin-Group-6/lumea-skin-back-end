using BusinessObject;
using DAL.DTO.Shift;
using DAL.DTO.ShiftDTO;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ShiftService : IShiftService
    {

        private readonly IShiftRepository _shiftRepo;

        public ShiftService(IShiftRepository shiftRepo)
        {
            _shiftRepo = shiftRepo;
        }

        public ShiftResponseDTO AddAsync(ShiftRequestDTO shiftRequest)
        {
            try
            {
                if (shiftRequest.Date < DateTime.Today)
                {
                    throw new ArgumentException("Date cannot be before the current date.");
                }
                if (shiftRequest.EndTime < shiftRequest.StartTime)
                {
                    throw new ArgumentException("EndTime cannot be before StartTime.");
                }
                if (shiftRequest.MaxStaff < shiftRequest.MinStaff)
                {
                    throw new ArgumentException("MaxStaff cannot be less than MinStaff.");
                }
                if (shiftRequest.MaxTherapist < shiftRequest.MinTherapist)
                {
                    throw new ArgumentException("MaxTherapist cannot be less than MinTherapist.");
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
                responseDTO.MaxStaff = shift.MaxStaff;
                responseDTO.Status = shift.Status;
                return responseDTO;

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Validation error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
                throw new Exception("An unexpected error occurred while adding shift.", ex);
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
