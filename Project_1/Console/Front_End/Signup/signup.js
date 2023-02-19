var UserID;

// function validation() {
//     var val = false;

//     var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

//     let email = document.getElementById("email").value;
    

//     if(emailRegex.match(email))
//     {
//         val = true;
//     }
//     else
//     {
//         alert("Email is invalid format")
//     }

//     if(val)
//     {
//         signUpfunction();
//     }
// }

function signUpfunction() {
    let userId = document.getElementById("userid").value; 
    let email = document.getElementById("emailid").value;
    let password = document.getElementById("password").value;
    
    if(email == null || email =="")
    {
        alert("Email ID cannot be empty");
    }
    if(password == null || password =="")
    {
        alert("Password cannot be empty");
    }

    addpersonal();
    addeducation();
    addskill();
    addcompany();

    alert("Submitted Successfully")
}


async function addpersonal() {

    const signinform = document.getElementById("signupform");

    signinform.addEventListener("submit", event => {
        event.preventDefault(); });

    //let userId = document.getElementById("userid").value; 
    let email = document.getElementById("emailid").value;
    let password = document.getElementById("password").value;
    let fname = document.getElementById("fname").value;
    let lname = document.getElementById("lname").value;
    let age = document.getElementById("age").value;
    let gender = document.getElementById("gender").value;
    let phonenumber = document.getElementById("phonenumber").value;
    let city = document.getElementById("city").value;

    let val = email.split('@');
    UserID = val[0];

    //console.log("1: " + UserID);

    await fetch("https://localhost:7234/Api/TrainerSignup/AddTrainer",
        {
            method: "POST",
            
            body: JSON.stringify({
                userid: UserID,
                emailid: email,
                password: password,
                firstname: fname,
                lastname: lname,
                age: age,
                gender: gender,
                phonenumber: phonenumber,
                city: city,
            }),

            headers: {
                'Accept': 'application/json',
                "Content-type": "application/json; charset=UTF-8",
            },
        })

        .then((response) => response.json())
        .then(json => console.log(json))
        .catch(error => console.log(error))
}

async function addeducation() {

    const signinform = document.getElementById("signupform");

    signinform.addEventListener("submit", event => {
        event.preventDefault(); });

    let uclgname = document.getElementById("uclgname").value;
    let ugstream = document.getElementById("ugstream").value;
    let ugper = document.getElementById("ugper").value;
    let ugyear = document.getElementById("ugyear").value;
    let pclgname = document.getElementById("pclgname").value;
    let pgstream = document.getElementById("pgstream").value;
    let pgper = document.getElementById("pgper").value;
    let pgyear = document.getElementById("pgyear").value;

    //console.log("2: " + UserID);

    await fetch("https://localhost:7234/Api/TrainerSignup/AddEducation",
        {
            method: "POST",

            body: JSON.stringify({
                userid: UserID,
                ug_collage: uclgname,
                ug_stream: ugstream,
                ug_percentage: ugper,
                ug_year: ugyear,
                pg_collage: pclgname,
                pg_stream: pgstream,
                pg_percentage: pgper,
                pg_year: pgyear
            }),

            headers: {
                "Content-type": "application/json; charset=UTF-8",
            },
        })

        .then((response) => response.json())
        .then(json => console.log(json))
}

async function addskill() {

    const signinform = document.getElementById("signupform");

    signinform.addEventListener("submit", event => {
        event.preventDefault(); });

    let skill1 = document.getElementById("skill1").value;
    let skill2 = document.getElementById("skill2").value;
    let skill3 = document.getElementById("skill3").value;

    //console.log("3: " + UserID);

    await fetch("https://localhost:7234/Api/TrainerSignup/AddSkill",
        {
            method: "POST",

            body: JSON.stringify({
                userid: UserID,
                skill_1: skill1,
                skill_2: skill2,
                skill_3: skill3
            }),

            headers: {
                "Content-type": "application/json; charset=UTF-8",
            },
        })

        .then((response) => response.json())
        .then(json => console.log(json))
}

async function addcompany() {

    const signinform = document.getElementById("signupform");

    signinform.addEventListener("submit", event => {
        event.preventDefault(); });

    let companyname = document.getElementById("companyname").value;
    let field = document.getElementById("field").value;
    let experience = document.getElementById("experience").value;

    //console.log("4: " + UserID);

    await fetch("https://localhost:7234/Api/TrainerSignup/AddCompany",
        {
            method: "POST",

            body: JSON.stringify({
                userid: UserID,
                companyname: companyname,
                field: field,
                experience: experience
            }),

            headers: {
                "Content-type": "application/json; charset=UTF-8",
            },
        })

        .then((response) => response.json())
        .then(json => console.log(json))
}
