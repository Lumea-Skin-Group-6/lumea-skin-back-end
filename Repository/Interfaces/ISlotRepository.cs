﻿using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ISlotRepository
    {
        Task<List<Slot>> GetFreeSlotsByTherapistIdAsync(int therapistId);

        void AddSlot(Slot slot);
        List<Slot> GetSlots();
    }
}
