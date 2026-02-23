using NUnit.Framework;

namespace Voorhees.Tests
{
    [TestFixture]
    public class JsonMapper_Read_KeyAttribute {
        class FieldsTest {
            public int intValue = 3;
            [JsonKey("custom_float")] public float floatVal = 3.5f;
        }

        [Test]
        public void ReadFieldWithKey() {
            Assert.Multiple(() => {
                string json = "{\"intValue\":5,\"custom_float\":7.9}";
                var instance = JsonMapper.FromJson<FieldsTest>(json);
                
                Assert.That(instance, Is.Not.Null);
                Assert.That(instance.intValue, Is.EqualTo(5));
                Assert.That(instance.floatVal, Is.EqualTo(7.9f));
            });
        }

        [Test]
        public void ThrowsIfReadingFieldWithOriginalName() {
            string json = "{\"intValue\":5,\"floatVal\":7.9}";
            Assert.Throws<InvalidJsonException>(() => JsonMapper.FromJson<FieldsTest>(json));
        }

        class PropertiesTest {
            public int intValue { get; set; } = 3;
            [JsonKey("custom_float")] public float floatVal { get; set; } = 3.5f;
        }

        [Test]
        public void ReadPropertyWithKey() {
            Assert.Multiple(() => {
                string json = "{\"intValue\":5,\"custom_float\":7.9}";
                var instance = JsonMapper.FromJson<PropertiesTest>(json);
                
                Assert.That(instance, Is.Not.Null);
                Assert.That(instance.intValue, Is.EqualTo(5));
                Assert.That(instance.floatVal, Is.EqualTo(7.9f));
            });
        }

        [Test]
        public void ThrowsIfReadingPropertyWithOriginalName() {
            string json = "{\"intValue\":5,\"floatVal\":7.9}";
            Assert.Throws<InvalidJsonException>(() => JsonMapper.FromJson<PropertiesTest>(json));
        }
    }
}