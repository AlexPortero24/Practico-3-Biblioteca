using System;// Para Console.WriteLine

namespace SistemaBiblioteca// Implementación de la clase Libro que representa la entidad Libro con sus atributos y métodos
{
    // Clase que representa la entidad Libro
    public class Libro
    {
        // Atributos autoproplementados
        public string? ISBN { get; set; }// El ISBN es la clave única para cada libro, se utiliza como clave en el mapa (Dictionary) de la clase Biblioteca
        public string? Titulo { get; set; }// El título del libro, se muestra en los reportes y se almacena como parte de la información del libro
        public string? Autor { get; set; }// El autor del libro, se muestra en los reportes y se almacena como parte de la información del libro
        public string? Genero { get; set; }// El género del libro, se muestra en los reportes y se almacena como parte de la información del libro, también se utiliza para llenar el conjunto (HashSet) de géneros únicos en la clase Biblioteca

        // Constructor para inicializar el objeto
        public Libro(string? isbn, string? titulo, string? autor, string? genero)// Constructor que recibe los atributos del libro para inicializar una nueva instancia de la clase Libro
        {
            ISBN = isbn;// Inicializamos los atributos del libro con los valores proporcionados al crear una instancia de la clase Libro
            Titulo = titulo;// Inicializamos los atributos del libro con los valores proporcionados al crear una instancia de la clase Libro
            Autor = autor;// Inicializamos los atributos del libro con los valores proporcionados al crear una instancia de la clase Libro
            Genero = genero;// Inicializamos los atributos del libro con los valores proporcionados al crear una instancia de la clase Libro
        }

        // Sobrescritura de ToString para facilitar la visualización en reportes
        public override string ToString()// Método para formatear la información del libro en una cadena legible
        {
            return $"ISBN: {(ISBN ?? string.Empty).PadRight(15)} | Título: {(Titulo ?? string.Empty).PadRight(20)} | Autor: {(Autor ?? string.Empty).PadRight(15)} | Género: {Genero ?? string.Empty}";
        }
    }
}// Fin de la clase Libro