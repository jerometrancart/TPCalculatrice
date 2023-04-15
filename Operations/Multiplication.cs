using System;

namespace TPCalculatrice.Operations
{
    public class Multiplication : Operation
    {
        //inherit
        public Multiplication(int operandeGauche, int operandeDroite) 
        : base(operandeGauche, operandeDroite)
        {
        }

        public override void Executer()
        {
            Resultat = OperandeGauche * OperandeDroite;
        }
    }
}