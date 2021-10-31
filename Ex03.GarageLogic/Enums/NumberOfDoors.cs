using System;
namespace Ex03.GarageLogic.Enums
{
    public class NumberOfDoors
    {
        private eNumberOfDoors m_CarDoors;

        public static NumberOfDoors Parse(string i_InputValue)
        {
            NumberOfDoors selectedNumDoors = new NumberOfDoors();

            switch (i_InputValue)
            {
                case "2":
                {
                    selectedNumDoors.m_CarDoors = eNumberOfDoors.Two;
                    break;
                }
                case "3":
                {
                    selectedNumDoors.m_CarDoors = eNumberOfDoors.Three;
                    break;
                }
                case "4":
                {
                    selectedNumDoors.m_CarDoors = eNumberOfDoors.Four;
                    break;
                }
                case "5":
                {
                    selectedNumDoors.m_CarDoors = eNumberOfDoors.Five;
                    break;
                }
                default:
                {
                    throw new FormatException("Wrong input. Please enter numbers according to right values.");
                }
            }

            return selectedNumDoors;
        }

        public override string ToString()
        {
            return string.Format(@"{0}", this.m_CarDoors);
        }
    }
}
