class MochilaDinamica {
    public int Resolver(int capacidad, int[] pesos, int[] valores, int n) {
        int[,] dp = new int[n + 1, capacidad + 1];

        for (int i = 0; i <= n; i++) {
            for (int w = 0; w <= capacidad; w++) {
                if (i == 0 || w == 0)
                    dp[i, w] = 0;
                else if (pesos[i - 1] <= w)
                    dp[i, w] = Math.Max(valores[i - 1] + dp[i - 1, w - pesos[i - 1]], dp[i - 1, w]);
                else
                    dp[i, w] = dp[i - 1, w];
            }
        }

        return dp[n, capacidad];
    }
}