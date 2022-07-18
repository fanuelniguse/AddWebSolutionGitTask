
function detailView( d) {
    var id = d.parentElement.parentElement.childNodes[1].textContent; 
    alert(id);
    var form = new FormData();
    form.append(id, "id")
    var jqxhr = $.ajax({
        url: "/Home/Detail",
        type: "POST",
        contentType: false,
        data: form,
        dataType: "json",
        cache: false,
        processData: false,
        async: false,
        xhr: function () {
            var xhr = new window.XMLHttpRequest();  
            xhr.upload.addEventListener("progress",
                function (evt) {
                    if (evt.lengthComputable) {
                        var progress = Math.round((evt.loaded / evt.total) * 100);

                        // Do something with the progress
                    }
                },
                false);
            return xhr;
        }
    })
        .done(function (data, textStatus, jqXhr) {
            alert("Uploading is done");

            // Clea r the input
            $("#file1").val();
        })
        .fail(function (jqXhr, textStatus, errorThrown) {
            if (errorThrown === "abort") {
                alert("Uploading was aborted");
            }
        })
        .always(function (data, textStatus, jqXhr) { });
    
    //this.parentElement.parentElement.childNodes[1].firstChild.style.backgroundColor = "red";
}


function saveExperience() {
    var table = document.getElementById("experieceList");
    var form = new FormData();
    var company = this.parentElement.parentElement.childNodes[1].firstChild.value.toString();
    var position = this.parentElement.parentElement.childNodes[2].firstChild.value.toString();
    var startDate = this.parentElement.parentElement.childNodes[3].firstChild.value.toString();
    var endDate = this.parentElement.parentElement.childNodes[4].firstChild.value.toString();
    if (endDate =="" || startDate == "" || position == ""    || company == null) {
        alert("Please Provide All Information");
        return;
    }
    //alert(this.parentElement.parentElement.childNodes[1].firstChild.value.toString());

    form.append(company, "Company");
    form.append(position, "Position");
    form.append(startDate, "StartDate");
    form.append(endDate, "EndDate");
    //form.append("EndDate", "EndDate");
    this.style.visibility = "hidden";
        
   // alert(this.parentElement.parentElement.id);
    var jqxhr = $.ajax({
        url: "/Home/addExperience",
        type: "POST",
        contentType: false,
        data: form,
        dataType: "json",
        cache: false,
        processData: false,
        async: false,
        xhr: function () {
            var xhr = new window.XMLHttpRequest();
            xhr.upload.addEventListener("progress",
                function (evt) {
                    if (evt.lengthComputable) {
                        var progress = Math.round((evt.loaded / evt.total) * 100);

                        // Do something with the progress
                    }
                },
                false);
            return xhr;
        }
    })
        .done(function (data, textStatus, jqXhr) {
            alert("Uploading is done");

            // Clea r the input
            $("#file1").val();
        })
        .fail(function (jqXhr, textStatus, errorThrown) {
            if (errorThrown === "abort") {
                alert("Uploading was aborted");
            }
        })
        .always(function (data, textStatus, jqXhr) { });

    
}

function removeExperience() {
    
    var x = this.id.toString();
    alert(this.parentElement.parentElement.id);
    this.parentElement.parentElement.remove();
   //alert(this.parentElement.parentElement.childNodes[3].firstChild.value);
   
   // this.parentElement.parentElement.childNodes[3].firstChild.style.backgroundColor = "red";

}

function addExperience() {
    

    
    var table = document.getElementById("experieceList");
    var experienceCount = table.childElementCount;
    var tr = document.createElement("tr");
    tr.id = experienceCount;
    var td = document.createElement("td");
    var td2 = document.createElement("td");
    var td3 = document.createElement("td");
    var td4 = document.createElement("td");
    var td5 = document.createElement("td");
    var td6 = document.createElement("td");
    var p = document.createElement("p");

    
    var header = document.getElementById("experienceHeader");
    console.log(header.childElementCount);
    if (header.childElementCount == 0) {
        
        var headerrow = document.createElement("tr");
        //var th1 = document.createElement("tr");
        var thd = document.createElement("td");
        var thd1 = document.createElement("td");
        var thd2 = document.createElement("td");
        var thd3 = document.createElement("td");
        var thd4 = document.createElement("td");
        thd.textContent = "No.";
        thd1.textContent = "Company";
        thd2.textContent = "Position";
        thd3.textContent = "Start Date";
        thd4.textContent = "End Date";

        headerrow.appendChild(thd); headerrow.appendChild(thd1);
        headerrow.appendChild(thd2); headerrow.appendChild(thd3);
        header.appendChild(headerrow); headerrow.appendChild(thd4);
    }
    

    var inputs = document.createElement("input");
    var input1 = document.createElement("input");
    var input2 = document.createElement("input");
    var delet = document.createElement("input");
    var save = document.createElement("input");
    save.type = "button";
    save.value = "save";    
    save.addEventListener("click", saveExperience, false);

    //delet.id = experienceCount;
    delet.type = "button";
    delet.value = "Delete";
    delet.addEventListener("click", removeExperience, false);
    delet.textContent = "Remove";
    input2.type = "date";
    var input3 = document.createElement("input");
    input3.type = "date";   
    inputs.type = "text";
    p.textContent = table.childElementCount+1;
    
    td2.appendChild(p);
    td.appendChild(inputs);
    td3.appendChild(input1);
    td4.appendChild(input2);
    td5.appendChild(input3);
    td6.appendChild(delet);
    td6.appendChild(save);
    tr.appendChild(td2);
    tr.appendChild(td); 
    tr.appendChild(td3);
    tr.appendChild(td4);   
    tr.appendChild(td5);
    tr.appendChild(td6);
   /// alert("Dsf");
    
    table.appendChild(tr);

 //    saveExperience();
}

function uploadExperience() {
    var end = { position: "Dfsa", dfhaj: "dsa" };
    var table = document.getElementById("experieceList");
    var experienceCount = table.childElementCount;
    var form = new FormData();
    for (x = 0; x < experienceCount; x++) {

        alert(document.getElementById(x).firstChild.childNodes(x).textContent);


    }
    
}
function ff() {
    
        
    var Fname = document.getElementsByName("Fname")[0].value;
    var Lname = document.getElementsByName("Lname")[0].value;
    var Email = document.getElementsByName("email")[0].value;
    //var startDate = document.getElemntByName("startDate")[0].value;
    //var endDate = document.getElementsByName("endDate")[0].value;
     
    var form = new FormData();
    
    form.append(Fname, "Fname");
    form.append(Lname, "Lname");
    form.append(Email, "Email");
    //form.append(startDate, "startDate");
    //form.append(endDate, "endDate");
    
   
        
    
    //form.append()
    alert("SDfa");
    
    alert(Fname + Lname + form.keys[0]);
    var jqxhr = $.ajax({
        url: "/Home/addUser",
        type: "POST",
        contentType: false,
        data: form,
        dataType: "json",
        cache: false,
        processData: false,
        async: false,
        xhr: function () {
            var xhr = new window.XMLHttpRequest();
            xhr.upload.addEventListener("progress",
                function (evt) {
                    if (evt.lengthComputable) {
                        var progress = Math.round((evt.loaded / evt.total) * 100);

                        // Do something with the progress
                    }
                },
                false);
            return xhr;
        }
    })  
        .done(function (data, textStatus, jqXhr) {
            alert("Uploading is done");

            // Clea r the input
            $("#file1").val();
        })
        .fail(function (jqXhr, textStatus, errorThrown) {
            if (errorThrown === "abort") {
                alert("Uploading was aborted");
            } 
        })
        .always(function (data, textStatus, jqXhr) { });

    alert("SDfa");

}