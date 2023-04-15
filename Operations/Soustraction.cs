using System;

namespace TPCalculatrice.Operations
{
    public class Soustraction : Operation
    {
        //inherit
        public Soustraction(int operandeGauche, int operandeDroite) 
        : base(operandeGauche, operandeDroite)
        {
        }
        public override string ToString()
        {
            return $"{OperandeGauche} - {OperandeDroite}";
        }

        public override void Executer()
        {
            Resultat = OperandeGauche - OperandeDroite;
        }
    }
}