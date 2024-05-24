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
            bool verifCoo = verifCoordonneesMap(map, int.Parse(nb[0]), int.Parse(nb[1]));
            while (verifCoo == false)
            {
                Console.WriteLine("Coordonnées invalides. Veuillez réessayer.");
                Console.Write($"Entrez les coordonnées du navire {i} : ");
                nombre = Console.ReadLine();
                nb = nombre.Split(' ');
                verifCoo = verifCoordonneesMap(map, int.Parse(nb[0]), int.Parse(nb[1]));
            }

            bool verifNav = verifNavireACetEndroit(map, int.Parse(nb[0]), int.Parse(nb[1]));
            while (verifNav == false)
            {
                Console.WriteLine("Vous avez déja un navire a cet endroit ! ");
                Console.Write($"Entrez les coordonnées du navire {i} : ");
                nombre = Console.ReadLine();
                nb = nombre.Split(' ');
                verifNav = verifNavireACetEndroit(map, int.Parse(nb[0]), int.Parse(nb[1]));
            }

            map[int.Parse(nb[0]), int.Parse(nb[1])] = "@";
            afficherMapJoueur(mapNaviresJoueur);
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
    }

    private static bool verifCoordonneesMap(string[,] mapNaviresJoueur, int un, int deux) { 
        if ( un > mapNaviresJoueur.GetLength(1) || un < 0)
        {
            return false;
        }
        else if (deux > mapNaviresJoueur.GetLength(1) || deux < 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private static bool verifNavireACetEndroit(string[,] map, int un, int deux)
    {
        if (map[un, deux] == ("@"))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void main()
    {
        remplirMapJoueur(mapNaviresJoueur);
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine();
        }
    }
}