import React, { useState } from 'react';
import { View,  TextInput, TouchableOpacity, StyleSheet, Image, Pressable,FlatList } from 'react-native';
import { styles } from './style.js';
import { Header, Text, Button, Input, Avatar, Icon } from 'react-native-elements';
import { SafeAreaProvider, SafeAreaView } from 'react-native-safe-area-context';
import signin from './signin';
import axios from 'axios';


const main = ({ navigation }) => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const handleLike = async () => {
    try{
      const config = {
        headers: { Authorization: `Bearer `+signin.jwToken }
      };
    
      const bodyParameters = {
        "postId": "8e2125d2-82a1-450d-ea91-08db7415489c",
        "userId": 15
      }
      const response = await axios.post( 
        'https://sociospace.azurewebsites.net/api/v1/Like/LikePost',
        bodyParameters,
        config
      ).then(console.log).catch(console.log);
 
   
      
    if(response.data.succeeded){
      
      alert('Liked!') 
    }

    }
    catch(error){
      alert("response.data.message");
    } 
  };

  const MOCK_DATA = [
    {
      id: '1',
      username: 'Abraham Pritched\n',
      usertitle: 'Founder at Personal Growth Base',
      question: 'Why do we need challenges in life?',
      answers: ['Answer1', 'Answer2'],
      image: 'https://www.imajakademi.com.tr/wp-content/uploads/kisisel-gelisim.jpg',
    },
    {
      id: '2',
      username: 'Ali Lincoln\n',
      usertitle: 'Student at Akdeniz University',
      question: 'What is personal development?',
      answers: ['Answer1', 'Answer2'],
      image: 'https://512solutions.com/wp-content/uploads/2011/12/Blog_9_Ways_to_Take_Responsiblity_for_Your_Life-1000x600.jpeg',

    },
  ];
  
  const Item = ({ username, usertitle, question, answers, image }) => (
    <View style={{ flex: 1, padding: 10, marginBottom: 20, borderWidth: 1, borderColor: '#000', borderRadius: 5 }}>
      <View style={{ flexDirection: 'row', alignItems: 'center' }}>
        <Avatar 
          rounded 
          title={username.split(' ').map(name => name[0]).join('')} 
          overlayContainerStyle={{backgroundColor: 'green'}}
          titleStyle={{color: 'white'}}
        />
        <Text style={{ fontWeight: 'bold', marginBottom: 5, marginLeft: 10 }}>
          {username}
          <Text style = {{fontStyle:'italik'}} >{usertitle} </Text>
        </Text>
      </View>
      {image && <Image source={{ uri: image }} style={{ width: '100%', height: 200 }} />}
      <Text style={{ marginBottom: 10 }}>{question}</Text>
      {answers.map((answer, index) => (
        <Text key={index}>- {answer}</Text>
      ))}
  
      <View style={{ flexDirection: 'row', justifyContent: 'space-between', marginTop: 10  }}>
  
  <Button
  title="Like"
  type="clear"
  icon={<Icon name="thumbs-up" type="font-awesome" color="blue" />}
  onPress={handleLike} 
  />
  <Button
  title="Comment"
  type="clear"
  icon={<Icon name="comment" type="font-awesome" color="black" />}
  onPress={() => {
  
  }}
  />
  </View>
    </View>
  );
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
        <TouchableOpacity  onPress={() => navigation.navigate('AddPost')}>
          <Image
            source={require('../images/add-button.png')}
            style={{ width: 70, height: 70 }}
          />
         </TouchableOpacity>  
      <SafeAreaProvider >
      <SafeAreaView style={{ flex: 1 }}>
       
        <View style={{ padding: 20 }}>
          <Input placeholder="What do you want to ask or share?" />
          <FlatList
            data={MOCK_DATA}
            renderItem={({ item }) => <Item {...item} />}
            keyExtractor={item => item.id}
          />
        </View>
      </SafeAreaView>
    </SafeAreaProvider>
      </View>  
        
    
    </View>
  );
};



export default main;