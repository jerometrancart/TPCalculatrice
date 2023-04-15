using System;
using TPCalculatrice.Operations;

namespace TPCalculatrice
{
    public class Calculatrice
    {
        
        // //PROPRIETES
        // //PORTEE TYPE Nom { get; set; } (ACCESSEURS LECTURE ECRITURE)
        public Operation Operation { get; set; }

        //CONSTRUCTEUR 
        //PORTEE TYPE (PARAMS)
        //POUR CONSTRUIRE UNE CALCULATRICE ON DEMANDE UN PARAM OPERATION
        //DONC L'INSTANCIATION DE LA CALCULATRICE NE PEUT PAS SE FAIRE SANS
        //AVOIR RECUPERé LA VARIABLE OPERATION AU PREALABLE
        public Calculatrice(Operation operation) {
            Operation = operation;
        }
        
        //METHODE 
        //PORTEE TYPE_RETOUR NOM (PARAMS) (PAS DE RETOUR : void)
        public void Executer(){

            // PATTERN MATCHING
            
            //IF CLASSE IS POUR VERIFIER SI LE PARENT EST DU TYPE ENFANT + VALEUR OU STOCKER L'ENFANT POUR APPELER SES METHODES
            //PUIS APPELLE LA METHODE UNIQUE DE CHAQUE ENFANT EN FONCTION DU TYPE DE L'ENFANT
            
            // if(Operation is Addition add) {
            //     add.Executer();
            // }
            // else if(Operation is Soustraction sous) {
            //     sous.Executer();
            // }
            // else if(Operation is Multiplication mult) {
            //     mult.Executer();
            // }
            // else if(Operation is Division div) {
            //     div.Executer();
            // }
            // else if(Operation is Modulo mod) {
            //     mod.Executer();
            // }  
            // else {
            //     Console.WriteLine("Votre opération n'est pas reconnue");
            // }

            // EQUIVALENT EN CLASSE ABSTRAITE : APPELER LA METHODE ABSTRAITE EXECUTER QUI EST FORCEMENT REDEFINIE DANS LES CLASSES FILLES
            Operation.Executer();
        }
    }
}
