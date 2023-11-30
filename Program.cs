namespace QuizSimplon;
using System;
using System.Collections.Concurrent;
using System.IO;
class Program
{
    static int score = 0;

    static string cheminFichierCSV = "QuestionsExample.csv";
             
    static string[] lignes = File.ReadAllLines(cheminFichierCSV);

    private static Dictionary<string, string> questionsCode = new Dictionary<string, string>
    {
        {"Quel language est utilisé pour créer des applications Android?", "Java"},
        {"Qu'est-ce que HTML représente?","HyperText Markup Langage"},
        {"Quel est le symbole utilisé pour écrire un commentaire en C# ?", "//"},
    };

    static void FaireQuizzAleatoire()
    {
        Console.WriteLine("Vous avez choisi le quizz aléatoire");
        Console.WriteLine(questionsCode);
        foreach (var question in questionsCode)
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
        Environment.Exit(0);
    }

    static void LireCsv() {

        foreach (string ligne in lignes) {
            string[] parts = ligne.Split(";");
            string question = parts[0];
            string[] answers = parts[1].Split("/");
            int correctAnswerIndex = int.Parse(parts[2]) -1;
            Console.WriteLine("Question: " + question);

            for (int i = 0; i < answers.Length; i++)
            {
                Console.WriteLine($"{i+1}. {answers[i]}");
            }

            bool validInput = false;
            int userInput = 0;

            while (!validInput)
            {
            Console.WriteLine("Entrez votre réponse (1, 2, 3, ect..): ");
            string? input = Console.ReadLine();
                if (int.TryParse(input, out userInput))
                    {
                        validInput = true;
                    } else {
                        Console.WriteLine("Entrez un nombre valide.");
                    }
            }        
                    {
                        if (userInput == correctAnswerIndex) {
                            Console.WriteLine("La réponse est correcte");
                        } else {
                            Console.WriteLine("La réponse est incorrecte");
                        }
                    } 

            Console.WriteLine("Réponse correcte: " + answers[correctAnswerIndex]);
            Console.WriteLine();
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
