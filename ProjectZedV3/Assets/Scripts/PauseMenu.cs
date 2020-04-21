using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool isOn = false;

    private NetworkManager networkManager;

    public void Start()
    {
        networkManager = NetworkManager.singleton;
    }

    public void LeaveRoomButton()
    {
        SceneManager.LoadScene("Main Menu");
        MatchInfo matchInfo = networkManager.matchInfo;
        networkManager.matchMaker.DropConnection(matchInfo.networkId, matchInfo.nodeId, 0, networkManager.OnDropConnection);
        networkManager.StopHost();
    }
}
