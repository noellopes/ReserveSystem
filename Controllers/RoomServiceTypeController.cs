public class RoomServiceTypeController : Controller
{
    // GET: RoomServiceType
    public ActionResult Index()
    {
        // RoomServiceType listesini görüntüleme
        return View(/* RoomServiceType listesi */);
    }

    // GET: RoomServiceType/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: RoomServiceType/Create
    [HttpPost]
    public ActionResult Create(RoomServiceType model)
    {
        if (ModelState.IsValid)
        {
            // RoomServiceType ekleme işlemi
            return RedirectToAction("Index");
        }
        return View(model);
    }

    // Diğer eylem yöntemleri (Edit, Delete vb.) eklenebilir
}
