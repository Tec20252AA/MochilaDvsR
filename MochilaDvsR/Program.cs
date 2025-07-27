using System;
using System.Diagnostics;

class Program {
    static void Main(string[] args) {
        int[] capacidades = { 10, 50, 100, 500, 1000, 5000, 100000 };
        int[] tamanos = { 5, 10, 20, 50, 100, 200, 5000 };

        foreach (int tamano in tamanos) {
            Console.WriteLine($"\nTamaño del problema: {tamano}");

            int[] pesos = new int[tamano];
            int[] valores = new int[tamano];
            Random random = new Random();

            for (int i = 0; i < tamano; i++) {
                pesos[i] = random.Next(1, 100);
                valores[i] = random.Next(1, 100);
            }

            foreach (int capacidad in capacidades) {
                MochilaDinamica mochilaDinamica = new MochilaDinamica();
                MochilaRecursiva mochilaRecursiva = new MochilaRecursiva();

                // Medir rendimiento de MochilaDinamica
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                mochilaDinamica.Resolver(capacidad, pesos, valores, tamano);
                stopwatch.Stop();
                long tiempoDinamica = stopwatch.ElapsedMilliseconds;

                // Medir rendimiento de MochilaRecursiva
                stopwatch.Reset();
                stopwatch.Start();
                mochilaRecursiva.Resolver(capacidad, pesos, valores, tamano);
                stopwatch.Stop();
                long tiempoRecursiva = stopwatch.ElapsedMilliseconds;

                Console.WriteLine($"\nCapacidad: {capacidad}");
                Console.WriteLine($"Tiempo de ejecución de MochilaDinamica: {tiempoDinamica} ms");
                Console.WriteLine($"Tiempo de ejecución de MochilaRecursiva: {tiempoRecursiva} ms");

                // Medir uso de memoria
                long memoriaUsada = GC.GetTotalMemory(true);
                Console.WriteLine($"Memoria utilizada: {memoriaUsada / 1024} KB");

            }
        }
    }
}
