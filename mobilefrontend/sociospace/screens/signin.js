import React, { useState } from 'react';
import { View, Text, TextInput, TouchableOpacity, StyleSheet, Image } from 'react-native';
import { styles } from './style.js';

const signin = ({ navigation }) => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');

  const handleLogin = () => {
    // Perform login authentication logic here
    if (username === 'admin' && password === 'password') {
      // Successful login
      alert('Login successful!');
    } else {
      // Failed login
      alert('Invalid username or passwordd!');
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
      <TouchableOpacity  onPress={() => navigation.navigate('Profile')}>
        <Image
          source={require('../images/profile.png')}
          style={{ width: 60, height: 70 }}
        />
      </TouchableOpacity>  
    </View>
      </View>
      <View style={styles.main}>
        <Text style={styles.title}>Login</Text>
        <TextInput
          style={styles.input}
          placeholder="Username"
          value={username}
          onChangeText={(text) => setUsername(text)}
        />
        
      
        <TextInput
          style={styles.input}
          placeholder="Password"
          secureTextEntry
          value={password}
          onChangeText={(text) => setPassword(text)}
        />
        <TouchableOpacity style={styles.button} onPress={handleLogin}>
          <Text style={styles.buttonText}>Login</Text>
        </TouchableOpacity>
        <TouchableOpacity style={styles.button} onPress={() => navigation.navigate('Register')}>
          <Text style={styles.buttonText}>Register</Text>
        </TouchableOpacity>
      </View>  
      <View style={styles.footer}>
      </View>  
    
    </View>
  );
};


export default signin;