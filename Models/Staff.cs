﻿using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Staff
    {
        public int StaffId { get; set; }

        [Required(ErrorMessage = "StaffName is required.")]
        [StringLength(100, ErrorMessage = "StaffName must be 100 chars max.")]
        public required string StaffName { get; set; }

        [Required(ErrorMessage = "StaffEmail is required.")]
        [EmailAddress(ErrorMessage = "StaffEmail not valid.")]
        public required string StaffEmail { get; set; }

        [Required(ErrorMessage = "StaffPhone is required.")]
        [Phone(ErrorMessage = "StaffPhone not valid.")]
        public required string StaffPhone { get; set; }

        [Required(ErrorMessage = "StaffDriversLicense is required.")]
        [StringLength(50, ErrorMessage = "StaffDriversLicense must be 50 chars max.")]
        public required string StaffDriversLicense { get; set; }

        [Required(ErrorMessage = "StaffDriversLicenseExpiringDate is required.")]
        [DataType(DataType.Date, ErrorMessage = "StaffDriversLicenseExpiringDate not valid.")]
        public DateTime StaffDriversLicenseExpiringDate { get; set; }

        [Required(ErrorMessage = "StaffDateOfBirth is required.")]
        [DataType(DataType.Date, ErrorMessage = "StaffDateOfBirth not valid.")]
        public DateTime StaffDateOfBirth { get; set; }

        [Required(ErrorMessage = "StaffPassword is required.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "StaffPassword must be 8 to 100 chars max.")]
        [DataType(DataType.Password)]
        public required string StaffPassword { get; set; }

        [Required(ErrorMessage = "StartFunctionsDate is required.")]
        [DataType(DataType.Date, ErrorMessage = "StartFunctionsDate not valid.")]
        [Range(typeof(DateTime), "1/1/2000", "12/31/9999", ErrorMessage = "StartFunctionsDate must be between 01/01/2000 and 31/12/9999.")]
        public DateTime StartFunctionsDate { get; set; }

        [DataType(DataType.Date, ErrorMessage = "EndFunctionsDate not valid.")]
        [Compare("StartFunctionsDate", ErrorMessage = "EndFunctionsDate must be later than StartFunctionsDate.")]
        public DateTime EndFunctionsDate { get; set; }

        [Required(ErrorMessage = "DaysOfVacationCount is required.")]
        [Range(0, 30, ErrorMessage = "DaysOfVacationCount must be 0 to 30 max.")]
        public required int DaysOfVacationCount { get; set; }

        public bool IsActive { get; set; }

        public int JobId { get; set; }

        public Job ? job { get; set; }

        public ICollection<Schedules> ? schedules { get; set; }

        public ICollection<Cleaning_Schedule> ? cleaningSchedules { get; set; }
    }
}