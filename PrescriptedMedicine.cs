using System;
using System.Collections.Generic;
using System.Text;

namespace dashboard
{
    abstract class PrescriptedMedicine : Medicines
    {
        override
        abstract public void AddDataInList(Medicines med);
        override
        abstract public void AddDataInDataBase(Medicines med);

    }
}
