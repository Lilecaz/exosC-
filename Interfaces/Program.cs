using System;
using System.Collections.Generic;

public interface IRentable
{
    decimal CalculateRent();
}

public class Livre : IRentable
{
    public string Titre { get; set; }
    public string Auteur { get; set; }
    public decimal Prix { get; set; }

    public Livre(string titre, string auteur, decimal prix)
    {
        Titre = titre;
        Auteur = auteur;
        Prix = prix;
    }

    public decimal CalculateRent()
    {
        // Règle de calcul pour Livre : 10% du prix
        return Prix * 0.10m;
    }
}

public class Disque : IRentable
{
    public string Titre { get; set; }
    public string Artiste { get; set; }
    public decimal Prix { get; set; }

    public Disque(string titre, string artiste, decimal prix)
    {
        Titre = titre;
        Artiste = artiste;
        Prix = prix;
    }

    public decimal CalculateRent()
    {
        // Règle de calcul pour Disque : 15% du prix
        return Prix * 0.15m;
    }
}

public class Video : IRentable
{
    public string Titre { get; set; }
    public string Réalisateur { get; set; }
    public decimal Prix { get; set; }

    public Video(string titre, string réalisateur, decimal prix)
    {
        Titre = titre;
        Réalisateur = réalisateur;
        Prix = prix;
    }

    public decimal CalculateRent()
    {
        // Règle de calcul pour Vidéo : 20% du prix
        return Prix * 0.20m;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Création d'une liste d'articles
        List<IRentable> articles = new List<IRentable>
        {
            new Livre("Le Petit Prince", "Antoine de Saint-Exupéry", 20.00m),
            new Disque("Thriller", "Michael Jackson", 15.00m),
            new Video("Inception", "Christopher Nolan", 25.00m)
        };

        // Parcours de la liste et affichage du coût de location pour chaque article
        foreach (var article in articles)
        {
            Console.WriteLine($"Le coût de location de l'article '{article.GetType().Name}' est : {article.CalculateRent()} €");
        }
    }
}