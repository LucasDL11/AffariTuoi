internal class Pacco
{
    public string Colore { get; set; }
    public int Valore { get; set; }
    public Persona Persona { get; set; }
    public bool Disponibile { get; set; }
    public bool AppartieneAlGiocatore { get; set; }

    // Costruttore predefinito
    public Pacco()
    {
    }

    // Costruttore
    public Pacco(string colore, int valore)
    {
        Colore = colore;
        Valore = valore;
        Persona = new Persona();
        Disponibile = true;
        AppartieneAlGiocatore = false;
    }

    public override string ToString()
    {
        return $"Persona: {Persona.NomePersona}, Regione di Persona: {Persona.RegionePersona}, Valore Pacco: {Valore}";
    }
}
