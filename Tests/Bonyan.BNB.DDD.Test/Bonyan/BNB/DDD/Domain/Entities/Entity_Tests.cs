using Shouldly;

namespace Bonyan.BNB.DDD.Domain.Entities;

public class EntityTests
{
    [Fact]
    public void EntityEquals_Should_Return_True_For_Same_Keys()
    {
        var idValue1 = Guid.NewGuid();
        var idValue2 = Guid.NewGuid();

        new Person(idValue1).EntityEquals(new Person(idValue1)).ShouldBeTrue();

        new Car(42).EntityEquals(new Car(42)).ShouldBeTrue();

        new Product("a").EntityEquals(new Product("a")).ShouldBeTrue();

        new Phone(idValue1, "123").EntityEquals(new Phone(idValue1, "123")).ShouldBeTrue();
    }

    [Fact]
    public void EntityEquals_Should_Return_False_For_Different_Keys()
    {
        var idValue1 = Guid.NewGuid();
        var idValue2 = Guid.NewGuid();

        new Person(idValue1).EntityEquals(new Person()).ShouldBeFalse();
        new Person(idValue1).EntityEquals(new Person(idValue2)).ShouldBeFalse();

        new Car(42).EntityEquals(new Car()).ShouldBeFalse();
        new Car(42).EntityEquals(new Car(43)).ShouldBeFalse();

        new Product("a").EntityEquals(new Product()).ShouldBeFalse();
        new Product("a").EntityEquals(new Product("b")).ShouldBeFalse();

        new Phone(idValue1, "123").EntityEquals(new Phone()).ShouldBeFalse();
        new Phone(idValue1, "123").EntityEquals(new Phone(idValue1, null)).ShouldBeFalse();
        new Phone(idValue1, "123").EntityEquals(new Phone(idValue1, "321")).ShouldBeFalse();
    }

    [Fact]
    public void EntityEquals_Should_Return_False_For_Both_Default_Keys()
    {
        new Person().EntityEquals(new Person()).ShouldBeFalse();

        new Car().EntityEquals(new Car()).ShouldBeFalse();

        new Product().EntityEquals(new Product()).ShouldBeFalse();

        new Phone().EntityEquals(new Phone()).ShouldBeFalse();
    }

  






    public class Person : BnbEntity<Guid>
    {
        public Person()
        {
        }

        public Person(Guid id)
            : base(id)
        {
        }
    }

    public class Car : BnbEntity<int>
    {

        public Car()
        {
        }

        public Car(int id)
            : base(id)
        {
        }
    }

    public class Product : BnbEntity<string>
    {
        public Product()
        {
        }

        public Product(string id)
            : base(id)
        {
        }
    }

    public class Phone : BnbEntity
    {
        public Guid PersonId { get; set; }

        public string Number { get; set; }

        public Phone()
        {

        }

        public Phone(Guid personId, string number)
        {
            PersonId = personId;
            Number = number;
        }

        public override object[] GetKeys()
        {
            return new Object[] { PersonId, Number };
        }
    }
}
