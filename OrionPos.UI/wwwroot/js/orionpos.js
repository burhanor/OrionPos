
function skeletonLoading() {
    $("#mainTableBody").empty();

    var skeleton = `
    `;
    for (var i = 0; i < 20; i++) {
        skeleton += `
        <tr>
                        <td>
                            <p class="placeholder-glow mb-0">
                                <span class="placeholder col-12"></span>
                            </p>
                        </td>
                        <td>
                            <p class="placeholder-glow mb-0">
                                <span class="placeholder col-12"></span>
                            </p>
                        </td>
                        <td>
                            <p class="placeholder-glow mb-0">
                                <span class="placeholder col-12"></span>
                            </p>

                        </td>
                    </tr>`;
    }

    
    $("#mainTableBody").html(skeleton);
   
}


function compareNames(a, b) {
    var nameA = a.firstName.toLowerCase();
    var nameB = b.firstName.toLowerCase();

    if (nameA < nameB) {
        return -1;
    }
    if (nameA > nameB) {
        return 1;
    }
    return 0;
}

function setTable(currentPage) {
    var dir = JSON.parse(localStorage.getItem("directories"));
    var searchKey = $("#searchInput").val().toLowerCase();
    var results = dir;
    if (searchKey != '') {
        results = dir.filter(function (elem) {
            return elem.firstName.toLowerCase().indexOf(searchKey) > -1
                || elem.lastName.toLowerCase().indexOf(searchKey) > -1
                || elem.telephoneNumber.toLowerCase().indexOf(searchKey) > -1
        });
    }
    results = results.sort(compareNames);

    var pageSize = Math.ceil(results.length / 20);
    setPaginationBar(pageSize, currentPage);
    skeletonLoading();
    var tBody = ``;
    if (results.length == 0) {

        $("#mainTableBody").empty();
         tBody = `
            <tr>
                <td class="text-center" colspan=3>Kayıt Bulunamadı</td>
            </tr>
        `;

        $("#mainTableBody").html(tBody);
       
    }
    else {
        setTimeout(
            function () {
                $("#mainTableBody").empty();

                var items = results.slice((currentPage - 1) * 20, (currentPage) * 20);

                var selected = JSON.parse(localStorage.getItem("selected"));

                tBody = items.map((e, i) => {
                    return `
                        <tr>
                            <td>
                                <div class="form-check">
                                     <input class="form-check-input" onclick="selectItem(this)" type="checkbox" value="" ${selected.includes(e.id)?"checked":""} data-id="${e.id}" >
                                </div>
                            </td>
                            <td>
                                ${e.firstName} ${e.lastName}
                            </td>
                             <td>
                                ${e.telephoneNumber} 
                            </td>
                        </tr>
                    ` });
                $("#mainTableBody").html(tBody);

            }, 500);

    }
}



function setPaginationBar(pageSize,currentPage) {
    $("#navigationBar").empty();
    var navigation = ``;
    if (pageSize <= 1) {
        navigation = `
        <nav aria-label="Page navigation example">
            <ul class="pagination justify-content-center">
                <li class="page-item disabled">
                    <a class="page-link">Önceki</a>
                </li>
                <li class="page-item"><a class="page-link active" data-page="1" href="#">1</a></li>
                <li class="page-item">
                    <a class="page-link disabled" href="#">Sonraki</a>
                </li>
            </ul>
        </nav>
        `;
    }
    else {
        var prev = ``;
        var pages = ``;
        var next = ``;
        if (currentPage == 1) {
            prev += `<li class="page-item disabled">
                        <a class="page-link">Önceki</a>
                    </li>`;
        }
        else {
            prev += `<li class="page-item ">
                        <a class="page-link cursor-pointer" onclick="goToPage(${(currentPage - 1)})" data-page="${(currentPage-1)}">Önceki</a>
                    </li>`;
        }

        if (currentPage == pageSize) {
            next += `<li class="page-item disabled">
                        <a class="page-link">Sonraki</a>
                    </li>`;
        }
        else {
            next += `<li class="page-item ">
                        <a class="page-link cursor-pointer" onclick="goToPage(${(currentPage + 1)})" data-page="${(currentPage + 1)}">Sonraki</a>
                    </li>`;
        }

        for (var i = 1; i <= pageSize; i++) {
            if (i == currentPage) {
                pages += `<li class="page-item"><a class="page-link active"  data-page="${i}" href="#">${i}</a></li>`;

            }
            else {
                pages += `<li class="page-item"><a class="page-link" onclick="goToPage(${i})"  data-page="${i}" href="#">${i}</a></li>`;
            }
        }
        navigation = `
        <nav aria-label="Page navigation example">
            <ul class="pagination justify-content-center">
                ${prev}
                ${pages}
                ${next}
            </ul>
        </nav>
        `;
    }
    $("#navigationBar").html(navigation);
}



function goToPage(pageNo) {
    setTable(pageNo);
}

function selectAll(elem) {
    if (elem.checked) {
        var dir = JSON.parse(localStorage.getItem("directories"));
        var searchKey = $("#searchInput").val().toLowerCase();
        var results = dir;
        if (searchKey != '') {
            results = dir.filter(function (elem) {
                return elem.firstName.toLowerCase().indexOf(searchKey) > -1
                    || elem.lastName.toLowerCase().indexOf(searchKey) > -1
                    || elem.telephoneNumber.toLowerCase().indexOf(searchKey) > -1
            });
        }
        var selected = results.map((e) => { return e.id });
        localStorage.setItem("selected", JSON.stringify(selected));
    }
    else {
        var selected = [];
        localStorage.setItem("selected", JSON.stringify(selected));
    }
 
    setButtonState(selected.length);
    refreshTable();
}
// Kayıt seçildiğinde veya kaldırıldığında yapılacak işlem
function selectItem(elem) {
    var selected = JSON.parse(localStorage.getItem("selected"));
    console.log(elem);
    if (elem.checked) {
        selected.push(parseInt(elem.dataset.id));
    }
    else {
      selected =  jQuery.grep(selected, function (value) {
            return value != elem.dataset.id;
        });
    }
    localStorage.setItem("selected", JSON.stringify(selected));

    setButtonState(selected.length);


}

// Güncelleme butonu ve silme butonunu aktif veya pasif hale getirmek için
function setButtonState(selectedLength) {
    // Guncelleme butonunu aktif et
    if (selectedLength == 1) {
        $("#updateButton").removeAttr("disabled");
    }
    else {
        $("#updateButton").attr("disabled", true);
    }
    if (selectedLength > 0) {
        $("#deleteButton").removeAttr("disabled");
    }
    else {
        $("#deleteButton").attr("disabled", true);

    }
}


// Tabloyu yenilemek icin
function refreshTable() {
    setTable(parseInt($(".page-link.active")[0].dataset.page));

}