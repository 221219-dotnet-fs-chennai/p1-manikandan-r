
let EmailID = localStorage.getItem("email")
EmailID = EmailID.replace(/['‘’"“”]/g, '')
// console.log(EmailID)
const signinform = document.getElementById("signupform");

signinform.addEventListener("submit", event => {
    event.preventDefault();
});


fetch("https://localhost:7234/Api/TrainerLogin/GetskillbyID?" + new URLSearchParams
    ({
        email: EmailID
    }))
    .then(response => response.json())
    .then(element => {
        const skill1 = document.getElementById("skill1")
        skill1.value = element.skill_1

        const skill2 = document.getElementById("skill2")
        skill2.value = element.skill_2

        const skill3 = document.getElementById("skill3")
        skill3.value = element.skill_3
    });

async function updateSkill() {
    let skill1 = document.getElementById("skill1").value
    let skill2 = document.getElementById("skill2").value
    let skill3 = document.getElementById("skill3").value

    let val = EmailID.split('@');
    UserID = val[0];

    fetch("https://localhost:7234/Api/TrainerLogin/UpdateSkill?" + new URLSearchParams
        ({
            email: EmailID
        }), {
        method: "PUT",

        body: JSON.stringify({
            userid: UserID,
            skill_1: skill1,
            skill_2: skill2,
            skill_3: skill3
        }),
        headers: {
            "Content-type": "application/json; charset=UTF-8",
        }
    })
        .then((response) => console.log(response))

    alert("Data Updated")
}