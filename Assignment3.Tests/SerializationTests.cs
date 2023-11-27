using Assignment3;
using Assignment3.Utility;

namespace Assignment3.Tests
{
    public class SerializationTests
    {
        private ILinkedListADT users;
        private readonly string testFileName = "users.json";

        [SetUp]
        public void Setup()
        {
            // Uncomment the following line
            this.users = new SinglyLinkedList();

            users.AddLast(new User("Joe Blow"));
            users.AddLast(new User("Joe Schmoe"));
            users.AddLast(new User("Colonel Sanders"));
            users.AddLast(new User("Ronald McDonald"));
        }

        [TearDown]
        public void TearDown()
        {
            this.users.Clear();
        }

        /// <summary>
        /// Tests the object was serialized.
        /// </summary>
        [Test]
        public void TestSerialization()
        {
            SerializationHelper.SerializeUsers(users, testFileName);
            Assert.IsTrue(File.Exists(testFileName));
        }

        /// <summary>
        /// Tests the object was deserialized.
        /// </summary>
        [Test]
        public void TestDeSerialization()
        {
            SerializationHelper.SerializeUsers(users, testFileName);
            ILinkedListADT deserializedUsers = SerializationHelper.DeserializeUsers(testFileName);

            Console.WriteLine($"Original users count: {users.Count()}");
            Console.WriteLine($"Deserialized users count: {deserializedUsers.Count()}");

            Assert.IsTrue(users.Count() == deserializedUsers.Count());

            for (int i = 0; i < users.Count(); i++)
            {
                User expected = users.GetValue(i);
                User actual = deserializedUsers.GetValue(i);

                Assert.AreEqual(expected.Name, actual.Name);
            }
        }


    }
}