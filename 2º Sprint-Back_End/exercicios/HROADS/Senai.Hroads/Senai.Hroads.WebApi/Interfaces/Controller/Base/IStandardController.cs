using Microsoft.AspNetCore.Mvc;

namespace Senai.Hroads.WebApi.Interfaces.Controller.Base {
    interface IStandardController<TEntity> {
        IActionResult Get();
        IActionResult Get(int id);
        IActionResult Post(TEntity newEntity);
        IActionResult Put(int id, TEntity newEntity);
        IActionResult Delete(int id);
    }
}
