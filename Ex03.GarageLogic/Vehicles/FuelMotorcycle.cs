using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Vehicles
{
    internal class FuelMotorcycle : Motorcycle
    {
        public FuelMotorcycle(string i_ModuleName, string i_LicensePlateNumber, LicenseType i_LicenseType, float i_CurrentAmountOfTank,
            string i_WheelManufacturerName, float[] i_WheelsCurrentPressure,  int i_EngineVolume)
           : base(i_ModuleName, i_LicensePlateNumber, i_CurrentAmountOfTank, i_LicenseType, i_EngineVolume, i_WheelsCurrentPressure, i_WheelManufacturerName)
        {
            this.m_MaxValueOfTank = MaxAmountOfFuel.Parse(TypeOfVehicle.Parse(eTypeOfVehicle.FuelMotorcycle));
            this.m_PercentageOfEnergyLeft = this.m_CurrentValueOfTank / this.m_MaxValueOfTank;
            this.m_FuelType = eFuelType.Octan98;
        }

        public override string ToString()
        {
            string          returnedString = "1. Vehicle type: FuelMotorcycle";

            returnedString += base.ToString() + string.Format(@"7. Fuel type: {0}
8. Current amount of fuel: {1}
9. Max amount of fuel: {2}", this.FuelType, this.CurrentValueOfTank, this.MaxValueOfTank);
            
            return returnedString;
        }

        public static List<Object> ChangeTypeInFuelMotorcycle(List<string> i_ListOfVariables)
        {
            List<Object>    listOfAllTheMemberOfTheNeededObjectToCreate = null;

            listOfAllTheMemberOfTheNeededObjectToCreate = Vehicle.MembersCheck(i_ListOfVariables, eTypeOfVehicle.FuelMotorcycle);
            Motorcycle.MembersCheck(i_ListOfVariables, listOfAllTheMemberOfTheNeededObjectToCreate, 2);
            Vehicle.AddWheelsAndWheelsManufactureToList(i_ListOfVariables, listOfAllTheMemberOfTheNeededObjectToCreate, (int)eNumOfWheels.Motorcycle,
                4, eMaxAirPressure.Motorcycle);

            return listOfAllTheMemberOfTheNeededObjectToCreate;

        }

    }
}
