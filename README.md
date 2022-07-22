# Employees Pairs

This repository contains a program developed in C#. The objective of the program is to get pairs of employee's name with the same time lapse at the company in any given day.

# Detailed problem description.

The company ACME offers their employees the flexibility to work the hours they want. But due to some external circumstances they need to know what employees have been at the office within the same time frame

The ojective is to output a table containing pairs of employees and how often they have coincided in the office.

Input: the name of an employee and the schedule they worked, indicating the time and hours. This should be a .txt file with at least five sets of data. 

Example 1:

INPUT
RENE=MO10:00-12:00,TU10:00-12:00,TH01:00-03:00,SA14:00-18:00,SU20:00- 21:00
ASTRID=MO10:00-12:00,TH12:00-14:00,SU20:00-21:00
ANDRES=MO10:00-12:00,TH12:00-14:00,SU20:00-21:00


OUTPUT:
ASTRID-RENE: 2
ASTRID-ANDRES: 3
RENE-ANDRES: 2

Example 2:

INPUT:
RENE=MO10:15-12:00,TU10:00-12:00,TH13:00-13:15,SA14:00-18:00,SU20:00-21:00
ASTRID=MO10:00-12:00,TH12:00-14:00,SU20:00-21:00

OUTPUT:
RENE-ASTRID: 3

# Proposed Solution

Having a text file which contains a set of formatted lines, it is reasonable to think that each line must have a unique format, based on the input lines shown in the examples in the previous section, a logical conclusion would be that the data must be formatted as follows:

NAME=WDHH:MM-HHMM,WDHH:MM-HHMM, ...WDHH:MM-HHMM

NAME.- Is the employee's name, only letters, no numbers.
WD.- Weekday, values accepted are, SU (sunday), MO (monday), TU (tuesday), WE (wednesday), TH (thursday), FR (friday), SA (saturday).
HH:MM.- Time format it is the same format for the time when the employee enter and the time when the employee leaves. It is a 24H time format. Valid values acceptes    are 00 to 23 to format hours and 00 to 59 to format minutes.

The name (NAME) and the day and times for each employee are separated by the character '=', each day and time sets are separated by ',' and each set of times are separated by '-'. Each line in the file must not have spaces within.

To validate this format, a RegEx expression will be used, so the validation can be done in just one instruction.

After the line of the file is read, the string have to be splitted to have at the end, the Name, Weekday, Check in time, Check out time, to achieve this, the proccess in charge of the reading the file, will split each line and stored in a class object, each individual object will be added to a List, and this List will be the outcome of the readin file proccess.

The use case of the problem is to find how many times, pairs of employees have been at the office at the same time and day. This will be achieved using the object list as a data struncture and using LINQ Instructions to select employees that have been the same date and around the same time at the office based on their check in and check out times. The logic of this algorithm is explained in the code.

# Solution structure.

The solution EmployeeOfficeTime.sln, contains the folowing solution folders.

Enterprise Business Rules: Contains the models for data structures and the interfaces to be implemented in the repository layer. This classes are contained in the  OfficeTime.Entities project.

Interface Adapter: In the subfolder Gateways, the proyect OfficeTime.Repositories contains the class definition for the DataContext and for the Repository. The Data Context isolate the data source from the other layers this layer is only accessed through the Repository class which implements the interface defined in the OfficeTime.Entities, interface class.

Apliccation Business Rules: The prject OfficeTime.Services contains the interface class IEmployeePair which is implemented by the EmployeePairInteractor class. The class EmployeePairInteractor, implement the use case and return the array that contains the expected result.

Frameworks and Drivers: The project OfficeTime.Con contains the console application which use the EmployeePairIntercator class throug dependency injection to get the expected result from a text file. The user have to enter the file path and name and then the console application will return the expected result.

# Instruction for exceution.

Open the EmployeeOfficeTime.sln using Visual Studio 2019 o 2022, the proyect uses the Net Core 3.1 framework and it is implemented using C#. Once the solution in opened, the layers described in the previous section will appear, then just execute the solution and the console app will run. The user will be asked to type the path and file name, and the app will return either the expected result or a list of errors.
