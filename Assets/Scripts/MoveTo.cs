using System;
using UnityEngine;

namespace BehaviorTree
{
    [Serializable]
    public class MoveTo : Task
    {
        // The character that is moving to a different location.
        private Character mover;
        public Character Mover
        {
            get { return mover; }
            set { mover = value; }
        }

        // The location the character is moving to.
        private Location where;
        public Location Where
        {
            get { return where; }
            set { where = value; }
        }

        // This constructor defaults the character and location to None.
        public MoveTo() : this(Character.None, Location.None) { }

        // This constructor takes parameters for the character and location.
        public MoveTo (Character mover, Location where)
        {
            Mover = mover;
            Where = where;
        }

        // This method runs the MoveTo action on the given WorldState object.
        public override bool run (WorldState state)
        {
            //if the Location Where is not the same location as the Character Mover's position
            if(Where != state.CharacterPosition[Mover])
            {
                Debug.Log($"location of where and mover is not the same");

                //if there is a connection between the Mover's position and the Where location
                if (state.ConnectedLocations[state.CharacterPosition[Mover]].Contains(Where))
                {
                    Debug.Log($"connection between {Mover} and {Where}");

                    //if there is a Gate between the Mover and the Where location
                    if (state.BetweenLocations.ContainsKey(Where) && state.BetweenLocations[Where].Item1 == Thing.Gate && state.BetweenLocations[Where].Item2 == state.CharacterPosition[Mover])
                    {
                        Debug.Log($"There's a gate between {Where} and {state.CharacterPosition[Mover]}");

                        //if that Gate is open
                        if (state.Open[state.BetweenLocations[Where].Item1])
                        {
                            Debug.Log($"The gate is open! CHAAAARRRGGGEE!!!");
                            state.CharacterPosition[Mover] = Where;
                            return true;
                        }
                    }
                    //there is no Gate
                    else
                    {
                        Debug.Log($"There's no gate between {Where} and {state.CharacterPosition[Mover]}");
                        state.CharacterPosition[Mover] = Where;
                        return true;
                    }
                    
                }

            }

            //if the code has dodged all of the true cases then it must be false
            Debug.Log($"The {Mover} is unable to move to {Where}");
            return false;
        }

        // Creates and returns a string describing the MoveTo action.
        public override string ToString()
        {
            return mover + " moves to " + where;
        }
    }
}
