namespace Models;

class Estudiante
{
    public string Nombre { get; set; }
    private Dictionary<Asignatura, double> calificaciones;

    public Estudiante(string nombre)
    {
        Nombre = nombre;
        calificaciones = new Dictionary<Asignatura, double>();
    }

    public void AñadirCalificacion(Asignatura asignatura, double calificacion)
    {
        ValidarCalificacion(asignatura, calificacion);
    }

    public void ValidarCalificacion(Asignatura asignatura, double calificacion)
    {
        if (calificacion <=10 || calificacion >=0)
        {
            calificaciones[asignatura] = calificacion;
            Console.WriteLine($"Esta calificacion ha sido añadida {calificacion}");
        }
        else{
            Console.WriteLine($"Esta calificacion {calificacion} no es valida");
        }
    }

    public void MostrarCalificaciones()
    {
        Console.WriteLine($"\n--- Calificaciones de {Nombre} ---");
        foreach (var entrada in calificaciones)
        {
            Console.WriteLine($"{entrada.Key.Nombre}: {entrada.Value:F2}");
        }
    }

    public double CalcularPromedio()
    {
        double suma = 0;
        foreach (var entrada in calificaciones)
        {
            suma += entrada.Value;
        }
        return calificaciones.Count > 0 ? Math.Truncate(suma / calificaciones.Count *100) /100 : 0;
    }

    public void ModificarCalificacion(Asignatura asignatura, double nuevaCalificacion)
    {
        if (calificaciones.ContainsKey(asignatura))
        {
            calificaciones[asignatura] = nuevaCalificacion;
            Console.WriteLine($"Calificación de {asignatura.Nombre} modificada a {nuevaCalificacion:F2}.");
        }
        else
        {
            Console.WriteLine($"El estudiante no tiene una calificación en {asignatura.Nombre}.");
        }
    }

}