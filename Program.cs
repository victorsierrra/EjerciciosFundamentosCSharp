using System;
using Models;

ProgramaEducativo programa = new ProgramaEducativo();

// Crear asignaturas
Asignatura servidor = new Asignatura("Servidor", 6);
var cliente = new Asignatura("Cliente", 4);
Asignatura diseño = new("Diseño", 8);

// Crear estudiantes
var estudiante1 = new Estudiante("Vanessa Llorente");
Estudiante estudiante2 = new Estudiante("Alejandro Giménez");

//Crear estudiante para borrar
Estudiante estudianteBorrado = new Estudiante("Jaimito");

// Añadir estudiantes al programa educativo
programa.AñadirEstudiante(estudiante1);
programa.AñadirEstudiante(estudiante2);
programa.AñadirEstudiante(estudianteBorrado);

// Añadir asignatura al programa educativo
programa.AñadirAsignatura(servidor);
programa.AñadirAsignatura(servidor);

// Asignar calificaciones
estudiante1.AñadirCalificacion(servidor, 9.5);
estudiante1.AñadirCalificacion(cliente, 8.0);
estudiante1.AñadirCalificacion(diseño, 9.0);

estudiante2.AñadirCalificacion(servidor, 7.5);
estudiante2.AñadirCalificacion(cliente, 8.5);

//Modificar calificaciones
estudiante1.ModificarCalificacion(cliente, 9.33);
estudiante2.ModificarCalificacion(servidor, 7.33);

//Eliminar estudiante
programa.EliminarEstudiante("Jaimito");
programa.EliminarEstudiante("Fernando");

//Buscar estudiante
programa.BuscarEstudiantesPorNombre("Alejandro");

//Calcular promedio global
Console.WriteLine($"El promedio global de las calificaciones es {programa.CalcularPromedioGlobal()}");

//Generar reporte estudiante
programa.GenerarReporteEstudiante(estudiante1);

// Mostrar estudiantes
programa.MostrarEstudiantes();

// Mostrar calificaciones de un estudiante específico
Estudiante estudianteSeleccionado = programa.ObtenerEstudiante("Vanessa Llorente");
if (estudianteSeleccionado != null)
{
    estudianteSeleccionado.MostrarCalificaciones();
    double promedio = estudianteSeleccionado.CalcularPromedio();
    Console.WriteLine($"Promedio de {estudianteSeleccionado.Nombre}: {promedio:F2}");
}

// Mostrar calificaciones del segundo estudiante
estudianteSeleccionado = programa.ObtenerEstudiante("Alejandro Giménez");
if (estudianteSeleccionado != null)
{
    estudianteSeleccionado.MostrarCalificaciones();
    double promedio = estudianteSeleccionado.CalcularPromedio();
    Console.WriteLine($"Promedio de {estudianteSeleccionado.Nombre}: {promedio:F2}");
}