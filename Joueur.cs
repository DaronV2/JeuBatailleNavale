public class Joueur
{
    // Declare a two dimensional array.
    private static string[,] mapNaviresJoueur = new string[5, 5];

    private static int numeroJoueur;

    public Joueur(int numJoueur)
    {
        numeroJoueur = numJoueur;
    }

    private static void remplirMapJoueur(string[,] map)
    {
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(0); j++)
            {
                map[i, j] = "-";
            }
        }
        Console.WriteLine($"JOUEUR {numeroJoueur}, entrez les coordonnées de vos navires, sous la forme \"L C\" \n" +
            $"(L représente la ligne entre 0 et 4 et C la colonne entre 0 et 4).");

        for (int i = 1; i <= 5; i++)
        {
            Console.Write($"Entrez les coordonnées du navire {i} : ");
            string nombre = Console.ReadLine();
            string[] nb = nombre.Split(' ');

            map[int.Parse(nb[0]), int.Parse(nb[1])] = "@";
        }
    }
        
    

    private static void afficherMapJoueur(string[,] map)
    {
        Console.WriteLine("  0 1 2 3 4");
        for (int i = 0; i < map.GetLength(0); i++)
        {
            Console.Write(i+" ");
            for (int j = 0; j < map.GetLength(0); j++)
            {
                Console.Write(map[i, j]+ " ");
            }
            Console.WriteLine();
        }
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine();
        }
    }

    public void main()
    {
        remplirMapJoueur(mapNaviresJoueur);
        afficherMapJoueur(mapNaviresJoueur);
    }
}