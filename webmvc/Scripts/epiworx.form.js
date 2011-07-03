$(function () {
});

function deleteRecord(action) {
    if (confirm("Are you sure you want to delete this item?")) {
        location.href = action;
    }
}