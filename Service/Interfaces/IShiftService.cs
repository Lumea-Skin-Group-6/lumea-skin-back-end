﻿

using BusinessObject;
using DAL.DTO;
using DAL.DTOs.RequestModel;
using DAL.DTOs.ResponseModel;

namespace Service.Interfaces
{
    public interface IShiftService
    {
        List<Shift> GetAllShift();
        ResponseModel GetShiftById(int id);
        public ResponseModel AddShift(ShiftRequestDTO shift);
        public ResponseModel UpdateAsync(int id, ShiftRequestDTO shift);
        public ResponseModel DeleteAsync(int id);
    }
}