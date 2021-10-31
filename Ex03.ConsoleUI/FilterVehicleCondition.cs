using System;

namespace Ex03.ConsoleUI
{
    public class FilterVehicleCondition
    {
        private eFilterVehicleCondition m_FilterChosen;

        public FilterVehicleCondition() 
        {
            m_FilterChosen = eFilterVehicleCondition.inReplacement;
        }

        public static FilterVehicleCondition Parse(string i_InputValue)
        {
            FilterVehicleCondition optionChosen = new FilterVehicleCondition();

            switch (i_InputValue)
            {
                case "1":
                    {
                        optionChosen.m_FilterChosen = eFilterVehicleCondition.inReplacement;
                        break;
                    }
                case "2":
                    {
                        optionChosen.m_FilterChosen = eFilterVehicleCondition.Complete;
                        break;
                    }
                case "3":
                    {
                        optionChosen.m_FilterChosen = eFilterVehicleCondition.Paid;
                        break;
                    }
                case "4":
                    {
                        optionChosen.m_FilterChosen = eFilterVehicleCondition.Unfiltered;
                        break;
                    }
                default:
                    {
                        throw new FormatException("Wrong input. Please enter a number according to the given values.");
                    }
            }

            return optionChosen;
        }

        public eFilterVehicleCondition FilterChosen
        {
            get
            {
                return m_FilterChosen;
            }
        }
    }
}
