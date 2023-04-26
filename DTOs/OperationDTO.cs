using System;

namespace TPCalculatrice.DTOs
{
    public class OperationDTO
    {
        public int Resultat { get; set; }
        public string Operation { get; set; }

        ///OVERRIDE TOSTRING POUR EVITER LES Operation.Addition QUAND ON DEMANDE UN STRING
        public override string ToString()
        {
            return $"{Operation} = {Resultat}";
        }

    }
}
