

async function getResponse() {
    const postData = {
        firstname: document.querySelector(".firstname").value,
        lastname: document.querySelector(".lastname").value,
        password: document.querySelector(".password").value,
        email: document.querySelector(".email").value
    }
    const responsePost = await fetch('API/User', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(postData)
    });
    if (!responsePost.ok)
    //Is status() a function? In fetch, status is a property: responsePost.status
    { throw new Error(`HTTP error! status:' ${responsePost.status()}`) }
    const res = await responsePost.json();
    //console.log('post data:', res);
    //console.log(typeof(res))
    sessionStorage.setItem('CurrentUser', res.id);
}
async function getResposeLogin() {
    const LogData = {
        password: document.querySelector(".login-password").value,
        email: document.querySelector(".login-email").value
    }
    const responseLogin = await fetch('api/User/login', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(LogData)
    });
    if (!responseLogin.ok)
        alert("This user is undifine!!")
    else
    {
    const res = await responseLogin.json();
    sessionStorage.setItem('CurrentUser', res.id);
    alert(JSON.stringify(res)); } 
}
async function put() {
    const id = sessionStorage.getItem("CurrentUser");
    if (!id) {
        alert("לא נמצא משתמש");
        return;
    }
    const currentResponse = await fetch(`API/User/${id}`);

    if (!currentResponse.ok) {
        alert("המשתמש לא נמצא");
        return;
    }
    const currentUser = await currentResponse.json();
    const firstname = document.querySelector(".firstname").value;
    const lastname = document.querySelector(".lastname").value;
    const password = document.querySelector(".password").value;
    const email = document.querySelector(".email").value;
    const postData = {
        id: Number(id),
        firstname: firstname || currentUser.firstname,
        lastname: lastname || currentUser.lastname,
        password: password || currentUser.password,
        email: email || currentUser.email
    };
    //const userJson = sessionStorage.getItem('currentUser');1
    
    console.log(id);
    const updateUser = await fetch(`API/User/${id}`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(postData)
    });
    if (!updateUser.ok)
        //throw new Error(`error!! status: ${updateUser.status}`);
        alert("undefine!")
    else
        alert("updates!")
}


//In JavaScript, function names are written in camelCase: checkPasswordStrong
const CheckPasswordStrong = async () =>
{
    
    const checkpassword = document.querySelector(".password").value
    //const result = zxcvbn(password);
    //const score = result.score;
    const response = await fetch('API/User/check', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(checkpassword)
    });
    if (!response.ok) {
        throw new Error(`שגיאת שרת: ${response.status}`);
    }
    const strength = await response.json();
    const progress = document.querySelector("#file");

    progress.value = strength;
    //if (strength < 2) {
    //    alert("הסיסמה חלשה");
    //}
    //else {
    //    alert("הסיסמה חזקה");
    //}


}