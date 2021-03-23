import Api from './Api';
import Util from '../util/Util';

async function getExtract(Id) {

  let Result = await Util.verifyConnection()

  if (Result) {
    try {

      const config = {
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json',
        }
      };

      let param = '?Id='+Id;
      
      return [
        {
          "id": "231fd182-1705-44f8-9519-04bced683562",
          "accountId": "ddc9ccde-fc66-4d07-820c-5f7601756f10",
          "data": "2021-03-21T23:24:13.4120702",
          "documentCode": "345678912",
          "type": 1,
          "amount": 1500,
          "observation": "Deposito B",
          "peso": 10,
          "dotz": 150
        },
        {
          "id": "092aae5f-b8e8-42da-95c1-0beb03799e52",
          "accountId": "ddc9ccde-fc66-4d07-820c-5f7601756f10",
          "data": "2021-03-21T23:46:08.8490252",
          "documentCode": "string",
          "type": 2,
          "amount": 10,
          "observation": "string",
          "peso": 10,
          "dotz": 1
        },
        {
          "id": "1b69291a-0d36-444d-86de-16e394fde266",
          "accountId": "ddc9ccde-fc66-4d07-820c-5f7601756f10",
          "data": "2021-03-21T23:24:13.4120725",
          "documentCode": "987654321",
          "type": 2,
          "amount": 100,
          "observation": "Pagamento B",
          "peso": 10,
          "dotz": 10
        },
        {
          "id": "8122b178-5a0d-4cf8-929d-29f1c1479818",
          "accountId": "ddc9ccde-fc66-4d07-820c-5f7601756f10",
          "data": "2021-03-21T23:42:37.1291543",
          "documentCode": "string",
          "type": 2,
          "amount": 10,
          "observation": "string",
          "peso": 10,
          "dotz": 1
        },
        {
          "id": "25105ff2-db7c-4a0a-98fd-4c60efca372d",
          "accountId": "ddc9ccde-fc66-4d07-820c-5f7601756f10",
          "data": "2021-03-21T23:24:13.4120474",
          "documentCode": "234567891",
          "type": 1,
          "amount": 2000,
          "observation": "Depositao A",
          "peso": 10,
          "dotz": 200
        },
        {
          "id": "0a290a5d-8763-45b3-8fbe-7a8270930c35",
          "accountId": "ddc9ccde-fc66-4d07-820c-5f7601756f10",
          "data": "2021-03-21T23:45:47.0237733",
          "documentCode": "string",
          "type": 2,
          "amount": 10,
          "observation": "string",
          "peso": 10,
          "dotz": 1
        },
        {
          "id": "52ec6baa-7060-4eda-a6bd-d7e8381db694",
          "accountId": "ddc9ccde-fc66-4d07-820c-5f7601756f10",
          "data": "2021-03-21T23:24:13.4112467",
          "documentCode": "123456789",
          "type": 1,
          "amount": 1000,
          "observation": "",
          "peso": 10,
          "dotz": 100
        },
        {
          "id": "577bd2ec-eb3e-4249-929d-f616b3f180eb",
          "accountId": "ddc9ccde-fc66-4d07-820c-5f7601756f10",
          "data": "2021-03-21T23:46:35.6216657",
          "documentCode": "string",
          "type": 2,
          "amount": 10,
          "observation": "string",
          "peso": 10,
          "dotz": 1
        },
        {
          "id": "ce46736f-ba6f-4ab3-8a63-f9c22b76a3be",
          "accountId": "ddc9ccde-fc66-4d07-820c-5f7601756f10",
          "data": "2021-03-21T23:44:23.7129472",
          "documentCode": "string",
          "type": 2,
          "amount": 10,
          "observation": "string",
          "peso": 10,
          "dotz": 1
        }];
      /*
      const response = await Api.get('/Account/ExtractByAccountID'+param, {}, config);
      if (response.status == 200) {
        return response.data;
      } 
      return null;
      */
    } catch (error) {
      Util.erroConexao();
      console.log(error)
      return null;
    }

  } else {
    Util.erroConexao();
    return null;
  }
}

async function getCard(Id) {

  let Result = await Util.verifyConnection()

  if (Result) {
    try {

      const config = {
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json',
        }
      };

      let param = '?Id='+Id;
      
      return [
        {
          "id": "afca80a4-b584-4e53-9a54-9b2125b07f5d",
          "accountId": "ddc9ccde-fc66-4d07-820c-5f7601756f10",
          "number": "7777-8888-5555-6666",
          "type": 2,
          "active": true,
          "data": "2021-03-21T23:24:13.4109763"
        },
        {
          "id": "80b8ee9b-c88a-47bb-b2c1-d84808fc881f",
          "accountId": "ddc9ccde-fc66-4d07-820c-5f7601756f10",
          "number": "6666-7777-8888-5555",
          "type": 2,
          "active": true,
          "data": "2021-03-21T23:24:13.4109598"
        },
        {
          "id": "b354d384-8e30-42f4-8132-ef897c016117",
          "accountId": "ddc9ccde-fc66-4d07-820c-5f7601756f10",
          "number": "5555-6666-7777-8888",
          "type": 1,
          "active": true,
          "data": "2021-03-21T23:24:13.410489"
        }
      ];
      /*
      const response = await Api.get('/Account/CardByAccountID'+param, {}, config);
      if (response.status == 200) {
        return response.data;
      } 
      return null;
      */
      
    } catch (error) {
      Util.erroConexao();
      console.log(error)
      return null;
    }

  } else {
    Util.erroConexao();
    return null;
  }
}

async function getAccountMail(Mail) {

  let Result = await Util.verifyConnection()

  if (Result) {
    try {

      const config = {
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json',
        }
      };

      let param = '?Mail='+Mail;
      
      return {
        "id": "ddc9ccde-fc66-4d07-820c-5f7601756f10",
        "number": "482067787",
        "name": "Ordep",
        "mail": "ordep@hotmail.com",
        "active": true,
        "data": "2021-03-21T23:24:13.4034219",
        "balance": 9950,
        "dotz": 1005
      };

      /*const response = await Api.get('/Account/AccountByMail'+param, {}, config);
      if (response.status == 200) {
        return response.data;
      } 
      return null;
      */
      
    } catch (error) {
      Util.erroConexao();
      console.log(error)
      return null;
    }

  } else {
    Util.erroConexao();
    return null;
  }
}


async function setPayment(d) {

  let Result = await Util.verifyConnection()

  if (Result) {
    try {

      const config = {
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json',
        }
      };

      const {
        AccountId,
        DocumentCode,
        Amount,
        Observation
      } = d;

      const data = {
        "accountId":AccountId,
        "documentCode":DocumentCode, 
        "amount":Amount, 
        "observation":Observation
      }
      
      const response = await Api.post('/Account/Payment', data, config);
      if (response.status == 200) {
        return response.data;
      } return null;

    } catch (error) {
      await Util.erroConexao();
      return null;
    }

  } else {
    await Util.erroConexao();
    return null;
  }
}

const AccountController = {
  getExtract,
  getCard,
  getAccountMail,
  setPayment
};

export default AccountController;