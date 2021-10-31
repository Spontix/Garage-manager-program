using System;

namespace Ex03.GarageLogic.Enums
{
    internal class CarColor
    {
        private eCarColor m_CarColorChosen;

        public static CarColor Parse (string i_InputValue)
        {
            CarColor returnColor = new CarColor();

            switch (i_InputValue)
            {
                case "1":
                {
                    returnColor.m_CarColorChosen = eCarColor.Red;
                    break;
                }
                case "2":
                {
                    returnColor.m_CarColorChosen = eCarColor.Silver;
                    break;
                }
                case "3":
                {
                    returnColor.m_CarColorChosen = eCarColor.White;
                    break;
                }
                case "4":
                {
                    returnColor.m_CarColorChosen = eCarColor.Black;
                    break;
                }
                default:
                {
                        throw new FormatException("Wrong input. Please enter numbers according to right values.");
                }
            }

            return returnColor;
        }

        public override string ToString()
        {
            return string.Format(@"{0}", this.m_CarColorChosen);
        }

        public eCarColor CarColorChosen
        {
            get
            {
                return m_CarColorChosen;
            }
        }
    }
}
