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
                joueurs[0].coulerShipEnnemi(coord);
                if (!joueurs[1].isThereStillBoats())
                {
                    isGameFinished = true;
                    System.Console.WriteLine("Joueur 1 a gagné !");
                    break;
                }
            }else{
                System.Console.WriteLine("Dans l'eau !");
                joueurs[0].rien(coord);
            }
            joueurs[0].AfficherMap(joueurs[0].getMapAttaquesJoueur());

            System.Console.WriteLine("");

            Coordonates coods = joueurs[1].RequestAttack();
            if (joueurs[0].VerifNavireACetEndroit(coods.getLigne(), coods.getCol()))
            {
                System.Console.WriteLine("Touché Coulé !");
                joueurs[0].couler(coods);
                joueurs[1].coulerShipEnnemi(coods);
                if (!joueurs[0].isThereStillBoats())
                {
                    isGameFinished = true;
                    System.Console.WriteLine("Joueur 2 a gagné !");
                    break;
                }
            }else{
                System.Console.WriteLine("Dans l'eau !");
                joueurs[1].rien(coods);
            }
            joueurs[1].AfficherMap(joueurs[1].getMapAttaquesJoueur());
        }
        joueurs[0].AfficherMap(joueurs[0].getMapNaviresJoueur());
        joueurs[1].AfficherMap(joueurs[1].getMapNaviresJoueur());
    }
}

