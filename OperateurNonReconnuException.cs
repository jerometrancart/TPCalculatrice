using System;
using System.Runtime.Serialization;

namespace TPCalculatrice
{
    //EXCEPTION PERSONNALISEE
    //HERITE DE LA CLASSE EXCEPTION DE BASE
    public class OperateurNonReconnuException : Exception
    {
        public string Operateur { get; set; } = "";
        //4 CONSTRUCTEURS
        public OperateurNonReconnuException()
        {
        }

        public OperateurNonReconnuException(string operateur)
        : base($"L'opérateur {operateur} n'est pas reconnu")
        {
            if(string.IsNullOrWhiteSpace(operateur))
            {
                throw new ArgumentException($"'{nameof(operateur)}' ne peut pas avoir une valeur nulle ou un espace blanc", nameof(operateur));
            }
            //passe le string récupéré dans la propriété Operateur
            Operateur = operateur;
            
        }



        public OperateurNonReconnuException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected OperateurNonReconnuException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
