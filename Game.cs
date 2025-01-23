public class Game
{

    private List<Joueur> joueurs;

    private bool isGameFinished = false;

    public Game(List<Joueur> joueurs)
    {
        this.joueurs = joueurs;
        Main();
    }

    public void Main()
    {
        foreach (Joueur joueur in joueurs)
        {
            joueur.Main();
        }
        while (isGameFinished == false)
        {
            Coordonates coord = joueurs[0].RequestAttack();
            if (joueurs[1].VerifNavireACetEndroit(coord.getLigne(), coord.getCol()))
            {
                System.Console.WriteLine("Touché Coulé !");
                joueurs[1].couler(coord);
                if (!joueurs[1].isThereStillBoats())
                {
                    isGameFinished = true;
                    System.Console.WriteLine("Joueur 1 a gagné !");
                    break;
                }
            }

            Coordonates coods = joueurs[1].RequestAttack();
            if (joueurs[0].VerifNavireACetEndroit(coord.getLigne(), coord.getCol()))
            {
                System.Console.WriteLine("Touché Coulé !");
                joueurs[0].couler(coord);
                if (!joueurs[0].isThereStillBoats())
                {
                    isGameFinished = true;
                    System.Console.WriteLine("Joueur 2 a gagné !");
                    break;
                }
            }
        }
        joueurs[0].AfficherMapJoueur();
        joueurs[1].AfficherMapJoueur();
    }
}

