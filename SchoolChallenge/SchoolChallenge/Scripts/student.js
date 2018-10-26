var Student = {};
Student.getAll = function () {
    $.ajax({
        url: "/Student/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                var hasScholarship = item.HasScholarship === true ? 'Yes' : 'No';
                html += '<tr>';
                html += '<td>' + item.Number + '</td>';
                html += '<td>' + item.FirstName + '</td>';
                html += '<td>' + item.LastName + '</td>';
                html += '<td>' + hasScholarship + '</td>';
                html += '<td><a href="#" onclick="return Student.getById(' + item.StudentId + ')">Edit</a> | <a href="#" onclick="Student.delete(' + item.StudentId + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert("Unable to load data");
        }
    });
};

Student.getById = function (studentID) {
    $('#Number').css('border-color', 'lightgrey');
    $('#FirstName').css('border-color', 'lightgrey');
    $('#LastName').css('border-color', 'lightgrey');
    $('#HasScholarship').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Student/getbyID/" + studentID,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#StudentId').val(result.StudentId);
            $('#Number').val(result.Number);
            $('#FirstName').val(result.FirstName);
            $('#LastName').val(result.LastName);
            $("input[name=HasScholarship][value=" + result.HasScholarship + "]").attr('checked', 'checked');
            $('#studentModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
};

Student.isValid = function () {
    var isValid = true;
    if ($('#Number').val().trim() === "") {
        $('#Number').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Number').css('border-color', 'lightgrey');
    }

    if ($('#FirstName').val().trim() === "") {
        $('#FirstName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#FirstName').css('border-color', 'lightgrey');
    }

    if ($('#LastName').val().trim() === "") {
        $('#LastName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#LastName').css('border-color', 'lightgrey');
    }

    return isValid;
};

Student.add = function () {
    if (!Student.isValid()) {
        return false;
    }

    var studentObj = {
        StudentId: $('#StudentId').val(),
        Number: $('#Number').val(),
        FirstName: $('#FirstName').val(),
        LastName: $('#LastName').val(),
        HasScholarship: $("input[name='HasScholarship']:checked").val()
    };
    $.ajax({
        url: "/Student/Add",
        data: JSON.stringify(studentObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            Student.getAll();
            $('#studentModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
};

Student.update = function () {
    if (!Student.isValid()) {
        return false;
    }

    var studentObj = {
        StudentId: $('#StudentId').val(),
        Number: $('#Number').val(),
        FirstName: $('#FirstName').val(),
        LastName: $('#LastName').val(),
        HasScholarship: $("input[name='HasScholarship']:checked").val()
    };
    $.ajax({
        url: "/Student/Update",
        data: JSON.stringify(studentObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            Student.getAll();
            $('#studentModal').modal('hide');
        },
        error: function (errormessage) {
            alert("error while update data");
        }
    });
};

Student.delete = function (studentId) {
    swal({
        title: "",
        text: 'Are you sure want to delete this record',
        icon: "warning",
        buttons: true,
        dangerMode: true
    })
        .then((willDelete) => {
            if (willDelete) {
                $.ajax({
                    url: "/Student/Delete/" + studentId,
                    type: "POST",
                    contentType: "application/json;charset=UTF-8",
                    dataType: "json",
                    success: function (result) {
                        Student.getAll();
                    },
                    error: function (errormessage) {
                        alert(errormessage.responseText);
                    }
                });
                window.location.href = href;
            } else {
                window.location.href = href;
            }
        });        
};

Student.clearForm = function () {
    $('#StudentId').val("");
    $('#Number').val("");
    $('#FirstName').val("");
    $('#LastName').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#Number').css('border-color', 'lightgrey');
    $('#FirstName').css('border-color', 'lightgrey');
    $('#LastName').css('border-color', 'lightgrey');
};

Student.clearUploadedFile = function() {
    $('#txtUploadStudents').val("");
};

Student.Import = function () { 
    $('#uploadStudents').on('click', function (e) {
        var files = $('#txtUploadStudents')[0].files[0];
        var myID = 3; //uncomment this to make sure the ajax URL works
        if (files.size > 0) {
            if (window.FormData !== undefined) {
                var data = new FormData();                
                data.append("file0",files);

                $.ajax({
                    type: "POST",
                    url: '/Student/UploadStudents',
                    contentType: false,
                    processData: false,
                    data: data,
                    success: function (result) {
                        if (result.sucess) {
                            Student.getAll();
                            $('#studentUploadModal').modal('hide');
                        }
                        else {
                            alert(result.errors);
                        }
                    },
                    error: function (xhr, status, p3, p4) {
                        var err = "Error " + " " + status + " " + p3 + " " + p4;
                        if (xhr.responseText && xhr.responseText[0] === "{")
                            err = JSON.parse(xhr.responseText).Message;
                        console.log(err);
                    }
                });
            } else {
                alert("This browser doesn't support HTML5 file uploads!");
            }
        }
    });
};

Student.getAssignStudents = function (teacherId) {
    $.ajax({
        url: "/Student/GetAssignedStudents?teacherId=" + teacherId,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                var hasScholarship = item.HasScholarship === true ? 'Yes' : 'No',
                    isAssigned = item.IsAssigend === true ? 'checked' : '';
                html += '<tr>';
                html += '<td><input type="checkbox" value = ' + item.StudentId + ' name="assignedStudents" ' + isAssigned + '></td>';
                html += '<td>' + item.Number + '</td>';
                html += '<td>' + item.FirstName + '</td>';
                html += '<td>' + item.LastName + '</td>';
                html += '<td>' + hasScholarship + '</td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert("Unable to load data");
        }
    });
};

Student.updateAssignedStudents = function () {
    var teacherId = $("#SelectTeacher").val(),
        studentId = '';
    $("[name='assignedStudents']:checked").each(function () {
        studentId = studentId + $(this).val() + ',';
    });

    var assignedStudents = {
        teacherId: teacherId,
        studentIds: studentId.substring(0, studentId.length - 1)
    };

    $.ajax({
        url: "/AssignStudents/UpdateAssignemnts",
        data: JSON.stringify(assignedStudents),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            Student.getAssignStudents($('#SelectTeacher').val());
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
};

//----------------------------------------
var Teacher = {};
Teacher.getAll = function () {
    $.ajax({
        url: "/Teacher/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.FirstName + '</td>';
                html += '<td>' + item.LastName + '</td>';
                html += '<td>' + item.NumberOfStudents + '</td>';
                html += '<td><a href="#" onclick="return Teacher.getById(' + item.TeacherId + ')">Edit</a> | <a href="#" onclick="Teacher.delete(' + item.TeacherId + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert("Unable to load data");
        }
    });
};

Teacher.getById = function (teacherId) {
    $('#FirstName').css('border-color', 'lightgrey');
    $('#LastName').css('border-color', 'lightgrey');

    $.ajax({
        url: "/Teacher/getbyID/" + teacherId,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#teacherId').val(result.TeacherId);
            $('#FirstName').val(result.FirstName);
            $('#LastName').val(result.LastName);
            $('#teacherModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
};

Teacher.isValid = function () {
    var isValid = true;

    if ($('#FirstName').val().trim() === "") {
        $('#FirstName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#FirstName').css('border-color', 'lightgrey');
    }

    if ($('#LastName').val().trim() === "") {
        $('#LastName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#LastName').css('border-color', 'lightgrey');
    }

    return isValid;
};

Teacher.add = function () {
    if (!Teacher.isValid()) {
        return false;
    }

    var teacherObj = {
        FirstName: $('#FirstName').val(),
        LastName: $('#LastName').val()
    };
    $.ajax({
        url: "/Teacher/Add",
        data: JSON.stringify(teacherObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            Teacher.getAll();
            $('#teacherModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
};

Teacher.update = function () {
    if (!Teacher.isValid()) {
        return false;
    }

    var teacherObj = {
        TeacherId: $('#teacherId').val(),
        FirstName: $('#FirstName').val(),
        LastName: $('#LastName').val(),
    };

    $.ajax({
        url: "/Teacher/Update",
        data: JSON.stringify(teacherObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            Teacher.getAll();
            $('#teacherModal').modal('hide');
        },
        error: function (errormessage) {
            alert("error while update data");
        }
    });
};

Teacher.delete = function (teacherId) {
    //var ans = confirm("Are you sure you want to delete this Record?");
    //if (ans) {
    //    $.ajax({
    //        url: "/Teacher/Delete/" + teacherId,
    //        type: "POST",
    //        contentType: "application/json;charset=UTF-8",
    //        dataType: "json",
    //        success: function (result) {
    //            Teacher.getAll();
    //        },
    //        error: function (errormessage) {
    //            alert(errormessage.responseText);
    //        }
    //    });
    //}
    swal({
        title: "",
        text: 'Are you sure want to delete this record',
        icon: "warning",
        buttons: true,
        dangerMode: true
    })
        .then((willDelete) => {
            if (willDelete) {
                $.ajax({
                    url: "/Teacher/Delete/" + teacherId,
                    type: "POST",
                    contentType: "application/json;charset=UTF-8",
                    dataType: "json",
                    success: function (result) {
                        Teacher.getAll();
                    },
                    error: function (errormessage) {
                        alert(errormessage.responseText);
                    }
                });
                window.location.href = href;
            } else {
                window.location.href = href;
            }
        });  
};

Teacher.clearForm = function () {
    $('#teacherId').val("");
    $('#FirstName').val("");
    $('#LastName').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#Number').css('border-color', 'lightgrey');
    $('#FirstName').css('border-color', 'lightgrey');
    $('#LastName').css('border-color', 'lightgrey');
};

Teacher.clearUploadedFile = function () {
    $('#txtUploadTeachers').val("");
};

Teacher.Import = function () {
    $('#uploadTeachers').on('click', function (e) {
        var files = $('#txtUploadTeachers')[0].files[0];
        var myID = 3; //uncomment this to make sure the ajax URL works
        if (files.size > 0) {
            if (window.FormData !== undefined) {
                var data = new FormData();
                data.append("file0", files);

                $.ajax({
                    type: "POST",
                    url: '/Teacher/UploadTeachers',
                    contentType: false,
                    processData: false,
                    data: data,
                    success: function (result) {
                        if (result.sucess) {
                            Teacher.getAll();
                            $('#teacherUploadModal').modal('hide');
                        }
                        else {
                            alert(result.errors);
                        }
                    },
                    error: function (xhr, status, p3, p4) {
                        var err = "Error " + " " + status + " " + p3 + " " + p4;
                        if (xhr.responseText && xhr.responseText[0] === "{")
                            err = JSON.parse(xhr.responseText).Message;
                        console.log(err);
                    }
                });
            } else {
                alert("This browser doesn't support HTML5 file uploads!");
            }
        }
    });
};