using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{

    private int _score;

    public int Score
    {
        get { return _score; }
        set { _score = value;
            if (EventManager.OnScoreUpdated != null)
                EventManager.OnScoreUpdated(this);
        }
    }
}
