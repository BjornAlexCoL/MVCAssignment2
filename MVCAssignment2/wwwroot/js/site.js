
$("#btnFetchPeople").click(() => {
    $.ajax({
        type: "GET", url: "/Ajax/FetchPeople", success: (res) => {
            if (res == null) {
                DisplayHtml("List is empty");
                return;
            }

            var htmlStr = "";
            for (index = 0; index < res.length; index++) {
                htmlStr += "<div id=\"divcol\">" + res[index].id + ". ";
                htmlStr += res[index].name + ", ";
                htmlStr += res[index].city + "</div>";
            }
            DisplayHtml(htmlStr);
        },
        error: (err) => {
            alert(err);
        }
    });
});

$("#btnDisplay").click(() => {
    var personId = document.getElementById("id").value;
    var _this = $(this);
    $.ajax({
        type: "POST", url: "/Ajax/Display?id=" + personId, success: (res) => {
            if (res == null) {
                DisplayHtml("Record Does Not Exist");
                return;
            }

            var htmlStr = "";
            htmlStr += "<div id=\"divcol\">" + res.name + "</div>";
            htmlStr += "<div id=\"divcol\">" + res.phone + "</div>";
            htmlStr += "<div id=\"divcol\">" + res.city + "</div>";
            DisplayHtml(htmlStr);
        },
        error: (err) => {
            alert(err);
        }
    });
});


$("#btnDelete").click(() => {
    var personId = document.getElementById("id").value;
    $.ajax({
        type: "POST", url: "/Ajax/Display?id=" + personId, success: (res) => {
            if (res == null) {
                DisplayHtml("Record Does Not Exist");
                return;
            }
            if (confirm('Are you sure you want to delete record no: '+ res.id+'. ' +res.name+', '+res.city+' '+res.phone) && res!=null) {
                $.ajax({
                    type: "POST", url: "/Ajax/Delete?id=" + personId, success: () => {
                        DisplayHtml("Record Deleted!");
                    },
                    error: (err) => {
                        alert(err);
                    }
                });
            }
        },
        error: (err) => {
            alert(err);
        }
    });
});


function DisplayHtml(htmlStr) {
    document.getElementById("container").innerHTML = htmlStr;
    document.body.appendChild;
}
