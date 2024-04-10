internal class Pacco
{
    // Properties
    public string NomeRegione { get; set; }

    public string Colore { get; set; }
    public int Valore { get; set; }
    public Persona Persona { get; set; }

    public bool Disponibile { get; set; }
    // Default Constructor
    public Pacco()
    {
    }

    // Constructor

    public Pacco(string colore, int valore)
    {
        Colore = colore;
        Valore = valore;
        Persona = new Persona();
        Disponibile = true;
    }

    public Pacco(string nomeRegione, int valore, Persona persona)
    {
        NomeRegione = nomeRegione;
        Valore = valore;
        Persona = persona;
    }
    public override string ToString()
    {
        return $"Persona: {Persona.NomePersona}, Regione di Persona: {Persona.RegionePersona}, Nome Regione Pacco: {NomeRegione}, Valore Pacco: {Valore}";
    }
}
