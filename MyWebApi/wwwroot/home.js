


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
    { throw new Error(`HTTP error! status:' ${responsePost.status()}`) }
    const res = await responsePost.json();
    //console.log('post data:', res);
    //console.log(typeof(res))
    sessionStorage.setItem('CurrentUser', JSON.stringify(res));
}
async function getResposeLogin() {
    const LogData = {
        password: document.querySelector(".password").value,
        email: document.querySelector(".email").value
    }
    const responseLogin = await fetch('API/User/login', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(responseLogin)
    });
    if (!responseLogin.ok) {
        alert("This user is undifine!!")
    else
        alert("The user exist in thesystem")
    }
    const res = await responsePost.json();
    sessionStorage.setItem('CurrentUser', JSON.stringify(res));
}
