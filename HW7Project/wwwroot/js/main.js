
//console.log("hello from main.js");


$("#theUser").ready(function () {
    console.log("page loaded main.js");
    var address = "api/users";
    $.ajax({
        type: "POST",
        dataType: "json",
        url: address,
        success: displayUser,
        error: errorOnAjax
    });
});

function errorOnAjax() {
    console.log("ERROR in ajax request");
}


function displayUser(data) {
    $("#theUser").empty();
    for (let i = 0; i < data.length; ++i) {
        $("#theUser").append($('<img class ="userImage" src="' + data[i]["profileImageUrl"] + '" width="350">'));
        $("#theUserDisplay").append($('<a class="titleText largerText" href="' + data[i]["userPageUrl"] + '">' + data[i]["name"] + "</a>"));
        $("#theUserDisplay").append($('<p class="titleText" >' + data[i]["userName"] + "</p>"));
        $("#theUserDisplay").append($('<p class="titleText" >' + data[i]["email"] + "</p>"));
        $("#theUserDisplay").append($('<p class="titleText" >' + data[i]["company"] + "</p>"));
        $("#theUserDisplay").append($('<p class="titleText" >' + data[i]["location"] + "</p>"));
    }
}


$("#repoHeader").ready(function () {
    console.log("page loaded main.js");
    var address = "api/repos";
    $.ajax({
        type: "POST",
        dataType: "json",
        url: address,
        success: displayRepo,
        error: errorOnAjax
    });
});


function displayRepo(data) {
    $(".theRepos").empty();
    for (let i = 0; i < data.length; ++i) {
        $(".theRepos").append($('<div class="card " ><div class="card-body text-center"><img width="80" src="' + data[i]["repoOwnerImg"] + '"><a class="card-title largerCardText" href="' + data[i]["repoPageUrl"] + '" id="repo_name">' + data[i]["repoName"] + '</a> <p class="card-text" >' + data[i]["updatedAt"] + '</p> <p class="card-text" id="repo_owner"> ' + data[i]["repoOwner"] + '</p> <button name="CommitButton" type="button" class="btn btn-primary CommitButton" data-user=' + data[i]["repoOwner"] + ' data-repo=' + data[i]["repoName"] + ' >Commits <img src="img/forward-arrow-icon-16.png" width="30" class="linkInRepos"  /></button></div ></div >'));
    }
}










$("body").on("click", ".CommitButton",  function () {
    console.log("page loaded main.js");
    var address = "api/commits";
    console.log(address);
    var params = { user: $(this).attr("data-user"), repo: $(this).attr("data-repo") };
    console.log(params);
    $.ajax({
        type: "GET",
        dataType: "json",
        url: address,
        data: params,
        success: displayCommits,
        error: errorOnAjax
    });
});


function displayCommits(data) {
    $("#theCommits").empty();
    $("#commitsHeader").empty();
    $("#commitsHeader").append("Commits in Repository");
    $("#theCommits").append('<thead><tr> <th scope="col">ShaHash</th><th scope="col">TimeStamp</th> <th scope="col">Committer</th> <th scope="col">Message</th></tr ></thead ><tbody>');
    for (let i = 0; i < data.length; ++i) {
        $("#theCommits").append('<tr><th scope="col"><a href="'+ data[i]["commitPageUrl"] + '">' + data[i]["shortShaHash"] + '</a></th><th scope="col">' + data[i]["timeStamp"] + '</th> <th scope="col">' + data[i]["committer"] +'</th> <th scope="col">'+ data[i]["commitMessage"] +'</th></tr>');
    }
    $("#theCommits").append($("</tbody>"));
}
 