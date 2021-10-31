using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Enums;
namespace Ex03.GarageLogic.Vehicles
{
    class ElectricCar : Car
    {
        public ElectricCar(string i_ModuleName, string i_LicensePlate, float i_CurrentValueOfTank, 
            CarColor i_CarColor, NumberOfDoors i_NumOfDoors, float[] i_WheelsCurrentPresure, string i_WheelManufactureName)
            : base(i_ModuleName, i_LicensePlate, i_CurrentValueOfTank, i_CarColor, i_NumOfDoors, i_WheelsCurrentPresure, i_WheelManufactureName)
        {
            this.m_MaxValueOfTank = MaxAmountOfFuel.Parse(TypeOfVehicle.Parse(eTypeOfVehicle.ElectricCar));
            this.m_PercentageOfEnergyLeft = m_CurrentValueOfTank / m_MaxValueOfTank;
            this.m_FuelType = eFuelType.Electricity;
        }

        public override string ToString()
        {
            string electricCarToPrint = "1. Vehicle type: ElectricCar";

            electricCarToPrint += base.ToString() + string.Format(@"7) Time left for engine power: {0}
8) Max engine power: {1} ", this.CurrentValueOfTank, this.MaxValueOfTank);

            return electricCarToPrint;
        }

        public static List<Object> ChangeType(List<string> i_ListOfVariables)
        {
            List<Object> listOfAllTheMemberOfTheNeededObjectToCreate = null;

            listOfAllTheMemberOfTheNeededObjectToCreate = Vehicle.MembersCheck(i_ListOfVariables, eTypeOfVehicle.ElectricCar);
            Car.MembersCheck(i_ListOfVariables, listOfAllTheMemberOfTheNeededObjectToCreate, 2);
            Vehicle.AddWheelsAndWheelsManufactureToList(i_ListOfVariables, listOfAllTheMemberOfTheNeededObjectToCreate, (int)eNumOfWheels.Car,
                4, eMaxAirPressure.Car);

            return listOfAllTheMemberOfTheNeededObjectToCreate;
        }

    }
}
