import Util from '../util/Util';
import auth from "@react-native-firebase/auth";

async function login(mail, password) {

  let Result = await Util.verifyConnection()

  if (Result) {
    
    try {
      
      const result = await auth().signInWithEmailAndPassword(mail, password);
      console.log(result)
      return result;
    } catch (error) {
      
      if (error.code === 'auth/email-already-in-use') {
          Util.erro('E-mail já usado.');
      }
  
      if (error.code === 'auth/invalid-email') {
        Util.erro('E-mail invalido.');
      }
  
      return null;
    }
  } else {
    Util.erroConexao();
    return null;
  }
}


const LoginController = {
  login
};

export default LoginController;