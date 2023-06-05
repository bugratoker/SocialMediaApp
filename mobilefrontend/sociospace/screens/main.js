import React, { useState } from 'react';
import { View, Text, TextInput, TouchableOpacity, StyleSheet, Image, Pressable } from 'react-native';
import { styles } from '../style.js';


const main = ({ navigation }) => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');

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
      <Image
        source={require('../images/search.png')}
        style={{ width: 60, height: 70 }}
      />
      <Image
        source={require('../images/profile.png')}
        style={{ width: 60, height: 70 }}
      />
    </View>
      </View>
      <View style={styles.main}>
        <Pressable onPress={() => navigation.navigate('Sign In')}>
            <Text style={styles.title}>Login</Text>
        </Pressable>
        <Pressable onPress={() => navigation.navigate('Register')}>
            <Text style={styles.title}>Register</Text>
        </Pressable>
      </View>  
      <View style={styles.footer}>
      </View>  
    
    </View>
  );
};



export default main;