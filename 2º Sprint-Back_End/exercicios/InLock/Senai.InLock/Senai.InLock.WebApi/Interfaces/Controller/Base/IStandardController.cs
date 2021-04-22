using Microsoft.AspNetCore.Mvc;

namespace Senai.InLock.WebApi.Interfaces {
    interface IStandardController<TEntity> {
        IActionResult Get();
        IActionResult Get(int id);
        IActionResult Post(TEntity newTEntity);
        IActionResult Put(TEntity newTEntity);
        IActionResult Delete(int id);
    }
}
