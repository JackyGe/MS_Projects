'use strict'

var clientContext;
var employeeList;
var completedItems;

function purgeCompletedItems() {
    clientContext = SP.ClientContext.get_current();
    employeeList = clientContext.get_web().get_lists().getByTitle('New Employees In Seattle');
    var camlQuery = new SP.CamlQuery();
    camlQuery.set_viewXml(
          '<View><Query><Where><Eq>' +
            '<FieldRef Name=\'OrientationStage\'/><Value Type=\'Text\'>Completed</Value>' +
          '</Eq></Where></Query></View>');
    completedItems = employeeList.getItems(camlQuery);
    clientContext.load(completedItems);
    clientContext.executeQueryAsync(deleteCompletedItems, onGetCompletedItemsFail);
    return false;
}

function deleteCompletedItems() {
    var itemArray = new Array();
    var listItemEnumerator = completedItems.getEnumerator();

    while (listItemEnumerator.moveNext()) {
        var item = listItemEnumerator.get_current();
        itemArray.push(item);
    }

    var i;
    for (i = 0; i < itemArray.length; i++) {
        employeeList.getItemById(itemArray[i].get_id()).deleteObject();
    }

    clientContext.executeQueryAsync(onDeleteCompletedItemsSuccess, onDeleteCompletedItemsFail);
}

function onDeleteCompletedItemsSuccess() {
    alert('Completed orientations have been deleted.');
    location.reload(true);
}

// Failure callbacks
function onGetCompletedItemsFail(sender, args) {
    alert('Unable to get completed items. Error:' + args.get_message() + '\n' + args.get_stackTrace());
}

function onDeleteCompletedItemsFail(sender, args) {
    alert('Unable to delete completed items. Error:' + args.get_message() + '\n' + args.get_stackTrace());
}

