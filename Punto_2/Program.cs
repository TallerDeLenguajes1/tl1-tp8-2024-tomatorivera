﻿using EspacioCalculadora;

var historial = new List<Operacion>();

Calculadora c = new Calculadora();
int opcion = 0, opcionSalir = 8;

do {
    Console.WriteLine("===== CALCULADORA =====");
    Console.WriteLine("1. Sumar");
    Console.WriteLine("2. Restar");
    Console.WriteLine("3. Multiplicar");
    Console.WriteLine("4. Dividir");
    Console.WriteLine("5. Limpiar resultado");
    Console.WriteLine("6. Mostrar resultado actual");
    Console.WriteLine("7. Mostrar historial");
    Console.WriteLine("8. Finalizar");
    Console.Write("> Seleccione una operacion: ");

    string strOpcion = Console.ReadLine();

    // Verifico si la opcion ingresada es valida
    if (!int.TryParse(strOpcion, out opcion)) {
        Console.WriteLine("\n[!] Opcion invalida\n");
    } else {
        int termino = 0;
        string strTermino = "0";
        
        // Si la opcion es mayor a 4 (5 o 6 o menor a 1) no es necesario solicitar un termino
        if (opcion >= 1 && opcion <= 4) 
        {
            Console.Write("\nIngrese el termino a operar: ");
            strTermino = Console.ReadLine();
        }

        // Si no se ingresó un termino (opción 5 o 6) esto será true puesto que strTermino inicializa en "0"
        if (!int.TryParse(strTermino, out termino)) {
            Console.WriteLine("\n[!] Debe ingresar un numero real\n");
        } else {
            Operacion ultimaOperacion;

            switch (opcion) {
                case 1:
                    ultimaOperacion = new Operacion();
                    ultimaOperacion.ResultadoAnterior = c.Resultado;

                    c.sumar(termino);

                    ultimaOperacion.NuevoValor = termino;
                    ultimaOperacion.tipoOperacion = TipoOperacion.SUMA;
                    historial.Add(ultimaOperacion);
                    break;
                case 2:
                    ultimaOperacion = new Operacion();
                    ultimaOperacion.ResultadoAnterior = c.Resultado;

                    c.restar(termino);

                    ultimaOperacion.NuevoValor = termino;
                    ultimaOperacion.tipoOperacion = TipoOperacion.RESTA;
                    historial.Add(ultimaOperacion);
                    break;
                case 3:
                    ultimaOperacion = new Operacion();
                    ultimaOperacion.ResultadoAnterior = c.Resultado;

                    c.multiplicar(termino);

                    ultimaOperacion.NuevoValor = termino;
                    ultimaOperacion.tipoOperacion = TipoOperacion.MULTIPLICACION;
                    historial.Add(ultimaOperacion);
                    break;
                case 4:
                    if (termino == 0) Console.WriteLine("\n[!] No se puede dividir por cero");
                    else
                    {
                        ultimaOperacion = new Operacion();
                        ultimaOperacion.ResultadoAnterior = c.Resultado;

                        c.dividir(termino);

                        ultimaOperacion.NuevoValor = termino;
                        ultimaOperacion.tipoOperacion = TipoOperacion.DIVISION;
                        historial.Add(ultimaOperacion);
                    }             
                    break;
                case 5:
                    ultimaOperacion = new Operacion();
                    ultimaOperacion.ResultadoAnterior = c.Resultado;

                    c.limpiar();

                    ultimaOperacion.NuevoValor = termino;
                    ultimaOperacion.tipoOperacion = TipoOperacion.LIMPIAR;
                    historial.Add(ultimaOperacion);
                    break;
                case 6:
                    // Muestra el resultado luego del switch
                    break;
                case 7:
                    Console.WriteLine("\n*** Historial de tareas ***");
                    foreach (Operacion op in historial)
                    {
                        Console.WriteLine($"\t{op}");
                    }
                    break;
                case 8:
                    Console.WriteLine("\n*** EJECUCION FINALIZADA ***");
                    break;
                default:
                    Console.WriteLine("\n[!] Opcion invalida");
                    break;
            }

            Console.WriteLine($"\n*** El resultado actual es: {c.Resultado} ***\n");
        }
    }
} while (opcion != opcionSalir);