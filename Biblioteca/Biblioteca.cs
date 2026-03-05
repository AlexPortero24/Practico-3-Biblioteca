using System; // Para Console.WriteLine
using System.Collections.Generic;// Para Dictionary y HashSet

namespace SistemaBiblioteca// Implementación de la clase Biblioteca utilizando Mapa (Dictionary) y Conjunto (HashSet)
{
    public class Biblioteca// Clase que representa una biblioteca con un catálogo de libros y un conjunto de géneros únicos
    {
        // MAPA: Dictionary para acceso rápido por ISBN (O(1))// Clave: ISBN, Valor: Objeto Libro
        private Dictionary<string, Libro> catalogoLibros;// Mapa para almacenar libros con acceso rápido por ISBN

        // CONJUNTO: HashSet para almacenar géneros únicos sin duplicados
        private HashSet<string> generosUnicos;// Conjunto para almacenar géneros únicos sin duplicados

        public Biblioteca()// Constructor que inicializa el mapa y el conjunto
        {
            catalogoLibros = new Dictionary<string, Libro>();// Inicializamos el mapa para almacenar libros
            generosUnicos = new HashSet<string>();// Inicializamos el conjunto para almacenar géneros únicos
        }

        // Método para registrar un libro con validación de duplicados
        public bool RegistrarLibro(Libro nuevoLibro)// Método para registrar un libro, devuelve true si se registró correctamente, false si el ISBN ya existe
        {
            // Verificamos en el mapa si el ISBN ya existe
            if (catalogoLibros.ContainsKey(nuevoLibro.ISBN ?? string.Empty))// Verificamos si el ISBN ya está registrado en el mapa
            {
                return false; // El ISBN ya está registrado
            }

            // Agregamos al mapa (clave = ISBN, valor = objeto Libro)
            catalogoLibros.Add(nuevoLibro.ISBN ?? string.Empty, nuevoLibro);

            // Agregamos al conjunto (el HashSet ignora automáticamente si el género ya existe)
            if (nuevoLibro.Genero != null)// Verificamos que el género no sea nulo antes de agregarlo al conjunto
            {
                generosUnicos.Add(nuevoLibro.Genero);// Agregamos el género al conjunto, el HashSet se encargará de evitar duplicados
            }
            
            return true;// El libro se registró correctamente
        }

        // Método de búsqueda instantánea por clave (Mapa)
        public Libro? BuscarPorIsbn(string isbn)// Método para buscar un libro por su ISBN, devuelve el libro si se encuentra o null si no existe
        {
            if (catalogoLibros.TryGetValue(isbn, out Libro? libroEncontrado))// Intentamos obtener el libro del mapa usando el ISBN como clave
            {
                return libroEncontrado;// Si se encuentra el libro, lo devolvemos
            }
            return null;// Si no se encuentra el libro, devolvemos null
        }

        // Reportería: Listado general de libros
        public void MostrarInventario()// Método para mostrar el inventario completo de libros registrados en la biblioteca
        {
            if (catalogoLibros.Count == 0)// Verificamos si el mapa está vacío antes de intentar mostrar los libros
            {
                Console.WriteLine("La biblioteca está vacía.");// Si no hay libros registrados, mostramos un mensaje indicando que la biblioteca está vacía
                return;// Salimos del método para evitar intentar mostrar libros cuando no hay ninguno registrado
            }

            foreach (var libro in catalogoLibros.Values)// Iteramos sobre los valores del mapa (los objetos Libro) para mostrar su información
            {
                Console.WriteLine(libro.ToString());// Mostramos la información de cada libro utilizando su método ToString() para formatear la salida
            }
        }

        // Reportería: Listado de categorías únicas (Conjunto)
        public void MostrarGenerosDisponibles()
        {
            Console.WriteLine("Categorías registradas (Sin duplicados):");// Mostramos un encabezado para la sección de géneros disponibles
            foreach (var genero in generosUnicos)// Iteramos sobre el conjunto de géneros únicos para mostrar cada uno de ellos
            {
                Console.WriteLine($"- {genero}");// Mostramos cada género único registrado en el conjunto, el HashSet garantiza que no haya duplicados
            }
        }
    }
}// Fin de la clase Biblioteca