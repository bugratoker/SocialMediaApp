import React, { useState } from 'react';
import {NavigationContainer} from '@react-navigation/native'
import {createStackNavigator} from '@react-navigation/stack'
import main from './screens/main'
import signin from './screens/signin'
import register from './screens/register'
import profile from './screens/profile'
import searchpage from './screens/searchpage'
import searchresult from './screens/searchresult'

const Stack = createStackNavigator()
console.log("hi");
const App = () => {
  return (
    <NavigationContainer>
      <Stack.Navigator 
        initialRouteName="Sign In"
        screenOptions={{headerShown : false}}>
        <Stack.Screen name="Sign In" component={signin} />
        <Stack.Screen name="Register" component={register} />
        <Stack.Screen name="Main" component={main} />
        <Stack.Screen name="Profile" component={profile} />
        <Stack.Screen name="SearchPage" component={searchpage} />
        <Stack.Screen name="SearchResult" component={searchresult} />
      </Stack.Navigator>
    </NavigationContainer>
  );
};

export default App;
