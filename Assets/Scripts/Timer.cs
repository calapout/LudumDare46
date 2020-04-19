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
        private bool isActive = false;
        private bool didThrowEvent = false;
        public UnityEvent timeOut;

        private void Start ( )
        {
            this.timeLeft = initialTime;
        }

        void Update ( )
        {
            Debug.Log( isActive );
            Debug.Log(timeLeft);
            if ( isActive && timeLeft >= 0 )
            {
                timeLeft -= Time.deltaTime;
                return;
            }
            if ( !didThrowEvent )
            {
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
