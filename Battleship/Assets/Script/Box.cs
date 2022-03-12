using UnityEngine;
using UnityEngine.EventSystems;

public class Box : MonoBehaviour
{
    public Color hoverColor;

    private Color startColor;
    private Renderer rend;
    private string state;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (transform.parent.gameObject.name == "GridAdvers" && !Game.instance.isFirstTour() && !BoatManager.instance.NextButtonIsActive() && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector3 boxPosition = transform.position;
            Player player = Game.instance.GetCurrentPlayer();
            Player adversaire = Game.instance.GetAdversaire();
            int x = (int)boxPosition.x;
            int y = (int)boxPosition.y;
            if (player.getName() == "Player2")
            {
                x -= 136;
            }
            x = Mathf.Abs(x) / 2;
            y = 9 - Mathf.Abs(y) / 2;
            int touche = player.attaquer(x, y, adversaire);
            if (touche != -1)
            {
                switch (touche)
                {
                    case 1:
                        state = "Plouf";
                        break;
                    case 2:
                        state = "Touché";
                        break;
                    case 3:
                        state = "Coulé";
                        break;
                    default:
                        state = "Plouf";
                        break;
                }
                GameObject tirToPlace;
                GameObject effectToPlace;
                GameObject deathEffectToPlace;
                (tirToPlace, effectToPlace, deathEffectToPlace) = BoatManager.instance.GetTirToPlace(state);
                adversaire.grilleJoueur.getBox(x, y).elem = (GameObject)Instantiate(tirToPlace, boxPosition, transform.rotation);
                if (state != "Coulé")
                {
                    effectToPlace = (GameObject)Instantiate(effectToPlace, boxPosition, transform.rotation);
                }
                else
                {
                    int[,] TabCoordonnées = adversaire.grilleJoueur.getBox(x, y).bateau.GetCoordonnées();
                    for (int rangee = 0; rangee < TabCoordonnées.GetLength(0); rangee++)
                    {
                        int X = TabCoordonnées[rangee, 0];
                        int Y = TabCoordonnées[rangee, 1];
                        Vector3 position = adversaire.grilleJoueur.getBox(X, Y).elem.transform.position;
                        Quaternion rotation = adversaire.grilleJoueur.getBox(X, Y).elem.transform.rotation;
                        Destroy(adversaire.grilleJoueur.getBox(X, Y).elem);
                        adversaire.grilleJoueur.getBox(X, Y).elem = (GameObject)Instantiate(tirToPlace, position, rotation);
                        effectToPlace = (GameObject)Instantiate(effectToPlace, position, transform.rotation);
                        X = -Mathf.Abs(X) * 2;
                        Y = Mathf.Abs(Y) * 2;
                        if (player.getName() == "Player1")
                        {
                            X += 136;
                        }
                        Vector3 deathEffectPosition = new Vector3(X, 0, Y);
                        deathEffectToPlace = (GameObject)Instantiate(deathEffectToPlace, deathEffectPosition, transform.rotation);
                    }
                }

                BoatManager.instance.EnableButtonNext();
            }
        }
    }

    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
