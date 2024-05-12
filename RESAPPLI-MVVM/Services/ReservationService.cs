using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RESAPPLI_MVVM.Context;

using RESAPPLI_MVVM.TestModels;
namespace RESAPPLI_MVVM.Services
{
    public class ReservationService:iReservationService
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

        public void AddUtilisateur(Utilisateur utilisateur)
        {
            _context.Utilisateurs.Add(utilisateur);
            _context.SaveChanges();
        }
        
        public void AddEntreprise(Entreprise entreprise)
        {
            _context.Entreprises.Add(entreprise);
            _context.SaveChanges();
        }
        
        public void AddReservation(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
        }

        public Utilisateur FindUtilisateurByMail(string mail)
        {
            return _context.Utilisateurs.Include(u => u.IdEntrepriseNavigation).FirstOrDefault(u => u.Email == mail);
        }
        
        public void DeleteReservation(Reservation reservation)
        {
            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
        }

        
        
    }
}