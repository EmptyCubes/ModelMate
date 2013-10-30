using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelMate;
using ModelMate.Map;
using UnitTest.Data;
using UnitTest.Helpers;

namespace UnitTest
{
    [TestClass]
    public class ObjectTranslatorTest
    {
        private ITranslater _translater;

        [TestInitialize]
        public void Initialize()
        {
            _translater = new DefaultTranslator();
        }

        [TestMethod]
        public void ConcreteTest()
        {
            RunTest(new ConcreteDataProvider(),
                    ConcreteMappings.GetMappings());
        }

        [TestMethod]
        public void DynamicTest()
        {
            RunTest(new DynamicDataProvider(),
                    DynamicMappings.GetMappings());
        }

        private void RunTest(IDataProvider provider,
                             IEnumerable<IMap> mappings)
        {
            var source = provider.GetSource();
            var converted = _translater.Translate(source,
                                                  mappings);

            Compare(converted,
                    provider.GetExpected());
        }

        private static void Compare(object obj1,
                                    object obj2)
        {
            var t1 = obj1.GetType();
            var t2 = obj2.GetType();

            Assert.AreEqual(t1.IsValueType,
                            t2.IsValueType);
            Assert.AreEqual(t1.IsArray,
                            t2.IsArray);
            Assert.AreEqual(obj1 is string,
                            obj2 is string);

            if (t1.IsValueType || obj1 is string)
            {
                Assert.AreEqual(obj1,
                                obj2);

                return;
            }

            if (t1.IsArray)
            {
                var a1 = ((IEnumerable) obj1).Cast<object>()
                                             .ToArray();
                var a2 = ((IEnumerable) obj2).Cast<object>()
                                             .ToArray();

                Assert.AreEqual(a1.Length,
                                a2.Length);

                for (var i = 0; i < a1.Length; i++)
                    Compare(a1[i],
                            a2[i]);

                return;
            }

            var o1 = obj1.AsDictionary();
            var o2 = obj2.AsDictionary();

            foreach (var kvPair in o1)
                Assert.IsTrue(o2.ContainsKey(kvPair.Key));

            foreach (var kvPair in o2)
            {
                Assert.IsTrue(o1.ContainsKey(kvPair.Key));
                Compare(o1[kvPair.Key],
                        kvPair.Value);
            }
        }
    }
}