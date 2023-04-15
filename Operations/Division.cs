using System;

namespace TPCalculatrice.Operations
{
    public class Division : Operation
    {
        //inherit
        public Division(int operandeGauche, int operandeDroite) 
        : base(operandeGauche, operandeDroite)
        {
        }

        public override string ToString()
        {
            return $"{OperandeGauche} / {OperandeDroite}";
        }
        public override void Executer()
        {
            Resultat = 0;
            if (OperandeDroite != 0)
            {
                Resultat = OperandeGauche / OperandeDroite;
            } 
        }
    }
}