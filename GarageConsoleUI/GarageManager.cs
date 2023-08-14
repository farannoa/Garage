using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{

    internal class GarageManager
    {
        static void Main()
        {
            startGarage();
        }

        private static void startGarage()
        {
            System.Console.WriteLine("Welcome to Our garage, here we don't have combinot!");
            while(true)
            {
                mainMenuMessage();
                int input = inputValidation(1, 8);
                if(input == 8)
                {
                    break;
                }

                casesToOperate(input);
            }
        }

        private static void casesToOperate(int i_IntToOperate)
        {
            switch(i_IntToOperate)
            {
                case 1: 
                    addVehicle();
                    break;

                case 2:  
                    showListLicenseNumber();
                    break;

                case 3: 
                    changeVehicleState();
                    break;

                case 4: 
                    inflationWheelsToMax();
                    break;

                case 5: 
                    fillFuel();
                    break;

                case 6: 
                    fillElectricity();
                    break;

                case 7: 
                    printDetails();
                    break;
            }
        }

        private static void mainMenuMessage()
        {
            StringBuilder enterNumberToStart = new StringBuilder();

            enterNumberToStart.Append("\nWhat would you like to do now?\n");
            enterNumberToStart.Append("For add a new vehicle press 1\n");
            enterNumberToStart.Append("For a list with all the current vehicle in the garage press 2\n");
            enterNumberToStart.Append("To change specific vehicle state press 3\n");
            enterNumberToStart.Append("To add air pressure to specific vehicle press 4\n");
            enterNumberToStart.Append("To fuel specific vehicle press 5\n");
            enterNumberToStart.Append("To charge specific vehicle press 6\n");
            enterNumberToStart.Append("To view full data about specific vehicle press 7\n");
            enterNumberToStart.Append("To exit press 8");
            System.Console.WriteLine(enterNumberToStart);
        }

        private static void addVehicle()
        {
            System.Console.WriteLine("Please Enter License Plate");
            string licensePlate = System.Console.ReadLine();
            if(GarageManagerLogic.GetCarsInTheGarage().ContainsKey(licensePlate))
            {
                GarageManagerLogic.GetCarsInTheGarage()[licensePlate].Status = Vehicle.eStatusOfVehicle.NeedToBeFixed;
            }

            else
            {
                addNewVehicle(licensePlate);
            }
        }

        private static void addNewVehicle(string i_LicensePlate)
        {
            System.Console.WriteLine("Please Enter The Owner's name");
            string ownersName = nameValidation();
            System.Console.WriteLine("Please Enter The Owner's Phone Number");
            string ownerPhoneNumber = phoneValidation();
            System.Console.WriteLine("Enter Type Of Your Vehicle");
            string typeOfVehicle = System.Console.ReadLine();
            System.Console.WriteLine("Please Enter The Model Of The Vehicle");
            string modelName = System.Console.ReadLine();
            System.Console.WriteLine("For an Fuel engine press 1, for a Electric Engine press 2");
            int engine = inputValidation(1, 2);
            System.Console.WriteLine("Please Enter The Current Capacity");
            float currentCapacityEnergy = floatInputValidation();
            System.Console.WriteLine("Enter wheels' manufacturer");
            string wheelsManufacturer = nameValidation();
            System.Console.WriteLine("Enter wheels' current air pressure");
            float wheelsCurrentAirPressure = floatInputValidation();
            GarageManagerLogic.AddVehicle(
                typeOfVehicle,
                ownersName,
                ownerPhoneNumber,
                modelName,
                i_LicensePlate,
                engine,
                currentCapacityEnergy,
                wheelsManufacturer,
                wheelsCurrentAirPressure);
            List <string> uniqueParams =  GarageManagerLogic.GetCarsInTheGarage()[i_LicensePlate].GetUniqueParams();
            List <string> uniqueParamsValues = new List<string>();
            foreach(string param in uniqueParams)
            {
                System.Console.WriteLine("Please enter {0}", param);
                uniqueParamsValues.Add(System.Console.ReadLine());
            }

            GarageManagerLogic.GetCarsInTheGarage()[i_LicensePlate].SetUniqueParams(uniqueParamsValues);
        }

        private static void showListLicenseNumber()
        {
            StringBuilder enterNumberToSelectList = new StringBuilder();

            enterNumberToSelectList.Append("Would you like to filter your list?\n");
            enterNumberToSelectList.Append("For the full list press 1\n");
            enterNumberToSelectList.Append("For a list with all the vehicles that need to be fixed press 2\n");
            enterNumberToSelectList.Append("For a list with all the vehicles that been fixed already press 3\n");
            enterNumberToSelectList.Append("For a list with all the vehicles that been paid for the fix press 4");
            System.Console.WriteLine(enterNumberToSelectList);
            int input = inputValidation(1, 4);
            showListLicenseNumberAndFiltering(input);
        }

        private static void showListLicenseNumberAndFiltering(int i_FilterBy)
        {
            System.Console.WriteLine("The List Of Current Vehicles By Their license:");
            foreach(KeyValuePair<string, Vehicle> vehicle in GarageManagerLogic.GetCarsInTheGarage())
            {
                switch(i_FilterBy)
                {
                    case 1:
                        System.Console.WriteLine(vehicle.Value.vehicleDetails());
                        break;

                    case 2:
                        if(vehicle.Value.Status == Vehicle.eStatusOfVehicle.NeedToBeFixed)
                        {
                            System.Console.WriteLine(vehicle.Value.vehicleDetails());
                        }

                        break;

                    case 3:
                        if(vehicle.Value.Status == Vehicle.eStatusOfVehicle.HasFixed)
                        {
                            System.Console.WriteLine(vehicle.Value.vehicleDetails());
                        }

                        break;

                    case 4:
                        if(vehicle.Value.Status == Vehicle.eStatusOfVehicle.BeenPaid)
                        {
                            System.Console.WriteLine(vehicle.Value.vehicleDetails());
                        }

                        break;

                    default:
                        System.Console.WriteLine("Error printing the list.");
                        break; 
                }
            }
        }

        private static void changeVehicleState()
        {
            System.Console.WriteLine("Enter license plate");
            string licensePlate = System.Console.ReadLine();
            if(GarageManagerLogic.GetCarsInTheGarage().ContainsKey(licensePlate))
            {
                GarageManagerLogic.GetCarsInTheGarage()[licensePlate].Status = statusOfVehicleValidation();
            }

            else
            {
                System.Console.WriteLine("There's no vehicle in the garage with this license number");
            }
        }

        private static Vehicle.eStatusOfVehicle statusOfVehicleValidation()
        {
            StringBuilder enterNumberToStart = new StringBuilder();

            enterNumberToStart.Append("What is the vehicle status?\n");
            enterNumberToStart.Append("For a vehicle that need to be fixed press 1\n");
            enterNumberToStart.Append("For a vehicle that been fixed already press 2\n");
            enterNumberToStart.Append("For a vehicle that been paid press 3");
            System.Console.WriteLine(enterNumberToStart);
            int userInput = inputValidation(1, 4);
            Vehicle.eStatusOfVehicle statusOfVehicle = new Vehicle.eStatusOfVehicle();
            switch(userInput)
            {
                case 1:
                    statusOfVehicle = Vehicle.eStatusOfVehicle.NeedToBeFixed;
                    break;

                case 2:
                    statusOfVehicle = Vehicle.eStatusOfVehicle.HasFixed;
                    break;

                case 3:
                    statusOfVehicle = Vehicle.eStatusOfVehicle.BeenPaid;
                    break;
            }

            return statusOfVehicle;
        }

        private static void inflationWheelsToMax()
        {
            System.Console.WriteLine("Enter license plate");
            string licensePlate = System.Console.ReadLine();
            if(!isVehicleInGarage(licensePlate))
            {
                System.Console.WriteLine("There's no vehicle with the license plate {0} in the garage", licensePlate);

                return;
            }

            foreach (Wheel wheel in GarageManagerLogic.GetCarsInTheGarage()[licensePlate].Wheels)
            {
                wheel.FillToMax();
            }
        }

        private static void fillFuel()
        {
            System.Console.WriteLine("Enter license plate");
            string licensePlate = System.Console.ReadLine();
            if (!isVehicleInGarage(licensePlate))
            {
                System.Console.WriteLine("There's no vehicle with the license plate {0} in the garage", licensePlate);

                return;
            }

            StringBuilder enterNumberToStart = new StringBuilder();
            enterNumberToStart.Append("Enter fuel type\n");
            enterNumberToStart.Append("For Octan95 press 1\n");
            enterNumberToStart.Append("For Octan96 press 2\n");
            enterNumberToStart.Append("For Octan98 press 3\n");
            enterNumberToStart.Append("For Soler press 4");
            System.Console.WriteLine(enterNumberToStart);
            int userInput = inputValidation(1, 4);
            Fuel.eFuelType fuelType = new Fuel.eFuelType();
            switch (userInput)
            {
                case 1:
                    fuelType = Fuel.eFuelType.Octan95;
                    break;

                case 2:
                    fuelType = Fuel.eFuelType.Octan96;
                    break;

                case 3:
                    fuelType = Fuel.eFuelType.Octan98;
                    break;
                
                case 4:
                    fuelType = Fuel.eFuelType.Soler;
                    break;
            }

            System.Console.WriteLine("Enter how much to fill");
            float amountToFill = floatInputValidation();
            Fuel fuel = (Fuel)GarageManagerLogic.GetCarsInTheGarage()[licensePlate].SourceOfEnergy;
            if (fuel.FuelType.Equals(fuelType))
            {
                (GarageManagerLogic.GetCarsInTheGarage()[licensePlate].SourceOfEnergy as Fuel).Fill(amountToFill);
            }
        }

        private static void fillElectricity()
        {
            System.Console.WriteLine("Enter license plate");
            string licensePlate = System.Console.ReadLine();
            if (!isVehicleInGarage(licensePlate))
            {
                System.Console.WriteLine("There's no vehicle with the license plate {0} in the garage", licensePlate);

                return;
            }

            System.Console.WriteLine("Enter how much to fill");
            float amountToFill = floatInputValidation();
            GarageManagerLogic.GetCarsInTheGarage()[licensePlate].SourceOfEnergy.Fill(amountToFill);
        }
        
        private static void printDetails()
        {
            System.Console.WriteLine("Enter license plate");
            string licensePlate = System.Console.ReadLine();
            if (!isVehicleInGarage(licensePlate))
            {
                System.Console.WriteLine("There's no vehicle with the license plate {0} in the garage", licensePlate);

                return;
            }

            string vehicleDetails = GarageManagerLogic.GetCarsInTheGarage()[licensePlate].vehicleDetails();
            System.Console.WriteLine(vehicleDetails);
        }

        private static int inputValidation(int i_MinValue, int i_MaxValue)
        {
            string input = System.Console.ReadLine();
            if (int.TryParse(input, out int value))
            {
                if (value >= i_MinValue && value <= i_MaxValue)
                {

                    return value;
                }
            }

            System.Console.WriteLine("Invalid option, please enter a valid one.");
            throw new ArgumentException();
        }

        private static string nameValidation()
        {
            string input = System.Console.ReadLine();
            if (input.All(c => Char.IsLetter(c) || c == ' '))
            {

                return input;
            }

            System.Console.WriteLine("Invalid model name, please enter a valid one");
            throw new ArgumentException();
        }

        private static string phoneValidation()
        {
            string input = System.Console.ReadLine();
            if (input.All(c => Char.IsDigit(c) || c == '-' || c == '+'))
            {

                return input;
            }

            System.Console.WriteLine("Invalid phone number, please enter a valid one");
            throw new ArgumentException();
        }

        private static float floatInputValidation()
        {
            string input = System.Console.ReadLine();
            if(float.TryParse(input, out float value))
            {

                return value;
            }

            System.Console.WriteLine("Invalid option, please enter a valid one.");
            throw new ArgumentException();
        }

        private static bool isVehicleInGarage(string i_LicensePlate)
        {
            return GarageManagerLogic.GetCarsInTheGarage().ContainsKey(i_LicensePlate);
        }
    }
}

