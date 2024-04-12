using System;
using UnityEngine;

namespace BehaviorTree
{
    [Serializable]
    public class IsHere : Task
    {
        // The character that is checking the thing.
        private Character checker;
        public Character Checker
        {
            get { return checker; }
            set { checker = value; }
        }

        // We will determine whether this thing is here.
        private Thing what;
        public Thing What
        {
            get { return what; }
            set { what = value; }
        }

        // This constructor defaults the thing to None.
        public IsHere() : this(Thing.None) { }

        // This constructor takes a parameter for the thing.
        public IsHere(Thing what)
        {
            What = what;
        }

        // This method runs the IsHere condition on the given WorldState object.
        public override bool run(WorldState state)
        {
            //if the location of the What and the location of the Checker are the same
            if (state.ThingPosition[What] == state.CharacterPosition[Checker])
            {
                //print and return true
                Debug.Log($"The {What} is here");
                return true;
            }
            else
            {
                //otherwise print and return false
                Debug.Log($"The {What} is not here");
                return false;
            }
        }

        // Creates and returns a string describing the IsHere condition.
        public override string ToString()
        {
            return "Is " + what + " here?";
        }
    }
}