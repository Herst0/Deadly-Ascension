using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const string playerIdPrefix = "Player";
    private static Dictionary<string, PlayerMulti> players = new Dictionary<string, PlayerMulti>();
    public static void RegisterPlayer(string netID, PlayerMulti player)
    {
        string playerId = playerIdPrefix + netID;
        players.Add(playerId, player);
        player.transform.name = playerId;
    }
    
    public static void UnregisterPlayer(string playerId)
    {
        players.Remove(playerId);
    }
    public static PlayerMulti GetPlayer(string playerId)
    {
        return players[playerId];
    }
    

}
