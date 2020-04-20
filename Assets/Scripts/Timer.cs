using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

namespace UnityEngine {
    public class Timer : MonoBehaviour
    {
        public float initialTime;
        [SerializeField]
        private float timeLeft;
        [SerializeField]
        private bool isActive = false;
        [SerializeField]
        private bool didThrowEvent = false;
        public UnityEvent timeOut;

        private void Start ( )
        {
            SetNewTime (initialTime);
        }

        void Update ( )
        {
            if ( !isActive ) return;

            if ( timeLeft >= 0 )
            {
                timeLeft -= Time.deltaTime;
                return;
            }
            if ( !didThrowEvent )
            {
                Pause ();
                didThrowEvent = true;
                timeOut.Invoke ( );
                return;
            }
        }

        public void Pause ( )
        {
            isActive = false;
        }

        public void Resume ( )
        {
            isActive = true;
        }

        public void SetNewTime ( float time )
        {
            initialTime = time;
            timeLeft = time;
            didThrowEvent = false;
        }

        public void ResetTimer ( )
        {
            SetNewTime ( initialTime );
        }

        public bool IsTimerActive ()
        {
            return isActive;
        }

        public float GetTimeLeft ()
        {
            return timeLeft;
        }
    }

};
