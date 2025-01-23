// See https://aka.ms/new-console-template for more information
public class App
{

    static void Main(string[] args) {
        List<Joueur> joueurs = new List<Joueur> {new Joueur(1), new Joueur(2)};
        Game game = new Game(joueurs);
    }

}