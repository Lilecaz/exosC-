using System;
using System.Collections.Generic;

public interface IRentable
{
    decimal CalculateRent();
}

public abstract class Publication
{
    public string Titre { get; set; }
    public decimal Prix { get; set; }

    public Publication(string titre, decimal prix)
    {
        Titre = titre;
        Prix = prix;
    }

    public abstract void PublishDetails();
}

public class Livre : Publication, IRentable
{
    public string Auteur { get; set; }

    public Livre(string titre, string auteur, decimal prix) : base(titre, prix)
    {
        Auteur = auteur;
    }

    public override void PublishDetails()
    {
        Console.WriteLine($"Livre: {Titre}, Auteur: {Auteur}, Prix: {Prix}");
    }

    public decimal CalculateRent()
    {
        // Règle de calcul pour Livre : 10% du prix
        return Prix * 0.10m;
    }
}

public class Disque : Publication, IRentable
{
    public string Artiste { get; set; }

    public Disque(string titre, string artiste, decimal prix) : base(titre, prix)
    {
        Artiste = artiste;
    }

    public override void PublishDetails()
    {
        Console.WriteLine($"Disque: {Titre}, Artiste: {Artiste}, Prix: {Prix}");
    }

    public decimal CalculateRent()
    {
        // Règle de calcul pour Disque : 15% du prix
        return Prix * 0.15m;
    }
}

public class Video : Publication, IRentable
{
    public string Réalisateur { get; set; }

    public Video(string titre, string réalisateur, decimal prix) : base(titre, prix)
    {
        Réalisateur = réalisateur;
    }

    public override void PublishDetails()
    {
        Console.WriteLine($"Vidéo: {Titre}, Réalisateur: {Réalisateur}, Prix: {Prix}");
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
        // Création d'une liste de publications
        List<Publication> publications = new List<Publication>
        {
            new Livre("Le Petit Prince", "Antoine de Saint-Exupéry", 20.00m),
            new Disque("Thriller", "Michael Jackson", 15.00m),
            new Video("Inception", "Christopher Nolan", 25.00m)
        };

        // Affichage des détails de chaque publication
        foreach (var publication in publications)
        {
            publication.PublishDetails();
        }

        // Création d'une liste d'articles rentables
        List<IRentable> articles = new List<IRentable>
        {
            new Livre("Le Petit Prince", "Antoine de Saint-Exupéry", 20.00m),
            new Disque("Thriller", "Michael Jackson", 15.00m),
            new Video("Inception", "Christopher Nolan", 25.00m)
        };

        // Affichage du coût de location pour chaque article
        foreach (var article in articles)
        {
            Console.WriteLine($"Le coût de location de l'article '{article.GetType().Name}' est : {article.CalculateRent()} €");
        }
    }
}