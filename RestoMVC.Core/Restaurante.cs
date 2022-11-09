namespace RestoMVC.Core;

public class Restaurante
{
    public int Id { get; set; }

    public string Nombre { get; set; }

    public string Direccion { get; set; }

    public string Mail { get; set; }

    public int Telefono { get; set; }

    public string Contrasenia { get; set; }
    public List<Plato> Platos { get; set; }
    public Restaurante() => Platos = new List<Plato>();
    public Restaurante(string nombre, string direccion, string mail, int telefono, string contrasenia) : this()
    {
        Nombre = nombre;
        Direccion = direccion;
        Mail = mail;
        Telefono = telefono;
        Contrasenia = contrasenia;
    }
    public void AgregarPlato(Plato plato) => Platos.Add(plato);

}