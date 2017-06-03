using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HS
{
  public class CrudController<TDto>: BaseController
    where TDto: class
  {
    private ICrudService<TDto> _service;

    public CrudController(ICrudService<TDto> service)
    {
      _service = service;
    }

    [Route(""), HttpGet]
    public IEnumerable<TDto> Listar()
    {
      return _service.Listar();
    }

    [Route("{id}"), HttpGet]
    public TDto Obtener(string id)
    {
      return _service.Get(id);
    }

    [Route(""), HttpPost]
    public void Crear([FromBody] TDto objeto)
    {
      _service.Crear(objeto);
    }

    [Route("{id}"), HttpPut]
    public void Actualizar(string id, [FromBody] TDto objeto)
    {
      _service.Actualizar(id, objeto);
    }

    [Route("{id}"), HttpDelete]
    public void Anular(string id)
    {
      _service.Anular(id);
    }
  }
}
