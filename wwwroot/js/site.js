// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
    document.getElementById("countrySelect").addEventListener("change", function() {
        const selectedOption = this.options[this.selectedIndex];
    const countryCode = selectedOption.getAttribute("data-code");
        const countryFlagCode = selectedOption.getAttribute("data-flag");
        const phoneLength = selectedOption.getAttribute("data-length");

    // Display the country code in the telephone input field
    const countryCodeElement = document.getElementById("telefone");
        countryCodeElement.value = countryCode + " ";
        countryCodeElement.setAttribute("maxlength", phoneLength);

    // Fetch the flag image from the API
        const flagUrl = `https://flagcdn.com/w320/${countryFlagCode}.png`;        

    // Display the flag image
    const flagElement = document.getElementById("flag");
    flagElement.src = flagUrl;
        document.getElementById("flagIcon").style.display = "inline"; // Show the flag icon        
    });

    // Trigger the change event on page load to set the default flag (optional)
    document.getElementById("countrySelect").dispatchEvent(new Event("change"));


