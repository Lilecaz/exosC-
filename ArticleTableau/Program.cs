using System;

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

    public void Ajouter(int quantite)
    {
        if (quantite > 0)
        {
            Quantite += quantite;
        }
        else
        {
            Console.WriteLine("La quantité à ajouter doit être un entier positif.");
        }
    }

    public void Retirer(int quantite)
    {
        if (quantite > 0)
        {
            if (Quantite >= quantite)
            {
                Quantite -= quantite;
            }
            else
            {
                Console.WriteLine("Quantité insuffisante pour retirer.");
            }
        }
        else
        {
            Console.WriteLine("La quantité à retirer doit être un entier positif.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Création d'un tableau de trois articles
        Article[] articles = new Article[3];
        articles[0] = new Article("Stylo", 1.50m, 100, TypeArticle.Loisir);
        articles[1] = new Article("Cahier", 2.75m, 50, TypeArticle.Habillement);
        articles[2] = new Article("Gomme", 0.99m, 200, TypeArticle.Droguerie);

        // Affichage des articles
        Console.WriteLine("Articles initiaux :");
        foreach (var article in articles)
        {
            article.Afficher();
        }

        // Modification des quantités
        articles[0].Ajouter(20);
        articles[1].Retirer(10);
        articles[2].Ajouter(50);

        // Affichage des articles après modification
        Console.WriteLine("\nAprès modification des quantités :");
        foreach (var article in articles)
        {
            article.Afficher();
        }
    }
}