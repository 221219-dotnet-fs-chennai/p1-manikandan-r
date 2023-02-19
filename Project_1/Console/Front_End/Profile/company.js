
let EmailID = localStorage.getItem("email")
EmailID = EmailID.replace(/['‘’"“”]/g, '')
// console.log(EmailID)
const signinform = document.getElementById("signupform");

signinform.addEventListener("submit", event => {
    event.preventDefault();
});


fetch("https://localhost:7234/Api/TrainerLogin/GetcompanybyID?" + new URLSearchParams
    ({
        email: EmailID
    }))
    .then(response => response.json())
    .then(element => {
        const companyname = document.getElementById("companyname")
        companyname.value = element.companyname

        const field = document.getElementById("field")
        field.value = element.field

        const experience = document.getElementById("experience")
        experience.value = element.experience
    });


async function updateCompany() {
    let compname = document.getElementById("companyname").value
    let field = document.getElementById("field").value
    let experience = document.getElementById("experience").value

    let val = EmailID.split('@');
    UserID = val[0];

    fetch("https://localhost:7234/Api/TrainerLogin/UpdateCompany?" + new URLSearchParams
        ({
            email: EmailID
        }), {
        method: "PUT",

        body: JSON.stringify({
            userid: UserID,
            companyname: compname,
            field: field,
            experience: experience
        }),
        headers: {
            "Content-type": "application/json; charset=UTF-8",
        }
    })
        .then((response) => console.log(response))

    alert("Data Updated")
}

