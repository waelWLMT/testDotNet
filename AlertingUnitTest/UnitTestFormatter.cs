using Alerting;

namespace AlertingUnitTest;

[TestClass]
public class UnitTestFormatter
{
    IList<Alert> Alerts = new List<Alert>
    {
        new Alert() { 
            Categories = "Water;Operator;Code=00010",
            Name = "WATER_TANK_OVERFLOW_00010_NORTH", 
            Area = "North", 
            Description = "Water tank overflow", 
            Priority = 9, 
            Status = Status.Active, 
            ActivationDate = DateTime.Parse("2024-04-29 14:20:35"),
            AckDate = DateTime.Parse("2024-04-29 14:23:45")},

        new Alert() { 
            Categories = "Energy;Admin;Code=00013",
            Name = "BATTERY_DOWN_00013_SOUTH", 
            Area = "South",
            Description = "Battery down",
            Priority = 1,
            Status = Status.Ack,
            ActivationDate = DateTime.Parse("2024-04-29 16:20:35"),
            AckDate = DateTime.Parse("2024-04-29 16:23:45")},
    };

    [TestMethod]
    public void TestFormatter1()
    {
        //Champ conditionné sur la présence de la catégorie "Operator"
        Formatter formatter = Formatter.GetFormatter(@"{""ConditionalFields"":[""Operator;1;0""]}");   

        string result = formatter.FormatAlert(Alerts[0]);
        Console.WriteLine(result);
        Assert.AreEqual("Water tank overflow", result);
 
        result = formatter.FormatAlert(Alerts[1]);
        Console.WriteLine(result);
        Assert.AreEqual("BATTERY_DOWN_00013_SOUTH", result);
    }

    [TestMethod]
    public void TestFormatter2()
    {
        //Deux champs conditionnés sur la présence de la catégorie "Admin"
        Formatter formatter = Formatter.GetFormatter(@"{""ConditionalFields"":[""Admin;0;1"",""Admin;3;2""]}");   

        string result = formatter.FormatAlert(Alerts[0]);
        Console.WriteLine(result);
        Assert.AreEqual("Water tank overflow;North", result);

        result = formatter.FormatAlert(Alerts[1]);
        Console.WriteLine(result);
        Assert.AreEqual("BATTERY_DOWN_00013_SOUTH;1", result);
    }

    [TestMethod]
    public void TestFormatter3()
    {
        //Champ conditionné sur l'état
        
        var formatter = Formatter.GetFormatter(@"{""ConditionalFields"":[""Active;4;2;1""]}");
        string result = formatter.FormatAlert(Alerts[0]);
        Assert.AreEqual("Active", result);        

        result = formatter.FormatAlert(Alerts[1]);
        string expected = "South";

        Assert.AreEqual(expected, result);

    }

}