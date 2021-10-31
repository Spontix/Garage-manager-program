namespace Ex03.GarageLogic.Enums
{

    public class MaxAmountOfFuel
    {
        private eTypeOfVehicle m_FuelInTank;

        public static float Parse(TypeOfVehicle i_InputValue)
        {
            float vehicleTypeChoice = 0;

            switch (i_InputValue.CarTypeChosen)
            {
                case eTypeOfVehicle.FuelMotorcycle:
                {
                    vehicleTypeChoice = 6.0f;
                    break;
                }
                case eTypeOfVehicle.ElectricMotorcycle:
                {
                    vehicleTypeChoice = 1.8f;
                    break;
                }
                case eTypeOfVehicle.FuelCar:
                {
                    vehicleTypeChoice = 45.0f;
                    break;
                }
                case eTypeOfVehicle.ElectricCar:
                {
                    vehicleTypeChoice = 3.2f;
                    break;
                }
                case eTypeOfVehicle.Truck:
                {
                    vehicleTypeChoice = 120.0f;
                    break;
                }
            }

            return vehicleTypeChoice;
        }
    }
}
