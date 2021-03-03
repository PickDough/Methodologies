using System;
using System.Collections.Generic;
using Entities;

namespace Data.Repositories.Abstract
{
    public interface IOrderRepository: IRepository<OrderEntity, Guid>
    {

    }
}