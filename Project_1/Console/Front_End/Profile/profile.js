
let EmailID = localStorage.getItem("email")
EmailID = EmailID.replace(/['‘’"“”]/g, '')

let Pass = localStorage.getItem("password")
Pass = Pass.replace(/['‘’"“”]/g, '')

function logout()
{
    localStorage.clear()
    window.location.href = "../Home/home.html";
}


function calldetele()
{
    if(window.confirm("Are you sure, Do you want to Delete your Profile?") ==  true)
    {
        deleteProfile()
    }
}

async function deleteProfile()
{
    console.log(EmailID);
    console.log(Pass);
    fetch("https://localhost:7234/Api/TrainerLogin/DeleteProfile?" + new URLSearchParams
    ({
        Email: EmailID,
        Password: Pass
    }), {
        method: "DELETE",

        headers: {
            "Content-type": "application/json; charset=UTF-8",
        }
    })

    .then((response) => {
        if (response.status == 200) {
            localStorage.clear()
            alert("Profile Deleted Successfully")
            window.location.href = "../Home/home.html";
        }
    })
    .then((response) => response.json())
    .then(json => console.log(json))
}
