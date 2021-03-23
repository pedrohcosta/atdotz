import axios from 'axios';

import GLOBALS from '../util/Globals';

const Api = axios.create({
    baseURL: GLOBALS.URL_API,
});

export default Api;