using Entity.Data;
using Entity.Entity;
using Entity.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SajidStore.Models;



namespace SajidStore.Controllers
{
    public class StoreController : Controller
    {
        private readonly ILogger<StoreController> _logger;
        private readonly AppDbContext context;
        private readonly IUnitOfWork<ItemTypes> itemTypesService;
        private readonly IUnitOfWork<Item> itemService;
        

        public IUnitOfWork<Menus> menuService { get; }

        public StoreController(ILogger<StoreController> logger, AppDbContext context ,IUnitOfWork<ItemTypes> itemTypesService, IUnitOfWork<Item> itemService , IUnitOfWork<Menus> menuService)
        {

            
            _logger = logger;
            this.context = context;
            this.itemTypesService = itemTypesService;
            this.itemService = itemService ?? throw new ArgumentNullException(nameof(itemService));
            this.menuService = menuService ?? throw new ArgumentNullException(nameof(menuService));
        }
        
        public IActionResult Home()
        {
            return View();
        }
      
        [HttpGet]
        public IActionResult Menus()
        {
            var menus = menuService.Entity.GetAll();
            return View(menus);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var itemTypes = context.ItemTypes.ToList();
            var vendors = context.Vendors.ToList();
            var viewModel = new AddItemViewModel
            {
                ItemTypes = itemTypes.Select(it => new SelectListItem
                {
                    Value = it.TypeID.ToString(),
                    Text = it.Name
                }) ?? new List<SelectListItem>(),
              Vendors = vendors.Select(v => new SelectListItem
              {
                  Value = v.VendorID.ToString(),
                  Text = v.VName
              }) ?? new List<SelectListItem>()


            };
            return View(viewModel);
        }
        [HttpPost]
        public  IActionResult Add(AddItemViewModel model)
        {
            var typeExists = context.ItemTypes.Any(t => t.TypeID == model.SelectedItemTypeID);
            if(!typeExists)
            {
                ModelState.AddModelError("ItemTypeId", "Selected item type is invalid");
            }
            var vendorExists = context.Vendors.Any(v => v.VendorID == model.SelectedVendorID);
            if (!vendorExists)
            {
                ModelState.AddModelError("SelectedVendorID", "Selected vendor is invalid");
            }
            //var existingItem = itemService.(newItem.ID);
            if (ModelState.IsValid)
            {
                var existingItem = new Item
                {
                  Name = model.Name,
                  TypeID = model.SelectedItemTypeID,
                  ParchingPrice = model.PurchingPrice,
                  Price = model.Price,
                  Quantity =model.Quantity,
                  VendorID = model.SelectedVendorID
                };
                try
                {
                    context.Add(existingItem);
                    context.SaveChanges();
                    return RedirectToAction("Store");
                } catch (DbUpdateException ex)
                {
                    _logger.LogError(ex, "Error saving item");
                    ModelState.AddModelError("", "Unable to save changes");
                }

               
            }

            // If model state is invalid, return the view with the model to show validation errors

            model.ItemTypes = (context.ItemTypes.ToList()).Select(it => new SelectListItem
            {
                Value = it.TypeID.ToString(),
                Text = it.Name
            });
            model.Vendors = (context.Vendors.ToList()).Select(v => new SelectListItem
            {
                Value = v.VendorID.ToString(),
                Text = v.VName
            });

            return View(model);
        }


        [HttpGet]
        public IActionResult Store()
        {
            var items = itemService.Entity.GetAll();
            
            return View(items);
        }


        public IActionResult Delete(int id)
        {

            var itemToDelete = itemService.Entity.GetById(id);
            if (itemToDelete != null)
            {
                itemService.Entity.Delete(id);
                itemService.Save();
            }
            return RedirectToAction("Store");

        }
        public IActionResult About()
        {
            return View();
        }
        [HttpGet]

        public IActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var itemDetails = itemService.Entity.GetById(id);
            return View(itemDetails);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = itemService.Entity.GetById(id);
            if (item == null) return NotFound();
            var viewModel = new EditItemViewModel
            {
                Id = item.ItemID,
                Name = item.Name,
                Price = item.Price,
                PurchasingPrice = item.ParchingPrice,
                Quantity = item.Quantity,
                SelectedItemTypeID = item.TypeID,
                ItemTypes = context.ItemTypes.Select(it => new SelectListItem
                {
                    Value = it.TypeID.ToString(),
                    Text = it.Name
                }).ToList() ,
                SelectedVendorID = item.VendorID,
                Vendors = context.Vendors.Select(v => new SelectListItem
                {
                    Value = v.VendorID.ToString(),
                    Text = v.VName
                }).ToList()

            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(int id , EditItemViewModel model)
        {
            if(id != model.Id)
            {
                return BadRequest("ID mismatch");
            }
            var typeExists = context.ItemTypes.Any(t => t.TypeID == model.SelectedItemTypeID);
            if (!typeExists)
            {
                ModelState.AddModelError("SelectedItemTypeID", "Selected item type is invalid");
            }

            if (ModelState.IsValid)
            {
                var item = itemService.Entity.GetById(id);
                if (item == null)
                {
                    return NotFound();
                }
                item.Name = model.Name;
                item.Price = model.Price;
                item.ParchingPrice = model.PurchasingPrice;
                item.Quantity = model.Quantity;
                item.TypeID = model.SelectedItemTypeID;
                itemService.Entity.Update(item);
                context.SaveChanges();
                return RedirectToAction("Store");
            }
            model.ItemTypes = (context.ItemTypes.ToList()).Select(it => new SelectListItem
            {
                Value = it.TypeID.ToString(),
                Text = it.Name
            });
            return View(model);
        }

        [HttpGet("ItemTypes")]
        public IActionResult TypesOfItems()
        {
            var types = itemTypesService.Entity.GetTypesOfItems();
            return View(types);
        }

        [HttpGet("Vendors")]
        public IActionResult Vendors()
        {
            var vendors = context.Vendors.ToList();
            return View(vendors);
        }
    }
}
