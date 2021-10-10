using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AstroTurffx.AstroUtils.Runtime {
    public class PlayerGroundCheck : MonoBehaviour
    {
        public BasicPlayerController player;

        public void OnValidate()
        {
            if (player != null) player.groundCheck = this;
        }

        private void OnTriggerEnter(Collider other)
        {
            player.jumped = false;
        }
    }
}