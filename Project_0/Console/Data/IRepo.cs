﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IRepo
    {
        Trainer Insertion(Trainer trainer);
        List<Trainer> GetAllTrainers();

        List<Trainer> GetAllTrainersDisconnected();
    }
}