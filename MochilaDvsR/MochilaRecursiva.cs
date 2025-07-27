class MochilaRecursiva {
    public int Resolver(int capacidad, int[] pesos, int[] valores, int n) {
        if (n == 0 || capacidad == 0)
            return 0;

        if (pesos[n - 1] > capacidad)
            return Resolver(capacidad, pesos, valores, n - 1);

        return Math.Max(
            valores[n - 1] + Resolver(capacidad - pesos[n - 1], pesos, valores, n - 1),
            Resolver(capacidad, pesos, valores, n - 1)
        );
    }
}