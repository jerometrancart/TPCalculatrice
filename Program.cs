using TPCalculatrice;
using TPCalculatrice.Operations;
using TPCalculatrice.DTOs;
using System.Text.Json;

///CREE LE NOM DU FICHIER EN CONST POUR POUVOIR LE MODIFIER RAPIDEMENT
const string nomFichier = "operation.json";
///STOCKE LA DERNIERE OPERATION
OperationDTO? derniereOperation = null;

///S'IL EXISTE UN FICHIER DE CE NOM
if(File.Exists(nomFichier))
{   
    ///LIT LE TEXTE (FLUX JSON) CONTENU DANS CE FICHIER
    derniereOperation = JsonSerializer.Deserialize<OperationDTO>(File.ReadAllText(nomFichier), new JsonSerializerOptions{
        ///INSENSIBLE A LA CASSE
        PropertyNameCaseInsensitive = true
    });
}



///SECURISE LE CODE POUR EVITER DE TENTER DE PARSE UNE VALEUR NULLABLE
/// WHILE (!variable.HasValue)
int GetIntValue(string rank) {

    int? resultat = null;
///    while (resultat is null) {
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
System.Console.WriteLine("Utilisez le raccourci CTRL + C pour quitter l'application");
System.Console.WriteLine();


while(true)
{

    ///DEPLACE L'INITIALISATION DE L OPERANDE GAUCHE ICI POUR LUI PERMETTRE D EXISTER AVANT LA VERIF DERNIERE OPERATION
    int? nb1 = null;

    if(derniereOperation is not null)
    {
        System.Console.WriteLine($"Dernière opération : {derniereOperation}");
        System.Console.WriteLine("Utilisez le raccourci M pour charger le résultat de cette opération dans l'opérande gauche ou appuyez sur Entrée pour saisir de nouvelles valeurs");

        var saisie = Console.ReadLine();
        ///COMPARE INDEPENDEMMENT DE LA CASSE4
        if(!string.IsNullOrWhiteSpace(saisie) && saisie.Equals("M", StringComparison.OrdinalIgnoreCase))
        {
            nb1 = derniereOperation.Resultat;
        }
    }

///DEMANDE UNE PREMIERE VALEUR UNIQUEMENT SI LE NB1 N EST PAS RECUPERE PAR LA DERNIERE OPERATION
if (!nb1.HasValue) 
{
nb1 = GetIntValue("première");
}
int nb2 = GetIntValue("seconde");


///COMPARAISON ENTRE CLASSES 
/// Operation secondeOperation;

try {
    Console.WriteLine("Saisissez l'opérateur C# à effectuer");
    string? operateur = Console.ReadLine();
    if(operateur is null){
        Console.WriteLine("Aucun opérateur n'a été saisi");
    }
    else {
    ///AFFECTE LE TYPE D'OPERATION EN FONCTION DE L'OPERATEUR RECUPERé

    ///EXPRESSION SWITCH (!= INSTRUCTION SWITCH)
    ///AFFECTATION OBLIGATOIRE A GAUCHE
        Operation operation = operateur switch
        {
            ///ICI ON SAIT QUE NB1 AURA UNE VALEUR QUOIQU IL ARRIVE PUISQU ON A DEMANDE SOIT L ANCIENNE OP SOIT DE SAISIR
            "+" => operation = new Addition(nb1.Value, nb2),
            "-" => operation = new Soustraction(nb1.Value, nb2),
            "*" => operation = new Multiplication(nb1.Value, nb2),
            "/" => operation = new Division(nb1.Value, nb2),
            "%" => operation = new Modulo(nb1.Value, nb2),
            // CAS PAR DEFAUT RENVOIE L'EXCEPTION
            _ => throw new OperateurNonReconnuException(operateur)
        };

    /// INSTANCIATION DE MA CALCULATRICE SEULEMENT APRES AVOIR RECUPERé LE TYPE D'OPERATION A EXECUTER
    Calculatrice calc = new Calculatrice(operation);
    calc.Executer();
    ///VA CHERCHER LE RESULTAT DANS LA CLASSE ENFANT OPERATION DE MA CALCULATRICE
    ///VA CHERCHER LA METHODE TOSTRING DE LA CLASSE OBJECT QUI A ETE OVERRIDE DANS ADDITION
    Console.WriteLine($"{calc.Operation.ToString()} = {calc.Operation.Resultat}.");

    ///AFFECTE LA VALEUR DE L OPERATION A LA DERNIERE OPERATION POUR LA PROCHAINE FOIS

    ///UTILISE LA METHODE D EXTENSION POUR CONVERTIR L'OPERATION EN OBJET DTO
    derniereOperation = operation.Convertir();
    
    ///UNE FOIS QU'ON A INSTANCIE LE DTO ON PEUT SERIALISER
    var json = JsonSerializer.Serialize(derniereOperation, new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
        WriteIndented = true
    });
    ///REMPLACE LE CONTENU DU FICHIER PAR LE JSON
    File.WriteAllText(nomFichier, json);
}


}

///SI JE RENCONTRE UNE EXCEPTION JE RENTRE DANS LE CATCH
///LES BLOCS CATCHS SE FONT TOUJOURS DU PLUS SPECIFIQUE AU MOINS SPECIFIQUE
/// (TERMINER PAR CATCH(EXCEPTION) EST UNE BONNE PRATIQUE)
catch (OperateurNonReconnuException e)
{
    Console.WriteLine(e.Message);
}
catch (Exception)
{
    Console.WriteLine("Une erreur est survenue, veuillez vérifier votre saisie");
}
///FINALLY DONNE LE BLOC DU TRY CATCH QUI SERA DE TOUTE FACON EXECUTé
}
