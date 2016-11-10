using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    
    // Configuration

    // State
    [System.NonSerialized] private CharacterController attachedCharacterController;
    [System.NonSerialized] public bool travellingFlag = false;

    public void Awake() {
        attachedCharacterController = GetComponent<CharacterController>();
    }

    public bool RequestTravelling(CameraTravelling.Request request) {
        // Discard travel request if already travelling
        if (IsTravelling()) {
            // Notifie the request was discarded
            return false;
        }

        // Execture travelling if not
        travellingFlag = true;
        StartCoroutine(TravellingCooroutine(request));
        // Notifie the request was accepted
        return true;
    }

    public IEnumerator TravellingCooroutine(CameraTravelling.Request request) {

        float remainingDistanceToTravel = request.distance;
        float remainingTimeForTravelling = request.duration;

        // Travel while there is still time
        float thisFrameVelocity;
        Vector3 thisFrameTranslation;
        while (remainingTimeForTravelling > 0) {
            thisFrameVelocity = (remainingDistanceToTravel / remainingTimeForTravelling);
            thisFrameTranslation = request.direction * thisFrameVelocity * Time.fixedDeltaTime;

            attachedCharacterController.Move(thisFrameTranslation);

            remainingDistanceToTravel -= thisFrameTranslation.magnitude;
            yield return new WaitForFixedUpdate();
            remainingTimeForTravelling -= Time.fixedDeltaTime;
        }

        // Reset travelling flag
        travellingFlag = false;
        yield return null;
    }

    public bool IsTravelling() {
        return travellingFlag;
    }
}
