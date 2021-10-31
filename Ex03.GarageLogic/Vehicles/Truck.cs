using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Vehicles
{
    internal class Truck : Vehicle
    {
        private readonly bool r_DrivingWithToxicMaterials;
        private readonly float r_MaxLoadWeight;

        public Truck(string i_ModuleName, string i_LicensePlateNumber, float i_CurrentAmountOfTank,
            bool i_IsContainToxicMaterials, float i_MaxLoadWeight, float[] i_WheelsCurrentPresure, string i_WheelManufactureName)
            : base(i_ModuleName, i_LicensePlateNumber, i_CurrentAmountOfTank)
        {
            r_DrivingWithToxicMaterials = i_IsContainToxicMaterials;
            r_MaxLoadWeight = i_MaxLoadWeight;
            m_FuelType = eFuelType.Soler;
            m_MaxValueOfTank = MaxAmountOfFuel.Parse(TypeOfVehicle.Parse(eTypeOfVehicle.Truck));
            m_WheelsList = new Wheel[(int)eNumOfWheels.Truck];
            for(int i=0 ; i < (int)eNumOfWheels.Truck; ++i)
            {
                m_WheelsList[i] = new Wheel((i + 1), i_WheelManufactureName, i_WheelsCurrentPresure[i], eMaxAirPressure.Truck);
            }
        }

        public string DrivingWithToxicMaterials
        {
            get
            {
                string output = "X";
                if (r_DrivingWithToxicMaterials)
                {
                    output = "V";
                }

                return output;
            }
        }

        public float MaxLoadWeight
        {
            get
            {
                return r_MaxLoadWeight;
            }
        }

        public override string ToString()
        {
            string truckDetailsToPrint = "1. Vehicle type: Truck" + Environment.NewLine;

            truckDetailsToPrint += base.ToString() + string.Format(@"5. Driving with dangerous materials: {0}
6. Max load: {1}
7. Fuel type: {2}
8. Current amount of fuel: {3}
9. Max amount of fuel: {4}
", this.DrivingWithToxicMaterials, this.MaxLoadWeight, this.FuelType, this.CurrentValueOfTank, this.MaxValueOfTank);

            return truckDetailsToPrint;
        }

        public new static void GetListOfDataMembers(ref List<string> io_DataMemberList)
        {
            Vehicle.GetListOfDataMembers(ref io_DataMemberList);
            io_DataMemberList.Add(@"Are you are carrying any Toxic materials? 
Yes
No");
            io_DataMemberList.Add("Max load weight:");
            io_DataMemberList.Add("Wheels manufacturer name:");
            for (int i = 1; i <= (int)eNumOfWheels.Truck; ++i)
            {
                io_DataMemberList.Add("Current air pressure of " + i + "the wheel");
            }
        }

        public static List<Object> ChangeTypeInTruck(List<string> i_ListOfVariables)
        {
            List<Object>        listOfAllTheMemberOfTheNeededObjectToCreate = null;
            float               maxLoadWeight;
            bool                isDrivingToxic;

            listOfAllTheMemberOfTheNeededObjectToCreate = Vehicle.MembersCheck(i_ListOfVariables, eTypeOfVehicle.Truck);
            isDrivingToxic = bool.Parse(i_ListOfVariables[2]);
            listOfAllTheMemberOfTheNeededObjectToCreate.Add(isDrivingToxic);
            maxLoadWeight = float.Parse(i_ListOfVariables[3]);
            listOfAllTheMemberOfTheNeededObjectToCreate.Add(maxLoadWeight);
            Vehicle.AddWheelsAndWheelsManufactureToList(i_ListOfVariables, listOfAllTheMemberOfTheNeededObjectToCreate, (int)eNumOfWheels.Truck,
                4, eMaxAirPressure.Truck);

            return listOfAllTheMemberOfTheNeededObjectToCreate;
        }
    }
}
