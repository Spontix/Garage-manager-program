using System;
using System.Collections.Generic;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.Factory;
using System.Threading;

// $G$ DSN-999 (-7) Why static? it's not object-oriented. You should have had an instance of this class created by the Main and 
// call a Run() method. This class should have members (such as Garage class) and not local variables within a method.

namespace Ex03.ConsoleUI
{
    public class GarageUI
    {
        public static void runGarageMenu()
        {
            Garage garage = new Garage();
            bool isThereVehicleInGarage = false;
            bool isExitClicked = false;

            while (!isExitClicked)
            {
                MenuIndex menuIndex = GarageUI.userInputCheck();
                Console.Write(Environment.NewLine);
                switch (menuIndex.IndexChosen)
                {
                    case eMenuIndex.InsertCar:
                        {
                            isThereVehicleInGarage = GarageUI.insertCar(garage);
                            break;
                        }
                    case eMenuIndex.ShowAllVehicles:
                        {
                            filterChoiceCheck(garage);
                            break;
                        }
                    case eMenuIndex.ChangeVehicleStatus:
                        {
                            changeCarState(garage, isThereVehicleInGarage);
                            break;
                        }
                    case eMenuIndex.InflateWheel:
                        {
                            fillAirInCar(garage, isThereVehicleInGarage);
                            break;
                        }
                    case eMenuIndex.FillTankOfFuelVehicle:
                        {
                            fillTank(garage, isThereVehicleInGarage);
                            break;
                        }
                    case eMenuIndex.FillBatteryOfElectricVehicle:
                        {
                            chargeBattery(garage, isThereVehicleInGarage);
                            break;
                        }
                    case eMenuIndex.ShowDetailsOfSpecificCar:
                        {
                            fullDetailsPrint(garage, isThereVehicleInGarage);
                            break;
                        }
                    case eMenuIndex.ExitGarage:
                        {
                            exit(ref isExitClicked);
                            break;
                        }
                }

                if (!isExitClicked)
                {
                    Console.WriteLine("Returning to menu.");
                }
            }
        }

        private static bool insertCar(Garage i_Garage)
        {
            bool isThereVehicleInGarage = false;
            VehicleOwner owner;
            VehicleInGarage vehicleInGarage;

            try
            {
                Console.WriteLine("Please enter the license plate:");
                string licensePlateNumber = Console.ReadLine();
                if (i_Garage.AllVehiclesInGarage.TryGetValue(licensePlateNumber, out vehicleInGarage))
                {
                    Console.WriteLine("There is already a vehicle with this license plate in the garage.");
                    vehicleInGarage.VehicleStatus = eStateInGarage.inReplacement;
                    isThereVehicleInGarage = true;
                }
                else
                {
                    Console.WriteLine("The vehicle is not a current member in the garage. Please insert relevent information.");
                    Thread.Sleep(2000);
                    //Console.Clear();
                    createNewOwner(out owner);
                    addNewCar(ref owner, i_Garage, licensePlateNumber);
                    isThereVehicleInGarage = true;
                }
            }
            catch (Exception exceptionMessage)
            {
                Thread.Sleep(5000);
                Console.WriteLine(exceptionMessage.Message);
            }

            return isThereVehicleInGarage;
        }

        

        private static void createNewOwner(out VehicleOwner o_Owner)
        {
            string ownerName, ownerPhoneNumber;

            Console.WriteLine("Owner Information " + Environment.NewLine);
            Console.WriteLine("Please enter your name: ");
            ownerName = Console.ReadLine();
            Console.WriteLine("Please enter your phone number. Integers Only: ");
            ownerPhoneNumber = Console.ReadLine();
            o_Owner = new VehicleOwner(ownerName, ownerPhoneNumber);
        }

        private static void printMenu()
        {
            //Console.Clear();
            Console.WriteLine(@"Please enter the number of the operation you would like to commit:
1. Enter new vehicle to the garage.
2. Show license plate with/out filters in garage. 
3. Update statuse of vehicle in garage.
4. Inflate wheels of a vehicle.
5. Refuel the fuel tank of the vehicle.
6. Charge electric battery of the vehicle.
7. Show full data of a sepecific vehicle.
8. Exit the program.");
        }

        private static void filterChoiceCheck(Garage i_Garage)
        {
            bool isValideInput = false;
            FilterVehicleCondition filterCondition = null;

            try
            {
                while (!isValideInput)
                {
                    showListAllVehiclesFilters();
                    string filterChoice = Console.ReadLine();

                    try
                    {
                        filterCondition = FilterVehicleCondition.Parse(filterChoice);
                        filterChoicePrint(i_Garage, filterCondition);
                        isValideInput = true;
                    }
                    catch (Exception exceptionMessage)
                    {
                        throw exceptionMessage;
                    }
                }
            }
            catch (Exception exceptionMessage)
            {
                Console.WriteLine(exceptionMessage.Message);
                Thread.Sleep(5000);
            }
        }

        private static void addNewCar(ref VehicleOwner i_Owner, Garage i_Garage, string i_LicensePlate)
        {
            int numOfChoice = 1;
            List<string> listNamesOfAvailableVehicles;
            List<string> inputRequestFromUser;
            List<string> inputResponsFromUser;
            string userVehicleChoice;
            TypeOfVehicle vehicleType;

            listNamesOfAvailableVehicles = VehicleFactory.GetAllVehicleNames();
            foreach (string carName in listNamesOfAvailableVehicles)
            {
                Console.WriteLine("Please choose " + numOfChoice + " for " + carName);
                numOfChoice++;
            }

            userVehicleChoice = Console.ReadLine();
            vehicleType = TypeOfVehicle.Parse(userVehicleChoice);
            inputRequestFromUser = VehicleFactory.ConvertUserChoiceToTypeOfVehicle(vehicleType);
            inputResponsFromUser = dataFromUser(inputRequestFromUser);
            VehicleInGarage addNewVehicle = VehicleFactory.CreateVehicle(ref i_Owner, inputResponsFromUser, vehicleType, i_LicensePlate);
            i_Garage.AddCarToGarage(addNewVehicle.StoredVehicle.LicensePlate, addNewVehicle);
        }

        private static List<string> dataFromUser(List<string> i_ListOfDemands)
        {
            List<string> listOfUserDetailes = new List<string>();

            foreach (string userInput in i_ListOfDemands)
            {
                Console.WriteLine("Please enter " + userInput);
                listOfUserDetailes.Add(Console.ReadLine());
            }

            return listOfUserDetailes;
        }

        private static void fillAirInCar(Garage i_Garage, bool i_IsGarageEmpty)
        {
            string licensePlate;

            if (!i_IsGarageEmpty)
            {
                garageEmptyMessage();
            }
            else
            {
                try
                {
                    Console.WriteLine("Please enter the license plate of the car:");
                    licensePlate = Console.ReadLine();
                    i_Garage.FillAirToMaximum(licensePlate);
                    Console.WriteLine("Air was filled successfully");
                }
                catch (Exception exceptionMessage)
                {
                    Console.WriteLine(exceptionMessage.Message);
                    Thread.Sleep(2000);
                }
            }
        }

        

        private static void filterChoicePrint(Garage i_Garage, FilterVehicleCondition i_FilteType)
        {
            List<string> listOfVehiclesToShow = new List<string>();

            switch (i_FilteType.FilterChosen)
            {
                case eFilterVehicleCondition.inReplacement:
                    {
                        listOfVehiclesToShow = i_Garage.GetListOfVehiclesLicensePlateByStatus(eStateInGarage.inReplacement);
                        break;
                    }
                case eFilterVehicleCondition.Complete:
                    {
                        listOfVehiclesToShow = i_Garage.GetListOfVehiclesLicensePlateByStatus(eStateInGarage.Complete);
                        break;
                    }
                case eFilterVehicleCondition.Paid:
                    {
                        listOfVehiclesToShow = i_Garage.GetListOfVehiclesLicensePlateByStatus(eStateInGarage.Paid);
                        break;
                    }
                case eFilterVehicleCondition.Unfiltered:
                    {
                        listOfVehiclesToShow = i_Garage.GetAllVehiclesLicensePlate();
                        break;
                    }
            }
            if (listOfVehiclesToShow.Count == 0)
            {
                Console.WriteLine("There are no vehicles in the garage yet.");
            }
            else
            {
                Console.WriteLine("The license plates are:");
                foreach (string plate in listOfVehiclesToShow)
                {
                    Console.WriteLine(plate);
                    Thread.Sleep(5000);
                }
            }

        }

        private static void showListAllVehiclesFilters()
        {
            Thread.Sleep(1000);
            Console.WriteLine(@"Please enter the number of the option according to the wanted filtering:
1. In replacement.
2. All vehicles repaired.
3. All vehicles Paid.
4. Show all vehicles without filters.");
        }

        private static MenuIndex userInputCheck()
        {
            MenuIndex menuIndex = new MenuIndex();
            bool isValideInput = false;

            while (!isValideInput)
            {
                printMenu();
                string userInput = Console.ReadLine();
                try
                {
                    menuIndex = MenuIndex.Parse(userInput);
                    isValideInput = true;
                    Thread.Sleep(4000);
                    Console.Clear();
                }
                catch (FormatException exceptionMessage)
                {
                    Console.WriteLine(exceptionMessage.Message);
                }
            }

            return menuIndex;
        }

        private static void garageEmptyMessage()
        {
            Console.WriteLine("The garage is empty at the moment.");
        }

        private static void changeCarState(Garage i_Garage, bool i_IsThereVehicleInGarage)
        {
            if (!i_IsThereVehicleInGarage)
            {
                garageEmptyMessage();
            }
            else
            {
                try
                {
                    Console.WriteLine(Environment.NewLine + "Please enter the vehicle's license plate.");
                    string licensePlate = Console.ReadLine();
                    Console.WriteLine(@"Please enter the new state for the vehicle:
1. In replacement.
2. Fixed.
3. Paid.");
                    string stateStr = Console.ReadLine();
                    StateInGarage state = StateInGarage.Parse(stateStr);
                    i_Garage.UpdateVehiclesState(licensePlate, state);
                }
                catch (Exception exceptionMessage)
                {
                    Console.WriteLine(exceptionMessage.Message);
                    Thread.Sleep(4000);
                }
            }
        }

        private static void fillTank(Garage i_Garage, bool i_IsThereVehicleInGarage)
        {
            if (!i_IsThereVehicleInGarage)
            {
                garageEmptyMessage();
            }
            else
            {
                try
                {
                    Console.WriteLine("Please enter the license plate of the car:");
                    string licensePlate = Console.ReadLine();
                    Console.WriteLine("Please enter the fuel type: [1 = Octan98 , 2 = Octan95 , 3 = Soler]");
                    string fuelStr = Console.ReadLine();
                    FuelType fuel = FuelType.Parse(fuelStr);
                    Console.WriteLine("Please enter amount of fuel to add:");
                    string amountStr = Console.ReadLine();
                    float amount = float.Parse(amountStr);
                    i_Garage.FillTank(licensePlate, fuel, amount);
                    Console.WriteLine("Your fuel tank has been successfully refilled");
                }
                catch (Exception exceptionMessage)
                {
                    Console.WriteLine(exceptionMessage.Message);
                    Thread.Sleep(4000);

                }
            }
        }

        private static void chargeBattery(Garage i_Garage, bool i_IsThereVehicleInGarage)
        {
            if (!i_IsThereVehicleInGarage)
            {
                garageEmptyMessage();
            }
            else
            {
                try
                {
                    Console.WriteLine("Please enter the license plate of the car:");
                    string licensePlate = Console.ReadLine();
                    Console.WriteLine("Please enter the amount of electricity to be charged:");
                    string electricityToAdd = Console.ReadLine();
                    float electricity = float.Parse(electricityToAdd);
                    i_Garage.ChargeElectricVehicle(licensePlate, electricity);
                    Console.WriteLine("Your battery has been successfully charged");
                }
                catch (Exception exceptionMessage)
                {
                    Console.WriteLine(exceptionMessage.Message);
                    Thread.Sleep(4000);
                }
            }
        }

        private static void fullDetailsPrint(Garage i_Garage, bool i_IsThereVehicleInGarage)
        {
            if (!i_IsThereVehicleInGarage)
            {
                garageEmptyMessage();
            }
            else
            {
                try
                {
                    Console.WriteLine("Please enter the license plate of the car:");
                    string licensePlate = Console.ReadLine();
                    Console.WriteLine(i_Garage.ShowDetailsOfVehicle(licensePlate));
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                    Console.WriteLine();
                }
                catch (Exception exceptionMessage)
                {
                    Console.WriteLine(exceptionMessage.Message);
                    Thread.Sleep(4000);
                }
            }
        }

        private static void exit(ref bool i_WasExitEntered)
        {
            i_WasExitEntered = true;
            Console.WriteLine(@"Exiting garage system.
GoodBye.");
            Thread.Sleep(2000);
        }
    }
}