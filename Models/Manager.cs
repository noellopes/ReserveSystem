namespace ReserveSystem.Models
{
    public class Manager
    {
    public int ManagerId { get; set; } // PK
    public string Email { get; set; }
    public string Password { get; set; }

    // Methods (represented as actions in the controller later)
    public void Login() { /* login logic */ }
    public void CreateEmployee() { /* create employee logic */ }
    public void AllocateEmployee() { /* allocate employee logic */ }
    public void NotifyEmployee() { /* notification logic */ }
    public void RequestDayOff() { /* day off request logic */ }
    public void AddEmployeeToSchedule() { /* scheduling logic */ }
    public void Logout() { /* logout logic */ }
    }
}