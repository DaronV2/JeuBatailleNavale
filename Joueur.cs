interface IJoueur
{
    void AfficherMapJoueur();

    Coordonates RequestAttack();

    bool VerifNavireACetEndroit(int un, int deux);
}

public class Joueur
{
    // Declare a two dimensional array.
    private string[,] mapNaviresJoueur = new string[5, 5];

    private int numeroJoueur;

    private List<string> ListAttacks = new List<string>();

    public Joueur(int numJoueur)
    {
        numeroJoueur = numJoueur;
    }

    private void RemplirMapJoueur()
    {
        for (int i = 0; i < mapNaviresJoueur.GetLength(0); i++)
        {
            for (int j = 0; j < mapNaviresJoueur.GetLength(0); j++)
            {
                mapNaviresJoueur[i, j] = "-";
            }
        }
        Console.WriteLine($"JOUEUR {numeroJoueur}, entrez les coordonn�es de vos navires, sous la forme \"L C\" \n" +
            $"(L repr�sente la ligne entre 0 et 4 et C la colonne entre 0 et 4).");

        for (int i = 1; i <= 5; i++)
        {
            Console.Write($"Entrez les coordonn�es du navire {i} : ");
            string nombre = Console.ReadLine();
            string[] nb = nombre.Split(' ');
            bool verifCoo = VerifCoordonneesMap(int.Parse(nb[0]), int.Parse(nb[1]));
            while (verifCoo == false)
            {
                Console.WriteLine("Coordonn�es invalides. Veuillez r�essayer.");
                Console.Write($"Entrez les coordonn�es du navire {i} : ");
                nombre = Console.ReadLine();
                nb = nombre.Split(' ');
                verifCoo = VerifCoordonneesMap(int.Parse(nb[0]), int.Parse(nb[1]));
            }
            bool verifNav = VerifNavireACetEndroit(int.Parse(nb[0]), int.Parse(nb[1]));
            while (verifNav == true)
            {
                Console.WriteLine("Vous avez d�ja un navire a cet endroit ! ");
                Console.Write($"Entrez les coordonn�es du navire {i} : ");
                nombre = Console.ReadLine();
                nb = nombre.Split(' ');
                verifNav = VerifNavireACetEndroit(int.Parse(nb[0]), int.Parse(nb[1]));
            }

            mapNaviresJoueur[int.Parse(nb[0]), int.Parse(nb[1])] = "@";
            AfficherMapJoueur();
        }
    }



    public void AfficherMapJoueur()
    {
        Console.WriteLine("  0 1 2 3 4");
        for (int i = 0; i < mapNaviresJoueur.GetLength(0); i++)
        {
            Console.Write(i + " ");
            for (int j = 0; j < mapNaviresJoueur.GetLength(0); j++)
            {
                Console.Write(mapNaviresJoueur[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    private bool VerifCoordonneesMap(int un, int deux)
    {
        if (un >= mapNaviresJoueur.GetLength(0) || un < 0 || deux >= mapNaviresJoueur.GetLength(1) || deux < 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }


    public bool VerifNavireACetEndroit(int un, int deux)
    {
        if (mapNaviresJoueur[un, deux] == ("@"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void couler(Coordonates coord){
        mapNaviresJoueur[coord.getLigne(), coord.getCol()] = "X";
    }

    public Coordonates RequestAttack()
    {
        Console.Write($"JOUEUR {numeroJoueur}, vous devez essayer de couler un bateau de votre adversaire ! \n Entrez des coordonnées :");
        String[] nombres = Console.ReadLine().Split(' ');
        Coordonates coord = new Coordonates(int.Parse(nombres[0]), int.Parse(nombres[1]), $"{int.Parse(nombres[0])}{int.Parse(nombres[1])}");
        if (coord.getLigne() <= 4 && coord.getCol() <= 4)
        {
            if (!ListAttacks.Contains(coord.GetId()))
            {
                ListAttacks.Add(coord.GetId());
                return coord;
            }
            Console.Write("\nVous avez déja attaqué cette case. Veuillez réessayer !");
        }
        else
        {
            Console.WriteLine("\nCoordonnées invalides. Veuillez réessayer. Les coordonées doivent être de la forme \"L C\" \n" +
            $"(L repr�sente la ligne entre 0 et 4 et C la colonne entre 0 et 4).");
            return RequestAttack();
        }
        return RequestAttack();
    }

    public void Main()
    {
        RemplirMapJoueur();
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine();
        }
    }

    public bool isThereStillBoats(){
        for (int i = 0; i < mapNaviresJoueur.GetLength(0); i++)
        {
            for (int j = 0; j < mapNaviresJoueur.GetLength(0); j++)
            {
                if(mapNaviresJoueur[i, j] == "@"){
                    return true;
                }
            }
        }
        return false;
    }
}