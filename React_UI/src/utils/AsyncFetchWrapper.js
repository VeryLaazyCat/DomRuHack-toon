import {urls} from '../URLs.js';

export default async function FetchResponse(url, method, body) {
    let response;
    if (body) {
        response = await fetch(urls.API_URL + url, {
            method: method,
            headers: headers(),
            body: JSON.stringify(body)
        });
    }
    else {
        response = await fetch(urls.API_URL + url, {
            method: method,
            headers: headers()
        });
    }
    let data = null;
    try {
        data = await response.json();
        if (!response.ok) {
            data = data.errors;
        }
    }
    finally {
        return data;
    }

}

function headers() {
    return {
        'Accept':'application/json',
        'Content-Type':'application/json'
    };
}
