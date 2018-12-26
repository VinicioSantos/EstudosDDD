using AutoMapper;
using ProjetoModeloDDD.Aplicacao.Interface;
using ProjetoModeloDDD.Domain.Interfaces.Servicos;
using ProjetoModeloDDD.Infra.Data.Repositorios;
using ProjetoModeloDDD.MVC.ViewModels;
using System.Collections;
using System.Collections.Generic;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteAppService _service;

        public ClientesController(IClienteAppService service)
        {
            _service = service;
        }

        // GET: Clientes
        public ActionResult Index()
        {
            var clienteViewModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_service.GetAll()); ;
            return View(clienteViewModel);
        }

        public ActionResult Especiais()
        {
            var clienteViewModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_service.ObterClientesEspeciais());
            return View(clienteViewModel);
        }


        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {
            var cliente = _service.GetById(id);
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);

            return View(clienteViewModel);
        }

        // GET: Clientes/Create
        //[HttpPost]
        public ActionResult Create(ClienteViewModel cliente)
        {
            
                if (ModelState.IsValid)
                {
                    var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(cliente);
                    _service.add(clienteDomain);
                    return RedirectToAction("Index");       
                }

            return View(cliente);
                
            
            //return View();
        }

        // POST: Clientes/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}


        
        // POST: Clientes/Edit/5
        
        public ActionResult Edit(int id)
        {
            var cliente = _service.GetById(id);
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);

            return View(clienteViewModel);
        }
        [HttpPost]
        public ActionResult Edit(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(cliente);
                _service.Update(clienteDomain);

                RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            var cliente = _service.GetById(id);
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);

            return View(clienteViewModel);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var cliente = _service.GetById(id);
                
                _service.Remove(cliente);

            return RedirectToAction("Index");
            
        }
    }
}
