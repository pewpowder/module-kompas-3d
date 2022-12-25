using System.Diagnostics;
using System;
using System.IO;
using System.Globalization;
using System.Xml.Linq;
using MugPlugin.Model;
using MugPlugin.Wrapper;
using MugPlugin.Wrapper;
using System.Linq;

var builder = new MugBuilder();
var parameters = new MugParameters();
var streamWriter = new StreamWriter($"log.txt", true);

long countDetail = 1;
builder.BuildMug(parameters);

using var myProcess = Process.GetProcessesByName("kStudy").FirstOrDefault();
do
{
    if (myProcess is { HasExited: false })
    {
        builder.BuildMug(parameters);
        countDetail++;
        myProcess.Refresh();
        Console.WriteLine();
        Console.WriteLine($"{myProcess} -");
        Console.WriteLine("-------------------------------------");
        Console.WriteLine($"  Details Count        : {countDetail}");
        Console.WriteLine($"  Physical memory usage     : {myProcess.WorkingSet64}");
        Console.WriteLine($"  User processor time       : {myProcess.UserProcessorTime}");
        streamWriter.WriteLine($"{countDetail} {myProcess.WorkingSet64} {myProcess.UserProcessorTime}");
        streamWriter.Flush();

        Console.WriteLine(myProcess.Responding ? "Status = Running" : "Status = Not Responding");
    }
}
while (countDetail != 2000);