using Distribuidora;

var tareasPendientes = new List<Tarea>();
var tareasRealizadas = new List<Tarea>();

var tareaA = new Tarea(1, "Tarea A", 10);
var tareaB = new Tarea(2, "Tarea B", 15);
var tareaC = new Tarea(3, "Tarea C", 20);
tareasPendientes.Add(tareaA);
tareasPendientes.Add(tareaB);
tareasPendientes.Add(tareaC);


// Interfaz
int opcionSalir = 4, opcionSeleccionada = 0;
do {
    Console.WriteLine("\n\n===== MENU DE TAREAS =====");
    Console.WriteLine("1. Ver tareas");
    Console.WriteLine("2. Marcar tarea como completada");
    Console.WriteLine("3. Filtrar tareas pendientes");
    Console.WriteLine("4. Salir");
    Console.Write("> Digite una opcion: ");
    string strOpcion = Console.ReadLine();

    if (!int.TryParse(strOpcion, out opcionSeleccionada))
    {
        Console.WriteLine("\n[!] Opcion invalida");
    }
    else
    {
        switch (opcionSeleccionada)
        {
            case 1:
                mostrarTareas(tareasPendientes, "PENDIENTES");
                mostrarTareas(tareasRealizadas, "REALIZADAS");
                break;
            case 2:
                Tarea tareaMover = seleccionarTarea(tareasPendientes);
                if (tareaMover.Id != -1) 
                {
                    tareasRealizadas.Add(tareaMover);
                }
                break;
            case 3:
                Console.Write("\nIngrese la descripcion a buscar: ");
                string descripcion = Console.ReadLine();

                Tarea tareaFiltrada = filtrarTarea(tareasPendientes, descripcion);
                if (tareaFiltrada.Id != -1)
                {
                    Console.WriteLine("\nInformacion de la tarea buscada: ");
                    Console.WriteLine($"\t{tareaFiltrada} - Estado: PENDIENTE");
                }
                else
                {
                    tareaFiltrada = filtrarTarea(tareasRealizadas, descripcion);
                    if (tareaFiltrada.Id != -1) 
                    {
                        Console.WriteLine("\nInformacion de la tarea buscada: ");
                        Console.WriteLine($"\t{tareaFiltrada} - Estado: REALIZADA");
                    }
                    else
                    {
                        Console.WriteLine($"\nNo hay ninguna tarea que coincida con la descripcion ingresada");
                    }
                }
                break;
            case 4:
                Console.WriteLine("\n\n* Programa finalizado");
                break;
            default:
                Console.WriteLine("\n[!] Opcion invalida");
                break;
        }
    }

} while (opcionSeleccionada != opcionSalir);

/// <summary>
/// Muestra el contenido de una lista de Tareas
/// </summary>
/// <param name="lista">
/// Lista a mostrar
/// </param>
/// <param name="titulo">
/// Titulo a mostrar antes de la lista
/// </param>
static void mostrarTareas(List<Tarea> lista, string titulo) {
    Console.WriteLine("\n\n*** TAREAS " + titulo + " ***");

    foreach (Tarea tarea in lista)
    {
        Console.WriteLine($"\tTarea {tarea}");
    }
}

/// <summary>
/// Obtiene una Tarea que el usuario puede seleccionar a partir de una lista
/// </summary>
/// <param name="lista">
/// Lista de donde seleccionar
/// </param>
/// <return>
/// Objeto tarea seleccionado por el usuario
/// </return>
static Tarea seleccionarTarea(List<Tarea> lista) {
    int opcion = 0;
    string strOpcion;
    Tarea tareaMover = new Tarea();

    if (lista.Count > 0) {

        Console.WriteLine("\n*** TAREAS PENDIENTES ***");
        for (int i=1 ; i<=lista.Count ; i++)
        {
            Console.WriteLine($"Opcion {i}) {lista.ElementAt(i-1)}");
        }
        Console.Write("> Digite una opcion: ");
        strOpcion = Console.ReadLine();

        bool conversion = int.TryParse(strOpcion, out opcion);
        if (!conversion || opcion <= 0 || opcion > lista.Count) {
            Console.WriteLine("\n\n[!] Opcion invalida");
        }
        else
        {
            tareaMover = lista.ElementAt(opcion-1);
            lista.RemoveAt(opcion-1);
        }

    }
    else {
        Console.WriteLine("\nNo hay tareas pendientes");
    }

    return tareaMover;
}

/// <summary>
/// Filtra una tarea de una lista segun su descripcion
/// </summary>
/// <param name="lista">
/// Lista de donde filtrar
/// </param>
/// <param name="descripcion">
/// Descripcion que se desea filtrar
/// </param>
/// <return>
/// Objeto tarea filtrado de la lista 'lista'
/// </return>
static Tarea filtrarTarea(List<Tarea> lista, string descripcion) {
    Tarea coincidencia = new Tarea();

    foreach (Tarea tarea in lista) {
        if (tarea.Descripcion.Contains(descripcion))
        {
            coincidencia = tarea;
        }
    }

    return coincidencia;
}