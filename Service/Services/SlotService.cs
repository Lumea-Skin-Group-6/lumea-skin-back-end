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

                List<Slot> slots = new List<Slot>();

                foreach (TherapistShift therapistshift in therapistShifts)
                {
                    Employee? employee = listEmployee.FirstOrDefault(e => e.Id == therapistshift.therapist_id);
                    if (employee == null) continue; // Bỏ qua nếu không tìm thấy Employee

                    foreach (Shift shift in shifts)
                    {
                        if (therapistshift.shift_id == shift.Id)
                        {
                            Slot newSlot = new Slot();
                            newSlot.employee_id = employee.Id;
                            newSlot.date = therapistshift.Date;
                            newSlot.time = shift.StartTime.ToLongTimeString();
                            newSlot.status = "Available";

                           _slotRepository.AddSlot(newSlot);
                            slots.Add(newSlot);
                        }
                    }
                }


                if (slots.IsNullOrEmpty())
                {
                    slots = new List<Slot>();
                }

                return new ResponseModel(200, "Auto Gen Slot Successfully!", slots);
            }
            catch (ErrorException ex)
            {
                var errorData = new ErrorResponseModel(ex.ErrorCode, ex.Message);
                return new ResponseModel(404, "Faile", errorData);
            }
        }

    }
}
