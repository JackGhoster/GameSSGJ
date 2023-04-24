//using LootLocker.Requests;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class LootlockerManager : MonoBehaviour
//{
//    // Start is called before the first frame update
//    void Start()
//    {
//        StartCoroutine(LoginRoutine());
//    }
    
//    IEnumerator LoginRoutine()
//    {
//        bool done = false;
//        LootLockerSDKManager.StartGuestSession((response) =>
//        {
//            if (!response.success)
//            {
//                Debug.Log("error starting LootLocker Session");

//                done = true;

//            }
//            else if (response.success)
//            {
//                Debug.Log("Successfully started Lootlocker Session");
//                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
//                done = true;
//            }

//        });
//        yield return new WaitWhile( () => done == false);
//    }
//}
