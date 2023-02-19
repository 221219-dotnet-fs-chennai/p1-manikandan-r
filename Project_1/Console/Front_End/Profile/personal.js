// async function getpersonalbyID() {

let EmailID = localStorage.getItem("email")
EmailID = EmailID.replace(/['‘’"“”]/g, '')
// console.log(EmailID)
const signinform = document.getElementById("signupform");

signinform.addEventListener("submit", event => {
    event.preventDefault();
});


fetch("https://localhost:7234/Api/TrainerLogin/GettrainerbyID?" + new URLSearchParams
    ({
        email: EmailID
    }))
    .then(response => response.json())
    .then(element => {
        const password = document.getElementById("password")
        password.value = element.password

        const firstname = document.getElementById("fname")
        firstname.value = element.firstname

        const lastname = document.getElementById("lname")
        lastname.value = element.lastname

        const age = document.getElementById("age")
        age.value = element.age

        const gender = document.getElementById("gender")
        gender.value = element.gender

        const phonenumber = document.getElementById("phonenumber")
        phonenumber.value = element.phonenumber

        const city = document.getElementById("city")
        city.value = element.city
    });
// }

async function updatePersonal() {
    // let email = document.getElementById("emailid").value
    let pass = document.getElementById("password").value
    let fname = document.getElementById("fname").value
    let lname = document.getElementById("lname").value
    let age = document.getElementById("age").value
    let gender = document.getElementById("gender").value
    let phonenumber = document.getElementById("phonenumber").value
    let city = document.getElementById("city").value

    let val = EmailID.split('@');
    UserID = val[0];
    
    fetch("https://localhost:7234/Api/TrainerLogin/UpdateTrainer?" + new URLSearchParams
    ({
        email: EmailID
    }),{
        method: "PUT",

        body: JSON.stringify({
            userid: UserID,
            emailid: EmailID,
            password:  pass,
            firstname: fname,
            lastname: lname,
            age: age,
            gender: gender,
            phonenumber: phonenumber,
            city: city
        }),

        headers: {
            "Content-type": "application/json; charset=UTF-8",
        }
    })
    .then((response) => console.log(response))

    alert("Data Updated")
}

