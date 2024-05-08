using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RESAPPLI_MVVM.Context;
using RESAPPLI_MVVM.Data;
using RESAPPLI_MVVM.TestModels;
namespace RESAPPLI_MVVM.Services
{
    public class ReservationService
    {
        private RESAPPLIContext _context;
        
        public ReservationService(RESAPPLIContext context)
        {
            _context = context;
        }

        public List<Reservation> GetReservations()
        {
            return _context.Reservations.ToList();
        }
    }
}