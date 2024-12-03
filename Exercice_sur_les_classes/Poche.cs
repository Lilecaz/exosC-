public class Poche : Livre
{
    private string categorie { get; set; }

    public Poche(string designation, float price, bool isNb, int nbPages, string categorie) : base(designation, price, isNb, nbPages)
    {
        this.categorie = categorie;
    }
}