

/*
Author: Elijah Morishita 
Description: Javasctipt logic for the requestor form
*/

/* 
To Add/Remove fields, make sure to adjust for following functions:
    makeJS_input_object
    repopulateFormData
    onEditButtonPress
*/

// The newhanle event is created outside of the function to prevent duplicate object creation
var newhandle = function (event) {
    event.preventDefault(); // this prevents the default HTML behaviour of it trying to submit the form by itself, which causes a page refresh
}

// Global variables
var allRequests = {}; // An object to hold all objects
let counter = 0; // used as a general counter
var currentlySelectedObjectForEditing = "";
var editButtonInUse = false;
var anchorlist = []; // used for holding the "li" elements

// This creates a Discard pop-up if you refresh the page and have partially filled out the form
window.onbeforeunload = function () {
    return "All data will be lost if you leave the page, are you sure?";
};

// function to pull Requestor Name and Date/time of request
function requestorInfo() {

    // gather requestor name from login info


    // get the UTC time (coordinated universal time) from the date object - getMonths() is zero indexed, thus +1
    const d = new Date()
    var UTCdateAndTime = (d.getMonth() + 1) + "/" + d.getDate() + "/" + d.getFullYear() + "_" + d.getUTCHours() + ":" + d.getUTCMinutes();
    return UTCdateAndTime;
}

// Process the submit button
function onSubmitPress() {

    if (confirm(submitMessage())) {
        // OK [true]
        //
        // Send first key to name the request on the SQL side
        var firstKey = Object.keys(allRequests)[0]; // get the first key (already dynamically named)
        firstKey = firstKey + "_" + Object.keys(allRequests).length; // adds the total # of parts on that request to the end of the name
        // Send data to database

        //reset the form
        var reset_button = document.getElementById("reset_button");
        reset_button.click();
    } else {
        // CANCEL [false]
        // do nothing
        return false;
    }
}


// The submit message
function submitMessage() {

    var alertMessage = '';

    for (let x in allRequests) {
        alertMessage += x + "\n";
    }
    alertMessage = requestorInfo() + " UTC Time\nAre you ready to submit the following?" + "\n\n" + alertMessage;
    return alertMessage;
}

// Form validation
function validate_request_form() {
    let inputs = document.getElementsByClassName('required');
    let isValid = true;
    for (var i = 0; i < inputs.length; i++) {
        let changedInput = inputs[i];
        // if there's no input
        if (changedInput.value.trim() === "" || changedInput.value === null) {
            isValid = false; // return false
            break;
        }
    }
    document.getElementById('primary_sbu_id').disabled = false; //enable the Primary SBU so it'll get added as an object attrib
    return isValid;
}

// Reset button
function reset_req_form() {

    if (confirm("Would you like to RESET (clear) the entire request?\nThis action will completely remove all items.")) {
        // OK [true]
        var element = document.getElementById("validate_request");
        element.classList.remove("was-validated"); // removes the .was_validated class
        document.getElementById("displayObjs").innerHTML = ""; // removes the li items from the ul
        document.getElementById("extend_id").disabled = false; // enables the extend radio button
        document.getElementById("create_id").disabled = false; // enables the create radio button
        document.getElementById("buy_id").disabled = false; // enables the buy radio button
        document.getElementById("make_id").disabled = false; // enables the make radio button
        document.getElementById('materialPlantExtend_id').disabled = true; // disables the extension field
        document.getElementById('productionSlocExtend_id').disabled = true; // disables the extension field
        document.getElementById('salesOrgExtend_id').disabled = true; // disables the extension field
        document.getElementById('submit_button_id').disabled = true; // disables the Submit button
        document.getElementById('additional_id').checked = false; // unchecks the Add sloc checkbox
        additionalCheckBox(); // removes required attributes
        createExtendFields(); // checks for radio boxes
        Object.keys(allRequests).forEach(key => delete allRequests[key]); // empties the object of objects
        return true;
    } else {
        // CANCEL [false]
        return false;
    }
}

// Send form data to JS object
function makeJS_input_object() {

    const form = document.getElementById('validate_request');
    // Create a dynamic name for the object
    const partName = form.materialNumber_id.value; // Get the PN
    const plantName = form.materialPlant_id.value; // Get the Plant #
    const extendAddPlant = form.materialPlantExtend_id.value; // Get the extended/additional Plant #

    const currentDate = today(); // Get the current date (DD_MM_YYYY) *Do NOT use DASHES ('-') as they're not an available variable name in JS

    // Naming convention for parts
    dynamicName = nameingConvention('aog_id', 'create_id', 'make_id', 'buy_id', partName, currentDate, plantName, extendAddPlant);

    // an object to store the dynamic data
    const tempObj = {
        materialNumber_id: form.materialNumber_id.value,
        materialDescription_id: form.materialDescription_id.value,
        materialPlant_id: form.materialPlant_id.value,
        materialType_id: form.materialType_id.value,
        ProgramType_id: form.ProgramType_id.value,
        productionSloc_id: form.productionSloc_id.value,
        salesOrg_id: form.salesOrg_id.value,
        scenarioType_id: form.scenarioType_id.value,
        old_pn_id: form.old_pn_id.value,
        sloc_ep_id: form.sloc_ep_id.value,
        materialPlantExtend_id: form.materialPlantExtend_id.value,
        productionSlocExtend_id: form.productionSlocExtend_id.value,
        salesOrgExtend_id: form.salesOrgExtend_id.value,
        commentBox_id: form.commentBox_id.value,
        mrp_cntrl_id: form.mrp_cntrl_id.value,
        component_id: form.component_id.value,
        raw_mat_id: form.raw_mat_id.value,
        authority_id: form.authority_id.value,
        next_higher_assm_id: form.next_higher_assm_id.value,
        prod_sup_id: form.prod_sup_id.value,
        sto_id: pickRadioButton('sto_id'),
        additional_id: pickRadioButton('additional_id'),
        leadTime_checkbox_id: pickRadioButton('leadTime_checkbox_id'),
        option_EPP_id: pickRadioButton('option_EPP_id'),
        option_MRO_id: pickRadioButton('option_MRO_id'),
        option_OE_id: pickRadioButton('option_OE_id'),
        primary_sbu_id: pickRadioButton('primary_sbu_id'),
        aog_id: pickRadioButton('aog_id'),
        civil_four_radio_id: pickRadioButton('civil_four_radio_id'),
        Military_three_radio_id: pickRadioButton('Military_three_radio_id'),
        civil_one_radio_id: pickRadioButton('civil_one_radio_id'),
        buy_id: pickRadioButton('buy_id'),
        make_id: pickRadioButton('make_id'),
        extend_id: pickRadioButton('extend_id'),
        create_id: pickRadioButton('create_id')
    }

    allRequests[dynamicName] = tempObj; // use dynamicName as a new property for the global "allRequests" object and assign it an object, making the property an object itself (with a custom name)

    console.log(allRequests); // test example

    form.addEventListener('submit', newhandle, false);
    return dynamicName;
}


// Gets todays date
function today() {
    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();

    today = mm + '_' + dd + '_' + yyyy;
    return today;
}


// Nameing convention for objects
function nameingConvention(aog_id, create_id, make_id, buy_id, partName, currentDate, plant, extendAddPlant) {
    if (pickRadioButton(aog_id)) {
        if (pickRadioButton(create_id)) {
            if (pickRadioButton(make_id)) {
                dynamicName = `AOG_MM_CREATE_MAKE_${partName}_${currentDate}_${plant}_${counter++}`;
            }
            if (pickRadioButton(buy_id)) {
                dynamicName = `AOG_MM_CREATE_BUY_${partName}_${currentDate}_${plant}_${counter++}`;
            }
        } else { // if create_id is false (an EXTEND)
            if (pickRadioButton(make_id)) {
                dynamicName = `AOG_MM_EXTEND_MAKE_${partName}_${currentDate}_${plant}_${counter++}`;
            }
            if (pickRadioButton(buy_id)) {
                dynamicName = `AOG_MM_EXTEND_BUY_${partName}_${currentDate}_${plant}_${counter++}`;
            }
        }
    } else { // if aog_id is false (not an AOG)
        if (pickRadioButton(create_id)) {
            if (pickRadioButton(make_id)) {
                dynamicName = `MM_CREATE_MAKE_${partName}_${currentDate}_${plant}_${counter++}`;
            }
            if (pickRadioButton(buy_id)) {
                dynamicName = `MM_CREATE_BUY_${partName}_${currentDate}_${plant}_${counter++}`;
            }
        } else { // if create_id is false (an EXTEND)
            if (pickRadioButton(make_id)) {
                dynamicName = `MM_EXTEND_MAKE_${partName}_${currentDate}_${plant}_${extendAddPlant}_${counter++}`;
            }
            if (pickRadioButton(buy_id)) {
                dynamicName = `MM_EXTEND_BUY_${partName}_${currentDate}_${plant}_${extendAddPlant}_${counter++}`;
            }
        }
    }
    return dynamicName;
}

// Sets defaults and disables/enables fields based on Create/Extend options
function createExtendFields() {

    if (document.getElementById('create_id').checked) {
        // On Create option select
        document.getElementById('primary_sbu_id').checked = true; // checks primary SBU
        document.getElementById('materialPlantExtend_id').disabled = true; // disables the extension field
        document.getElementById('productionSlocExtend_id').disabled = true; // disables the extension field
        document.getElementById('salesOrgExtend_id').disabled = true; // disables the extension field
        document.getElementById('BlankPlantExtendOption').selected = true; // selects the blank option
        document.getElementById('productionSlocExtend_id').value = ""; // clears the text
        document.getElementById('blankSalesOrgExtendOption').selected = true; // selects the blank option
        // make the additional checkbox and label visible
        document.getElementById('additional_id').setAttribute('style', 'visibility: visible');
        document.getElementById('additional_id_label').setAttribute('style', 'visibility: visible');
        document.getElementById('additional_id_small').setAttribute('style', 'visibility: visible');
        document.getElementById('additional_id').checked = false; // unchecks the Add sloc checkbox
        additionalCheckBox(); // removes required attributes
        document.getElementById('materialPlantExtendLabel').innerHTML = "Additional Plant"; // change label to additional reflect options
        document.getElementById('productionSlocExtendLabel_id').innerHTML = "Additional sloc"; // change label to additional reflect options
        document.getElementById('salesOrgExtendLabel_id').innerHTML = "Additional Organization"; // change label to additional reflect options
        document.getElementById('materialPlantExtendLabel').classList.remove('requiredLabel'); // removes the red asterisk
        document.getElementById('productionSlocExtendLabel_id').classList.remove('requiredLabel'); // removes the red asterisk
        document.getElementById('salesOrgExtendLabel_id').classList.remove('requiredLabel'); // removes the red asterisk
    } else if (document.getElementById('extend_id').checked) {
        // On Extend option select
        document.getElementById('primary_sbu_id').checked = false; // unchecks primary SBU
        document.getElementById('additional_id').checked = true; // checks the Add sloc checkbox
        additionalCheckBox(); // enables the extend-to fields
        // make the additional checkbox and label invisible
        document.getElementById('additional_id').setAttribute('style', 'visibility: hidden');
        document.getElementById('additional_id_label').setAttribute('style', 'visibility: hidden');
        document.getElementById('additional_id_small').setAttribute('style', 'visibility: hidden');
        document.getElementById('materialPlantExtendLabel').innerHTML = "Extend-to Plant"; // change label to extend reflect options
        document.getElementById('productionSlocExtendLabel_id').innerHTML = "Extend-to sloc"; // change label to extend reflect options
        document.getElementById('salesOrgExtendLabel_id').innerHTML = "Extend-to Sales Organization"; // change label to extend reflect options
        document.getElementById('materialPlantExtendLabel').classList.add('requiredLabel'); // adds the red asterisk
        document.getElementById('productionSlocExtendLabel_id').classList.add('requiredLabel'); // adds the red asterisk
        document.getElementById('salesOrgExtendLabel_id').classList.add('requiredLabel'); // adds the red asterisk
    }
}

function additionalCheckBox() {

    var ai = document.getElementById('additional_id');
    var mpe = document.getElementById('materialPlantExtend_id');
    var pse = document.getElementById('productionSlocExtend_id');
    var soe = document.getElementById('salesOrgExtend_id');
    var bpeo = document.getElementById('BlankPlantExtendOption');
    var bsoeo = document.getElementById('blankSalesOrgExtendOption');

    if (ai.checked) {
        // Add sloc is checked
        mpe.disabled = false; // enables "additional" field
        pse.disabled = false; // enables "additional" field
        soe.disabled = false; // enables "additional" field
        mpe.required = true; // sets the required attribute
        pse.required = true; // sets the required attribute
        soe.required = true; // sets the required attribute
        mpe.classList.add("required"); // also adds required as a class
        pse.classList.add("required"); // also adds required as a class
        soe.classList.add("required"); // also adds required as a class
    } else {
        // Add sloc is unchecked
        mpe.disabled = true; // disables "additional" field
        pse.disabled = true; // disables "additional" field
        soe.disabled = true; // disables "additional" field
        mpe.removeAttribute('required'); // removes the required attribute
        pse.removeAttribute('required'); // removes the required attribute
        soe.removeAttribute('required'); // removes the required attribute
        mpe.classList.remove("required"); // also removes required as a class
        pse.classList.remove("required"); // also removes required as a class
        soe.classList.remove("required"); // also removes required as a class
        bpeo.selected = true; // selects the blank option
        pse.value = ""; // clears the text
        bsoeo.selected = true; // selects the blank option
    }

}

// Set defaults and disables/enables fields based on Make/Buy options
function makeBuyFields() {

    if (document.getElementById('make_id').checked) {
        // On Make option select

    }
}

// OE Input constraints
function OE_button_selected() {

    if (document.getElementById('option_OE_id').checked) {
        //// changes the MaxLength of the Material Number to 20 chars
        //document.getElementById('materialNumber_id').setAttribute('maxlength', 20);
        //document.getElementById('matNumHelp_id_small').innerHTML = "20x Character Max";
        //// disables the CIVL 04 button
        //document.getElementById('civil_one_radio_id').disabled = false; // re-enables the CIVIL 01 button (in case EPP was clicked)
        //document.getElementById('civil_one_radio_id').click(); // this moves the selector off of the CIVIL 04 button
        //document.getElementById('civil_four_radio_id').disabled = true;
        //// make the primary SBU checkbox and label invisible
        //document.getElementById('primary_sbu_id').setAttribute('style', 'visibility: hidden');
        //document.getElementById('primary_sbu_id_label').setAttribute('style', 'visibility: hidden');

        //document.getElementById('option_EPP_id').value = pickRadioButton('option_EPP_id');
        //document.getElementById('option_MRO_id').value = pickRadioButton('option_MRO_id');
        //document.getElementById('option_OE_id').value = pickRadioButton('option_OE_id');

    }
}

// MRO Input constraints
function MRO_button_selected() {

    if (document.getElementById('option_MRO_id').checked) {
        //// changes the MaxLength of the Material Number to 40 chars
        //document.getElementById('materialNumber_id').setAttribute('maxlength', 40);
        //document.getElementById('matNumHelp_id_small').innerHTML = "40x Character Max";
        //// disables the CIVL 04 button
        //document.getElementById('civil_one_radio_id').disabled = false; // re-enables the CIVIL 01 button (in case EPP was clicked)
        //document.getElementById('civil_one_radio_id').click(); // this moves the selector off of the CIVIL 04 button
        //document.getElementById('civil_four_radio_id').disabled = true;
        //// make the primary SBU checkbox and label visible
        //document.getElementById('primary_sbu_id').setAttribute('style', 'visibility: visible');
        //document.getElementById('primary_sbu_id_label').setAttribute('style', 'visibility: visible');

        //document.getElementById('option_EPP_id').value = pickRadioButton('option_EPP_id');
        //document.getElementById('option_MRO_id').value = pickRadioButton('option_MRO_id');
        //document.getElementById('option_OE_id').value = pickRadioButton('option_OE_id');


    }

}

// EPP (Jasksonville) Input constraints
function EPP_button_selected() {

    if (document.getElementById('option_EPP_id').checked) {
        //// changes the MaxLength of the Material Number to 40 chars
        //document.getElementById('materialNumber_id').setAttribute('maxlength', 40);
        //document.getElementById('matNumHelp_id_small').innerHTML = "40x Character Max";
        //// enables the CIVL 04 button + disables CIVIL 01 button
        //document.getElementById('civil_four_radio_id').disabled = false;
        //document.getElementById('civil_four_radio_id').click(); // this moves the selector to the CIVIL 04 button
        //document.getElementById('civil_one_radio_id').disabled = true; // disables the CIVIL 01 button
        //// make the primary SBU checkbox and label invisible
        //document.getElementById('primary_sbu_id').setAttribute('style', 'visibility: hidden');
        //document.getElementById('primary_sbu_id_label').setAttribute('style', 'visibility: hidden');

        //document.getElementById('option_EPP_id').value = pickRadioButton('option_EPP_id');
        //document.getElementById('option_MRO_id').value = pickRadioButton('option_MRO_id');
        //document.getElementById('option_OE_id').value = pickRadioButton('option_OE_id');

    }

}

// Add more Parts button
function addMoreParts() {

    // applies .was_validated class 
    document.getElementById("validate_request").className = "was-validated";

    // validate the form
    var isValid = validate_request_form();

    if (isValid) {

        // enable the Submit button
        document.getElementById('submit_button_id').disabled = false;

        // create an object from the request form data
        dynamicName = makeJS_input_object();

        // display the parts on the DOM
        displayObjects(dynamicName);

        // disables opposite radio buttons for create/extend and make/buy radio options
        disableAlternateRadioButtons();

        if (!editButtonInUse) {
            if (confirm("ADD ANOTHER PART --\nWould you like to DUPLICATE the currently entered material onto the form?\n(OK = Yes, Cancel = No)")) {
                // [Yes]
                document.getElementById('materialNumber_id').innerHTML = ""; // remove the part number
                // everything else stays as is
            } else {
                // [No] clears the fields
                var element = document.getElementById("validate_request");
                element.classList.remove("was-validated"); // removes the .was_validated class
                document.getElementById("validate_request").reset(); // resets the form but keeps the li elements
            }
            // object is then printed to the screen via the makeJS_input_object function - after the confirmBox
        }
    }
}

// Radio button check
function pickRadioButton(radioButton) {

    if (document.getElementById(radioButton).checked) {
        return true;
    } else {
        return false;
    }
}


// Display objects (used during multiple part request)
function displayObjects(theObject) {

    var ul = document.getElementById("displayObjs"); //gets the unordered list id
    var li = document.createElement("li"); // used to add list items
    var a = document.createElement('a'); // used to add REMOVE links to list items
    var a1 = document.createElement('a'); // used to add EDIT links to list items
    var countId = theObject;

    li.className = 'item'; // not currently used
    // Add a COPY button perhaps

    a.textContent = " - REMOVE";
    a1.textContent = " - EDIT";
    a.setAttribute('href', "javascript:void(0)"); // links it to nothing (makes it "clickable") - using only # will auto-scroll to the top of the page, using "javascript:void(0)"" instead
    a1.setAttribute('href', "javascript:void(0)"); // links it to nothing (makes it "clickable") - same
    a.setAttribute('id', countId); // assigns the dynamic name as the id to the link element
    a1.setAttribute('id', countId); // assigns the dynamic name as the id to the link element
    li.setAttribute('id', countId); // assigns the dynamic name as the id to the list element
    a.setAttribute('onclick', 'removeAnElement(this.id); parentNode.remove();'); // removes the "li" element
    a1.setAttribute('onclick', 'editElement(this.id);');
    a.setAttribute('style', "text-decoration: none"); // this removes the hyperlink underline
    a1.setAttribute('style', "text-decoration: none"); // this removes the hyperlink underline

    li.appendChild(document.createTextNode(theObject)); // adds the object to the created list item
    li.appendChild(a); // adds the REMOVE button to the list item
    li.appendChild(a1); // adds the EDIT button to the list item
    ul.appendChild(li); // adds the list item to an unordered list
}

// This tests to see if an object is empty
function isEmpty(obj) {
    return Object.keys(obj).length === 0;
}

// Removes the element from the DOM and also deletes the JS Object element 
function removeAnElement(clicked_id) {

    delete allRequests[clicked_id];

    if (isEmpty(allRequests)) {
        // disable the Submit button
        document.getElementById('submit_button_id').disabled = true;
    }
}


// The onclick actions for the edit button (the one by the request)
function editElement(clicked_id) {

    // make the edit button visible
    document.getElementById('edit_button').setAttribute('style', 'visibility: visible');
    // Hide the Submit, Add Another Part, and Reset Buttons
    document.getElementById('submit_button_id').disabled = true;
    document.getElementById('add_part_button_id').disabled = true;
    document.getElementById('reset_button').disabled = true;

    currentlySelectedObjectForEditing = clicked_id;
    anchorlist = document.getElementsByTagName('li'); // place all "li" elements in an array
    for (let i = 0; i < anchorlist.length; i++) { anchorlist[i].setAttribute('style', 'visibility: hidden') } // hide the "li" elements so their actions cannot activate (edit/delete)
    document.getElementById('DisplayCurrentlySelectedItemForEditing').innerHTML = "Now Editing: <strong>" + clicked_id + "<strong>"; // displays the currently selected item for editing
    for (var key in allRequests) {// displays the remaining items for reference sake (but now without any links)
        if (key !== clicked_id) { // doesn't display the already selected item for a 2nd time
            document.getElementById('DisplayUnavailableItemsInGray').innerHTML += key + "<BR>";
        }
    }
    repopulateFormData(clicked_id);
}

// This function refills the data back onto the form for editing purposes
function repopulateFormData(anObjectName) {

    // Get a reference to the form element
    const form = document.getElementById('validate_request');
    someObj = allRequests[anObjectName];

    const objectProperty = [someObj.option_OE_id, someObj.option_MRO_id, someObj.option_EPP_id, someObj.civil_one_radio_id, someObj.Military_three_radio_id, someObj.civil_four_radio_id,
    someObj.aog_id, someObj.primary_sbu_id,
    someObj.leadTime_checkbox_id, someObj.sto_id,
    someObj.create_id, someObj.extend_id,
    someObj.make_id, someObj.buy_id,
    someObj.materialNumber_id, someObj.materialDescription_id,
    someObj.materialPlant_id, someObj.productionSloc_id, someObj.salesOrg_id,
    someObj.additional_id, someObj.materialPlantExtend_id, someObj.productionSlocExtend_id, someObj.salesOrgExtend_id,
    someObj.materialType_id, someObj.ProgramType_id, someObj.scenarioType_id,
    someObj.component_id, someObj.raw_mat_id, someObj.authority_id, someObj.next_higher_assm_id,
    someObj.old_pn_id, someObj.prod_sup_id, someObj.mrp_cntrl_id, someObj.sloc_ep_id,
    someObj.commentBox_id];

    if (!someObj.additionalCheckBox) {
        document.getElementById('materialPlantExtend_id').removeAttribute('required'); // removes the required attribute
        document.getElementById('productionSlocExtend_id').removeAttribute('required'); // removes the required attribute
        document.getElementById('salesOrgExtend_id').removeAttribute('required'); // removes the required attribute
    }

    // Loop through the object properties and create label and span elements for each property
    for (let i = 0; i < objectProperty.length; i++) {

        // Set the value of the corresponding form input field
        const inputField = form.elements[i];
        const fieldName = inputField.id;
        const fieldValue = objectProperty[i];

        // for checkboxes and radios
        if (inputField.type === 'checkbox' || inputField.type === 'radio') {
            inputField.checked = (fieldValue === true);
        }
        // For select elements
        if (inputField.tagName === 'SELECT') {
            for (let j = 0; j < inputField.options.length; j++) {
                const option = inputField.options[j];
                if (option.value === fieldValue) {
                    option.selected = true;
                }
            }
        }
        inputField.value = objectProperty[i];
    }
}

// Edit button submit
function onEditButtonPress() {

    // make the edit button invisible again
    document.getElementById('edit_button').setAttribute('style', 'visibility: hidden');
    // Make the Submit, Add Another Part, and Reset Buttons visible
    document.getElementById('submit_button_id').disabled = false;
    document.getElementById('add_part_button_id').disabled = false;
    document.getElementById('reset_button').disabled = false;
    for (let i = 0; i < anchorlist.length; i++) { anchorlist[i].setAttribute('style', 'visibility: visible') } // show the "li" elements on the DOM again
    document.getElementById('DisplayCurrentlySelectedItemForEditing').innerHTML = ""; // removes the item that was selected for editing
    document.getElementById('DisplayUnavailableItemsInGray').innerHTML = ""; // removes the item that were displayed as non-editable (for reference sake)

    // document.getElementById(currentlySelectedObjectForEditing).classList.remove("bold"); // remove bold style to the selected element

    const form = document.getElementById('validate_request');

    // Create a dynamic name for the object
    partName = form.materialNumber_id.value; // Get the PN
    plantName = form.materialPlant_id.value; // Get the Plant #
    extendAddPlant = form.materialPlantExtend_id.value; // Get the extended/additional Plant #

    currentDate = new Date().toISOString().slice(0, 10); // Get the current date in ISO format (YYYY-MM-DD)

    // Naming convention for parts
    dynamicName = nameingConvention('aog_id', 'create_id', 'make_id', 'buy_id', partName, currentDate, plantName, extendAddPlant);

    // Store the new info in a temporary object
    const tempObj = {
        materialNumber_id: form.materialNumber_id.value,
        materialDescription_id: form.materialDescription_id.value,
        materialPlant_id: form.materialPlant_id.value,
        materialType_id: form.materialType_id.value,
        ProgramType_id: form.ProgramType_id.value,
        productionSloc_id: form.productionSloc_id.value,
        salesOrg_id: form.salesOrg_id.value,
        scenarioType_id: form.scenarioType_id.value,
        old_pn_id: form.old_pn_id.value,
        sloc_ep_id: form.sloc_ep_id.value,
        materialPlantExtend_id: form.materialPlantExtend_id.value,
        productionSlocExtend_id: form.productionSlocExtend_id.value,
        salesOrgExtend_id: form.salesOrgExtend_id.value,
        commentBox_id: form.commentBox_id.value,
        mrp_cntrl_id: form.mrp_cntrl_id.value,
        component_id: form.component_id.value,
        raw_mat_id: form.raw_mat_id.value,
        authority_id: form.authority_id.value,
        next_higher_assm_id: form.next_higher_assm_id.value,
        prod_sup_id: form.prod_sup_id.value,
        sto_id: pickRadioButton('sto_id'),
        additional_id: pickRadioButton('additional_id'),
        leadTime_checkbox_id: pickRadioButton('leadTime_checkbox_id'),
        option_EPP_id: pickRadioButton('option_EPP_id'),
        option_MRO_id: pickRadioButton('option_MRO_id'),
        option_OE_id: pickRadioButton('option_OE_id'),
        primary_sbu_id: pickRadioButton('primary_sbu_id'),
        aog_id: pickRadioButton('aog_id'),
        civil_four_radio_id: pickRadioButton('civil_four_radio_id'),
        Military_three_radio_id: pickRadioButton('Military_three_radio_id'),
        civil_one_radio_id: pickRadioButton('civil_one_radio_id'),
        buy_id: pickRadioButton('buy_id'),
        make_id: pickRadioButton('make_id'),
        extend_id: pickRadioButton('extend_id'),
        create_id: pickRadioButton('create_id')
    }

    editButtonInUse = true;

    // If they're editing the Part Number
    if (allRequests[currentlySelectedObjectForEditing].partName !== partName) {
        document.getElementById(currentlySelectedObjectForEditing).remove(); // removes the li element from the DOM
        removeAnElement(currentlySelectedObjectForEditing); // delete the object entirely
        addMoreParts(); // adds PN to main object and DOM
        editButtonInUse = false; // resets the variable (in use in the addMoreParts function)
    } else {
        // Replaces the info on the form into the object that's been selected for editing
        Object.assign(allRequests[currentlySelectedObjectForEditing], tempObj);
    }
}

function editSuccessful() {

    document.getElementById('edit_success_pop_up_id').setAttribute('style', 'visibility: visible');
    document.getElementById('edit_success_pop_up_id').innerHTML = '<svg class="bi flex-shrink-0 me-2" width="24" height="24" role="img" aria-label="Success:"><use xlink:href="#check-circle-fill"/></svg><div>Item has been successfully updated!</div><button type="button" class="btn-close" aria-label="Close" onclick="hideSuccesPopUp()"></button>';
    document.getElementById('edit_success_pop_up_id').classList.add("alert", "alert-success", "d-flex", "align-items-center");
    document.getElementById('edit_success_pop_up_id').setAttribute('role', 'alert');
}

function hideSuccesPopUp() {
    document.getElementById('edit_success_pop_up_id').setAttribute('style', 'visibility: hidden');
}

// Disables opposite radio buttons for create/extend and make/buy radio options
function disableAlternateRadioButtons() {

    // disable opposite create/extend radio button, that way requests can only consist of one or the other
    if (pickRadioButton('create_id')) {
        document.getElementById("extend_id").disabled = true;
    } else {
        document.getElementById("create_id").disabled = true;
    }
    // disable opposite make/buy radio button also
    if (pickRadioButton('make_id')) {
        document.getElementById("buy_id").disabled = true;
    } else {
        document.getElementById("make_id").disabled = true;
    }
}

// Sanitize Input
function sanitize() {
    // add JS level sanizitation 
}