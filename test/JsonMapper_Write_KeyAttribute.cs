using NUnit.Framework;

namespace Voorhees.Tests
{
    [TestFixture]
    public class JsonMapper_Write_KeyAttribute {
        class FieldsTest {
            public int intValue = 3;
            [JsonKey("custom_float")] public float floatVal = 3.5f;
        }

        [Test]
        public void KeyAttributeField() {
            var instance = new FieldsTest();
            Assert.That(JsonMapper.ToJson(instance), Is.EqualTo("{\"intValue\":3,\"custom_float\":3.5}"));
        }

        class PropertiesTest {
            public int intValue { get; set; } = 3;
            [JsonKey("custom_float")] public float floatVal { get; set; } = 3.5f;
        }

        [Test]
        public void KeyAttributeProperty() {
            var instance = new PropertiesTest();
            Assert.That(JsonMapper.ToJson(instance), Is.EqualTo("{\"intValue\":3,\"custom_float\":3.5}"));
        }
    }
}