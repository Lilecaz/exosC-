public class Article
{
    public string designation { get; set; }
    public float price { get; set; }

    public Article(string designation, float price)
    {
        this.designation = designation;
        this.price = price;
    }

    public override string ToString()
    {
        return "Article : " + designation + " - " + price + "€";
    }

    public void acheter()
    {
        Console.WriteLine("Achat de l'article : " + designation);
    }
}