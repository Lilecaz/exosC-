public class Video : Article
{
    public float duree { get; set; }

    public Video(string designation, float price, float duree) : base(designation, price)
    {
        this.duree = duree;
    }

    public void afficher()
    {
        Console.WriteLine("Affichage de la vidéo : " + designation);
    }
}