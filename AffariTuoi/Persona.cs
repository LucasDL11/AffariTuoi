internal class Persona
{
    // Proprietà
    public string NomePersona { get; set; }
    public string RegionePersona { get; set; }

    // Costruttore predefinito
    public Persona()
    {
    }

    // Costruttore
    public Persona(string nomePersona, string regionePersona)
    {
        NomePersona = nomePersona;
        RegionePersona = regionePersona;
    }

    // Metodo per il saluto
    public string SalutoPersona()
    {
        return $"Ciao, sono {NomePersona} della regione {RegionePersona}, in bocca al lupo!";
    }
}
