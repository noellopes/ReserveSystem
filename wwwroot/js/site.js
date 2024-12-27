


//document.getElementById("countrySelect").addEventListener("change", function () {
//    const selectedOption = this.options[this.selectedIndex];
//    const countryCode = selectedOption.getAttribute("data-code");
//    const countryFlagCode = selectedOption.getAttribute("data-flag");
//    const phoneLength = selectedOption.getAttribute("data-length");

//    const telephoneElement = document.getElementById("telefone");
//    const flagElement = document.getElementById("flag");
//    const flagWrapper = document.getElementById("flagIcon");

//    // Preserve the user's input (excluding the previous country code if any)
//    let userInput = telephoneElement.value.replace(/^\+\d+\s/, "").trim();

//    // If "Others" is selected, clear the telephone input and hide the flag
//    if (!countryCode) {
//        telephoneElement.value = ""; // Clear the phone number input
//        flagElement.src = ""; // Hide the flag
//        flagWrapper.style.display = "none"; // Hide the flag wrapper
//        telephoneElement.removeAttribute("maxlength"); // Remove maxlength attribute
//        return; // Exit early if no valid country is selected
//    }

//    // Display the new country code and user input in the telephone field
//    telephoneElement.value = `${countryCode} ${userInput}`;
//    if (phoneLength) {
//        telephoneElement.setAttribute("maxlength", parseInt(phoneLength) + countryCode.length + 1); // Account for the country code length
//    } else {
//        telephoneElement.removeAttribute("maxlength"); // Remove maxlength if phoneLength is not set
//    }

//    // Update the flag if available
//    if (countryFlagCode) {
//        const flagUrl = `https://flagcdn.com/80x60/${countryFlagCode}.png`;
//        flagElement.src = flagUrl;  // Update flag URL
//        flagWrapper.style.display = "block";  // Show the flag icon
//    } else {
//        flagElement.src = "";  // Hide the flag if not available
//        flagWrapper.style.display = "none"; // Hide the flag wrapper
//    }

   
//});


//// Trigger the change event on page load to set the default flag (optional)
//document.getElementById("countrySelect").dispatchEvent(new Event("change"));

//document.getElementById("telefone").addEventListener("input", function (event) {
//    validatePhoneLength();

//    // Prevent form submission if there's a validation error
//    const phoneError = document.getElementById("phoneError");
//    if (phoneError.style.display === "inline") {
//        event.preventDefault();
//    }

//    // Remove previous input validation handler and attach a new one
//    telephoneElement.removeEventListener("input", validatePhoneLength);
//    telephoneElement.addEventListener("input", validatePhoneLength);

//    // Validate the phone length
//    function validatePhoneLength() {
//        const countryCodeLength = countryCode ? countryCode.length + 1 : 0; // +1 for the space
//        const maxDigits = phoneLength ? parseInt(phoneLength) + countryCodeLength : Infinity;

//        if (telephoneElement.value.length > maxDigits) {
//            telephoneElement.value = telephoneElement.value.slice(0, maxDigits); // Truncate to max length
//        }

//        // Validate the length of the number excluding the country code
//        const currentLength = telephoneElement.value.replace(/^\+\d+\s/, "").length;
//        const phoneError = document.getElementById("phoneError");
//        if (phoneLength && currentLength < parseInt(phoneLength)) {
//            phoneError.style.display = "inline"; // Show error if too short
//        } else {
//            phoneError.style.display = "none"; // Hide error if valid
//        }
//        if (phoneLength) {
//            telephoneElement.setAttribute("maxlength", parseInt(phoneLength) + countryCode.length + 1);
//        } else {
//            telephoneElement.removeAttribute("maxlength");
//        }

//    }
//});
//document.getElementById("telefone").dispatchEvent(new Event("change"));


// Event listener for changes in the Identification Type
// Event listener for changes in the Identification Type
//document.getElementById("IdentificationType").addEventListener("change", function () {
//    var identificationType = this.value;
//    var identificationInputWrapper = document.getElementById("IdentificationInputWrapper");
//    var identificationInput = document.getElementById("IdentificationNumber");

//    // Show or hide the Identification Number input based on the selected identification type
//    if (identificationType) {
//        identificationInputWrapper.style.display = "block";  // Show the input field
//        identificationInput.removeAttribute("disabled");  // Enable the input field
//    } else {
//        identificationInputWrapper.style.display = "none";  // Hide the input field if no type is selected
//        identificationInput.setAttribute("disabled", "true");  // Disable the input field
//    }
//    if (identificationType === "NIF") {
//        isValid = IsNifValid(inputValue);
//    } else if (identificationType === "IDCard") {
//        isValid = IsIDCardValid(inputValue);
//    } else if (identificationType === "Passport") {
//        isValid = IsPassportValid(inputValue);
//    }

//    // Add an event listener to validate the identification number when it changes
//    identificationInput.removeEventListener("input", validateIdentificationNumber);
//    identificationInput.addEventListener("input", validateIdentificationNumber);   
//});

//// Trigger the change event on page load to set the initial state (optional)
//document.getElementById("IdentificationType").dispatchEvent(new Event("change"));


//$(document).ready(function () {
//    // When the user types in the search bar
//    $("#searchQuery").on("input", function () {
//        var query = $(this).val();

//        // Send AJAX request to the server
//        $.ajax({
//            url: "@Url.Action("Index", "Client")", // The Index action that returns the filtered data
//            type: "GET",
//            data: { searchQuery: query }, // Send the query parameter
//            success: function (data) {
//                // Replace the table body with the filtered data (updated rows)
//                $("#clientTableBody").html(data);
//            }
//        });
//    });
//});
