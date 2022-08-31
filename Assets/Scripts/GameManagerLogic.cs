using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerLogic : MonoBehaviour
{
    public int totalItemCount;
    public int stage;

    public Text stageCount;
    Player player;
    void Awake()
    {
        stageCount.text = "/ " + totalItemCount;
    }
}
