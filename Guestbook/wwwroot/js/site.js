'use strict';

function GoToPage(pageCount) {
    let requestedPage = document.getElementById("pageNumber").value;
    if (requestedPage < 0) {
        alert("There are no pages with negative numbers!");
    }
    else if (requestedPage >= pageCount) {
        alert("There are no pots on that page!");
    }
    else {
        window.location.href = "/Home/Index/" + requestedPage;
    }
}
