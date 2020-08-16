using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChanger : MonoBehaviour
{
    [SerializeField]
    GameObject prefabCharacterSuneo;
    [SerializeField]
    GameObject prefabCharacterGian;

    // needed for the location of the new character
    GameObject currentCharacter;
    
    bool gian = false;

    // first frame input support 
    bool previousFrameChangeCharacterInput = false;

    // Start is called before the first frame update
    void Start()
    {
        currentCharacter = Instantiate<GameObject>(prefabCharacterSuneo, Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        // change character on left mouse button
        if (Input.GetAxis("ChangeCharacter") > 0) {
            if (!previousFrameChangeCharacterInput) {
                previousFrameChangeCharacterInput = true;
                // save current position and destroy current character
                Vector3 position = currentCharacter.transform.position;
                Destroy(currentCharacter);

                currentCharacter = Instantiate(gian ? prefabCharacterSuneo : prefabCharacterGian, position, Quaternion.identity);
                gian = !gian;
            }
        }
        else {
            // not changing character input
            previousFrameChangeCharacterInput = false;
        }
    }
}
