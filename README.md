
Object-Oriented Programming (OOP) Example: Garage Management System
This document explains the Object-Oriented Programming (OOP) structure of a Garage Management System.
The system is designed to manage different types of vehicles in a garage, including cars, motorcycles, and trucks.

Classes
Garage Manager Logic (GarageManagerLogic)
This class acts as the core of the system. It contains a dictionary that holds information about all the vehicles in the garage. It provides methods to add new vehicles to the garage and manage their data.

Material (Material - Abstract Class)
An abstract class that holds common attributes of different materials used in vehicles, such as wheels, fuel, and electric components.

Wheel (Wheel)
A class that represents a wheel in the system. Inherits from the Material class.

Fuel (Fuel)
A class that represents the fuel used in vehicles. It contains an enum eFuelType that defines different types of fuel (Octane 95, Octane 96, Octane 98, Solar).

Electric (Electric)
A class that represents the electric components of vehicles.

Vehicle (Vehicle)
An abstract class that serves as the base for all vehicle types. It contains common parameters and methods that are shared by all vehicles.

Car (Car - Inherits from Vehicle)
A class representing a car. Inherits from the Vehicle class. It includes additional attributes such as the number of doors and car color.

Motorcycle (Motorcycle - Inherits from Vehicle)
A class representing a motorcycle. Inherits from the Vehicle class. It includes additional attributes like license type and engine volume.

Truck (Truck - Inherits from Vehicle)
A class representing a truck. Inherits from the Vehicle class. It includes additional attributes like a boolean parameter indicating the presence of a cargo unit and the trunk volume.

ValueOutOfRangeExceptions (ValueOutOfRangeExceptions)
A set of custom exceptions related to value ranges. Used for handling scenarios where values fall outside acceptable ranges.

Enums
eFuelType
An enum holding different types of fuel that are available in the garage, including Octane 95, Octane 96, Octane 98, and Solar.

eNumberOfDoors
An enum that defines the acceptable values for the number of doors in a car (2, 3, 4, 5).

eColorOfCar
An enum that defines the acceptable colors for a car (White, Green, Blue, Red).

eLicenseType
An enum that lists the available license types for motorcycles (A, A1, B1, BB).

eStatusOfVehicle
An enum that defines the possible statuses for a vehicle in the garage (Need to be fixed, Been fixed, Been paid).

Summary
The Garage Management System is a comprehensive implementation of Object-Oriented Programming principles. It uses a hierarchy of classes to represent various types of vehicles, with inheritance and abstraction to organize shared functionality. Enums are utilized to categorize and limit possible attribute values. The system provides a structured and modular approach to managing a garage's vehicle inventory and operations.