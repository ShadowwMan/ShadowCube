﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cubes.CubeHyber
{
    public class DoorLogic2 : MonoBehaviour
    {
        public GameObject door;
        public GameObject door1;
        public GameObject door2;
        public GameObject door3;
        public AudioSource audio_door;

        public DoorStage dootstage = DoorStage.closed;

        private float speedToOpen = 0.01f;

        private void Open()
        {
            if (dootstage == DoorStage.closed)
            {
                dootstage = DoorStage.opening;
                audio_door.Play();
                StartCoroutine("Animation_Door");
                dootstage = DoorStage.open;
            }
        }

        public void Using()
        {
            if (dootstage == DoorStage.closed)
            {
                UserToOpen();
            }
        }

        public void UserToOpen()
        {
            Open();
            transform.parent.gameObject.SendMessage("OpenedDoor");
        }

        public void MegaCubeToOpen()
        {
            Open();
        }

        public void Close()
        {
            if (dootstage == DoorStage.open || dootstage == DoorStage.opening)
            {
                dootstage = DoorStage.closing;
                dootstage = DoorStage.closed;
            }
        }


        IEnumerator Animation_Door()
        {
            yield return new WaitForSecondsRealtime(0.9f);
            for (int i = 0; i < 50; ++i)
            {
                door.transform.localPosition = door.transform.localPosition + new Vector3(speedToOpen, 0 ,-speedToOpen);
                door1.transform.localPosition = door1.transform.localPosition + new Vector3(speedToOpen, 0, speedToOpen);
                door2.transform.localPosition = door2.transform.localPosition + new Vector3(-speedToOpen, 0, speedToOpen);
                door3.transform.localPosition = door3.transform.localPosition + new Vector3(-speedToOpen, 0, -speedToOpen);
                yield return new WaitForSecondsRealtime(0.02f);
            }
        }
    }
}