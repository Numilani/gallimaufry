using System;
using Microsoft.AspNetCore.Components;

namespace gallimaufry.Pages.mandoa
{
    public partial class TimeConvert : ComponentBase
    {
           
    string mandoTime { get; set; }
    string realTime { get; set; }
    string errorMessage { get; set; } = "";

    private void toMandoTime()
    {
        errorMessage = "";
        if (realTime.Length != 4)
        {
            errorMessage = "Invalid formatting. Enter real time in 4-digit military time (i.e. 0500, 1730).";
            return;
        }
        int hrs = Convert.ToInt32(realTime.Substring(0, 2));
        int mins = Convert.ToInt32(realTime.Substring(2, 2));

        int secs = (hrs * 3600) + (mins * 60);
        Console.WriteLine(secs);
        Console.WriteLine($"{hrs} hrs, {mins} mins");
        mandoTime = secsToMando(secs);
    }

    private void toRealTime()
    {
        errorMessage = "";
        if (mandoTime.Length != 7)
        {
            errorMessage = "Invalid formatting. Enter mando'a time in 5-digit military time with colons (i.e. 2:00:00, 8:11:29).";
            return;
        }
        // int shifts = Convert.ToInt32(mandoTime.Substring(0, 1));
        // int hrs = Convert.ToInt32(mandoTime.Substring(1, 2));
        // int mins = Convert.ToInt32(mandoTime.Substring(3, 2));
        
        int shifts = Convert.ToInt32(mandoTime.Split(":")[0]);
        int hrs = Convert.ToInt32(mandoTime.Split(":")[1]);
        int mins = Convert.ToInt32(mandoTime.Split(":")[2]);
        
        int secs = ((shifts) * 10800) + (hrs * 900) + (mins * 30);
        Console.WriteLine(secs);
        Console.WriteLine($"{shifts} shift, {hrs} mando-hrs, {mins} mando-mins");
        realTime = secsToReal(secs);
    }

    private string secsToMando(int s)
    {
        int secs, mins, hours, shifts;
        (mins, secs) = (s / 30, s % 30);
        (hours, mins) = (mins / 30, mins % 30);
        (shifts, hours) = (hours / 12, hours % 12);
        Console.WriteLine($"Converted to {shifts} shifts, {hours} hours, {mins} minutes");
        return $"{shifts.ToString()}:{hours.ToString().PadLeft(2,'0')}:{mins.ToString().PadLeft(2,'0')}";
    }

    private string secsToReal(int s)
    {
        int secs, mins, hours;
        (mins, secs) = (s / 60, s % 60);
        (hours, mins) = (mins / 60, mins % 60);
        Console.WriteLine($"Converted to {hours} hours, {mins} minutes");
        return $"{hours.ToString().PadLeft(2, '0')}{mins.ToString().PadLeft(2, '0')}";
    }

    }
}