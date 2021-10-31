using System;
namespace Ex03.GarageLogic.Enums
{
    public class TypeOfVehicle
    {
        private eTypeOfVehicle m_CarTypeChosen;

        public static TypeOfVehicle Parse(eTypeOfVehicle i_InputValue)
        {
            TypeOfVehicle vehicleChoice = new TypeOfVehicle(); 

            switch (i_InputValue)
            {
                case eTypeOfVehicle.FuelMotorcycle:
                    {
                        vehicleChoice.m_CarTypeChosen = eTypeOfVehicle.FuelMotorcycle;
                        break;
                    }
                case eTypeOfVehicle.ElectricMotorcycle:
                    {
                        vehicleChoice.m_CarTypeChosen = eTypeOfVehicle.ElectricMotorcycle;
                        break;
                    }
                case eTypeOfVehicle.FuelCar:
                    {
                        vehicleChoice.m_CarTypeChosen = eTypeOfVehicle.FuelCar;
                        break;
                    }
                case eTypeOfVehicle.ElectricCar:
                    {
                        vehicleChoice.m_CarTypeChosen = eTypeOfVehicle.ElectricCar;
                        break;
                    }
                case eTypeOfVehicle.Truck:
                    {
                        vehicleChoice.m_CarTypeChosen = eTypeOfVehicle.Truck;
                        break;
                    }
                default:
                    {
                        throw new FormatException("Wrong input. Please enter number according to given values values.");
                    }
            }

            return vehicleChoice;
        }

        public static TypeOfVehicle Parse(string i_InputValue)
            {
                TypeOfVehicle typeVehicle = new TypeOfVehicle();

                switch (i_InputValue)
                {
                case "1":
                    {
                        typeVehicle.m_CarTypeChosen = eTypeOfVehicle.FuelMotorcycle;
                        break;
                    }
                case "2":
                    {
                        typeVehicle.m_CarTypeChosen = eTypeOfVehicle.ElectricMotorcycle;
                        break;
                    }
                case "3":
                    {
                        typeVehicle.m_CarTypeChosen = eTypeOfVehicle.FuelCar;
                        break;
                    }
                case "4":
                    {
                        typeVehicle.m_CarTypeChosen = eTypeOfVehicle.ElectricCar;
                        break;
                    }
                case "5":
                    {
                        typeVehicle.m_CarTypeChosen = eTypeOfVehicle.Truck;
                        break;
                    }
                    default:
                    {
                        throw new FormatException("Wrong input. Input did not matched any type of vehicle please try again.");
                    }
                }

                return typeVehicle;
        }

        public override string ToString()
        {
            return string.Format(@"{0}", this.m_CarTypeChosen);
        }

        public eTypeOfVehicle CarTypeChosen
        {
            get
            {
                return m_CarTypeChosen;
            }
        }
    }
}
