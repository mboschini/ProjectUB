using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
    [Header("RoomList")]
    public Transform roomListContainer;
    public UIRoomListObject roomItemPf;
    //List<RoomListObj> roomListObjs = new List<RoomListObj>();

    public void BTN_ExitGame()
    {
        Application.Quit();
    }
    public void BTN_UpdateRoomList()
    {
        /*
        foreach (RoomInfo room in _roomsUpdates)
        {
            if (room.RemovedFromList)
            {
                int index = roomListObjs.FindIndex(x => x.roomInfo.Name == room.Name);
                if (index != -1)
                {
                    Destroy(roomListObjs[index].gameObject);
                    roomListObjs.RemoveAt(index);
                }
            }
            else if (roomListObjs.FindIndex(x => x.roomInfo.Name == room.Name) != -1)
                return;
            else
            {
                RoomListObj newRoom = Instantiate(roomItemPf, roomListContainer)
                        .SetRoomName(room)
                        .SetLauncher(this);
                roomListObjs.Add(newRoom);
            }
        }
        */
    }

    public void BTN_JoinRoom()
    {
#if UNITY_EDITOR
        Debug.Log("JoinRoom clicked");
#endif
    }

    public void BTN_CreatePublicRoom()
    {
#if UNITY_EDITOR
        Debug.Log("Create Public Room clicked");
#endif
    }

    public void BTN_CreatePrivateRoom()
    {
#if UNITY_EDITOR
        Debug.Log("Create Private Room clicked");
#endif
    }
}
