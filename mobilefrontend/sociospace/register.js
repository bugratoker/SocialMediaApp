import React, { useState } from 'react';
import { View, Text, TextInput, TouchableOpacity, StyleSheet, Image } from 'react-native';
import { styles } from './style.js';
const LoginScreen = () => {
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
        <Image source={require('./images/sociospacewhite.png')} style={styles.logo} />
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
        <TextInput
          style={styles.input}
          placeholder="Email"
          value={email}
          onChangeText={(text) => setEmail(text)}
        />
        <TouchableOpacity style={styles.button} onPress={handleLogin}>
          <Text style={styles.buttonText}>Register</Text>
        </TouchableOpacity>
        <TouchableOpacity style={styles.button} onPress={handleLogin}>
          <Text style={styles.buttonText}>Login</Text>
        </TouchableOpacity>
      </View>  
      <View style={styles.footer}>
      </View>  
    
    </View>
  );
};


export default LoginScreen;