
using System.Linq;
using System.Runtime.CompilerServices;

namespace Models;

class ProgramaEducativo
{
    private List<Estudiante> estudiantes;
    private List<Asignatura> asignaturas;

    

    public ProgramaEducativo()
    {
        asignaturas = new List<Asignatura>();
        estudiantes = new List<Estudiante>();
    }

    public void AñadirEstudiante(Estudiante estudiante)
    {
        if (estudiantes.Exists(e => e.Nombre == estudiante.Nombre))
            {
                Console.WriteLine($"El estudiante {estudiante.Nombre} ya existe en el programa.");
            }
            else
            {
                // Añadir la asignatura a la lista global
                estudiantes.Add(estudiante);
                Console.WriteLine($"El estudiante {estudiante.Nombre} con ha sido añadido.");
            }
    }

    public void AñadirAsignatura(Asignatura asignatura)
    {
        if (asignaturas.Exists(a => a.Nombre == asignatura.Nombre))
        {
            Console.WriteLine($"La asignatura {asignatura.Nombre} ya existe en el programa");
        }
        else
        {
            asignaturas.Add(asignatura);
            Console.WriteLine($"La asignatura {asignatura.Nombre} ha sido añadida");
        }
    }

    public void MostrarEstudiantes()
    {
        Console.WriteLine("\n--- Lista de Estudiantes ---");
        foreach (var estudiante in estudiantes)
        {
            Console.WriteLine($"Estudiante: {estudiante.Nombre}");
        }
    }

    public void MostrarRankingEstudiantes()
    {
        Console.WriteLine("\n--- Ranking de Estudiantes ---");
        Dictionary <string,  double> ranking = new Dictionary<string, double>();

        foreach (var estudiante in estudiantes)
        {
            ranking.Add(estudiante.Nombre, estudiante.CalcularPromedio());
            //Console.WriteLine(estudiante.Nombre + estudiante.CalcularPromedio());
        }
        ranking = ranking.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        foreach (var rank in ranking){
            Console.WriteLine($"{rank.Key}: {rank.Value:F2}");
        }
    }

        public void ListarEstudiantesSuspensos()
    {
        List<Estudiante> estudiantesSuspensos =  new List<Estudiante>();

        Console.WriteLine("\n--- Estudiantes con Notas Suspensas ---");
        foreach (var estudiante in estudiantes)
        {
            if (estudiante.CalcularPromedio() < 5.0)
            {
                estudiantesSuspensos.Add(estudiante);
            }
        }
        foreach (var suspensos in estudiantesSuspensos)
        {
            Console.WriteLine($"{suspensos.Nombre} está en riesgo de suspender con un promedio de {suspensos.CalcularPromedio()}");
        }
    }

    public Estudiante ObtenerEstudiante(string nombre)
    {
        foreach (var estudiante in estudiantes)
        {
            if (estudiante.Nombre == nombre)
            {
                return estudiante;
            }
        }
        return null;
    }

    public List<Estudiante> BuscarEstudiantesPorNombre(string parteDelNombre)
    {
        List<Estudiante> resultados = estudiantes.FindAll(e => e.Nombre.ToLower().Contains(parteDelNombre.ToLower()));
        foreach(var resultado in resultados){
            Console.WriteLine($"Estudiante {resultado.Nombre}");
        }
        return resultados;
    }

    public void EliminarEstudiante(string nombre)
    {
        Estudiante estudiante = ObtenerEstudiante(nombre);
        if (estudiante != null)
        {
            estudiantes.Remove(estudiante);
            Console.WriteLine($"El estudiante {nombre} ha sido eliminado.");
        }
        else
        {
            Console.WriteLine($"El estudiante {nombre} no fue encontrado.");
        }
    }

    public double CalcularPromedioGlobal()
    {
        double sumaPromedios = 0;
        int contadorEstudiantes = 0;

        foreach (var estudiante in estudiantes)
        {
            sumaPromedios += estudiante.CalcularPromedio();
            contadorEstudiantes++;
        }


        return contadorEstudiantes > 0 ? Math.Truncate(sumaPromedios / contadorEstudiantes * 100) / 100 : 0;
    }

    public void GenerarReporteEstudiante(Estudiante estudiante)
    {
        Console.WriteLine($"\n--- Reporte para {estudiante.Nombre} ---");
        estudiante.MostrarCalificaciones();
        double promedio = estudiante.CalcularPromedio();
        Console.WriteLine($"Promedio final: {promedio:F2}");
    }

}