import React from 'react'
import {NavigationContainer} from '@react-navigation/native'
import {createStackNavigator} from '@react-navigation/stack'
import main from './screens/main'
import signin from './screens/signin'
import register from './screens/register'

const Stack = createStackNavigator()

const App = () => {
  return (
    <NavigationContainer>
      <Stack.Navigator 
        initialRouteName="main">
        <Stack.Screen name="Sign In" component={signin} />
        <Stack.Screen name="Register" component={register} />
        <Stack.Screen name="Main" component={main} />
      </Stack.Navigator>
    </NavigationContainer>
  );
};

export default App;
