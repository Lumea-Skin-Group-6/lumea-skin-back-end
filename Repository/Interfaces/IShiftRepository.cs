using BusinessObject;

namespace Repository.Interfaces
{
    public interface IShiftRepository
    {
        List<Shift> GetAllShift();
        Shift GetShiftById(int id);
        void AddShift(Shift shift);
        void UpdateAsync(Shift shift);
        void DeleteAsync(Shift shift);

        void AddTherapistShift(TherapistShift therapistShift);

        List<TherapistShift> GetAllTherapistShift();

        TherapistShift GetTherapistShift(int id);

        void UpdateTherapistShift(TherapistShift therapistShift);

        List<Shift> GetShiftsByTherapistId(int id);
        void DeleteTherapistShift(TherapistShift id);
        Task AutoCheckSlotsWhenPassDay();
    }
}
