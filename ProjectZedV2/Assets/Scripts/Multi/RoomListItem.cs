using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking.Match;

public class RoomListItem : MonoBehaviour
{
    [SerializeField] private Text roommNameText;

    private MatchInfoSnapshot match;

    public void Setup(MatchInfoSnapshot _match)
    {
        match = _match;

        roommNameText.text = match.name + "(" + match.currentSize + "/" + match.maxSize + ")";
    }
}
