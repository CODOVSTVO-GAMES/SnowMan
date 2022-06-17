using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishMultiplierStageDoor : MonoBehaviour
{
    float Multiplier;
    string data;
    public void Collision()
    {
        transform.parent.GetChild(0).gameObject.GetComponent<FinishMultiplierStageDoor>().TransformDoor();
        transform.parent.GetChild(1).gameObject.GetComponent<FinishMultiplierStageDoor>().TransformDoor();
    }
    void TransformDoor()
    {
        if (gameObject.name == "LeftDoor")
        {
            data = transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text;
            data = data.Substring(1);
            Multiplier = float.Parse(data);
            Camera.main.GetComponent<GameManager>().Multiplier = Multiplier;
            Destroy(gameObject);
            // print("Левая дверь открылась");
        }
        if (gameObject.name == "RightDoor")
        {
            Destroy(gameObject);
            // print("Правая дверь открылась");
        }
    }
}
