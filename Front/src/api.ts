import axios from "axios";

export const $axios = axios.create({
    baseURL: "http://localhost:5179/api",
    headers: {
        'Content-Type': 'application/json',
        'Authorization':  localStorage.getItem('authToken') ? `Bearer ${localStorage.getItem('authToken')}` : null
    }
})