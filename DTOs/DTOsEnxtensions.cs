using System;
using TPCalculatrice.Operations;

///CONVERTIT UNE OPERATION EN OBJET DTO
namespace TPCalculatrice.DTOs
{
    public static class DTOsEnxtensions
    {
        public static OperationDTO Convertir(this Operation operation)
        {
            return new OperationDTO
            {
                Resultat = operation.Resultat,
                Operation = operation.ToString()
            };
        }
    }
}
