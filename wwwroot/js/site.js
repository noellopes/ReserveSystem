document.getElementById("countrySelect").addEventListener("change", function () {
    const selectedOption = this.options[this.selectedIndex];
    const countryCode = selectedOption.getAttribute("data-code");
    const countryFlagCode = selectedOption.getAttribute("data-flag");
    const phoneLength = selectedOption.getAttribute("data-length");

    const telephoneElement = document.getElementById("telefone");

    // Preserve the user's input (excluding the previous country code if any)
    let userInput = telephoneElement.value.replace(/^\+\d+\s/, "").trim();

    // If "Others" is selected, clear the telephone input and hide the flag
    if (countryCode === "others") {
        telephoneElement.value = ""; // Clear the phone number input
        document.getElementById("flag").src = ""; // Hide the flag
        document.getElementById("flagIcon").style.display = "none"; // Hide the flag icon
        telephoneElement.removeAttribute("maxlength"); // Remove maxlength attribute
        return; // Exit early if "Others" is selected
    }

    // Display the new country code and user input in the telephone field
    telephoneElement.value = `${countryCode} ${userInput}`;
    if (phoneLength) {
        telephoneElement.setAttribute("maxlength", parseInt(phoneLength) + countryCode.length + 2);
    } else {
        telephoneElement.removeAttribute("maxlength");
    }

    // Check if the countryFlagCode exists to fetch the flag image
    const flagElement = document.getElementById("flag");
    if (countryFlagCode) {
        const flagUrl = `https://flagcdn.com/w320/${countryFlagCode}.png`;

        // Display the flag image
        flagElement.src = flagUrl;
        document.getElementById("flagIcon").style.display = "inline"; // Show the flag icon
    } else {
        // Hide the flag if not available
        flagElement.src = "";
        document.getElementById("flagIcon").style.display = "none";
    }

    // Remove previous event listener to avoid stacking multiple handlers
    telephoneElement.removeEventListener("input", validatePhoneLength);

    // Attach an input validation handler
    telephoneElement.addEventListener("input", validatePhoneLength);

    // Function to validate input length
    function validatePhoneLength() {
        const countryCodeLength = countryCode ? countryCode.length + 2 : 0; // +1 for the space
        const maxDigits = phoneLength ? parseInt(phoneLength) + countryCodeLength : Infinity;

        if (telephoneElement.value.length > maxDigits) {
            telephoneElement.value = telephoneElement.value.slice(0, maxDigits);
        }

        // Check if the length is correct (excluding country code)
        const currentLength = telephoneElement.value.replace(/^\+\d+\s/, "").length;
        if (phoneLength && currentLength < parseInt(phoneLength)) {
            document.getElementById("phoneError").style.display = "inline";
        } else {
            document.getElementById("phoneError").style.display = "none";
        }
    }
});

// Trigger the change event on page load to set the default flag (optional)
document.getElementById("countrySelect").dispatchEvent(new Event("change"));
