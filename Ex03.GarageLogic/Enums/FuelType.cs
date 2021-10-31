using System;
namespace Ex03.GarageLogic.Enums
{
    public class FuelType
    {
        internal eFuelType m_TankFuel;

        public static FuelType Parse(string i_InputValue)
        {
            FuelType fuelTypeChoice = new FuelType();

            switch (i_InputValue)
            {
                // $G$ CSS-999 (-5) You should use the value of the enum.
                case "1":
                    {
                        fuelTypeChoice.m_TankFuel = eFuelType.Octan98;
                        break;
                    }
                case "2":
                    {
                        fuelTypeChoice.m_TankFuel = eFuelType.Octan95;
                        break;
                    }
                case "3":
                    {
                        fuelTypeChoice.m_TankFuel = eFuelType.Soler;
                        break;
                    }
                case "4":
                    {
                        fuelTypeChoice.m_TankFuel = eFuelType.Electricity;
                        break;
                    }
                default:
                    {
                        throw new FormatException("Wrong input. The current input did not matched any fuel type.");
                    }
            }

            return fuelTypeChoice;
        }

        public eFuelType TankFuel
        {
            get
            {
                return this.m_TankFuel;
            }
        }
    }
}
