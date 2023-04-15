using TPCalculatrice;
using TPCalculatrice.Operations;

//SECURISE LE CODE POUR EVITER DE TENTER DE PARSE UNE VALEUR NULLABLE
// WHILE (!variable.HasValue)
int GetIntValue(string rank) {

    int? resultat = null;
//    while (resultat is null) {
    while (!resultat.HasValue) {
    
    Console.WriteLine($"Saisissez la {rank} valeur entière");
    string? saisie = Console.ReadLine();

        if(saisie is not null)
        {   try
            {
                resultat = int.Parse(saisie);
            }
            catch
            {
                resultat = null;
            }
        }

    }
    return resultat.Value;
}


Console.WriteLine("Bienvenue sur ma calculatrice");


int nb1 = GetIntValue("première");

int nb2 = GetIntValue("seconde");


//COMPARAISON ENTRE CLASSES 
// Operation secondeOperation;

try {
    Console.WriteLine("Saisissez l'opérateur C# à effectuer");
    string? operateur = Console.ReadLine();
    if(operateur is null){
        Console.WriteLine("Aucun opérateur n'a été saisi");
    }
    else {
    // //AFFECTE LE TYPE D'OPERATION EN FONCTION DE L'OPERATEUR RECUPERé

    //EXPRESSION SWITCH (!= INSTRUCTION SWITCH)
    //AFFECTATION OBLIGATOIRE A GAUCHE
        Operation operation = operateur switch
        {
            "+" => operation = new Addition(nb1, nb2),
            "-" => operation = new Soustraction(nb1, nb2),
            "*" => operation = new Multiplication(nb1, nb2),
            "/" => operation = new Division(nb1, nb2),
            "%" => operation = new Modulo(nb1, nb2),
            // CAS PAR DEFAUT RENVOIE L'EXCEPTION
            _ => throw new OperateurNonReconnuException(operateur)
        };

    // INSTANCIATION DE MA CALCULATRICE SEULEMENT APRES AVOIR RECUPERé LE TYPE D'OPERATION A EXECUTER
    Calculatrice calc = new Calculatrice(operation);
    calc.Executer();
    //VA CHERCHER LE RESULTAT DANS LA CLASSE ENFANT OPERATION DE MA CALCULATRICE
    //VA CHERCHER LA METHODE TOSTRING DE LA CLASSE OBJECT QUI A ETE OVERRIDE DANS ADDITION
    Console.WriteLine($"{calc.Operation.ToString()} = {calc.Operation.Resultat}.");
    }

//ANCIEN CODE : VERSION IF ELSE
// if (operateur == "+")
// {
//     operation = new Addition(nb1, nb2);
//     // //COMPARAISON ENTRE CLASSES 
//     // secondeOperation = new Addition(nb1, nb2);
//     // //COMPARAISON ENTRE CLASSES 
//     // Console.WriteLine($"Additions égales ? {operation.Equals(secondeOperation)}");
// }
// else if (operateur == "-")
// {
//     operation = new Soustraction(nb1, nb2);
// }
// else if (operateur == "*")
// {
//     operation = new Multiplication(nb1, nb2);
// }
// else if (operateur == "/")
// {
//     operation = new Division(nb1, nb2);
// }
// else 
// {
//     operation = new Modulo(nb1, nb2);
// } 
}

//SI JE RENCONTRE UNE EXCEPTION JE RENTRE DANS LE CATCH
//LES BLOCS CATCHS SE FONT TOUJOURS DU PLUS SPECIFIQUE AU MOINS SPECIFIQUE
// (TERMINER PAR CATCH(EXCEPTION) EST UNE BONNE PRATIQUE)
catch (OperateurNonReconnuException e)
{
    Console.WriteLine(e.Message);
}
catch (Exception)
{
    Console.WriteLine("Une erreur est survenue, veuillez vérifier votre saisie");
}
//FINALLY DONNE LE BLOC DU TRY CATCH QUI SERA DE TOUTE FACON EXECUTé

