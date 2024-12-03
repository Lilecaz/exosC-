public class Disque : Article
{
    public string label { get; set; }

    public Disque(string designation, float price, string label) : base(designation, price)
    {
        this.label = label;
    }

    public void ecouter()
    {
        Console.WriteLine("Ecoute du disque : " + designation);
    }
}