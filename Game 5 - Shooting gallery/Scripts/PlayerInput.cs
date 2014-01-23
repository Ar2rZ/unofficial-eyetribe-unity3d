using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {


    public AudioClip canHitSound;

	void Update () {	
        if(true){
			
			EyeTribeClient trackerScript = (EyeTribeClient )FindObjectOfType(typeof(EyeTribeClient ));
		
			Vector3 currentPosition= trackerScript.gazePosInvertY;
					
			Ray ray = Camera.main.ScreenPointToRay (currentPosition);
			
            RaycastHit hit;
            if (Physics.Raycast (ray, out hit, 100)) {

                Debug.DrawLine (ray.origin, hit.point);

                if (hit.transform.tag == "ShootingObject")
                {
                    audio.pitch = Random.Range(0.9f, 1.3f);
                    audio.Play();
					
					
                    GameManager.SP.RemoveObject(hit.transform);
					
                }else if(hit.transform.tag == "Can"){
					
                    audio.PlayOneShot(canHitSound);

                    Vector3 explosionPos = transform.position;
                    hit.rigidbody.AddExplosionForce(5000, explosionPos, 25.0f, 1.0f);
                }

            }
        }
	}
}
