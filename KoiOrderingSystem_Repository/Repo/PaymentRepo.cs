﻿using ClassBookingRoom_Repository;
using KoiOrderingSystem_BusinessObject.Data;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Repository.Repo
{
    public class PaymentRepo : BaseRepository<Payment>, IPaymentRepo
    {
        public PaymentRepo(KoiOrderingSystemContext context) : base(context)
        {
        }
    }
}
