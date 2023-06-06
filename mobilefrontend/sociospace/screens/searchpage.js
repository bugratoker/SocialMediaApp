import React, { useState } from 'react';
import { View, Text, TextInput, TouchableOpacity, StyleSheet, Image, Pressable } from 'react-native';
import { styles } from './style.js';


const searchpage = ({ navigation }) => {
  const [search, setSearch] = useState('');
  

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
        <TextInput
          style={styles.input}
          placeholder="Search"
          value={search}
          onChangeText={(text) => setSearch(text)}
        />
        <TouchableOpacity style={styles.button} onPress={()=>navigation.navigate('SearchResult', {searchText: search })}>
          <Text style={styles.buttonText}>Search</Text>
        </TouchableOpacity> 
    
    </View>
       
    <View style={styles.footer}>
          
    </View>  
    
    </View>
  );
};



export default searchpage;