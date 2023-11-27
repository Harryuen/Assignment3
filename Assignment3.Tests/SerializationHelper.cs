using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json;
using Assignment3.Utility;

namespace Assignment3.Tests
{
    public static class SerializationHelper
    {
        /// <summary>
        /// Serializes (encodes) users
        /// </summary>
        /// <param name="users">List of users</param>
        /// <param name="fileName"></param>
        public static void SerializeUsers(ILinkedListADT users, string fileName)
        {
            // Convert the linked list to a list of User objects
            List<User> userList = new List<User>();
            for (int i = 0; i < users.Count(); i++)
            {
                userList.Add(users.GetValue(i));
            }

            // Use System.Text.Json to serialize the list to JSON and write to file
            string json = JsonSerializer.Serialize(userList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fileName, json);
        }


        /// <summary>
        /// Deserializes (decodes) users
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>List of users</returns>
        public static ILinkedListADT DeserializeUsers(string fileName)
        {
            // Read the JSON string from the file
            string json = File.ReadAllText(fileName);

            // Use System.Text.Json to deserialize the JSON string to a list of User objects
            List<User> userList = JsonSerializer.Deserialize<List<User>>(json);

            // Create a new SinglyLinkedList and add each User from the list
            ILinkedListADT deserializedUsers = new SinglyLinkedList();
            foreach (User user in userList)
            {
                deserializedUsers.AddLast(user);
            }

            return deserializedUsers;
        }



    }
}
