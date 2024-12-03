using System;
using System.Collections.Generic;

public enum TypeArticle
{
    Alimentaire,
    Droguerie,
    Habillement,
    Loisir
}

public struct Article
{
    public string Nom { get; set; }
    public decimal Prix { get; set; }
    public int Quantite { get; set; }
    public TypeArticle Type { get; set; }

    public Article(string nom, decimal prix, int quantite, TypeArticle type)
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

public delegate decimal DiscountStrategy(Article article);

public static class DiscountStrategies
{
    public static decimal FixedPercentageDiscount(Article article)
    {
        decimal discountRate = 0.10m; // 10% de remise
        return article.Prix * discountRate;
    }

    public static decimal TypeBasedDiscount(Article article)
    {
        decimal discount = 0m;
        switch (article.Type)
        {
            case TypeArticle.Alimentaire:
                discount = article.Prix * 0.05m; // 5% de remise pour les articles alimentaires
                break;
            case TypeArticle.Droguerie:
                discount = article.Prix * 0.10m; // 10% de remise pour les articles de droguerie
                break;
            case TypeArticle.Habillement:
                discount = article.Prix * 0.15m; // 15% de remise pour les articles d'habillement
                break;
            case TypeArticle.Loisir:
                discount = article.Prix * 0.20m; // 20% de remise pour les articles de loisir
                break;
        }
        return discount;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Création d'une liste d'articles
        List<Article> articles = new List<Article>
        {
            new Article("Pomme", 1.00m, 100, TypeArticle.Alimentaire),
            new Article("Shampooing", 5.00m, 50, TypeArticle.Droguerie),
            new Article("T-shirt", 20.00m, 30, TypeArticle.Habillement),
            new Article("Jeu vidéo", 60.00m, 10, TypeArticle.Loisir)
        };

        // Affichage des articles avec remise fixe
        Console.WriteLine("Remise fixe de 10% :");
        foreach (var article in articles)
        {
            decimal remise = DiscountStrategies.FixedPercentageDiscount(article);
            Console.WriteLine($"Article: {article.Nom}, Prix: {article.Prix}, Remise: {remise}, Prix après remise: {article.Prix - remise}");
        }

        // Affichage des articles avec remise basée sur le type
        Console.WriteLine("\nRemise basée sur le type d'article :");
        foreach (var article in articles)
        {
            decimal remise = DiscountStrategies.TypeBasedDiscount(article);
            Console.WriteLine($"Article: {article.Nom}, Prix: {article.Prix}, Remise: {remise}, Prix après remise: {article.Prix - remise}");
        }
    }
}