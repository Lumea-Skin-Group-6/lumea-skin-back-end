using BusinessObject;

namespace Repository.Interfaces
{
    public interface IShiftRepository
    {
        List<Shift> GetAllShift();
        Shift GetShiftById(int id);
        void AddAsync(Shift shift);
        void UpdateAsync(Shift shift);
        void DeleteAsync(Shift shift);

        void Addsync(TherapistShift therapistShift);

        List<TherapistShift> GetAllTherapistShift();

        TherapistShift GetTherapistShift(int id);

        void UpdateTherapistShift(TherapistShift therapistShift);
    }
}
