import React, { useState } from 'react';
import { View, Text, TextInput, TouchableOpacity, StyleSheet, Image, SectionList } from 'react-native';
import { styles } from './style.js';
import axios from 'axios'
const register = ({ navigation }) => {
  const [UserName, setUsername] = useState('');
  const [Password, setPassword] = useState('');
  const [Email, setEmail] = useState('');
  const [FirstName, setFirstName] = useState('');
  const [LastName, setLastName] = useState('');
  const [ConfirmPassword, setConfirmPassword] = useState('');

  const handleRegister = async () => {
    try {
      const response=await axios.post('https://sociospace.azurewebsites.net/api/v1/User/Register', { 
        "name": FirstName,
        "surname": LastName,
        "email": Email,
        "password": Password,
        "username": UserName,
      })
    
      if(response.data.succeeded){
        alert('Register successful!')
        navigation.navigate('Sign In');
      }
      
      
    }
    catch (error) {
      alert("Username or Email is already used. Please enter valid values.")
    }
  };

  return (
    
    <View style={styles.container}>
      <View style= {styles.header}>
      <View style={{ flexDirection: 'row' }}>
      <TouchableOpacity  onPress={() => navigation.navigate('Main')}>
        <Image
          source={require('../images/sspacelogo.png')}
          style={{ width: 290, height: 70 }}
        />
      </TouchableOpacity> 
      <TouchableOpacity  onPress={() => navigation.navigate('SearchPage')}>
        <Image
          source={require('../images/search.png')}
          style={{ width: 60, height: 70 }}
        />
      </TouchableOpacity> 
      <TouchableOpacity  onPress={() => navigation.navigate('Sign In')}>
        <Image
          source={require('../images/profile.png')}
          style={{ width: 60, height: 70 }}
        />
      </TouchableOpacity>  
    </View>
      </View>
      <View style={styles.main}>
        <Text style={styles.title}>Register</Text>
        <TextInput
          style={styles.input}
          placeholder="Name"
          value={FirstName}
          onChangeText={(text) => setFirstName(text)}
        />
        
      
        <TextInput
          style={styles.input}
          placeholder="Surname"
          
          value={LastName}
          onChangeText={(text) => setLastName(text)}
        />
         <TextInput
          style={styles.input}
          placeholder="Username"
          
          value={UserName}
          onChangeText={(text) => setUsername(text)}
        />
        <TextInput
          style={styles.input}
          placeholder="Email"
          value={Email}
          onChangeText={(text) => setEmail(text)}
        />
         <TextInput
          style={styles.input}
          placeholder="Password"
          secureTextEntry
          value={Password}
          onChangeText={(text) => setPassword(text)}
        />
        <TextInput
          style={styles.input}
          placeholder="Confirm Password"
          secureTextEntry
          value={ConfirmPassword}
          onChangeText={(text) => setConfirmPassword(text)}
        />
        
        <TouchableOpacity style={styles.button} onPress={handleRegister}>
          <Text style={styles.buttonText}>Register</Text>
        </TouchableOpacity>
        <TouchableOpacity style={styles.button} onPress={() => navigation.navigate('Sign In')}>
          <Text style={styles.buttonText}>Login</Text>
        </TouchableOpacity>
      </View>  
      <View style={styles.footer}>
      </View>  
    
    </View>
  );
};


export default register;