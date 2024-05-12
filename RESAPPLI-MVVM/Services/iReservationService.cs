using System.Collections.Generic;
using RESAPPLI_MVVM.TestModels;

namespace RESAPPLI_MVVM.Services;

public interface iReservationService
{


     List<Reservation> GetReservations();
     void AddUtilisateur(Utilisateur utilisateur);
     void AddEntreprise(Entreprise entreprise);
     Utilisateur FindUtilisateurByMail(string mail);
     void DeleteReservation(Reservation reservation);
     void AddReservation(Reservation reservation);
}