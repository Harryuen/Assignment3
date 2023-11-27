using Assignment3.Utility;

namespace Assignment3.Tests
{
    internal class LinkedListTests
    {
        private ILinkedListADT list;

        /// <summary>
        /// Set up method executed before each test case.
        /// Initializes a new instance of the SinglyLinkedList and assigns it to the list variable.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.list = new SinglyLinkedList();
        }

        /// <summary>
        /// Tear down method executed after each test case.
        /// Clears the list and sets it to null to free resources.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            this.list.Clear();
            this.list = null;
        }

        /// <summary>
        /// Test method to validate IsEmpty method when the list is empty.
        /// </summary>
        [Test]
        public void TestListIsEmpty()
        {
            Assert.IsTrue(this.list.IsEmpty());
        }

        /// <summary>
        /// Test method to validate IsEmpty method when the list is not empty.
        /// </summary>
        [Test]
        public void TestListIsNotEmpty()
        {
            this.list.AddLast(new User("John"));

            Assert.IsFalse(this.list.IsEmpty());
        }

        /// <summary>
        /// Test method to validate Clear method clears the list.
        /// </summary>
        [Test]
        public void TestListCleared()
        {
            this.list.AddLast(new User("John"));
            this.list.AddLast(new User("Jane"));
            this.list.Clear();
            
            Assert.IsTrue(this.list.IsEmpty());
        }

        /// <summary>
        /// Test method to validate that a single item is added to the end of the list.
        /// </summary>
        [Test]
        public void TestSingleItemAppended()
        {
            User user = new User("John");

            this.list.AddLast(user);

            Assert.AreEqual(user, this.list.GetValue(0));
            Assert.AreEqual(1, this.list.Count());
        }

        /// <summary>
        /// Test method to validate that a single item is added to the start of the list.
        /// </summary>
        [Test]
        public void TestSingleItemPrepended()
        {
            User user = new User("John");

            this.list.AddFirst(user);

            Assert.AreEqual(user, this.list.GetValue(0));
            Assert.AreEqual(1, this.list.Count());
        }

        /// <summary>
        /// Test method to validate that items are added at the specified index in the list.
        /// </summary>
        [Test]
        public void TestItemsAddedAtIndex()
        {
            User user1 = new User("John");
            User user2 = new User("Jane");

            this.list.Add(user1, 0);
            this.list.Add(user2, 1);

            Assert.AreEqual(user1, this.list.GetValue(0));
            Assert.AreEqual(user2, this.list.GetValue(1));
            Assert.AreEqual(2, this.list.Count());
        }

        /// <summary>
        /// Test method to validate that adding an item at an invalid index throws an IndexOutOfRangeException.
        /// </summary>
        [Test]
        public void TestAddThrowsIndexOutOfRangeException()
        {
            User user = new User("John");

            try
            {
                this.list.Add(user, 5);

                Assert.Fail("IndexOutOfRangeException was not thrown");
            } 
            catch (IndexOutOfRangeException)
            {
                Assert.Pass();
            }
        }

        /// <summary>
        /// Test method to validate that an item is replaced at the specified index in the list.
        /// </summary>
        [Test]
        public void TestItemReplacedAtIndex()
        {
            User user1 = new User("John");
            User user2 = new User("Jane");

            this.list.AddFirst(user1);
            this.list.Replace(user2, 0);

            Assert.AreEqual(user2, this.list.GetValue(0));
            Assert.AreEqual(1, this.list.Count());
        }

        /// <summary>
        /// Test method to validate that attempting to replace an item at an invalid index throws an IndexOutOfRangeException.
        /// </summary>
        [Test]
        public void TestItemReplacedAtInvalidIndex()
        {
            User user = new User("John");

            try
            {
                this.list.Replace(user, 5);

                Assert.Fail("IndexOutOfRangeException was not thrown");
            }
            catch (IndexOutOfRangeException)
            {
                Assert.Pass();
            }
        }

        /// <summary>
        /// Test method to validate that the first item is successfully removed from the list.
        /// </summary>
        [Test]
        public void TestRemovesFirstItem()
        {
            User user1 = new User("John");
            User user2 = new User("Jane");

            this.list.AddFirst(user1);
            this.list.AddLast(user2);
            this.list.RemoveFirst();

            Assert.AreEqual(user2, this.list.GetValue(0));
            Assert.AreEqual(1, this.list.Count());
        }

        /// <summary>
        /// Test method to validate that attempting to remove the first item from an empty list throws an IndexOutOfRangeException.
        /// </summary>
        [Test]
        public void TestCannotRemoveFirstItemFromEmptyList()
        {
            try
            {
                this.list.RemoveFirst();

                Assert.Fail("IndexOutOfRangeException was not thrown");
            } 
            catch (IndexOutOfRangeException)
            {
                Assert.Pass();
            }
        }

        /// <summary>
        /// Test method to validate that the last item is successfully removed from the list.
        /// </summary>
        [Test]
        public void TestRemovesLastItem()
        {
            User user1 = new User("John");
            User user2 = new User("Jane");

            this.list.AddFirst(user1);
            this.list.AddLast(user2);
            this.list.RemoveLast();

            Assert.AreEqual(user1, this.list.GetValue(0));
            Assert.AreEqual(1, this.list.Count());
        }

        /// <summary>
        /// Test method to validate that attempting to remove the last item from an empty list throws an IndexOutOfRangeException.
        /// </summary>
        [Test]
        public void TestCannotRemoveLastItemFromEmptyList()
        {
            try
            {
                this.list.RemoveLast();

                Assert.Fail("IndexOutOfRangeException was not thrown");
            }
            catch (IndexOutOfRangeException)
            {
                Assert.Pass();
            }
        }

        /// <summary>
        /// Test method to validate that removing an item from a valid index updates the list correctly.
        /// </summary>
        [Test]
        public void TestRemoveFromValidIndex()
        {
            User user1 = new User("John");
            User user2 = new User("Jane");

            this.list.AddFirst(user1);
            this.list.AddLast(user2);
            this.list.Remove(1);

            Assert.AreEqual(user1, this.list.GetValue(0));
            Assert.AreEqual(1, this.list.Count());
        }

        /// <summary>
        /// Test method to validate that attempting to remove an item from an invalid index throws an IndexOutOfRangeException.
        /// </summary>
        [Test]
        public void TestRemoveFromInvalidIndex()
        {
            try
            {
                this.list.Remove(5);

                Assert.Fail("IndexOutOfRangeException was not thrown");
            }
            catch (IndexOutOfRangeException)
            {
                Assert.Pass();
            }
        }

        /// <summary>
        /// Test method to validate that retrieving an item from a valid index returns the expected value.
        /// </summary>
        [Test]
        public void TestGetsItemAtValidIndex()
        {
            User user1 = new User("John");
            User user2 = new User("Jane");

            this.list.AddFirst(user1);
            this.list.AddLast(user2);

            Assert.AreEqual(user2, this.list.GetValue(1));
            Assert.AreEqual(2, this.list.Count());
        }

        /// <summary>
        /// Test method to validate that attempting to retrieve an item from an invalid index throws an IndexOutOfRangeException.
        /// </summary>
        [Test]
        public void TestGetsItemAtInvalidIndex()
        {
            try
            {
                this.list.GetValue(5);

                Assert.Fail("IndexOutOfRangeException was not thrown");
            }
            catch (IndexOutOfRangeException)
            {
                Assert.Pass();
            }
        }

        /// <summary>
        /// Test method to validate that retrieving the index of an existing item returns the expected index.
        /// </summary>
        [Test]
        public void TestGetsIndexOfExistingItem()
        {
            User user1 = new User("John");
            User user2 = new User("Jane");

            this.list.AddFirst(user1);
            this.list.AddLast(user2);

            Assert.AreEqual(1, this.list.IndexOf(user2));
            Assert.AreEqual(2, this.list.Count());
        }

        /// <summary>
        /// Test method to validate that retrieving the index of a non-existing item returns -1.
        /// </summary>
        [Test]
        public void TestGetsIndexOfNonExistingItem()
        {
            User user1 = new User("John");
            User user2 = new User("Jane");

            this.list.AddFirst(user1);

            Assert.AreEqual(-1, this.list.IndexOf(user2));
            Assert.AreEqual(1, this.list.Count());
        }

        /// <summary>
        /// Test method to validate Contains method when the list contains the specified item.
        /// </summary>
        [Test]
        public void TestListContainsItem()
        {
            User user1 = new User("John");
            
            this.list.AddFirst(user1);

            Assert.IsTrue(this.list.Contains(user1));
            Assert.AreEqual(1, this.list.Count());
        }

        /// <summary>
        /// Test method to validate Contains method when the list does not contain the specified item.
        /// </summary>
        [Test]
        public void TestListDoesntContainItem()
        {
            User user1 = new User("John");
            User user2 = new User("Jane");

            this.list.AddFirst(user1);
            
            Assert.IsFalse(this.list.Contains(user2));
            Assert.AreEqual(1, this.list.Count());
        }

        [Test]
        public void TestListSorted()
        {
            User user1 = new User("John");
            User user2 = new User("Jane");
            User user3 = new User("Doe");

            this.list.AddFirst(user2);
            this.list.AddLast(user1);
            this.list.Add(user3, 1);

            // Sort the list
            this.list.Sort();

            // Check the order after sorting
            Assert.AreEqual("Doe", this.list.GetValue(0).Name, "First element after sorting is incorrect.");
            Assert.AreEqual("Jane", this.list.GetValue(1).Name, "Second element after sorting is incorrect.");
            Assert.AreEqual("John", this.list.GetValue(2).Name, "Third element after sorting is incorrect.");
            Assert.AreEqual(3, this.list.Count(), "Count of elements after sorting is incorrect.");
        }



    }
}
