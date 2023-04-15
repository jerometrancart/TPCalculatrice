using System;

namespace TPCalculatrice.Operations
{
    public class Addition : Operation
    {
        //inherit :base
        //RECUPERE LES PROPS DU PARENT QUI SONT COMMUNES A TOUTES LES OPERATIONS
        public Addition(int operandeGauche, int operandeDroite) 
        : base(operandeGauche, operandeDroite)
        {
        }
        //CREE UNE METHODE UNIQUE POUR CETTE CLASSE
        public override void Executer()
        {
            Resultat = OperandeGauche + OperandeDroite;
        }

        public override string ToString()
        {
            return $"{OperandeGauche} + {OperandeDroite}";
        }

        // public override bool Equals(object? obj)
        // {
        //     // COMPARER DEUX CLASSES ENTRE ELLES POUR SAVOIR SI CE SONT LA MEME ADDITION
        //     if (obj is null)
        //     {
        //     // SI L'OBJET DE LA COMPARAISON VAUT NULL ALORS EVIDEMMENT LES ADDITIONS NE SONT PAS LES MEMES
        //         return false;
        //     }
        //     // PATTERN MATCHING ON RENTRE DANS LE IF SI l'OBJET EST UNE CLASSE ADDITION
        //     if(obj is Addition add)
        //     {
        //         // RETURN TRUE UNIQUEMENT SI LES DEUX PROPRIETES SONT EGALES
        //         return add.OperandeDroite == OperandeDroite
        //         && add.OperandeGauche == OperandeGauche;

        //     }
        //     else
        //     {
        //         return false;
        //     }
        // }
    }
}
