using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIRoomListObject : MonoBehaviour
{
    public TextMeshProUGUI roomName;
    
    /*
    public Text roomName;
    public Button thisButton;
    Launcher manager;
    public RoomInfo roomInfo { get; private set; }

    public RoomListObj SetRoomName(RoomInfo _room)
    {
        roomName.text = _room.Name;
        roomInfo = _room;
        thisButton.interactable = true;
        return this;
    }

    public RoomListObj SetLauncher(Launcher launch)
    {
        manager = launch;
        return this;
    }

    public void OnClickRoomItem()
    {
        thisButton.interactable = false;
        manager.JoinRoom(roomName.text);
    }
    */

    public void OnClickRoomItem()
    {
#if UNITY_EDITOR
        Debug.Log("Room " + roomName.text + " clicked");
#endif
    }

}
