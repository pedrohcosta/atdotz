import NetInfo from '@react-native-community/netinfo';
import {Alert} from 'react-native';


async function verifyConnection(onlyWifi = true) {
  let response = false;

  await NetInfo.fetch().then(state => {
    if (state.isConnected && (state.type === 'wifi' || !onlyWifi)) {
      response = true;
    }
  });

  return response;
}

function erroConexao() {
  Alert.alert(
    'Atenção!',
    'Erro ao realizar login. Falha na conexão com internet!',
    [
      {
        text: 'OK', onPress: () => {

        }
      },
    ],
    { cancelable: false },
  );
}

function erro(msg) {
  Alert.alert(
    'Atenção!',
    msg,
    [
      {
        text: 'OK', onPress: () => {

        }
      },
    ],
    { cancelable: false },
  );
}

function sucesso(msg) {
  Alert.alert(
    'Sucesso!',
    msg,
    [
      {
        text: 'OK', onPress: () => {

        }
      },
    ],
    { cancelable: false },
  );
}

function isNumber(n) {
  return !isNaN(parseFloat(n)) && isFinite(n);
}

const Util = {
  verifyConnection,
  erroConexao,
  erro,
  sucesso,
  isNumber
};

export default Util;