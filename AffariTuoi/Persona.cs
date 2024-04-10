internal class Persona
{
    // Properties
    public string NomePersona { get; set; }

    public string RegionePersona{ get; set; }
    // Default Constructor
    public Persona()
    {
    }

    // Constructor
    public Persona(string nomePersona, string regionePersona)
    {
        NomePersona = nomePersona;
        RegionePersona = regionePersona;
    }

    public string SalutoPersona()
    {
        return "Ciao, sono " + NomePersona + " regione di " + RegionePersona + ", in bocca al lupo!";
    }
}
