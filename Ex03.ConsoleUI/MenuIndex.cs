using System;

namespace Ex03.ConsoleUI
{
    public class MenuIndex
    {
        private eMenuIndex m_IndexChosen;

        public static MenuIndex Parse(string i_InputValue)
        {
            MenuIndex choiceInput = new MenuIndex();

            switch (i_InputValue)
            {
                // $G$ CSS-018 (-3) You should have used enumerations here.
                case "1":
                {
                    choiceInput.m_IndexChosen = eMenuIndex.InsertCar;
                    break;
                }
                case "2":
                {
                    choiceInput.m_IndexChosen = eMenuIndex.ShowAllVehicles;
                    break;
                }
                case "3":
                {
                    choiceInput.m_IndexChosen = eMenuIndex.ChangeVehicleStatus;
                    break;
                }
                case "4":
                {
                    choiceInput.m_IndexChosen = eMenuIndex.InflateWheel;
                    break;
                }
                case "5":
                {
                    choiceInput.m_IndexChosen = eMenuIndex.FillTankOfFuelVehicle;
                    break;
                }
                case "6":
                {
                    choiceInput.m_IndexChosen = eMenuIndex.FillBatteryOfElectricVehicle;
                    break;
                }
                case "7":
                {
                    choiceInput.m_IndexChosen = eMenuIndex.ShowDetailsOfSpecificCar;
                    break;
                }
                case "8":
                {
                    choiceInput.m_IndexChosen = eMenuIndex.ExitGarage;
                    break;
                }
                default:
                {
                    throw new FormatException("Wrong input. Please enter numbers according to right values.");
                }
            }

            return choiceInput;
        }

        public eMenuIndex IndexChosen
        {
            get
            {
                return this.m_IndexChosen;
            }
        }
    }
}
