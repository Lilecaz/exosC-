using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;

public enum TypeArticle
{
    Alimentaire,
    Droguerie,
    Habillement,
    Loisir
}

public struct ArticleTypé
{
    public string Nom { get; set; }
    public decimal Prix { get; set; }
    public int Quantite { get; set; }
    public TypeArticle Type { get; set; }

    public ArticleTypé(string nom, decimal prix, int quantite, TypeArticle type)
    {
        Nom = nom;
        Prix = prix;
        Quantite = quantite;
        Type = type;
    }

    public void Afficher()
    {
        Console.WriteLine($"Nom: {Nom}, Prix: {Prix}, Quantité: {Quantite}, Type: {Type}");
    }
}

public static class ExtensionMethods
{
    public static void AfficherTous(this IEnumerable<ArticleTypé> articles)
    {
        foreach (var article in articles)
        {
            article.Afficher();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Initialisation d'une liste d'articles
        List<ArticleTypé> articles = new List<ArticleTypé>
        {
            new ArticleTypé("Pomme", 2.5m, 50, TypeArticle.Alimentaire),
            new ArticleTypé("Savon", 3.2m, 30, TypeArticle.Droguerie),
            new ArticleTypé("T-shirt", 15.0m, 20, TypeArticle.Habillement),
            new ArticleTypé("Jeu vidéo", 60.0m, 10, TypeArticle.Loisir)
        };

        // Utilisation de la méthode d'extension AfficherTous() pour afficher tous les articles
        Console.WriteLine("Liste des articles :");
        articles.AfficherTous();

        // Requêtes LINQ de base
        // 1. Lister tous les articles appartenant à un type spécifique (ex. "Alimentaire")
        var alimentaires = articles.Where(a => a.Type == TypeArticle.Alimentaire);
        Console.WriteLine("\nArticles de type Alimentaire :");
        alimentaires.AfficherTous();

        // 2. Trier les articles par prix décroissant
        var articlesTries = articles.OrderByDescending(a => a.Prix);
        Console.WriteLine("\nArticles triés par prix décroissant :");
        articlesTries.AfficherTous();

        // 3. Calculer le stock total pour tous les articles
        var stockTotal = articles.Sum(a => a.Quantite);
        Console.WriteLine($"\nStock total pour tous les articles : {stockTotal}");

        // Calculer la valeur totale du stock de tous les articles en utilisant une expression lambda
        var valeurTotaleStock = articles.Sum(a => a.Prix * a.Quantite);
        Console.WriteLine($"\nValeur totale du stock pour tous les articles : {valeurTotaleStock} €");

        // Filtrage avancé avec l’opérateur OfType
        // Créez une liste contenant à la fois des objets ArticleTypé et d’autres objets quelconques
        List<object> mixedList = new List<object>
        {
            new ArticleTypé("Pomme", 2.5m, 50, TypeArticle.Alimentaire),
            new ArticleTypé("Savon", 3.2m, 30, TypeArticle.Droguerie),
            "Un objet quelconque",
            12345
        };

        // Utilisez l’opérateur OfType<ArticleTypé>() pour extraire uniquement les articles typés de cette collection
        var articlesFiltres = mixedList.OfType<ArticleTypé>();
        Console.WriteLine("\nArticles filtrés avec OfType<ArticleTypé> :");
        articlesFiltres.AfficherTous();

        // Projection avec des types anonymes
        // Créez une vue simplifiée de vos articles en ne conservant que le nom et le prix sous forme de type anonyme
        var articlesAnonymes = articles.Select(a => new { a.Nom, a.Prix });
        Console.WriteLine("\nNom et prix des articles (types anonymes) :");
        foreach (var article in articlesAnonymes)
        {
            Console.WriteLine($"Nom: {article.Nom}, Prix: {article.Prix}");
        }

        // Sérialisation JSON
        string jsonString = JsonSerializer.Serialize(articles, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("articles.json", jsonString);
        Console.WriteLine("\nListe des articles exportée vers le fichier articles.json");

        // Désérialisation JSON
        string jsonStringFromFile = File.ReadAllText("articles.json");
        List<ArticleTypé> articlesDeserialized = JsonSerializer.Deserialize<List<ArticleTypé>>(jsonStringFromFile);
        Console.WriteLine("\nListe des articles chargée depuis le fichier articles.json :");
        articlesDeserialized.AfficherTous();
    }
}