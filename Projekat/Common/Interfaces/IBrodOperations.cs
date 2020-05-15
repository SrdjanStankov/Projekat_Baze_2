﻿using System;
using System.ServiceModel;
using Common.Models;

namespace Common
{
    [ServiceContract]
    public interface IBrodOperations : IAddBrodOperations, IGetBrodOperations, IEditBrodOperations, IRemoveBrodOperations
    {
        [OperationContract]
        void AddMornarToPosada(string mornarJmbg, Guid selectedPosadaId);
    }
}
