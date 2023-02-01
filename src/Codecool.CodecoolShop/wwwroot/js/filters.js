const filters = document.getElementById("Filters")
filters.addEventListener("click", () => {
    $('#filtersModal').modal('show');
})
const filtersCloseButton = document.querySelectorAll(".filtersCloseButton")
filtersCloseButton.forEach(function (e) {
    e.addEventListener("click", () => {
        $('#filtersModal').modal('hide');
    })
})

const filterInputs = document.querySelectorAll(".form-check-input")

filterInputs.forEach(function (el) {
    el.setAttribute("style", "cursor:pointer")
})

const filterHeaders = document.querySelectorAll(".filterHeader")

filterHeaders.forEach(function (el) {
    el.setAttribute("style", "cursor:default")
})

const filtersTitle = document.getElementById("filtersModalTitle")
filtersTitle.setAttribute("style", "cursor:default")