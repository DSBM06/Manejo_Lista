using System;
using System.Collections.Generic;

namespace Ejercicio_1_Manejo_Listas
{
    class Producto
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }

        public override string ToString()
        {
            return $"Codigo: {Codigo}, Nombre: {Nombre}, Cantidad: {Cantidad}, Precio: {Precio}";
        }
    }

    class Program
    {
        static void Main()
        {
            List<Producto> productos = new List<Producto>();
            int opcion = 0;

            do
            {
                Console.WriteLine("\n--- Menú de Inventario ---");
                Console.WriteLine("1. Agregar producto");
                Console.WriteLine("2. Eliminar producto");
                Console.WriteLine("3. Modificar producto");
                Console.WriteLine("4. Consultar producto");
                Console.WriteLine("5. Mostrar todos los productos");
                Console.WriteLine("6. Salir");
                Console.Write("\nElige una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1: agregarProducto(productos); 
                            break;
                    case 2: eliminarProducto(productos); 
                            break;
                    case 3: modificarProducto(productos); 
                            break;
                    case 4: consultarProducto(productos); 
                            break;
                    case 5: mostrarProductos(productos);
                            break;
                    case 6: Console.WriteLine("Has trabajado exitosamente en el inventario de la tienda."); break;
                    default: Console.WriteLine("Opción no válida, por favor intenta de nuevo."); break;
                }

            } while (opcion != 6);
        }

        static void agregarProducto(List<Producto> productos)
        {
            Console.WriteLine("\n--- Agregar Producto ---");

            Console.Write("Código: ");
            int codigo = int.Parse(Console.ReadLine());
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Cantidad: ");
            int cantidad = int.Parse(Console.ReadLine());
            Console.Write("Precio: ");
            double precio = double.Parse(Console.ReadLine());

            productos.Add(new Producto { Codigo = codigo, Nombre = nombre, Cantidad = cantidad, Precio = precio });
            Console.WriteLine("Producto agregado exitosamente.");
        }

        static void eliminarProducto(List<Producto> productos)
        {
            Console.WriteLine("\n--- Eliminar Producto ---");

            Console.Write("Ingresa el código del producto a eliminar: ");
            int codigo = int.Parse(Console.ReadLine());

            Producto producto = productos.Find(p => p.Codigo == codigo);
            if (producto != null)
            {
                productos.Remove(producto);
                Console.WriteLine("Producto eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        static void modificarProducto(List<Producto> productos)
        {
            Console.WriteLine("\n--- Modificar Producto ---");

            Console.Write("Ingresa el código del producto a modificar: ");
            int codigo = int.Parse(Console.ReadLine());

            Producto producto = productos.Find(p => p.Codigo == codigo);
            if (producto != null)
            {
                Console.Write("Nuevo nombre (deja vacío para mantener el actual): ");
                string nombre = Console.ReadLine();
                Console.Write("Nueva cantidad (deja vacío para mantener la actual): ");
                string cantidadStr = Console.ReadLine();
                Console.Write("Nuevo precio (deja vacío para mantener el actual): ");
                string precioStr = Console.ReadLine();

                if (!string.IsNullOrEmpty(nombre)) producto.Nombre = nombre;
                if (!string.IsNullOrEmpty(cantidadStr)) producto.Cantidad = int.Parse(cantidadStr);
                if (!string.IsNullOrEmpty(precioStr)) producto.Precio = double.Parse(precioStr);

                Console.WriteLine("Producto modificado exitosamente.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        static void consultarProducto(List<Producto> productos)
        {
            Console.WriteLine("\n--- Consultar Producto ---");

            Console.Write("Ingresa el código del producto a consultar: ");
            int codigo = int.Parse(Console.ReadLine());

            Producto producto = productos.Find(p => p.Codigo == codigo);
            if (producto != null)
            {
                Console.WriteLine(producto);
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        static void mostrarProductos(List<Producto> productos)
        {
            Console.WriteLine("\n--- Inventario Completo ---");

            if (productos.Count > 0)
            {
                foreach (var producto in productos)
                {
                    Console.WriteLine(producto);
                }
            }
            else
            {
                Console.WriteLine("No hay productos en el inventario.");
            }
        }
    }
}