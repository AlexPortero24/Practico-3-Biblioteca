using System;// Para Console.WriteLine

namespace SistemaBiblioteca// Implementación de la clase Programa que contiene el método Main para ejecutar el sistema de gestión de biblioteca
{
    class Program// Clase principal que contiene el método Main, el punto de entrada del programa
    {
        static void Main(string[] args)// Método principal que se ejecuta al iniciar el programa, contiene la lógica para interactuar con el usuario y gestionar la biblioteca
        {
            Biblioteca miBiblioteca = new Biblioteca();// Creamos una instancia de la clase Biblioteca para gestionar nuestros libros y géneros
            bool salir = false;

            while (!salir)// Bucle principal del programa que se ejecuta hasta que el usuario decida salir, muestra un menú de opciones para interactuar con la biblioteca
            {
                Console.WriteLine("\n========================================");
                Console.WriteLine("   SISTEMA DE GESTIÓN DE BIBLIOTECA");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Registrar nuevo libro");
                Console.WriteLine("2. Buscar libro por ISBN");
                Console.WriteLine("3. Ver inventario completo");
                Console.WriteLine("4. Ver géneros literarios únicos");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine() ?? string.Empty;// Leemos la opción seleccionada por el usuario, si es nula asignamos una cadena vacía para evitar errores

                switch (opcion)// Estructura de control para manejar las diferentes opciones del menú, cada caso corresponde a una funcionalidad del sistema de gestión de biblioteca
                {
                    case "1":// Opción para registrar un nuevo libro, solicita al usuario ingresar los detalles del libro y lo registra en la biblioteca
                        Console.Write("Ingrese ISBN: ");
                        string isbn = Console.ReadLine() ?? string.Empty;// Solicitamos al usuario ingresar el ISBN del libro, si es nulo asignamos una cadena vacía para evitar errores
                        Console.Write("Ingrese Título: ");
                        string titulo = Console.ReadLine() ?? string.Empty;// Solicitamos al usuario ingresar el título del libro, si es nulo asignamos una cadena vacía para evitar errores
                        Console.Write("Ingrese Autor: ");
                        string autor = Console.ReadLine() ?? string.Empty;// Solicitamos al usuario ingresar el autor del libro, si es nulo asignamos una cadena vacía para evitar errores
                        Console.Write("Ingrese Género: ");
                        string genero = Console.ReadLine() ?? string.Empty;// Solicitamos al usuario ingresar el género del libro, si es nulo asignamos una cadena vacía para evitar errores

                        Libro nuevo = new Libro(isbn, titulo, autor, genero);// Creamos una nueva instancia de la clase Libro con los datos ingresados por el usuario
                        if (miBiblioteca.RegistrarLibro(nuevo))// Intentamos registrar el nuevo libro en la biblioteca, si el método devuelve true significa que se registró correctamente, si devuelve false significa que el ISBN ya existe en el sistema
                            Console.WriteLine("\n[EXITO] Libro registrado correctamente.");// Si el libro se registró correctamente, mostramos un mensaje de éxito al usuario
                        else
                            Console.WriteLine("\n[ERROR] El ISBN ya se encuentra en el sistema.");// Si el ISBN ya existe en el sistema, mostramos un mensaje de error al usuario indicando que no se pudo registrar el libro debido a un ISBN duplicado
                        break;

                    case "2":// Opción para buscar un libro por su ISBN, solicita al usuario ingresar el ISBN y muestra la información del libro si se encuentra o un mensaje de aviso si no se encuentra
                        Console.Write("Ingrese el ISBN a buscar: ");
                        string busqueda = Console.ReadLine() ?? string.Empty;
                        Libro? encontrado = miBiblioteca.BuscarPorIsbn(busqueda);
                        if (encontrado != null)// Si se encontró el libro, mostramos su información formateada utilizando el método ToString de la clase Libro
                            Console.WriteLine($"\nResultado: {encontrado}");
                        else// Si no se encontró el libro, mostramos un mensaje de aviso al usuario indicando que no se encontró ningún libro con ese ISBN
                            Console.WriteLine("\n[AVISO] No se encontró ningún libro con ese ISBN.");
                        break;// Salimos del caso después de manejar la búsqueda

                    case "3":// Opción para mostrar el inventario completo de libros registrados en la biblioteca, muestra un mensaje de aviso si la biblioteca está vacía o la lista de libros si hay alguno registrado
                        Console.WriteLine("\n--- INVENTARIO GENERAL ---");// Mostramos un encabezado para la sección de inventario general
                        miBiblioteca.MostrarInventario();// Llamamos al método MostrarInventario de la clase Biblioteca para mostrar el inventario completo de libros registrados, el método se encargará de mostrar un mensaje si la biblioteca está vacía o la lista de libros si hay alguno registrado
                        break;

                    case "4":// Opción para mostrar los géneros literarios únicos registrados en la biblioteca, muestra un mensaje de aviso si no hay géneros registrados o la lista de géneros si hay alguno registrado
                        Console.WriteLine("\n--- REPORTE DE GÉNEROS ---");// Mostramos un encabezado para la sección de reporte de géneros
                        miBiblioteca.MostrarGenerosDisponibles();// Llamamos al método MostrarGenerosDisponibles de la clase Biblioteca para mostrar los géneros literarios únicos registrados, el método se encargará de mostrar un mensaje si no hay géneros registrados o la lista de géneros si hay alguno registrado
                        break;// Opción para salir del programa, muestra un mensaje de despedida al usuario antes de cerrar el sistema

                    case "5":// Opción para salir del programa, muestra un mensaje de despedida al usuario antes de cerrar el sistema
                        salir = true;
                        Console.WriteLine("Cerrando el sistema...");
                        break;

                    default:// Si el usuario ingresa una opción no válida, mostramos un mensaje de error indicando que la opción no es válida
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }
}// Fin de la clase Programa