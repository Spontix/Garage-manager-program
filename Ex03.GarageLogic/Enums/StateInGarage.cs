using System;
namespace Ex03.GarageLogic.Enums
{
    public class StateInGarage
    {
        private eStateInGarage m_CurrentStateOfVehicle;

        public static StateInGarage Parse(string i_InputValue)
        {
            StateInGarage statusChoice = new StateInGarage();

            switch (i_InputValue)
            {
                case "1":
                {
                    statusChoice.m_CurrentStateOfVehicle = eStateInGarage.inReplacement;
                    break;
                }
                case "2":
                {
                    statusChoice.m_CurrentStateOfVehicle = eStateInGarage.Complete;
                    break;
                }
                case "3":
                {
                    statusChoice.m_CurrentStateOfVehicle = eStateInGarage.Paid;
                    break;
                }
                default:
                {
                    throw new FormatException("Wrong input. Please enter numbers according to right values.");
                }
            }

            return statusChoice;
        }

        public eStateInGarage CurrentState
        {
            get
            {
                return this.m_CurrentStateOfVehicle;
            }
        }
    }
}
