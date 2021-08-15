using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace DaiMangou.BridgedData
{
    /// <summary>
    ///  This script is automatically added to route buttons
    /// </summary>
    public class ClickListener : MonoBehaviour
    {
        public Interaction interactionComponent;
        public int indexInList;
        public UnityEvent OnClickEvent = new UnityEvent();


        /// <summary>
        /// when a route button is clicked we switch routes
        /// </summary>
        public void SwitchRoute()
        {
            if (interactionComponent)
            {
                var route = (RouteNodeData)interactionComponent.ActiveNodeData;// (RouteNodeData) characterComponent.sceneData.ActiveCharacterDialogueSet[characterComponent.ActiveIndex];
                interactionComponent.ReturnPointUID = route.DataIconnectedTo[indexInList].UID;
                route.RuntimeRouteID = indexInList;
                interactionComponent.CachedRoute = route;
                OnClickEvent.Invoke();
            }
        }
    }
}