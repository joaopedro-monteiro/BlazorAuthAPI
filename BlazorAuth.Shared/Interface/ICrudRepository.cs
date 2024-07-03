using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAuth.Shared.Interface;

public interface ICrudRepository<TModel, in TId>
{
    ICollection<TModel> FindAll();
    TModel Create(TModel model);
    void DeleteById(TId id);
}

