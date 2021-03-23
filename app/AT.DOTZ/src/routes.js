
import * as React from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';
import { BackHandler, View, Button } from 'react-native';

import Login from './pages/login/Index'
import AccountIndex from './pages/account/Index'
import AccountPayment from './pages/account/Payment'
import AccountExtract from './pages/account/Extract'
import AccountCard from './pages/account/Card'

const Stack = createStackNavigator();
const MyStack = () => {
  return (
    <NavigationContainer>
      <Stack.Navigator>
        <Stack.Screen
          name="Login"
          component={Login}
          options={{ 
              title: 'Login',
              headerTitleStyle:{ 
                color: '#f29433'
              }
          }}
        />
        <Stack.Screen
           name="AccountIndex"
           component={AccountIndex}
            options={{
            title: 'Conta',
            headerLeft: null,
            headerTitleStyle:{ 
              color: '#f29433'
            },
            headerRight: () => (
              <View style={{ padding: 6 }}>
                  <Button
                      onPress={() => {  BackHandler.exitApp()}}
                      title="Sair"
                      color="#f29433"
                  />
              </View>
          )
          }}
        />
        <Stack.Screen
           name="AccountPayment"
           component={AccountPayment}
            options={{
            title: 'Pagamento',
            headerLeft: null,
            headerTitleStyle:{ 
              color: '#f29433'
            }
          }}
        />
         <Stack.Screen
           name="AccountExtract"
           component={AccountExtract}
            options={{
            title: 'Extrato',
            headerLeft: null,
            headerTitleStyle:{ 
              color: '#f29433'
            }
          }}
        />
         <Stack.Screen
           name="AccountCard"
           component={AccountCard}
            options={{
            title: 'Cartões',
            headerLeft: null,
            headerTitleStyle:{ 
              color: '#f29433'
            }
          }}
        />
      </Stack.Navigator>
    </NavigationContainer>
  );
};

export default MyStack;