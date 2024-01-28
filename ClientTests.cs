using AnkaraLab_BackEnd.WebAPI.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AnkaraLab_Backend.Tests;

[TestFixture]
public class ClientTests
{
    [Test]
    public void Client_Id_ShouldHaveKeyAttribute()
    {
        var propertyInfo = typeof(Client).GetProperty("Id");
        Assert.NotNull(propertyInfo, "Property 'Id' not found in Client class.");
        var keyAttribute = propertyInfo.GetCustomAttributes(typeof(KeyAttribute), false);
        Assert.IsTrue(keyAttribute.Length > 0);
    }

    [Test]
    public void Client_Id_ShouldHaveDatabaseGeneratedAttribute()
    {
        var propertyInfo = typeof(Client).GetProperty("Id");
        Assert.NotNull(propertyInfo, "Property 'Id' not found in Client class.");
        var databaseGeneratedAttribute = propertyInfo.GetCustomAttributes(typeof(DatabaseGeneratedAttribute), false);
        Assert.IsTrue(databaseGeneratedAttribute.Length > 0);
    }

    [TestCase("Name")]
    [TestCase("Surname")]
    [TestCase("Email")]
    [TestCase("Password")]
    [Test]
    public void Client_RequiredProperties_ShouldHaveRequiredAttribute(string propertyName)
    {
        var propertyInfo = typeof(Client).GetProperty(propertyName);
        Assert.NotNull(propertyInfo, $"Property '{propertyName}' not found in Client class.");
        var requiredAttribute = propertyInfo.GetCustomAttributes(typeof(RequiredAttribute), false);
        Assert.IsTrue(requiredAttribute.Length > 0);
    }

    [Test]
    public void Client_Discount_ShouldNotHaveRequiredAttribute()
    {
        var propertyInfo = typeof(Client).GetProperty("Discount");
        Assert.NotNull(propertyInfo, "Property 'Discount' not found in Client class.");
        var requiredAttribute = propertyInfo.GetCustomAttributes(typeof(RequiredAttribute), false);
        Assert.That(requiredAttribute.Length, Is.EqualTo(0));
    }

    [Test]
    public void Client_LastLoginDate_ShouldHaveDateTimeType()
    {
        var propertyInfo = typeof(Client).GetProperty("LastLoginDate");
        Assert.That(propertyInfo.PropertyType, Is.EqualTo(typeof(DateTime)));
    }

    [Test]
    public void Client_Newsletter_ShouldHaveDefaultValueFalse()
    {
        var client = new Client();
        Assert.IsFalse(client.Newsletter);
    }

    [Test]
    public void Client_IsActive_ShouldHaveDefaultValueTrue()
    {
        var client = new Client();
        Assert.IsTrue(client.IsActive);
    }

    [Test]
    public void Client_IsAdmin_ShouldHaveDefaultValueFalse()
    {
        var client = new Client();
        Assert.IsFalse(client.IsAdmin);
    }
}
