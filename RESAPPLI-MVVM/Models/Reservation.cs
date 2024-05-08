using System;
namespace RESAPPLI_MVVM.Models;

public class Reservation
{

        public int ID { get; set; }
        public DateTime DateReservation { get; set; }
        public TimeSpan HeureDebut { get; set; }
        public TimeSpan HeureFin { get; set; }
}
