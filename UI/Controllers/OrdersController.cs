using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Models.Entities;
using Data.Contexts;
using Bussiness.Services.Abstracts;
using Bussiness.Services;

namespace UI.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;

        public OrdersController(IOrderService OrderService, ICustomerService customerService)
        {
            _orderService = OrderService;
            _customerService = customerService;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _orderService.GetAllOrders();
            return View(orders);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _orderService.GetOrder(id.GetValueOrDefault());
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        public async Task<IActionResult> Create()
        {
            var customers = await _customerService.GetAllCustomers();
            ViewData["CustomerId"] = new SelectList(customers, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CustomerId")] Order order)
        {
            if (ModelState.IsValid)
            {
                await _orderService.AddOrder(order);
                return RedirectToAction(nameof(Index));
            }
            var customers = await _customerService.GetAllCustomers();
            ViewData["CustomerId"] = new SelectList(customers, "Id", "Name", order.CustomerId);
            return View(order);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _orderService.GetOrder(id.GetValueOrDefault());
            if (order == null)
            {
                return NotFound();
            }
            var customers = await _customerService.GetAllCustomers();
            ViewData["CustomerId"] = new SelectList(customers, "Id", "Name", order.CustomerId);
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CustomerId,OrderCode")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                await _orderService.UpdateOrder(order);

                return RedirectToAction(nameof(Index));
            }
            var customers = await _customerService.GetAllCustomers();
            ViewData["CustomerId"] = new SelectList(customers, "Id", "Name", order.CustomerId);
            return View(order);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _orderService.GetOrder(id.GetValueOrDefault());
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _orderService.GetOrder(id);
            if (order != null)
            {
                await _orderService.DeleteOrder(order);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
