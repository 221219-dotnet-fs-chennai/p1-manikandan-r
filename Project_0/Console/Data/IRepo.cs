using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IRepo
    {
        Trainer Insertion(Trainer trainer);
        List<Trainer> GetAllTrainersDisconnected();
        Trainer GetAllTrainer(string eMail);
        bool login(string email);

        void UpdateTrainer(string tableName, string columnName, string newValue, string userID);
    }
}
