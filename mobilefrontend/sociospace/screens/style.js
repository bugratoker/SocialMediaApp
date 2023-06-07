import { View, Text, TextInput, TouchableOpacity, StyleSheet, Image } from 'react-native';
import styled from 'styled-components/native';

export const Container = styled.View`
  flex: 1;
  align-items: center;
  background-color: #fff;
  padding: 20px;
`;

export const Card = styled.View`
    background-color: #f8f8f8;
    width: 100%;
    margin-bottom: 20px;
    border-radius: 10px;
`;

export const UserInfo = styled.View`
    flex-direction: row;
    justify-content: flex-start;
    padding: 15px;
`;

export const UserImg = styled.Image`
    width: 50px;
    height: 50px;
    border-radius: 25px;
`;

export const UserInfoText = styled.View`
    flex-direction: column;
    justify-content: center;
    margin-left: 10px;
`;

export const UserName = styled.Text`
    font-size: 14px;
    font-weight: bold;
    font-family: 'Lato-Regular';
`;

export const PostTime = styled.Text`
    font-size: 12px;
    font-family: 'Lato-Regular';
    color: #666;
`;

export const PostText = styled.Text`
    font-size: 14px;
    font-family: 'Lato-Regular';
    padding-left: 15px;
    padding-right: 15px;
    margin-bottom: 15px;
`;

export const PostImg = styled.Image`
    width: 100%;
    height: 250px;
    /* margin-top: 15px; */
`;

export const Divider = styled.View`
    border-bottom-color: #dddddd;
    border-bottom-width: 1px;
    width: 92%;
    align-self: center;
    margin-top: 15px;
`;

export const InteractionWrapper = styled.View`
    flex-direction: row;
    justify-content: space-around;
    padding: 15px;
`;

export const Interaction = styled.TouchableOpacity`
    flex-direction: row;
    justify-content: center;
    border-radius: 5px;
    padding: 2px 5px;
    background-color: ${props => props.active ? '#2e64e515' : 'transparent'}
`;

export const InteractionText = styled.Text`
    font-size: 12px;
    font-family: 'Lato-Regular';
    font-weight: bold;
    color: ${props => props.active ? '#2e64e5' : '#333'};
    margin-top: 5px;
    margin-left: 5px;
`;

export const styles = StyleSheet.create({
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
      width:  300,
      height: 40,
      borderColor: 'gray',
      borderWidth: 1,
      marginBottom: 10,
      paddingHorizontal: 10,
    },
    button: {
      backgroundColor: '#dd5b5e',
      paddingVertical: 7,
      paddingHorizontal: 14,
      borderRadius: 15,
    },
    buttonText: {
      color: 'white',
      fontSize: 15,
      fontWeight: 'bold',
      
    },
    spacelogo: {
      width: 250,
      height: 40,
     
      
    },
    logo: {
    width: 50,
    height: 50,  
      
    },

    header: {
        flex: 1,
        flexDirection: 'row',
        alignContent: 'center',
        justifyContent: 'center',
        width: '100%',
        height: '10%',
    },
    headerlogo: {
        flex : 20,
        
        alignContent: 'center',
        justifyContent: 'center',
        
        width: '100%',
        height: '10%',
    },
    headersearch: {
      flexDirection: 'row',
      flex : 1127,
      alignContent: 'center',
      justifyContent: 'center',
      
      width: '100%',
        height: '10%',
    },
    headerprofile: {
      flexDirection: 'row',
      flex : 1,
      alignContent: 'center',
      justifyContent: 'center',
      
      width: '100%',
        height: '10%',
    },
    main: {
        flex: 18,
        alignContent: 'center',
        justifyContent: 'center',
        
    },
    footer: {
        flex: 2,
        alignContent: 'center',
        justifyContent: 'center',
        
    },
    
  });