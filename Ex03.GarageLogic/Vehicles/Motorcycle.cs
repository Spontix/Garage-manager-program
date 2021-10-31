using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Vehicles
{
    internal abstract class Motorcycle : Vehicle
    {
        protected LicenseType m_TypeOfLicense;
        protected int m_EngineVolume;

        protected Motorcycle (string i_ModuleName, string i_LicensePlate, float i_CurrentValueOfTank,
            LicenseType i_TypeOfLicense, int i_EngineSize, float[] i_WheelsCurrentPressure, string i_WheelManufactureName) 
            : base(i_ModuleName, i_LicensePlate, i_CurrentValueOfTank)
        {
            m_TypeOfLicense = i_TypeOfLicense;
            m_EngineVolume = i_EngineSize;
            m_WheelsList = new Wheel[(int)eNumOfWheels.Motorcycle];
            for(int i = 0; i<(int)eNumOfWheels.Motorcycle; ++i)
            {
                m_WheelsList[i] = new Wheel((i + 1), i_WheelManufactureName, i_WheelsCurrentPressure[i], eMaxAirPressure.Motorcycle);
            }
        }

        public LicenseType TypeOfLicense
        {
            get
            {
                return m_TypeOfLicense;
            }
        }

        public int EngineSize
        {
            get
            {
                return m_EngineVolume;
            }
        }

        public override string ToString()
        {
            string returnedString = base.ToString() + string.Format(@"5. License type: {0}
6. Engine size: {1}
", this.TypeOfLicense, this.EngineSize);

            return returnedString;
        }

        public new static void GetListOfDataMembers(ref List<string> io_DataList)
        {
            Vehicle.GetListOfDataMembers(ref io_DataList);
            io_DataList.Add(@"Motorcycle license type:
1. A
2. B1
3. AA
4. BB");
            io_DataList.Add("Engine volume");
            io_DataList.Add("Wheels manufacturer name");
            io_DataList.Add("Current air pressure of 1st wheel");
            io_DataList.Add("Current air pressure of 2nd wheel");
        }

        public static void MembersCheck(List<string> i_ListOfVariables, List<Object> i_ListOfAllTheMemberOfTheNeededObjectToCreate, int i_IndexToStartFrom)
        {
            int engineSize;
            LicenseType typeOfLicense;

            typeOfLicense = LicenseType.Parse(i_ListOfVariables[i_IndexToStartFrom]);
            i_ListOfAllTheMemberOfTheNeededObjectToCreate.Add(typeOfLicense);
            engineSize = int.Parse(i_ListOfVariables[i_IndexToStartFrom + 1]);
            i_ListOfAllTheMemberOfTheNeededObjectToCreate.Add(engineSize);
        }


    }
}
