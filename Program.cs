namespace QuizSimplon;
using System;
using System.IO;
class Program
{
    static int score = 0;

    static string cheminFichierCSV = "QuestionsExample.csv";
             
    static string[] lignes = File.ReadAllLines(cheminFichierCSV);

    private static Dictionary<string, string> questions = new Dictionary<string, string>
    {
        {"Quel language est utilisé pour créer des applications Android?", "Java"},
        {"Qu'est-ce que HTML représente?","HyperText Markup Langage"},
        {"Quel est le symbole utilisé pour écrire un commentaire en C# ?", "//"},
    };

    static void FaireQuizzAleatoire()
    {
        Console.WriteLine("Vous avez choisi le quizz aléatoire");
        Console.WriteLine(questions);
        foreach (var question in questions)
        {
            Console.WriteLine(question.Key);
            string? userAnswer = Console.ReadLine();

            if (userAnswer?.ToLower() == question.Value.ToLower())
            {
                Console.WriteLine("Correct");
                score++;

            }

            else
            {
                Console.WriteLine("Incorrect");
            }
        }
    }

    static void ChangerCategorie()
    {
        Console.WriteLine("Vous avez choisi de changer de catégorie");
    }

    static void QuitterProgramme()
    {
        Console.WriteLine("Vous quittez le programme");
    }

    static void LireCsv() {

     for (int i = 1; i < lignes.Length; i++) {
            string[] champs = lignes[i].Split(";");
            string question = champs[0];
            string reponse1 = champs[1];
            string reponse2 = champs[2];
            string reponse3 = champs[3];
            string numeroBonneReponse = champs[4];

            Console.WriteLine($"Question : {question}");
            Console.WriteLine($"Réponses : {reponse1}, {reponse2}, {reponse3}");
            Console.WriteLine($"La bonne réponse est la réponse : {numeroBonneReponse}");
        }
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Bienvenue dans le quiz Simplon");
        Console.WriteLine("Que souhaitez-vous faire?");
        bool continuer = true;
        while (continuer)
        {
            Console.WriteLine();
            Console.WriteLine("1. Faire un quizz aléatoire");
            Console.WriteLine("2. Changer de catégorie");
            Console.WriteLine("3. Quitter");

            Console.Write("Entrez votre choix : ");
            string? choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    LireCsv();
                    Console.WriteLine($"Votre score est de {score}");
                    break;

                case "2":
                    ChangerCategorie();
                    break;

                case "3":
                    continuer = false;
                    QuitterProgramme();
                    break;
            }
        }
    }
}
