public class Livre : Article
{
    public bool isNb { get; set; }

    public int nbPages { get; set; }

    public Livre(string designation, float price, bool isNb, int nbPages) : base(designation, price)
    {
        this.isNb = isNb;
        this.nbPages = nbPages;
    }

}