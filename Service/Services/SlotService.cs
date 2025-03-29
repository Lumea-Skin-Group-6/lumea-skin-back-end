using BusinessObject;
using CloudinaryDotNet.Actions;
using DAL.DTO;
using DAL.DTOs.ResponseModel;
using Microsoft.IdentityModel.Tokens;
using Repository.HandleException;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class SlotService : ISlotService
    {
        private readonly ISlotRepository _slotRepository;
        private readonly ITherapistRepository _therapistRepository;
        private readonly IShiftRepository _shiftRepository;

        public SlotService(ISlotRepository slotRepository, ITherapistRepository therapistRepository, IShiftRepository shiftRepository)
        {
            _slotRepository = slotRepository;
            _therapistRepository = therapistRepository;
            _shiftRepository = shiftRepository;
        }


        public async Task<List<Slot>> GetFreeSlotsOfTherapist(int employeeID)
        {
            return await _slotRepository.GetFreeSlotsByTherapistIdAsync(employeeID);
        }

        public async Task<ResponseModel> AddSlot()
        {
            try
            {
                var therapists = await _therapistRepository.GetAllAsync();
                List<Employee> listEmployee = therapists.Select(x => x.Employee).ToList();
                List<TherapistShift> therapistShifts = _shiftRepository.GetAllTherapistShift();
                List<Shift> shifts = _shiftRepository.GetAllShift();

                //Lấy danh sách Slot đã tồn tại trong DB
                List<Slot> existingSlots = _slotRepository.GetSlots();

                List<Slot> slots = new List<Slot>();

                foreach (TherapistShift therapistshift in therapistShifts)
                {
                    Employee? employee = listEmployee.FirstOrDefault(e => e.Id == therapistshift.therapist_id);
                    if (employee == null) continue; // Bỏ qua nếu không tìm thấy Employee

                    foreach (Shift shift in shifts)
                    {
                        if (therapistshift.Date < DateTime.Today) continue;

                        if (therapistshift.shift_id == shift.Id && employee.Id == therapistshift.therapist_id)
                        {
                            List<string> shiftTimes = GenerateShiftTimes(shift);

                            foreach (string time in shiftTimes)
                            {
                                //  Kiểm tra nếu Slot đã tồn tại
                                bool isDuplicate = existingSlots.Any(s =>
                                    s.employee_id == employee.Id &&
                                    s.date == therapistshift.Date &&
                                    s.time == time
                                );

                                if (!isDuplicate) // Chỉ thêm nếu chưa tồn tại
                                {
                                    Slot newSlot = new Slot
                                    {
                                        employee_id = employee.Id,
                                        date = therapistshift.Date,
                                        time = time,
                                        status = "Available"
                                    };

                                    _slotRepository.AddSlot(newSlot);
                                    slots.Add(newSlot);
                                }
                            }
                        }
                    }
                }

                if (slots.IsNullOrEmpty())
                {
                    throw new ErrorException(404, "Cannot gen slot because there are allready data!");
                }

                return new ResponseModel(200, "Auto Gen Slot Successfully!", slots);
            }
            catch (ErrorException ex)
            {
                var errorData = new ErrorResponseModel(ex.ErrorCode, ex.Message);
                return new ResponseModel(404, "Failed", errorData);
            }
        }

         private List<string> GenerateShiftTimes(Shift shift)
        {
            List<string> times = new List<string>();
            DateTime startTime, endTime;

            switch (shift.Name)
            {
                case "Sáng":
                    startTime = DateTime.Parse("07:00");
                    endTime = DateTime.Parse("12:00");
                    break;

                case "Trưa":
                    startTime = DateTime.Parse("13:00");
                    endTime = DateTime.Parse("17:00");
                    break;

                case "Tối":
                    startTime = DateTime.Parse("17:00");
                    endTime = DateTime.Parse("22:00");
                    break;

                default:
                    throw new ArgumentException("Invalid shift name");
            }

            while (startTime <= endTime)
            {
                times.Add(startTime.ToString("HH:mm:ss"));
                startTime = startTime.AddMinutes(30);
            }

            return times;
        }


    }
}
