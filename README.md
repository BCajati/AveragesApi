# AveragesApi - This API has a Post method that returns a Moving Average given an integer value for the 'window' and a list of double values.
This is built using .Net 3.1 - with a Visual Studio solution file that includes the project and a test project.

The default uri when running locally: http://localhost:5000/movingaverages
Call Post with 2 variables, window - integer and values - array of double
Example Input
{
    "window": 3,
    "values": "[0,1,2,3]"
}
