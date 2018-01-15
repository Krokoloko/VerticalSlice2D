using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour {

	public class Seed
    {
        public float yTravel;
        public float xTravel;

        public void Travel()
        {
            
        }
    }
    public class Spore
    {
        public bool leftside;
        private Vector3 _res;

        public Vector3 Travel()
        {
            if (leftside)
            {
                _res = new Vector3(-0.3f, -0.7f);
            }
            else
            {
                _res = new Vector3(0.3f, 0.7f);
            }
            return _res;
        }
    }
}
