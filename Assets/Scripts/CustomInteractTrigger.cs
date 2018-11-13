namespace VRTK
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CustomInteractTrigger : MonoBehaviour
    {

        public List<GameObject> goList;

        [Header("Trigger Settings")]

        [Tooltip("The button used to spawn an object.")]
        public VRTK_ControllerEvents.ButtonAlias triggerButton = VRTK_ControllerEvents.ButtonAlias.TriggerPress;
        [Tooltip("The controller to listen for the events on. If the script is being applied onto a controller then this parameter can be left blank as it will be auto populated by the controller the script is on at runtime.")]
        public VRTK_ControllerEvents controllerEvents;


        /// <summary>
        /// Emitted when the Trigger button is pressed.
        /// </summary>
        public event ControllerInteractionEventHandler TriggerButtonPressed;
        /// <summary>
        /// Emitted when the Trigger button is released.
        /// </summary>
        public event ControllerInteractionEventHandler TriggerButtonReleased;

        /// <summary>
        /// Emitted when a Trigger of a valid object is started.
        /// </summary>
        public event ObjectInteractEventHandler ControllerStartTriggerInteractableObject;
        /// <summary>
        /// Emitted when a valid object is Triggerbed.
        /// </summary>
        public event ObjectInteractEventHandler ControllerTriggerInteractableObject;
        /// <summary>
        /// Emitted when a unTrigger of a valid object is started.
        /// </summary>
        public event ObjectInteractEventHandler ControllerStartUnTriggerInteractableObject;
        /// <summary>
        /// Emitted when a valid object is released from being Triggerbed.
        /// </summary>
        public event ObjectInteractEventHandler ControllerUnTriggerInteractableObject;

        protected VRTK_ControllerEvents.ButtonAlias subscribedGrabButton = VRTK_ControllerEvents.ButtonAlias.Undefined;
        protected bool triggerPressed;

        protected GameObject spawnedObject = null;
        protected bool influencingSpawnedObject = false;
        protected int triggerEnabledState = 0;

        public virtual void OnControllerStartTriggerInteractableObject(ObjectInteractEventArgs e)
        {
            if (ControllerStartTriggerInteractableObject != null)
            {
                ControllerStartTriggerInteractableObject(this, e);
            }
        }

        public virtual void OnControllerTriggerInteractableObject(ObjectInteractEventArgs e)
        {
            if (ControllerTriggerInteractableObject != null)
            {
                ControllerTriggerInteractableObject(this, e);
            }
        }

        public virtual void OnControllerStartUnTriggerInteractableObjectt(ObjectInteractEventArgs e)
        {
            if (ControllerStartUnTriggerInteractableObject != null)
            {
                ControllerStartUnTriggerInteractableObject(this, e);
            }
        }

        public virtual void OnControllerUnTriggerInteractableObject(ObjectInteractEventArgs e)
        {
            if (ControllerUnTriggerInteractableObject != null)
            {
                ControllerUnTriggerInteractableObject(this, e);
            }
        }

        public virtual void OnTriggerButtonPressed(ControllerInteractionEventArgs e)
        {
            if (TriggerButtonPressed != null)
            {
                TriggerButtonPressed(this, e);
                //Debug.Log("TRIGGER TRIGGER TRIGGER");
            }
        }

        public virtual void OnTriggerButtonReleased(ControllerInteractionEventArgs e)
        {
            if (TriggerButtonReleased != null)
            {
                TriggerButtonReleased(this, e);
                //Debug.Log("RELEASE");
            }
        }

        /// <summary>
        /// The IsGrabButtonPressed method determines whether the current grab alias button is being pressed down.
        /// </summary>
        /// <returns>Returns true if the grab alias button is being held down.</returns>
        public virtual bool IsTriggerButtonPressed()
        {
            return triggerPressed;
        }

        protected virtual void Awake()
        {
            controllerEvents = (controllerEvents != null ? controllerEvents : GetComponentInParent<VRTK_ControllerEvents>());
            VRTK_SDKManager.instance.AddBehaviourToToggleOnLoadedSetupChange(this);
        }

        protected virtual void OnDestroy()
        {
            VRTK_SDKManager.instance.RemoveBehaviourToToggleOnLoadedSetupChange(this);
        }


        protected virtual void DoTriggerObject(object sender, ControllerInteractionEventArgs e)
        {
            OnTriggerButtonPressed(controllerEvents.SetControllerEvent(ref triggerPressed, true));
            //Debug.Log("TRIGGER TRIGGER TRIGGER");
            SpawnObject();
        }

        protected virtual void DoReleaseObject(object sender, ControllerInteractionEventArgs e)
        {

            OnTriggerButtonReleased(controllerEvents.SetControllerEvent(ref triggerPressed, false));
            //Debug.Log("RELEASE");
        }

        protected virtual void ManageTriggerListener(bool state)
        {
            if (controllerEvents != null && subscribedGrabButton != VRTK_ControllerEvents.ButtonAlias.Undefined && (!state || !triggerButton.Equals(subscribedGrabButton)))
            {
                controllerEvents.UnsubscribeToButtonAliasEvent(subscribedGrabButton, true, DoTriggerObject);
                controllerEvents.UnsubscribeToButtonAliasEvent(subscribedGrabButton, false, DoReleaseObject);
                subscribedGrabButton = VRTK_ControllerEvents.ButtonAlias.Undefined;
            }

            if (controllerEvents != null && state && triggerButton != VRTK_ControllerEvents.ButtonAlias.Undefined && !triggerButton.Equals(subscribedGrabButton))
            {
                controllerEvents.SubscribeToButtonAliasEvent(triggerButton, true, DoTriggerObject);
                controllerEvents.SubscribeToButtonAliasEvent(triggerButton, false, DoReleaseObject);
                subscribedGrabButton = triggerButton;
            }
        }

        protected virtual void OnEnable()
        {
            ManageTriggerListener(true);
        }

        protected virtual void OnDisable()
        {

            ManageTriggerListener(false);

        }

        protected virtual void Update()
        {
            ManageTriggerListener(true);

        }

        void SpawnObject()
        {
            // GameObject randomGO = goList[Random.RandomRange(0.0f, goList.Count)];
            if (goList.Count != 0)
            {
                Instantiate(goList[Random.Range(0, goList.Count)], this.transform.position, Quaternion.identity);     
            }
        }
    }
}