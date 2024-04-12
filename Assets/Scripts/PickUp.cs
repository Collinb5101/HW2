using System;
using UnityEngine;

namespace BehaviorTree
{
    [Serializable]
    public class PickUp : Task
    {
        // The character that is grabbing the thing.
        private Character grabber;
        public Character Grabber
        {
            get { return grabber; }
            set { grabber = value; }
        }

        // The thing that is being grabbed.
        private Thing grabThis;
        public Thing GrabThis
        {
            get { return grabThis; }
            set { grabThis = value; }
        }

        // This constructor defaults the character and thing to None.
        public PickUp() : this(Character.None, Thing.None) { }

        // This constructor takes parameters for the character and thing.
        public PickUp(Character grabber, Thing grabThis)
        {
            Grabber = grabber;
            GrabThis = grabThis;
        }

        // This method runs the PickUp action on the given WorldState object.
        public override bool run(WorldState state)
        {

            //if the character is already holding the potion it is already picked up, return true
            if (state.CharacterInventories[Grabber] == Thing.Potion)
            {
                return true;
            }
            //if the position of the Character Grabber and the position of the Thing GrabThis are the same
            //--AND--
            //the Grabber is not already carrying the GrabThis
            else if (state.CharacterPosition[Grabber] == state.ThingPosition[GrabThis] && state.CharacterInventories[Grabber] != GrabThis)
            {
                //set the GrabThis variable to the Grabber's inventory slot and set the GrabThis's location to None
                state.CharacterInventories[Grabber] = GrabThis;
                state.ThingPosition[GrabThis] = Location.None;

                //print and return true
                Debug.Log($"{this} successfully");
                return true;
            }
            else
            {
                //otherwise print and return false
                Debug.Log($"{this} unsuccessfully");
                return false;
            }
        }

        // Creates and returns a string describing the PickUp action.
        public override string ToString()
        {
            return grabber + " picks up " + grabThis;
        }
    }
}
