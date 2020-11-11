var itemCount = 1;
$('#cmdAdd1').click(function () { addNewItem(); });

function addNewItem() {
    var thisItem = itemCount;
    // Make last text box readonly
    $('#txt' + itemCount).attr('readonly', 'readonly');
    // Change button to Remove button
    $('#cmdAdd' + itemCount).attr('value', 'Remove');
    $('#cmdAdd' + itemCount).unbind();
    $('#cmdAdd' + itemCount).click(function () { removeItem(thisItem); });

    // Add new line with text field and button
    itemCount++;
    var newItem = '<div id="item' + itemCount + '">'
    newItem += '<input id="txt' + itemCount + '" name="txt' + itemCount + '" type="text"></input>';
    newItem += '<input id="cmdAdd' + itemCount + '" type="button" value="Add"></input>';
    newItem += "</div>";

    $('#myDiv').append(newItem);
    $('#cmdAdd' + itemCount).click(function () { addNewItem(); });
}

function removeItem(i) {
    $('#item' + i).remove();
}