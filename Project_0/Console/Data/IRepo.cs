using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IRepo
    {
        /// <summary>
        /// User to insert add into the sql database
        /// </summary>
        /// <param name="trainer"></param>
        /// <returns>returs the table which is added</returns>
        Trainer Insertion(Trainer trainer);

        /// <summary>
        /// Used to get data from the database using list and disconnect the database
        /// </summary>
        /// <returns>returns list of trainer data in collection type of list</returns>
        List<Trainer> GetAllTrainersDisconnected();

        /// <summary>
        /// used to get all trainer form databse and store it for other options
        /// </summary>
        /// <param name="eMail"></param>
        /// <returns>returns object from the database</returns>
        Trainer GetAllTrainer(string eMail);

        /// <summary>
        /// check the email and password present in the table
        /// </summary>
        /// <param name="email"></param>
        /// <returns>returns true if email and password is match</returns>
        bool login(string email);

        bool forgetPassword(string email);

        /// <summary>
        /// update trainer details in the database
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columnName"></param>
        /// <param name="newValue"></param>
        /// <param name="userID"></param>
        void UpdateTrainer(string tableName, string columnName, string newValue, string userID);

        /// <summary>
        /// delete the particular trainer details from database
        /// </summary>
        /// <param name="eMail"></param>
        void DeleteTrainer(string eMail);

    }
}
