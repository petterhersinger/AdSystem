namespace AdSystem.Models;

public class AnnonsorModel
{
    public int AnnonsorId { get; set; }
    public int? PrenumerantId { get; set; }
    public bool ForetagsAnnonsor { get; set; }
    public string Namn { get; set; }
    public string Organisationsnummer { get; set; }
    public string Telefonnummer { get; set; }
    public string Utdelningsadress { get; set; }
    public string Postnummer { get; set; }
    public string Ort { get; set; }
    public string Fakturaadress { get; set; }
}