using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour {

    [SerializeField]
    private Behaviour[] componentsToDisable;
    private Camera sceneCamera;

    private void Start() {
        if (!isLocalPlayer) {
            foreach (Behaviour component in componentsToDisable) {
                component.enabled = false;
            }
        } else {
            sceneCamera = Camera.main;
            if (sceneCamera != null) {
                sceneCamera.gameObject.SetActive(false);
            }            
        }
    }

    private void OnDisable() {
        if (sceneCamera != null) {
            sceneCamera.gameObject.SetActive(true);
        }
    }

}
