using System;
using System.Collections.Generic;
using System.Text;

namespace FindRectangle.Application.Common.Interfaces
{
    public interface IFindRectangleService
    {
        int GetCountRectangle(int[,] inputData);
    }
}
