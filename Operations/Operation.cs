using System;

namespace TPCalculatrice.Operations
{
    public abstract class Operation
    {
        //prop
        //TOUTES LES OPERATIONS AURONT BESOIN DE CES PROPRIETES

        //PAS DE SETTER : PROP EN READONLY, ACCESSIBLE UNIQUEMENT A LA CONSTRUCTION
        protected int OperandeGauche { get; }
        protected int OperandeDroite { get; }
        //PROTEGER LE SETTER QUI NE POURRA ETRE REECRIT QUE DANS LES CLASSES FILLES
        public int Resultat { get; protected set; }
        //ctor
        public Operation(int operandeGauche, int operandeDroite)
        {
            OperandeGauche = operandeGauche;
            OperandeDroite = operandeDroite;   
        }

        public abstract void Executer();
        
    }
}
