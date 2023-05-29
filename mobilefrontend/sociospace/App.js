import React, { useState } from 'react';
import { View, Text, TextInput, TouchableOpacity, StyleSheet, Image } from 'react-native';

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
      alert('Invalid username or password!');
    }
  };

  return (
    
    <View style={styles.container}>
      
      <Image source={require('./images/sociospacewhite.png')} style={styles.logo} />
      
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
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
  },
  title: {
    fontSize: 24,
    fontWeight: 'bold',
    marginBottom: 20,
  },
  input: {
    width: '80%',
    height: 40,
    borderColor: 'gray',
    borderWidth: 1,
    marginBottom: 10,
    paddingHorizontal: 10,
  },
  button: {
    backgroundColor: '#dd5b5e',
    paddingVertical: 15,
    paddingHorizontal: 30,
    borderRadius: 15,
  },
  buttonText: {
    color: 'white',
    fontSize: 25,
    fontWeight: 'bold',
    
  },
  logo: {
    width: 300 ,
    height: 60,
    position: 'absolute',
    top: 80,
    
  },
});

export default LoginScreen;