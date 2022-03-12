using UnityEngine;

public class GridJoueur : MonoBehaviour
{

    private GameObject Test;

    public void PlaceBoat(GameObject box, string draggedType, GameObject button, GameObject text)
    {
        Vector3 boxPosition = box.transform.position;
        float buttonRotation = button.transform.rotation.eulerAngles.z;


        GameObject boatToPlace = BoatManager.instance.GetBoatToPlace(draggedType);
        Player player = Game.instance.GetCurrentPlayer();
        int x = (int)boxPosition.x;
        int y = (int)boxPosition.z;
        if (player.getName() == "Player2")
        {
            x -= 136;
        }
        x = Mathf.Abs(x) / 2;
        y = Mathf.Abs(y) / 2;

        string sens = "bas";
        switch (buttonRotation)
        {
            case 0:
                sens = "bas";
                break;
            case 90:
                sens = "droite";
                break;
            case 180:
                sens = "haut";
                break;
            case 270:
                sens = "gauche";
                break;
        }

        if (!player.placerBateau(boatToPlace.name, x, y, sens))
        {
            Vector3 Offset = new Vector3(0, 0, 1);
            switch (boatToPlace.name)
            {
                case "Croiseur":
                    Offset = new Vector3(0, 0.1f, 4);
                    break;
                case "Cuirasse":
                    Offset = new Vector3(0, 0, 3);
                    break;
                case "Fregate":
                    Offset = new Vector3(0, 0, 2);
                    break;
                case "Torpilleur":
                    Offset = new Vector3(0, 0, 2);
                    break;
                case "Corvette":
                    Offset = new Vector3(0, 0, 1);
                    break;
            }
            Quaternion OffsetRotation = Quaternion.Euler(0, -buttonRotation, 0);
            Offset = OffsetRotation * Offset;
            Test = (GameObject)Instantiate(boatToPlace, boxPosition + Offset, box.transform.rotation * OffsetRotation);
            Destroy(button);
            Destroy(text);
            foreach (Bateaux bateau in player.bateaux)
            {
                if (!bateau.getActive())
                {
                    return;
                }
            }
            Destroy(GameObject.Find("Bateaux "+ player.getName()));
            BoatManager.instance.EnableButtonNext();
        }
    }
}
